using EletricCar_Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
using EletricCar_Store.DAO;
using Newtonsoft.Json;

namespace EletricCar_Store.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                CarDAO dao = new CarDAO();
                var carList = dao.Listagem();
                var cart = GetCartFromSession();
                //@ViewBag.TotalCarrinho = carrinho.Sum(c => c.Quantidade);
                @ViewBag.CartTotal = 0;
                foreach (var c in cart.CartItens)
                    @ViewBag.CartTotal += c.Quantity;
                return View(carList);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Detalhes(int carId)
        {
            try
            {
                CartViewModel cart = GetCartFromSession();
                CarDAO carDao = new CarDAO();
                var carModel = carDao.Consulta(carId);
                CartItemViewModel cartItemModel = cart.CartItens.Find(x => x.Id == carId);
                if (cartItemModel == null)
                {
                    cartItemModel = new CartItemViewModel();
                    cartItemModel.ProductId = carId;
                    cartItemModel.Price = carModel.Price;
                    cartItemModel.Quantity = 0;
                }
                // preenche a imagem
                //cartItemModel.ImagemEmBase64 = carModel.ImagemEmBase64;
                return View(cartItemModel);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        private CartViewModel GetCartFromSession()
        {
            CartViewModel cart = new CartViewModel();
            string cartJson = HttpContext.Session.GetString("cart");
            if (cartJson != null)
                cart = JsonConvert.DeserializeObject<CartViewModel>(cartJson);
            return cart;
        }
        public IActionResult AdicionarCarrinho(int carId, int quantity)
        {
            try
            {
                CartViewModel cart = GetCartFromSession();
                CartItemViewModel cartItemModel = cart.CartItens.Find(c => c.Id == carId);
                if (cartItemModel != null && quantity == 0)
                {
                    //tira do carrinho
                    cart.CartItens.Remove(cartItemModel);
                }
                else if (cartItemModel == null && quantity > 0)
                {
                    //não havia no carrinho, vamos adicionar
                    CarDAO carDao = new CarDAO();
                    var carModel = carDao.Consulta(carId);
                    cartItemModel = new CartItemViewModel();
                    cartItemModel.ProductId = carId;
                    cartItemModel.Price = carModel.Price;
                    cart.CartItens.Add(cartItemModel);
                }

                if (cartItemModel != null)
                    cartItemModel.Quantity = quantity;
                string cartJson = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString("cart", cartJson);
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Visualizar()
        {
            try
            {
                CartItemDAO dao = new CartItemDAO();
                var cart = GetCartFromSession();
                foreach (var carItem in cart.CartItens)
                {
                    var car = dao.Consulta(carItem.Id);
                    //car.ImagemEmBase64 = car.ImagemEmBase64;
                }
                return View(cart);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!HelperControllers.VerifyUserIsLog(HttpContext.Session))
                context.Result = RedirectToAction("Index", "Login");
            else
            {
                ViewBag.Logado = true;
                base.OnActionExecuting(context);
            }
        }


        public IActionResult EfetuarPedido()
        {
            try
            {
                using (var transacao = new System.Transactions.TransactionScope())
                {
                    OrderViewModel order = new OrderViewModel();
                    order.UserId = HelperDAO.CurrentUser.Id;
                    order.PurchaseDate = DateTime.Now;
                    OrderDAO orderDao = new OrderDAO();
                    int orderId = orderDao.Insert(order);

                    CartItemDAO cartItemDAO = new CartItemDAO();
                    var cart = GetCartFromSession();

                    if (cart.CartItens.Count < 1)
                        throw new Exception("Não possui itens");

                    foreach (var cartItem in cart.CartItens)
                    {
                        cartItem.OrderId = orderId;
                        cartItem.UpdateTotalValue();
                        cartItemDAO.Insert(cartItem);
                    }
                    transacao.Complete();
                }
                HelperControllers.CleanCart(HttpContext.Session);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
