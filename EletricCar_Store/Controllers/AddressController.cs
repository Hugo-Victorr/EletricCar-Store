using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using EletricCar_Store.DAO;
using EletricCar_Store.Models;

namespace EletricCar_Store.Controllers
{
    public class AddressController : PadraoController<AddressViewModel>
    {
        public AddressController()
        {
            DAO = new AddressDAO();
            GeraProximoId = true;
        }


        protected override void ValidaDados(AddressViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.CEP))
                ModelState.AddModelError("CEP", "Preencha o CEP.");
            if (string.IsNullOrEmpty(model.Address))
                ModelState.AddModelError("Endereço", "Campo obrigatório.");
            if (string.IsNullOrEmpty(model.Number))
                ModelState.AddModelError("Numero", "Informe o numero da residência.");
            if (string.IsNullOrEmpty(model.City))
                ModelState.AddModelError("Cidade", "Informe a cidade.");
            if (string.IsNullOrEmpty(model.Neighborhood))
                ModelState.AddModelError("Bairro", "Informe o bairro.");
            if (string.IsNullOrEmpty(model.State))
                ModelState.AddModelError("Numero", "Informe o UF.");

        }


        protected override void PreencheDadosParaView(string Operacao, AddressViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            if (Operacao == "I")
                model.Id = DAO.ProximoId();

            model.UserId = HelperDAO.CurrentUser.Id;

        }

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
        //    ViewBag.Address = listaCidades;
        //}
    }
}
