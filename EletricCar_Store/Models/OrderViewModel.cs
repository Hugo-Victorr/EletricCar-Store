using System;
using System.Collections.Generic;

namespace EletricCar_Store.Models
{
    public class OrderViewModel : PadraoViewModel
    {
        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
