using EletricCar_Store.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System;
using System.Reflection;

namespace EletricCar_Store.DAO
{
    public class CarDAO : PadraoDAO<CarViewModel>
    {
        protected override SqlParameter[] CriaParametros(CarViewModel car)
        {
            object imgByte = car.ImagemEmByte;
            if (imgByte == null)
                imgByte = DBNull.Value;
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("id", car.Id);
            p[1] = new SqlParameter("marca", car.Brand);
            p[2] = new SqlParameter("modelo", car.Model);
            p[3] = new SqlParameter("preco", car.Price);
            p[4] = new SqlParameter("imagem", imgByte);
            return p;
        }

        protected override CarViewModel MontaModel(DataRow registro)
        {
            CarViewModel a = new CarViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Brand = Convert.ToInt32(registro["marca"]);
            a.Model = registro["modelo"].ToString();
            a.Price = Convert.ToDecimal(registro["preco"].ToString());
            if (registro["imagem"] != DBNull.Value)
                a.ImagemEmByte = registro["imagem"] as byte[];

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Carro";
        }
    }
}
