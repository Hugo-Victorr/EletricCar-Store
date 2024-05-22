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
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("id", user.Id);
            p[1] = new SqlParameter("nome", user.Name);
            p[2] = new SqlParameter("idade", user.Age); 
            p[3] = new SqlParameter("email", user.Email);
            p[4] = new SqlParameter("senha", user.Password);
            p[5] = new SqlParameter("dataNascimento", user.BornDate);
            return p;
        }

        protected override UserViewModel MontaModel(DataRow registro)
        {
            UserViewModel a = new UserViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Name = registro["nome"].ToString();
            a.Age = Convert.ToInt32(registro["idade"]);
            a.Email = registro["email"].ToString();
            a.Password = registro["senha"].ToString();
            a.BornDate = Convert.ToDateTime(registro["dataNascimento"]);

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario";
        }
    }
}
