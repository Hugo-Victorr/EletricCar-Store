using System.Reflection.Metadata;

namespace EletricCar_Store.Models
{
    public class CarViewModel : PadraoViewModel
    {
        public int Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }


    }
}
