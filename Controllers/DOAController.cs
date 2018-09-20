using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DOA.Data;
using DOA.Models;
using DOA.Services;

namespace DOA.Controllers
{
    public class DOAController : Controller
    {
        private readonly IDayService _dayService;
        public DOAController(IDayService dayService)
        {
            _dayService = dayService;
        }

        // Displays items
        public async Task<IActionResult> Index()
        {
            var allDays = await _dayService.GetIncompleteItemsAsync();
            var model = new DayViewModel()
            {
                AllDays = allDays
            };
            return View(model);
        }

        // GET Create Action Method
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST Create Action Method
        [HttpPost]
        [ValidateAntoForgeryKey]
        public IActionResult Create(AllDays allDays)
        {
            if(ModelState.IsValid)
            {
                _dayService.Add(allDays);
                _dayService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(allDays);
        }



    }
}
