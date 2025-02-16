﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web_CRUD.Entities;

namespace Web_CRUD.Controllers
{
    public class TinhController : Controller
    {
        private readonly CrudDbContext _context;

        public TinhController(CrudDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Tinhs.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tinh model)
        {
            if (ModelState.IsValid)
            {
                Tinh newItem = new Tinh()
                {
                    Ten = model.Ten,
                    Cap = model.Cap
                };
                _context.Tinhs.Add(newItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var data = _context.Tinhs.FirstOrDefault(x => x.IdTinh == id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edited(Tinh model)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Tinhs.FirstOrDefault(x => x.IdTinh == model.IdTinh);
                data.Ten = model.Ten;
                data.Cap = model.Cap;
                _context.Tinhs.Update(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = _context.Tinhs.FirstOrDefault(x => x.IdTinh == id);
            if (data != null)
            {
                _context.Tinhs.Remove(data);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
