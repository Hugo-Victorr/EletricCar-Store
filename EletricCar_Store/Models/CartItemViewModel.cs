namespace EletricCar_Store.Models
{
    public class CartItemViewModel : PadraoViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalValue { get; set;}
        public string ImagemEmBase64 { get; set; }

        public void UpdateTotalValue()
        {
            TotalValue= Quantity * Price;
        }
    }
}
