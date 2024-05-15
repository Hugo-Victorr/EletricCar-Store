using System;

namespace EletricCar_Store.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string msgErro)
        {
            Erro = msgErro;
        }

        public ErrorViewModel()
        { }

        public string Erro { get; set; }

        #region Inútil 

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        #endregion
    }
}