using EletricCar_Store.DAO;
using EletricCar_Store.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EletricCar_Store.Controllers
{
    public class BrandController : PadraoController<BrandViewModel>
    {
        public BrandController()
        {
            DAO = new BrandDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(BrandViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.Description))
                ModelState.AddModelError("Marca", "Preencha o nome da Marca.");

        }


        protected override void PreencheDadosParaView(string Operacao, BrandViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            //if (Operacao == "I")
            //    model.DataNascimento = DateTime.Now;

            PreparaListaCidadesParaCombo();
        }

        private void PreparaListaCidadesParaCombo()
        {
            BrandDAO brandDao = new BrandDAO();
            var brands = brandDao.Listagem();
            List<SelectListItem> brandList = new List<SelectListItem>();
            brandList.Add(new SelectListItem("Selecione uma Marca...", "0"));
            foreach (var brand in brands)
            {
                SelectListItem item = new SelectListItem(brand.Description, brand.Id.ToString());
                brandList.Add(item);
            }
            ViewBag.Address = brandList;
        }
    }   
}

