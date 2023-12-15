using System;
using Ponce14.Services;
using Ponce14.Models;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Ponce14.ViewModels
{
    public class ViewModelCompra : BaseViewModel
    {
        private string fecha;
        public string Fecha
        {
            get { return this.fecha; }
            set { SetValue(ref this.fecha, value); }
        }

        private string cliente;
        public string Cliente
        {
            get { return this.cliente; }
            set { SetValue(ref this.cliente, value); }
        }

        private int total;
        public int Total
        {
            get { return this.total; }
            set { SetValue(ref this.total, value); }
        } 

        private string vendedor;
        public string Vendedor
        {
            get { return this.vendedor; }
            set { SetValue(ref this.vendedor, value); }
        }

        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }


        private List<Compra> people;
        public List<Compra> People
        {
            get { return this.people; }
            set { SetValue(ref this.people, value); }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }


        public ViewModelCompra()
        {
            SearchCommand = new Command(() =>
            {
                CompraService service = new CompraService();
                People = service.GetByText(Filter);
            });

            InsertCommand = new Command(() =>
            {
                CompraService service = new CompraService();
                int newPersonId = service.Get().Count + 1;
                service.Create(new Compra { Fecha = Fecha, Cliente = Cliente, Total = Total, Vendedor = Vendedor });

                App.Current.MainPage.DisplayAlert("Success", "Your data are saved", "Ok");
            });
        }

    }
}
