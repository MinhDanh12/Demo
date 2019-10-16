using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDemo.Services;

namespace WpfAppDemo.Models
{
    public partial class Order : INotifyPropertyChanged
    {
        private readonly ProductService productService = new ProductService();

        int _ProductId;
        string _Detail;
        string _Unit;
        double? _Price;
        int _Quantity;
        double? _Total;

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        //public int? Quantity { get; set; }
        public int? UserId { get; set; }
        //public int? ProductId { get; set; }
        //public double? Total { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }

        public int ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                if (_ProductId != value)
                {
                    _ProductId = value;
                    RaisePropertyChanged("ProductId");
                    RefreshData(_ProductId);
                    CalculateTotalPrice(_Price, _Quantity);
                }
            }
        }

        public string Detail
        {
            get
            {
                return _Detail;
            }
            set
            {
                if (_Detail != value)
                {
                    _Detail = value;
                    RaisePropertyChanged("Detail");
                }
            }
        }

        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                if (_Unit != value)
                {
                    _Unit = value;
                    RaisePropertyChanged("Unit");
                }
            }
        }

        public double? Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (_Price != value)
                {
                    _Price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }

        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                if (_Quantity != value)
                {
                    _Quantity = value;
                    RaisePropertyChanged("Quantity");
                    CalculateTotalPrice(_Price, _Quantity);
                }
            }
        }

        public double? Total
        {
            get
            {
                return _Total;
            }
            set
            {
                if (_Total != value)
                {
                    _Total = value;
                    RaisePropertyChanged("Total");
                }
            }
        }

        // Private Methods
        void RefreshData(int _productId)
        {
            // Function call the API to get Product and get response data.
            var response = productService.GetProductOrder(_productId);
            var responseData = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response data.
                Product product = JsonConvert.DeserializeObject<Product>(responseData);
                this.Detail = (product == null ? "" : product.Detail);
                this.Unit = (product == null ? "" : product.Unit);
                this.Price = (product == null ? 0 : product.Price);
            }
            return;
        }

        void CalculateTotalPrice(double? _Price, int? _Quantity)
        {
            this.Total = _Price * _Quantity;
        }

        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
