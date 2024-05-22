using EletricCar_Store.DAO;
using EletricCar_Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;
using System;

namespace EletricCar_Store.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FazLogin(string usuario, string senha)
        {
            //Este é apenas um exemplo, aqui você deve consultar na sua tabela de usuários
            //se existe esse usuário e senha
            if (usuario == "admin" && senha == "1234")
            {
                HttpContext.Session.SetString("Logado", "true");
                HelperDAO.CurrentUser = new UserViewModel()
                {
                    Id = 1,
                    Name = usuario,
                    Age = 22,
                    Email = "teste@teste.com",
                    Password = senha,
                    BornDate = DateTime.UtcNow
                };

                //var userDao = new UserDAO();
                //var currentUser = userDao.Consulta(usuario);
                //HelperDAO.CurrentUser = currentUser;

                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
