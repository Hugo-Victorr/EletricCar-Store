using Microsoft.AspNetCore.Http;
using System;

namespace EletricCar_Store.Controllers
{
    public static class HelperControllers
    {
        public static bool VerifyUserIsLog(ISession session)
        {
            string logado = session.GetString("Logado");
            if (logado == null)
                return false;
            else
                return true;
        }

        public static void CleanCart(ISession session)
        {
            session.Remove("cart");                
        }
    }

}

