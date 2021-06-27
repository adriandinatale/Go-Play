using GoPlay.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoPlay.Controllers

{
    [Authorize]
    public class ListaReproduccionesController : Controller
    {
        private ApplicationDbContext context;

        public ListaReproduccionesController(ApplicationDbContext context)
        {
            this.context = context;

        }

    }
}