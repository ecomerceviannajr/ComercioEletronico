using NHibernateComercio.DataBase;
using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComercioEletronico.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
           return View();           
        }
        [HttpPost]
        public ActionResult GravarUsuario(Usuario usuario)
        {
            DBFactory.Instance.UsuarioRepository.Save(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult EditarUsuario(int id)
        {
            var usuario = DBFactory.Instance.UsuarioRepository.FindById(id);
            if (usuario != null)
            {
                return View(usuario);
            }
            return RedirectToAction("Index");
        }

        public ActionResult VerificarUsuario(Usuario usuario)
        {
            var logado = DBFactory.Instance.UsuarioRepository.FindByEmailSenha(usuario.Email, usuario.Senha);
            if (logado != null)
            {
                Session.Add("Usuario", logado);
                return View("Sucesso", "Usuario");
            }
            else
            {
                return View("Login");
            }

        }
        public ActionResult DetalhesUsuario(int id)
        {
            var usuario = DBFactory.Instance.UsuarioRepository.FindById(id);
            if (usuario != null)
            {
                return View(usuario);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sucesso()
        {
            return View();
        }
        public ActionResult Logoff()
        {
            if (Session["Usuario"] != null)
            {
                Session["Usuario"] = null;
                Session.Remove("Usuario");
            }
            return RedirectToAction("Index");
        }
        
        
    }
}