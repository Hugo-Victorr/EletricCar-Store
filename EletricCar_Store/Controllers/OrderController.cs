using EletricCar_Store.DAO;
using EletricCar_Store.Models;

namespace EletricCar_Store.Controllers
{
    public class OrderController : PadraoController<OrderViewModel>
    {
        public OrderController()
        {
            DAO = new OrderDAO();
            GeraProximoId = true;
        }
    }
}
