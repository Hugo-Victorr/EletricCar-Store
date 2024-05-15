using EletricCar_Store.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace EletricCar_Store.DAO
{
    public class AddressDAO : PadraoDAO<AddressViewModel>
    {
        protected override SqlParameter[] CriaParametros(AddressViewModel address)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("id", address.Id);
            p[1] = new SqlParameter("userId", address.UserId);
            p[2] = new SqlParameter("cep", address.CEP);
            p[3] = new SqlParameter("Address", HelperDAO.NullAsDbNull(address.Address));
            p[4] = new SqlParameter("number", address.Number);
            return p;
        }

        protected override AddressViewModel MontaModel(DataRow registro)
        {
            AddressViewModel a = new AddressViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.UserId = Convert.ToInt32(registro["cep"]);
            a.CEP = registro["cep"].ToString();
            
            if (registro["address"] != DBNull.Value)
                a.Address = registro["address"].ToString();

            a.Number = Convert.ToInt32(registro["number"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Address";
            NomeSpListagem = "spListingAddresses";
        }
    }
}
