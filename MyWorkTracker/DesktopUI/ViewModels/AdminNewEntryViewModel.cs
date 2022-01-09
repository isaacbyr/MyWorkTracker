using Caliburn.Micro;
using DesktopUI.EventModels;
using DesktopUI.Library.Api;
using DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopUI.ViewModels
{
    //TODO: Set it up so if data loads into job fields we update existing data instead of adding new
    public class AdminNewEntryViewModel: Screen
    {
        private readonly ICompanyEndpoint _companyEndpoint;
        private readonly IProductEndpoint _productEndpoint;
        private readonly IEventAggregator _events;
        private readonly IEntryEndpoint _entryEndpoint;

        public AdminNewEntryViewModel(ICompanyEndpoint companyEndpoint, IProductEndpoint productEndpoint,
            IEventAggregator events, IEntryEndpoint entryEndpoint)
        {
            _companyEndpoint = companyEndpoint;
            _productEndpoint = productEndpoint;
            _events = events;
            _entryEndpoint = entryEndpoint;
        }

        public bool NextMonth { get; set; }
        public bool PrevMonth { get; set; }
        public DateTime SelectedDate { get; set; }
        public int CompanyId { get; set; } 
        public DateTime CurrentSelectedDate { get; set; }

        private string _date;

        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                NotifyOfPropertyChange(() => Date);
                NotifyOfPropertyChange(() => ViewingDate);
            }
        }

        public string ViewingDate
        {
            get
            {
                int currentSelectedMonth = SelectedDate.Month;
                int currentSelectedYear = SelectedDate.Year;
                int convertedDay;
                int.TryParse(Date, out convertedDay);
                if (!PrevMonth && !NextMonth)
                {
                    var date = new DateTime(currentSelectedYear, currentSelectedMonth, convertedDay);
                    CurrentSelectedDate = date; ;
                    return date.ToString("dddd, MMM d yyyy").ToUpper();
                }
                else if (!PrevMonth && NextMonth)
                {
                    var date = new DateTime(currentSelectedYear, currentSelectedMonth + 1, convertedDay);
                    CurrentSelectedDate = date;
                    return date.ToString("dddd, MMM d yyyy").ToUpper();
                }
                else if (PrevMonth && !NextMonth)
                {
                    var date = new DateTime(currentSelectedYear, currentSelectedMonth - 1, convertedDay);
                    CurrentSelectedDate = date;
                    return date.ToString("dddd, MMM d yyyy").ToUpper();
                }

                return "Cal Error";
            }
        }

        protected override async void OnViewLoaded(object view)
        {
            await LoadEmployeeData();
            await LoadProducts();
            await LoadEntry();
            
        }

        public async Task LoadEntry()
        {
            var foundEntry = await _entryEndpoint.LoadEntry(CurrentSelectedDate);
            if (foundEntry != null)
            {
                Job = foundEntry.Job;
                Location = foundEntry.Location;
                Hours = foundEntry.Hours;
                Wage = Math.Round(foundEntry.Wage,2);
                Description = foundEntry.Description;
                StartTime = foundEntry.StartTime;
                EndTime = foundEntry.EndTime;
            }
            else
            {
                Job = "";
                Location = "";
                Hours = 0;
                Wage = 0;
                Description = "";
                StartTime = "";
                EndTime = "";
            }

            NotifyOfPropertyChange(() => Job);
            NotifyOfPropertyChange(() => Hours);
            NotifyOfPropertyChange(() => Location);
            NotifyOfPropertyChange(() => Wage);
            NotifyOfPropertyChange(() => Description);
        }

        public async Task LoadProducts()
        {
            string date = CurrentSelectedDate.ToString("dd-MM-yy");

            var products =  await _productEndpoint.LoadProducts(date, CompanyId);
            
            Products = new BindingList<ProductModel>(products);
            
            
            NotifyOfPropertyChange(() => Total);
        }

        public async Task LoadEmployeeData()
        {
            var employeesList = await _companyEndpoint.GetEmployeeEntries(CurrentSelectedDate, CompanyId);
            Employees = new BindingList<EmployeeDataModel>(employeesList);

            foreach (var employee in Employees)
            {
                employee.SubTotal = Math.Round((employee.BilledOut - employee.Wage) * employee.Hours,2);
                employee.BilledOut = Math.Round(employee.BilledOut, 2);
                employee.Wage = Math.Round(employee.Wage, 2);
            }

            NotifyOfPropertyChange(() => Total);
        }

        private BindingList<EmployeeDataModel> _employees;

        public BindingList<EmployeeDataModel> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                NotifyOfPropertyChange(() => Employees);
            }
        }

        private string _product;

        public string Product
        {
            get { return _product; }
            set 
            { 
                _product = value;
                NotifyOfPropertyChange(() => Product);
            }
        }

        private int _purchasePrice;

        public int PurchasePrice
        {
            get { return _purchasePrice; }
            set 
            { 
                _purchasePrice = value;
                NotifyOfPropertyChange(() => PurchasePrice);
            }
        }

        private int _retailPrice;

        public int RetailPrice
        {
            get { return _retailPrice; }
            set 
            {
                _retailPrice = value;
                NotifyOfPropertyChange(() => RetailPrice);
            }
        }

        public decimal Total
        {
            get
            {
                decimal sum = 0.00M;

                if(Employees != null && Products != null)
                {
                    foreach (var employee in Employees)
                    {
                        sum += employee.SubTotal;
                    }
                    foreach (var product in Products)
                    {
                        sum += (product.RetailPrice - product.PurchasePrice) * product.Quantity;
                    }
                }

                sum += Subtotal;

                return Math.Round(sum,2);
            }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set 
            { 
                _quantity = value;
                NotifyOfPropertyChange(() => Quantity);
            }
        }



        private BindingList<ProductModel> _products;
                
        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set 
            { 
                _products = value;
                NotifyOfPropertyChange(() => Products);
                NotifyOfPropertyChange(() => Job);
            }
        }

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            { 
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
            }
        }

        private string _startTime;

        public string StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                NotifyOfPropertyChange(() => StartTime);
            }
        }

        private string _endTime;

        public string EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                NotifyOfPropertyChange(() => EndTime);
            }
        }


        private string _job;

        public string Job
        {
            get { return _job; }
            set
            {
                _job = value;
                NotifyOfPropertyChange(() => Job);
            }
        }

        private string _location;

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                NotifyOfPropertyChange(() => Location);
            }
        }

        private decimal _hours;

        public decimal Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                _hours = value;
                NotifyOfPropertyChange(() => Hours);
                NotifyOfPropertyChange(() => Subtotal);
                NotifyOfPropertyChange(() => Total);
            }
        }

        private decimal _wage;

        public decimal Wage
        {
            get { return _wage; }
            set
            {
                _wage = value;
                NotifyOfPropertyChange(() => Wage);
                NotifyOfPropertyChange(() => Subtotal);
                NotifyOfPropertyChange(() => Total);
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public decimal Subtotal
        {
            get
            {
                return Math.Round(Wage * Hours,2);
            }
        }

        public async Task AddProduct()
        {

            if (!string.IsNullOrEmpty(Product) && PurchasePrice >= 0 && RetailPrice >= 0 && Quantity >= 1)
            {
                var product = new ProductModel
                {
                    ProductName = Product,
                    PurchasePrice = PurchasePrice,
                    RetailPrice = RetailPrice,
                    Date = CurrentSelectedDate,
                    CompanyId = CompanyId,
                    Job = Job,
                    Quantity = Quantity
                };
                Products.Add(product);

                await _productEndpoint.PostProduct(product);
            }

            NotifyOfPropertyChange(() => Products);
            NotifyOfPropertyChange(() => Total);
        }

        public async Task RemoveProduct()
        {
            await _productEndpoint.RemoveProduct(SelectedProduct.Id);
            await LoadProducts();

            NotifyOfPropertyChange(() => Total);

        }

        public void Cancel()
        {
            _events.PublishOnUIThread(new ReturnHomeEvent());
        }

        public async Task Save()
        {

            var entry = new EntryModel();

            entry.Job = Job;
            entry.Location = Location;
            entry.JobDate = CurrentSelectedDate;
            entry.StartTime = StartTime;
            entry.EndTime = EndTime;
            entry.Description = Description;
            entry.Subtotal = Subtotal;
            entry.Hours = Hours;
            entry.Wage = Wage;
            entry.Total = Total;

            await _entryEndpoint.PostEntry(entry);

            _events.PublishOnUIThread(new ReturnHomeEvent());
        }
    }
}
