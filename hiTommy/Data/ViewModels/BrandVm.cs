using System.Collections.Generic;
using hiTommy.Models;

namespace hiTommy.Data.ViewModels
{
    public class BrandVm
    {
        public string Name { get; set; }
    }

    public class BrandWithShoesVm
    {
        public string Name { get; set; }
        public virtual List<Shoe> Shoes { get; set; }
    }
}