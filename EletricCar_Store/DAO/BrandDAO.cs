﻿using EletricCar_Store.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace EletricCar_Store.DAO
{
    public class BrandDAO : PadraoDAO<BrandViewModel>
    {
        protected override SqlParameter[] CriaParametros(BrandViewModel brand)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("id", brand.Id);
            p[1] = new SqlParameter("descricao", brand.Description);
            return p;
        }

        protected override BrandViewModel MontaModel(DataRow registro)
        {
            BrandViewModel a = new BrandViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Description = registro["descricao"].ToString();

            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "Marca";
        }
    }
}
