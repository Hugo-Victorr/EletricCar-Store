namespace EletricCar_Store.Models
{
    public class AddressViewModel : PadraoViewModel
    {
        public int UserId { get; set; }
        public string CEP { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }

    }
}
