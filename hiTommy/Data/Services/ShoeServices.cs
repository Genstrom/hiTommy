using System.Collections.Generic;
using System.Linq;
using hiTommy.Data.ViewModels;
using hiTommy.Models;

namespace hiTommy.Data.Services
{
    public class ShoeServices
    {
        private readonly ApplicationDbContext _context;

        public ShoeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddShoe(ShoeVm shoe)
        {
            var _shoe = new Shoe
            {
                Name = shoe.Name,
                Price = shoe.Price,
                BrandId = shoe.BrandId,
                IsOnSale = shoe.IsOnSale,
                SalePrice = shoe.IsOnSale ? shoe.SalePrice : null,
                Description = shoe.Description,
                PictureUrl = shoe.PictureUrl,

                Brand = _context.Brands.Where(n => n.Id == shoe.BrandId).Select(n => n.Name).FirstOrDefault()
            };
            _context.Shoes.Add(_shoe);
            _context.SaveChanges();
        }

        public List<Shoe> GetAllShoes()
        {
            return _context.Shoes.ToList();
        }

        public Shoe GetShoeById(int shoeId)
        {
            return _context.Shoes.FirstOrDefault(n => n.Id == shoeId);
        }

        public Shoe UpdateShoeById(int shoeId, ShoeVm shoe)
        {
            var _shoe = _context.Shoes.FirstOrDefault(n => n.Id == shoeId);
            if (_shoe is not null)
            {
                _shoe.Name = shoe.Name;
                _shoe.Price = shoe.Price;
                _shoe.IsOnSale = shoe.IsOnSale;
                _shoe.SalePrice = shoe.IsOnSale ? shoe.SalePrice : null;
                _shoe.BrandId = shoe.BrandId;

                _context.SaveChanges();
            }

            return _shoe;
        }

        public Shoe SetShoeOnSaleById(int shoeId, ShoeVmSale shoe)
        {
            var _shoe = _context.Shoes.FirstOrDefault(n => n.Id == shoeId);
            if (_shoe is not null)
            {
                _shoe.SalePrice = shoe.IsOnSale ? shoe.SalePrice : null;

                _context.SaveChanges();
            }

            return _shoe;
        }

        public void DeleteShoeById(int shoeId)
        {
            var _shoe = _context.Shoes.FirstOrDefault(n => n.Id == shoeId);
            if (_shoe is not null)
            {
                _context.Shoes.Remove(_shoe);
                _context.SaveChanges();
            }
        }
    }
}