using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class ProductData
    {
        public void PostProduct(ProductModel product)
        {
            var sql = new SqlDataAccess();
            var p = new
            {
                Date = product.Date,
                CompanyId = product.CompanyId,
                ProductName = product.ProductName,
                PurchasePrice = product.PurchasePrice,
                RetailPrice = product.RetailPrice,
                Job = product.Job,
                Quantity = product.Quantity
            };

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spInsertProduct", p);
                sql.CommitTransaction();
            }
            catch (Exception e)
            {
                sql.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }

        public List<ProductModel> GetProducts(DateTime date, int companyId)
        {
            var sql = new SqlDataAccess();

            var p = new { Date = date, CompanyId = companyId };

            try
            {
                var output = sql.LoadData<ProductModel, dynamic>("dbo.spGetProduct", p, "WTData");
                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteProduct(int productId)
        {
            var sql = new SqlDataAccess();
            var p = new { Id = productId };


            try
            {
                sql.LoadData<dynamic, dynamic>("dbo.spDeleteProductById", p, "WTData");
                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
