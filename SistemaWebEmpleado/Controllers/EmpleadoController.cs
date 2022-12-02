using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoDBContext _context;
        public EmpleadoController(EmpleadoDBContext context) { _context = context; }


        // GET: Empleado/Index
        public IActionResult Index()
        {
            return View(_context.Empleados.ToList());
        }

        //GET Empleado/Create

        [HttpGet]
        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Crear", empleado);
        }

        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", empleado);
            }
        }

        [HttpGet("{titulo}")]
        public IActionResult ListarPorTitulo(string titulo)
        {
            IEnumerable<Empleado> listXTitulo = BuscarXTitulo(titulo);
            return View("Index", listXTitulo);
        }

        public IActionResult Edit(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View("Modificar", empleado);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit([Bind(include: "EmpleadoId,Nombre,Apellido,Dni,Legajo,Titulo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Modificar", empleado);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View("Eliminar", empleado);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Empleado empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Detalle", empleado);
            }
        }

        #region Metodos nonAction
        [NonAction]
        public IEnumerable<Empleado> BuscarXTitulo(string titulo)
        {
            if (titulo != null)
            {
                IEnumerable<Empleado> ListEmpleados = (from e in _context.Empleados
                                                       where e.Titulo.ToLower() == titulo.ToLower()
                                                       select e).ToList();
                return ListEmpleados;
            }
            else
                return Enumerable.Empty<Empleado>();
        }
        #endregion
    }
}
    