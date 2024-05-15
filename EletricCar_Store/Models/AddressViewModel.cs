namespace EletricCar_Store.Models
{
    public class AddressViewModel : PadraoViewModel
    {
        public int UserId { get; set; }
        public string CEP { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
    }
}
