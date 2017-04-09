using NHibernateComercio.DataBase;
using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComercioEletronico.Controllers
{
    public class InteressesController : Controller
    {
        // GET: Interesses
        public ActionResult Index(int id)
        {
            var usuario = DBFactory.Instance.UsuarioRepository.FindById(id);
            if (usuario != null)
            {
                var inter = new Interesses()
                {
                    Usuario = usuario
                };
                return View(inter);
            }
            return RedirectToAction("Index", new { id = id });
        }

        [HttpPost]
        public ActionResult GravarInteresse(Interesses inter)
        {           
            DBFactory.Instance.InteressesRepository.Save(inter);
            return RedirectToAction("Index", new { id = inter.Usuario.Id });
        }
    }
}