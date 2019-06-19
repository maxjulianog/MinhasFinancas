using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ContasPagarController : Controller
    {
        // GET: ClintePessoaFisica
        public ActionResult Index()
        {
            ContasPagarRepository repositorio = new ContasPagarRepository();
            ViewBag.ContasPagar = repositorio.ObterTodos("");

            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Store(string nome, decimal valor, string tipo, string descricao, string status)
        {
            ContaPagar conta = new ContaPagar();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;

            ContasPagarRepository repositorio = new ContasPagarRepository();
            repositorio.Insert(conta);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            ContasPagarRepository repositorio = new ContasPagarRepository();
            ViewBag.ContasPagarEditar = repositorio.ObterPeloId(id);
            return View();
        }

        public ActionResult Update(string nome, decimal valor, string tipo, string descricao, string status, int id)
        {
            ContaPagar conta = new ContaPagar();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;
            conta.Id = id;

            ContasPagarRepository repositorio = new ContasPagarRepository();
            repositorio.Atualizar(conta);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            ContasPagarRepository repositorio = new ContasPagarRepository();
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}