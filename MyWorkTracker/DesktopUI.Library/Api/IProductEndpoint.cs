using DesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> LoadProducts(string date, int companyId);
        Task PostProduct(ProductModel product);
        Task RemoveProduct(int productId);
    }
}