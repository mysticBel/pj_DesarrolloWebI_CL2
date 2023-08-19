using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
// 1. agregamos referencias
using Proyecto_Cl2_Maribel.Models;

namespace Proyecto_Cl2_Maribel.Controllers
{
    public class PostulanteController : Controller
    {
        // 2. Creamos los objetos interfaces
        private IPostulante iPostulante;
        private ICarrera iCarrera;

        //3 . Las instanciamos en el constructor
        public PostulanteController()
        {
            iPostulante = new PostulanteRepositorio();
            iCarrera = new CarreraRepositorio();
        }


        public async Task<IActionResult> Index()
        {
            return View(await Task.Run(() => iPostulante.GetPostulantes()));
        }

        // 5. Para CRUD : vista Create
        public async Task<IActionResult> Create()
        {
            //viewbags para listar el combo para las carreras
            ViewBag.carreras = new SelectList(
                await Task.Run(() => iCarrera.GetCarreras()),
                "idCarrera", 
                "nombreCarrera"      
                );
            // retorna un postulante vacio
            return View(new Postulante());

        }
        //
        [HttpPost]
        public async Task<IActionResult> Create(Postulante postulante)
        {
            //recibe un objeto Postulante
            ViewBag.carreras = new SelectList(
                await Task.Run(() => iCarrera.GetCarreras()),
                "idCarrera",
                "nombreCarrera",
                postulante.idCarrera
                );

            //
            if (!ModelState.IsValid)
            {
                return View(postulante);
            }
            //
            ViewBag.mensaje = iPostulante.Agregar(postulante);
            return View(postulante);
        }


        // 6. Para CRUD : vista Edit
        public async Task<IActionResult> Edit(int idPostulante)
        {
            //
            Postulante postulante = iPostulante.GetPostulantes()
                                .Where(item => item.idPostulante == idPostulante)
                                .FirstOrDefault();
            if (postulante == null)
                return RedirectToAction("Index");


            //viewbags para listar el combo 
            ViewBag.carreras = new SelectList(
                await Task.Run(() => iCarrera.GetCarreras()),
                "idCarrera",
                "nombreCarrera"

                );
            // retorna el postulante encontrado
            return View(postulante);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Postulante postulante)
        {

            //viewbags para listar el combo 
            ViewBag.carreras = new SelectList(
                await Task.Run(() => iCarrera.GetCarreras()),
                "idCarrera",
                "nombreCarrera"

                );
            //
            if (!ModelState.IsValid)
            {
                return View(postulante);
            }
            //
            ViewBag.mensaje = iPostulante.Editar(postulante);
            return View(postulante);


        }

        // 7. Para CRUD : vista Delete
        public async Task<IActionResult> Delete(int idPostulante)
        {
            //
            Postulante postulante = iPostulante.GetPostulantes()
                                .Where(item => item.idPostulante == idPostulante)
                                .FirstOrDefault();
            if (postulante == null)
                return RedirectToAction("Index");


            // retorna el postulante encontrado
            return View(postulante);

        }

        //
        [HttpPost]
        public async Task<IActionResult> Delete(Postulante postulante)
        {

            ViewBag.mensaje = iPostulante.Delete(postulante);
            return RedirectToAction("Index");


        }
    }
}
