using Microsoft.AspNetCore.Mvc;
using reserva_de_sala_dsm.Models;
using System.Linq.Expressions;

namespace reserva_de_sala_dsm.Controllers
{
    public class SalaController : Controller
    {
        private readonly Interfaces.ISalaService _salaService;

        public SalaController(Interfaces.ISalaService salaService)
        {
            _salaService = salaService;
        }

        // GET: /Salas
        public IActionResult Index()
        {
            var salas = _salaService.GetAllSalasAsync().Result;

            return View(salas);
        }

        public async Task<IActionResult> Details(long id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);
            if (sala == null)
            {
                TempData["ErrorMessage"] = "Sala não encontrada.";
                return RedirectToAction("Index");
            }
            return View(sala);
        }

        // GET: /Salas/Create
        public IActionResult Create()
        {
            return View(new Sala());
        }

        // POST: /Salas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome, Capacidade, Recursos")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _salaService.SaveSalaAsync(sala);
                    TempData["SuccessMessage"] = "Sala criada com sucesso.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao criar a sala: {ex.Message}");
                }
            }
            return View(sala); // Ensure a return statement exists outside the try-catch block
        }

        // GET: /Salas/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);
            if (sala == null)
            {
                TempData["ErrorMessage"] = "Sala não encontrada.";
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }

        // POST: /Salas/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id, Nome, Capacidade, Recursos")] Sala sala)
        {
            if (id != sala.Id)
            {
                TempData["ErrorMessage"] = "ID da sala inconsistente.";
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _salaService.SaveSalaAsync(sala);
                    TempData["SuccessMessage"] = "Sala atualizada com sucesso.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao atualizar a sala: {ex.Message}");
                }
            }
            return View(sala);
        }
        // GET: /Salas/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);
            if (sala == null)
            {
                TempData["ErrorMessage"] = "Sala não encontrada.";
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }
        // POST: /Salas/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                await _salaService.DeleteSalaAsync(id);
                TempData["SuccessMessage"] = "Sala deletada com sucesso.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao deletar a sala: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}