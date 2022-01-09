using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public int PurchasePrice { get; set; }
        public int RetailPrice { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Job { get; set; }
    }
}
