using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using EletricCar_Store.Models;
using EletricCar_Store.DAO;

namespace EletricCar_Store.Controllers
{
    public class UserController : PadraoController<UserViewModel>
    {
        public UserController()
        {
            DAO = new UserDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(UserViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Nome", "Preencha o nome.");
            if (model.Age <= 0 && model.Age >= 100)
                ModelState.AddModelError("Idade", "Preencha a idade.");
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Preencha o email.");
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                ModelState.AddModelError("Senha", "Informe uma senha.");
            if (model.BornDate > DateTime.Now)
                ModelState.AddModelError("DataNascimento", "Data inválida!");

        }


        //protected override void PreencheDadosParaView(string Operacao, UserViewModel model)
        //{
        //    base.PreencheDadosParaView(Operacao, model);
        //    if (Operacao == "I")
        //        model.BornDate = DateTime.Now;

        //    PreparaListaCidadesParaCombo();
        //}

        //private void PreparaListaCidadesParaCombo()
        //{
        //    CidadeDAO cidadeDao = new CidadeDAO();
        //    var cidades = cidadeDao.Listagem();
        //    List<SelectListItem> listaCidades = new List<SelectListItem>();
        //    listaCidades.Add(new SelectListItem("Selecione uma cidade...", "0"));
        //    foreach (var cidade in cidades)
        //    {
        //        SelectListItem item = new SelectListItem(cidade.Nome, cidade.Id.ToString());
        //        listaCidades.Add(item);
        //    }
        //    ViewBag.Cidades = listaCidades;
        //}
    }
}
