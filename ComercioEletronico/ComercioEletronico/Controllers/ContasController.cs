
using NHibernateComercio.DataBase;
using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComercioEletronico.Controllers
{
    public class ContasController : Controller
    {
        // GET: Contas
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logado(Administrativo admin)
        {
            string usuarioLogado = null;
            var user = new Administrativo();
            var data = DateTime.Now;
            var soma = data.Year + data.Day;

            user.Senha = "admin" + soma;

            if (admin.Senha == user.Senha)
            {
                usuarioLogado = "admin";
            }

            if (usuarioLogado != null)
            {
                Session.Add("Usuario", usuarioLogado);
                return View("Logado", admin);
            }
            else
            {
                ModelState.AddModelError("", "Senha Incorreta.");
                return View("Index", admin);
            }
        }

        public ActionResult LoginUsuarios(Usuario usuario)
        {
            var logado = DBFactory.Instance.UsuarioRepository.FindByEmailSenha(usuario.Email, usuario.Senha);
            if (logado != null)
            {
                Session.Add("Usuario", logado);
                return View("Sucesso");
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Logoff()
        {
            if (Session["Usuario"] != null)
            {
                Session["Usuario"] = null;
                Session.Remove("Usuario");
            }
            return RedirectToAction("Index","Home");
        }
    }
}