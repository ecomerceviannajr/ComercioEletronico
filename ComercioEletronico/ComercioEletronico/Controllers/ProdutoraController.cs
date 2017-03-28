using NHibernateComercio.DataBase;
using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComercioEletronico.Controllers
{
    public class ProdutoraController : Controller
    {
        // GET: Produtora
        public ActionResult Index()
        {
            var produtoras = DBFactory.Instance.ProdutoraRepository.FindAll();
            return View(produtoras);
        }

        public ActionResult CriarProdutora()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GravarProdutora(Produtora produtora)
        {
            if(produtora != null)
            {
                DBFactory.Instance.ProdutoraRepository.Save(produtora);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult ApagarProdutora(int id)
        {
            var produtora = DBFactory.Instance.ProdutoraRepository.FindById(id);
            if (produtora != null)
            {
                DBFactory.Instance.ProdutoraRepository.Delete(produtora);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AlterarProdutora(int id)
        {
            var produtora = DBFactory.Instance.ProdutoraRepository.FindById(id);
            if (produtora != null)
            {
                return View(produtora);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DetalhesProdutora(int id)
        {
            var produtora = DBFactory.Instance.ProdutoraRepository.FindById(id);
            if (produtora != null)
            {
                return View(produtora);
            }
            return RedirectToAction("Index");
        }

    }
}