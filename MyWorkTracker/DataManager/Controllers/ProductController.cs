using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataManager.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public void Post(ProductModel product)
        {
            var productData = new ProductData();

            productData.PostProduct(product);
        }

        [Route("{date}/{companyId}")]
        public List<ProductModel> Get(string date, int companyId)
        {
            DateTime convDate;
            DateTime.TryParseExact(date, "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out convDate);

            var productData = new ProductData();

            return productData.GetProducts(convDate, companyId);
        }

        [Route("{productId}")]
        public void Delete(int productId)
        {
            var productData = new ProductData();

            productData.DeleteProduct(productId);
        }
    }
}
