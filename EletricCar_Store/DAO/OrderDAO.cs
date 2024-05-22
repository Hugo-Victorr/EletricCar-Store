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
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("id", order.Id);
            p[1] = new SqlParameter("usuarioId", order.UserId);
            p[2] = new SqlParameter("dataCompra", order.PurchaseDate);
            return p;
        }

        protected override OrderViewModel MontaModel(DataRow registro)
        {
            OrderViewModel a = new OrderViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.UserId = Convert.ToInt32(registro["usuarioId"]);
            a.PurchaseDate = Convert.ToDateTime(registro["dataCompra"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Pedido";
            NomeSpListagem = "spListaPedidos";
        }
    }
}
