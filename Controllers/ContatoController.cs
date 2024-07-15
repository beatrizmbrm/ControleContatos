using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorios _contatoRepositorios;

        public ContatoController(IContatoRepositorios contatoRepositorios)
        {
            _contatoRepositorios = contatoRepositorios;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorios.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorios.ListaPorId(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
            ContatoModel contato = _contatoRepositorios.ListaPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Add(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorios.Adicionar(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorios.Atualizar(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }
    }
}
