using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteApiPartner.Models;

namespace TesteApiPartner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : Controller
    {
        MarcaDataAccesLayer obj = new MarcaDataAccesLayer();

        public IActionResult Index()
        {
            List<Marca> lstMarca = new List<Marca>();
            lstMarca = obj.GetAllMarcas().ToList();

            return View(lstMarca);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Marca Marca)
        {
            if (ModelState.IsValid)
            {
                obj.PostMarca(Marca);
                return RedirectToAction("Index");
            }
            return View(Marca);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Marca Marca = obj.GetMarca(id);

            if (Marca == null)
            {
                return NotFound();
            }
            return View(Marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Marca Marca)
        {
            if (id != Marca.MarcaId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                obj.PutMarca(Marca);
                return RedirectToAction("Index");
            }
            return View(Marca);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Marca Marca = obj.GetMarca(id);

            if (Marca == null)
            {
                return NotFound();
            }
            return View(Marca);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Marca Marca = obj.GetMarca(id);

            if (Marca == null)
            {
                return NotFound();
            }
            return View(Marca);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            obj.DeleteMarca(id);
            return RedirectToAction("Index");
        }
    }
}