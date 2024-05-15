using System;
using System.Collections.Generic;

namespace EletricCar_Store.Models
{
    public class OrderViewModel : PadraoViewModel
    {
        public int UserId { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime PurchaseDate { get; set; }

        public OrderViewModel()
        {

        } 

        public OrderViewModel(UserViewModel user, int totalValue)
        {
            UserId = user.Id;
            TotalValue = totalValue;
            PurchaseDate = DateTime.Now;
        }
    }
}
