﻿using Model;
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
            return RedirectToAction("Index");
        }
        
        public ActionResult Editar(int id)
        {
            ContasRecebidasRepository repositorio = new ContasRecebidasRepository();
            ViewBag.ContaRecebidaEditar = repositorio.ObterPeloId(id);
            return View();
        }

        public ActionResult Update(string nome, decimal valor, string tipo, string descricao, string status, int id)
        {
            ContaRecebida conta = new ContaRecebida();
            conta.Nome = nome;
            conta.Valor = valor;
            conta.Tipo = tipo;
            conta.Descricao = descricao;
            conta.Status = status;
            conta.Id = id;

            ContasRecebidasRepository repositorio = new ContasRecebidasRepository();
            repositorio.Atualizar(conta);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            ContasRecebidasRepository repositorio = new ContasRecebidasRepository();
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }
       
    }
}