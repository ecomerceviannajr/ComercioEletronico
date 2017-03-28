using NHibernateComercio.DataBase;
using NHibernateComercio.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComercioEletronico.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Endereco
       
        public ActionResult IncluirEndereco(int idu)
        {
            var usuario = DBFactory.Instance.UsuarioRepository.FindById(idu);

            if (usuario != null)
            {
                var endereco = new Endereco()
                {
                    Usuario = usuario
                };
                return View(endereco);
            }
            return RedirectToAction("DetalhesPessoas", new { id = idu });
        }
        public ActionResult GravarEndereco(Endereco endereco)
        {
            DBFactory.Instance.EnderecoRepository.Save(endereco);
            return RedirectToAction("DetalhesUsuario","Usuarios", new { id = endereco.Usuario.Id });
        }
        public ActionResult DeletarEndereco(int id)
        {
            var endereco = DBFactory.Instance.EnderecoRepository.FindById(id);
            if (endereco != null)
            {
                
                DBFactory.Instance.EnderecoRepository.Delete(endereco);
                return RedirectToAction("DetalhesUsuario", "Usuarios", new {  id = endereco.Usuario.Id });
            }
            return RedirectToAction("Index");
        }
    }
}