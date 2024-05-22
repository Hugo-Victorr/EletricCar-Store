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
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("id", address.Id);
            p[1] = new SqlParameter("usuarioId", address.UserId);
            p[2] = new SqlParameter("cep", address.CEP);
            p[3] = new SqlParameter("endereco", address.Address);
            p[4] = new SqlParameter("numero", address.Number);
            p[5] = new SqlParameter("cidade", address.City);
            p[6] = new SqlParameter("bairro", address.Neighborhood);
            p[7] = new SqlParameter("uf", address.State);
            return p;
        }

        protected override AddressViewModel MontaModel(DataRow registro)
        {
            AddressViewModel a = new AddressViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.UserId = Convert.ToInt32(registro["usuarioId"]);
            a.CEP = registro["cep"].ToString();
            a.Address = registro["endereco"].ToString();
            a.Number = registro["numero"].ToString();
            a.City = registro["cidade"].ToString();
            a.Neighborhood = registro["bairro"].ToString();
            a.State = registro["uf"].ToString();

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Endereco";
        }
    }
}
