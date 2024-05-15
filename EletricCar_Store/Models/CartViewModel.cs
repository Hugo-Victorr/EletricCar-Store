using System.Collections.Generic;

namespace EletricCar_Store.Models
{
    public class CartViewModel
    {
        public int UserId { get; set; }
        public List<CartItemViewModel> Cars { get; set; }
    }
}
