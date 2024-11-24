using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab5.Core.Services;
using Lab5.Web.Models;

namespace Lab5.Web.Controllers
{
    [Authorize]
    public class LabsController : Controller
    {
        private readonly Lab1Service _lab1Service;
        private readonly Lab2Service _lab2Service;
        private readonly Lab3Service _lab3Service;

        public LabsController(Lab1Service lab1Service, Lab2Service lab2Service, Lab3Service lab3Service)
        {
            _lab1Service = lab1Service;
            _lab2Service = lab2Service;
            _lab3Service = lab3Service;
        }

        // Lab1
        public IActionResult Lab1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab1(Lab1InputModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _lab1Service.Calculate(model.N, model.K);
            return View("Lab1Result", result);
        }

        // Lab2
        public IActionResult Lab2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab2(Lab2InputModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _lab2Service.CalculateMoves(model.Direction, model.Parameter, model.Rules);
            return View("Lab2Result", result);
        }

        // Lab3
        public IActionResult Lab3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab3(Lab3InputModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = _lab3Service.CalculateShortestPaths(model.Vertices, model.Edges);
            return View("Lab3Result", result);
        }
    }
}