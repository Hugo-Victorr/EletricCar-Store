using EletricCar_Store.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System;

namespace EletricCar_Store.DAO
{
    public class UserDAO : PadraoDAO<UserViewModel>
    {
        protected override SqlParameter[] CriaParametros(UserViewModel user)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("id", user.Id);
            p[1] = new SqlParameter("name", user.Name);
            p[2] = new SqlParameter("email", user.Email);
            p[3] = new SqlParameter("password", user.Password);
            p[4] = new SqlParameter("age", user.Age);
            return p;
        }

        protected override UserViewModel MontaModel(DataRow registro)
        {
            UserViewModel a = new UserViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Name = registro["name"].ToString();
            a.Email = registro["email"].ToString();
            a.Password = registro["password"].ToString();
            a.Age = Convert.ToInt32(registro["age"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "User";
            NomeSpListagem = "spListingUsers";
        }
    }
}
