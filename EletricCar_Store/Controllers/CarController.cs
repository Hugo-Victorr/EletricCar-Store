using EletricCar_Store.DAO;
using EletricCar_Store.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EletricCar_Store.Controllers
{
    public class CarController : PadraoController<CarViewModel>
    {
        public CarController()
        {
            DAO = new CarDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(CarViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (model.Brand <= 0)
                ModelState.AddModelError("Marca", "Preencha a Marca.");

            if (string.IsNullOrEmpty(model.Model))
                ModelState.AddModelError("Modelo", "Preencha o Modelo.");

            if (model.Price <= 0)
                ModelState.AddModelError("Preço", "Preencha o Preço.");

            //Imagem será obrigatio apenas na inclusão.
            //Na alteração iremos considerar a que já estava salva.
            //if (model.Imagem == null && operacao == "I")
            //    ModelState.AddModelError("Imagem", "Escolha uma imagem.");
            //if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
            //    ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");
            //if (ModelState.IsValid)
            //{
            //    //na alteração, se não foi informada a imagem, iremos manter a que já estava salva.
            //    if (operacao == "A" && model.Imagem == null)
            //    {
            //        CarViewModel cid = DAO.Consulta(model.Id);
            //        model.ImagemEmByte = cid.ImagemEmByte;
            //    }
            //    else
            //    {
            //        model.ImagemEmByte = ConvertImageToByte(model.Imagem);
            //    }
            //}
        }

        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }
    }
}
