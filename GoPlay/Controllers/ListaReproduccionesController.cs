using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoPlay.Data;
using GoPlay.Models;
using GoPlay.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace GoPlay.Controllers

{
    [Authorize]
    public class ListaReproduccionesController : Controller
    {
        private ApplicationDbContext _context;

        public ListaReproduccionesController(ApplicationDbContext context)
        {
            _context = context;

        }

  

        public async Task<IActionResult> Abrir()
        {

            List<ListaReproduccion> reproduccionesLista = await _context.ListaReproducciones.ToListAsync();


            var Tiempo = DateTime.Now;
            var Hora = Tiempo.ToShortTimeString();
            ViewBag.DateTime = Hora;
      
            return View(reproduccionesLista);

        }




        public async Task<IActionResult> Mostrar(int id)
        {

            var listaReproduccion = await _context.ListaReproducciones
            .FirstOrDefaultAsync(m => m.ID == id);


            ViewBag.ID = id;
            ViewBag.Nombre = listaReproduccion.Nombre;
            ViewBag.Detalle = listaReproduccion.Detalle;


            return View("Abrir", _context.ListaReproducciones);

        }




        public async Task<IActionResult> Crear()
        {

            List<ListaReproduccion> reproduccionesLista = await _context.ListaReproducciones.ToListAsync();

            return View(reproduccionesLista);
        }



        [HttpPost]

        public async Task<IActionResult> Crear(ListaReproduccion subir, int Numero, string Nombre, string Detalle)
        {

            using (var ms = new MemoryStream())
            {
                var listaReproduccion = new ListaReproduccion();
                listaReproduccion.Numero = Numero;
                listaReproduccion.Nombre = Nombre;
                listaReproduccion.Detalle = Detalle;
                listaReproduccion.ProyectoID = 1;

                await subir.MyFile.CopyToAsync(ms);
                listaReproduccion.Pista = ms.ToArray();
                _context.ListaReproducciones.Add(listaReproduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Crear");


                //if (listaReproduccion.ProyectoID != 1)
                //{

                //    listaReproduccion.ProyectoID = 2;
                //    _context.Add(listaReproduccion);
                //    await _context.SaveChangesAsync();
                //    return RedirectToAction("Crear");
                //}

                //else
                //{
                //    _context.Add(listaReproduccion);
                //    await _context.SaveChangesAsync();
                //    return RedirectToAction("Crear");
                //}
            }
        }



        public async Task<IActionResult> Editar(int id, int Numero, string Nombre, string Detalle)
        {

            var listaReproduccion = await _context.ListaReproducciones
            .FirstOrDefaultAsync(m => m.ID == id);

            return View(listaReproduccion);
        }


        [HttpPost]

        public async Task<IActionResult> Editar(int id, [Bind("ID,Numero,Nombre,Detalle,ProyectoID")] ListaReproduccion listaReproduccion)
        {

            _context.Update(listaReproduccion);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Crear));

        }



        public async Task<IActionResult> Eliminar(int? id)
        {

            var listaReproduccion = await _context.ListaReproducciones
            .FirstOrDefaultAsync(m => m.ID == id);

            return View(listaReproduccion);
        }



        [HttpPost, ActionName("Eliminar")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaReproduccion = await _context.ListaReproducciones.FindAsync(id);
            _context.ListaReproducciones.Remove(listaReproduccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Crear));
        }

        
       























































    }
}