using Microsoft.AspNetCore.Mvc;
using NovoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace NovoMVC.Controllers
{
    public class ProdutosController : Controller
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { ID = 1, Nome = "Caneta", Preco = 2.50m },
            new Produto { ID = 2, Nome = "Lápis", Preco = 1.85m },
            new Produto { ID = 3, Nome = "Caderno", Preco = 18.99m }
        };

        // GET: Produtos
        public IActionResult Index()
        {
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = produtos.FirstOrDefault(p => p.ID == id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Nome,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.ID = produtos.Max(p => p.ID) + 1;
                produtos.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = produtos.FirstOrDefault(p => p.ID == id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Nome,Preco")] Produto produto)
        {
            var original = produtos.FirstOrDefault(p => p.ID == id);
            if (original == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                original.Nome = produto.Nome;
                original.Preco = produto.Preco;
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = produtos.FirstOrDefault(p => p.ID == id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.ID == id);
            if (produto != null)
            {
                produtos.Remove(produto);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
