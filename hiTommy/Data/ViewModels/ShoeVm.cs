using System.ComponentModel.DataAnnotations.Schema;

namespace hiTommy.Data.ViewModels
{
    public class ShoeVm
    {
        public string Name { get; set; }

        [Column(TypeName = "Price")] public decimal Price { get; set; }

        public int BrandId { get; set; }
        public bool IsOnSale { get; set; }

        [Column(TypeName = "SalePrice")] public decimal? SalePrice { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
    }

    public class ShoeVmSale
    {
        public bool IsOnSale = true;

        [Column(TypeName = "SalePrice")] public decimal? SalePrice { get; set; }
    }
}