using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        // GET: ToDo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDos.ToListAsync());
        }


        // GET: ToDo/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new ToDo());
            else
                return View(_context.ToDos.Find(id));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Description,datetime")] ToDo todo)
        {
            if (ModelState.IsValid)
            {
                if (todo.Id == 0)
                    _context.Add(todo);
                else
                    _context.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }


        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.ToDos.FindAsync(id);
            _context.ToDos.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}