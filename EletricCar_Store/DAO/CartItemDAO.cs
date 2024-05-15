using EletricCar_Store.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System;

namespace EletricCar_Store.DAO
{
    public class CartItemDAO : PadraoDAO<CartItemViewModel>
    {
        protected override SqlParameter[] CriaParametros(CartItemViewModel cartItem)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("id", cartItem.Id);
            p[1] = new SqlParameter("orderId", cartItem.OrderId);
            p[2] = new SqlParameter("productId", cartItem.ProductId);
            p[3] = new SqlParameter("quantity", cartItem.Quantity);
            p[4] = new SqlParameter("price", cartItem.Price);
            p[5] = new SqlParameter("totalValue", cartItem.TotalValue);
            return p;
        }

        protected override CartItemViewModel MontaModel(DataRow registro)
        {
            CartItemViewModel a = new CartItemViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.OrderId = Convert.ToInt32(registro["orderId"]);
            a.ProductId = Convert.ToInt32(registro["productId"]);
            a.Quantity = Convert.ToInt32(registro["quantity"]);
            a.Price = Convert.ToDecimal(registro["price"]);
            a.TotalValue = Convert.ToDecimal(registro["totalValue"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "CartItem";
            NomeSpListagem = "spListingCartItens";
        }
    }
}
