using EletricCar_Store.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System;

namespace EletricCar_Store.DAO
{
    public class OrderDAO : PadraoDAO<OrderViewModel>
    {
        protected override SqlParameter[] CriaParametros(OrderViewModel order)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("id", order.Id);
            p[1] = new SqlParameter("userId", order.UserId);
            p[2] = new SqlParameter("totalValue", order.TotalValue);
            p[3] = new SqlParameter("purchaseDate", order.PurchaseDate);
            return p;
        }

        protected override OrderViewModel MontaModel(DataRow registro)
        {
            OrderViewModel a = new OrderViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.UserId = Convert.ToInt32(registro["userId"]);
            a.TotalValue = Convert.ToInt32(registro["totalValue"]);
            a.PurchaseDate = Convert.ToDateTime(registro["purchaseDate"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Order";
            NomeSpListagem = "spListingOrders";
        }
    }
}
