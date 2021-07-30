using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoPlay.Data;
using GoPlay.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GoPlay.Controllers


{

    [Authorize]
    public class ProyectosController : Controller
    {
        private ApplicationDbContext _context;
        public ProyectosController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Abrir()
        {

            List<Proyecto> proyectosLista = await _context.Proyectos.ToListAsync();

            return View(proyectosLista);

        }

        
        
        public IActionResult Crear()
        {
            return View();
        }
       

        [HttpPost]

        public async Task<IActionResult> Crear([Bind("ID,NombreObra")] Proyecto proyecto)
        {


            _context.Add(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Abrir");


        }

       


        public async Task<IActionResult> Editar(int id)
        {

            var proyectos = await _context.Proyectos
            .FirstOrDefaultAsync(m => m.ID == id);

            return View(proyectos);
        }


        [HttpPost]

        public async Task<IActionResult> Editar(int id, [Bind("ID,NombreObra")] Proyecto Proyecto)
        {


            _context.Update(Proyecto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Abrir));

        }




        public async Task<IActionResult> Eliminar(int? id)
        {

            var proyecto = await _context.Proyectos
            .FirstOrDefaultAsync(m => m.ID == id);

            return View(proyecto);
        }



        [HttpPost, ActionName("Eliminar")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Abrir));
        }

    }
}

