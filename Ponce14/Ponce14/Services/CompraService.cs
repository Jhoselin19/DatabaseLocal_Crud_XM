using Ponce14.DataContext;
using Ponce14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ponce14.Services
{
    public class CompraService
    {
        private readonly AppDbContext _context;

        public CompraService() => _context = App.GetContext();


        public bool Create(Compra item)
        {
            try
            {
                //EntityFrameworkCore
                _context.People.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool CreateRange(List<Compra> items)
        {
            try
            {
                //EntityFrameworkCore
                _context.People.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Compra> Get()
        {
            return _context.People.ToList();
        }


        public List<Compra> GetByText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return _context.People.ToList();

            // Convertir el texto de búsqueda a int
            if (int.TryParse(text, out int searchValue))
            {
                return _context.People.Where(x =>
                    x.Fecha.Contains(text) ||
                    x.Cliente.Contains(text) ||
                    x.Total == searchValue ||
                    x.Vendedor.Contains(text)
                ).ToList();
            }
            else
            {
                // El texto de búsqueda no es un número válido, realizar búsqueda solo con cadenas
                return _context.People.Where(x =>
                    x.Fecha.Contains(text) ||
                    x.Cliente.Contains(text) ||
                    x.Vendedor.Contains(text)
                ).ToList();
            }
        }

    }
}
