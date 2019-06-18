using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ContasRecebidasController : Controller
    {
        // GET: ClintePessoaFisica
        public ActionResult Index()
        {
            ContasRecebidasRepository repositorio = new ContasRecebidasRepository();
            ViewBag.ContasRecebidas = repositorio.ObterTodos("");

            return View();  
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Store(string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaRecebida conta = new ContaRecebida();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;

            ContasRecebidasRepository repositorio = new ContasRecebidasRepository();
            repositorio.Insert(conta);
            return RedirectToAction("index");
        }
        
        public ActionResult Editar(int id)
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }
    }
}