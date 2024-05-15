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
            if (model.Number <= 0)
                ModelState.AddModelError("Numero", "Informe o numero da residência.");

        }


        protected override void PreencheDadosParaView(string Operacao, AddressViewModel model)
        {
            //base.PreencheDadosParaView(Operacao, model);
            //if (Operacao == "I")
            //    model.DataNascimento = DateTime.Now;

            //PreparaListaCidadesParaCombo();
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
