using NHibernateComercio.DataBase;
using NHibernateComercio.DataBase.Models;
using NHibernateComercio.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComercioEletronico.Controllers
{
    public class ProdutoController : Controller
    {

        // GET: Produto
        public ActionResult Home()
        {
            var Produtos = DBFactory.Instance.ProdutoRepository.FindAll();
            if(Produtos == null)
            {
                Produtos = new List<Produto>();
            }
            return View(Produtos);
        }

        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto
        public ActionResult Details(int id)
        {
            var produto = DBFactory.Instance.ProdutoRepository.FindById(id);
            if(produto != null)
            {
                return View(produto);
            }
            return RedirectToAction("Home");
        }

        // GET: Produto
        public ActionResult Edit(int id)
        {
            var produto = DBFactory.Instance.ProdutoRepository.FindById(id);
            if(produto != null)
            {
                return View(produto);
            }
            return RedirectToAction("Home");
        }

        // GET: Produto
        public ActionResult Delete(int id)
        {
            var produto = DBFactory.Instance.ProdutoRepository.FindById(id);
            if (produto != null)
            {
                DBFactory.Instance.ProdutoRepository.Delete(produto);
            }
            return RedirectToAction("Home");
        }
        [HttpPost]
        public ActionResult Cadastrar(Produto obj)
        {
            if (obj.Id == 0 && obj.Produtora != null)
            {
                var produtora = DBFactory.Instance.ProdutoraRepository.FindById(obj.Produtora.Id);
                if (produtora != null)
                {
                    DBFactory.Instance.ProdutoRepository.Save(obj);
                    return RedirectToAction("Home");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult BuscarProduto(string nome)
        {
            if(nome == "")
            {
                return RedirectToAction("Home");
            }else
            {
                var produtos = DBFactory.Instance.ProdutoRepository.FindByNome(nome);
                return View("Home", produtos);
            }
        }

        [HttpPost]
        public ActionResult InsereFoto(int idProduto)
        {
            var produto = DBFactory.Instance.ProdutoRepository.FindById(idProduto);
            if(produto != null)
            {
                var foto = new Foto()
                {
                    Produto = produto
                };
                return View(foto);
            }
            return View();
        }

        [HttpPost]
        public ActionResult GravaImagem(Foto foto)
        {
            DBFactory.Instance.FotoRepository.Save(foto);
            return RedirectToAction("Details", new { id = foto.Produto.Id});
        }

        public ActionResult DropFoto(int id)
        {
            var foto = DBFactory.Instance.FotoRepository.FindById(id);
            if(foto != null)
            {
                var produto = foto.Produto.Id;
                DBFactory.Instance.FotoRepository.Delete(foto);
                return RedirectToAction("Details", new { id = produto });
            }
            return RedirectToAction("Home");
        }
        public ActionResult ExibirByProdutora(int id)
        {
            var produtos = DBFactory.Instance.ProdutoRepository.FindByIdProdutora(id);
            if (produtos == null)
            {
                produtos = new List<Produto>();
            }
            return View("Home", produtos);
        }

        public ActionResult Busca()
        {
            return View();

        }
        [HttpPost]
        public ActionResult BuscaR(String nome)
        {
            var produto = (IList<Produto>) DBFactory.Instance.ProdutoRepository.FindByNome(nome);
            return View(produto);

        }
        public ActionResult BuscaAvancada()
        {
            return View();

        }
        [HttpPost]
        public ActionResult BuscaAvancadaR(string nome = null, Double preco =0 , int data = 0, String categoria = null, Double peso =0, String descricao = null)
        {
            var produto = (IList<Produto>)DBFactory.Instance.ProdutoRepository.FindByIdAvancada(nome, preco, data, categoria, peso ,descricao);
            return View(produto);

        }
    }
}