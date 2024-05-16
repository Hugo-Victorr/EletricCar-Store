using System;

namespace EletricCar_Store.Models
{
    public class UserViewModel : PadraoViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BornDate { get; set; }
    }
}
