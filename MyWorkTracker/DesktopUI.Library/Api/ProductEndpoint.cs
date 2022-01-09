using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
     public class ProductEndpoint: IProductEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public ProductEndpoint(IApiHelper apiHelper)
        {
           _apiHelper = apiHelper;
        }

        public async Task PostProduct(ProductModel product)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/product", product))
            {
                if(response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<ProductModel>> LoadProducts(string date, int companyId)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync($"/api/product/{date}/{companyId}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task RemoveProduct(int productId)
        {
            using(HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync($"/api/product/{productId}"))
            {
                if(response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
