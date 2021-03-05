using System.Collections.Generic;
using System.Linq;
using hiTommy.Data.ViewModels;
using hiTommy.Models;

namespace hiTommy.Data.Services
{
    public class BrandServices
    {
        private readonly ApplicationDbContext _context;

        public BrandServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public void AddBrand(BrandVm brand)
        {
            var _brand = new Brand
            {
                Name = brand.Name
            };
            _context.Brands.Add(_brand);
            _context.SaveChanges();
        }

        public BrandWithShoesVm GetShoesByBrandId(int orderId)
        {
            var _brand = _context.Brands.Where(n => n.Id == orderId).Select(n => new BrandWithShoesVm
            {
                Name = n.Name,
                Shoes = n.Shoes
            }).FirstOrDefault();

            return _brand;
        }

        public void DeleteBrandById(int brandId)
        {
            var _brand = _context.Brands.FirstOrDefault(n => n.Id == brandId);
            if (_brand is not null)
            {
                _context.Brands.Remove(_brand);
                _context.SaveChanges();
            }
        }
    }
}