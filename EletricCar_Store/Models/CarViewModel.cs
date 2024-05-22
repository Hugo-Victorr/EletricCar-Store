using Microsoft.AspNetCore.Http;
using System;
using System.Reflection.Metadata;

namespace EletricCar_Store.Models
{
    public class CarViewModel : PadraoViewModel
    {
        public int Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public IFormFile Imagem { get; set; }
        /// <summary>
        /// Imagem em bytes pronta para ser salva
        /// </summary>
        public byte[] ImagemEmByte { get; set; }
        /// <summary>
        /// Imagem usada para ser enviada ao form no formato para ser exibida
        /// </summary>
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
    }
}
