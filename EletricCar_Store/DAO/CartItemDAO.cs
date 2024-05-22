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
            p[1] = new SqlParameter("pedidoId", cartItem.OrderId);
            p[2] = new SqlParameter("produtoId", cartItem.ProductId);
            p[3] = new SqlParameter("quantidade", cartItem.Quantity);
            p[4] = new SqlParameter("preco", cartItem.Price);
            p[5] = new SqlParameter("valorTotal", cartItem.TotalValue);
            return p;
        }

        protected override CartItemViewModel MontaModel(DataRow registro)
        {
            CartItemViewModel a = new CartItemViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.OrderId = Convert.ToInt32(registro["pedidoId"]);
            a.ProductId = Convert.ToInt32(registro["produtoId"]);
            a.Quantity = Convert.ToInt32(registro["quantidade"]);
            a.Price = Convert.ToDecimal(registro["preco"]);
            a.TotalValue = Convert.ToDecimal(registro["valorTotal"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "CarrinhoItem";
            //NomeSpListagem = "spListaCarrinhoItens";
        }
    }
}
