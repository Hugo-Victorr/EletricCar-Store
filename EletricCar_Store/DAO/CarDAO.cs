using EletricCar_Store.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System;

namespace EletricCar_Store.DAO
{
    public class CarDAO : PadraoDAO<CarViewModel>
    {
        protected override SqlParameter[] CriaParametros(CarViewModel car)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("id", car.Id);
            p[1] = new SqlParameter("brand", car.Brand);
            p[2] = new SqlParameter("model", car.Model);
            p[3] = new SqlParameter("price", car.Price);
            return p;
        }

        protected override CarViewModel MontaModel(DataRow registro)
        {
            CarViewModel a = new CarViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Brand = Convert.ToInt32(registro["brand"]);
            a.Model = registro["model"].ToString();
            a.Price = Convert.ToDecimal(registro["price"].ToString());

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Car";
            NomeSpListagem = "spListingCars";
        }
    }
}
