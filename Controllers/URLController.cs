using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webdev.Interfaces;
using webdev.Models;

namespace webdev.Controllers
{
    public class URLController : Controller
    {
        private IURLsRepository _repository;
        
        public URLController(IURLsRepository URLsRepository)
        {
            _repository = URLsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var URLs = _repository.GetURLs();
            return View(URLs);
        }

        [HttpPost]
        public IActionResult Create(URL URL)
        {
            _repository.AddURL(URL);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(URL URL)
        {
            _repository.Delete(URL);
            return Redirect("Index");
        }


        [HttpGet]
        public IActionResult Edit(URL URL) 
        {
            return View(URL);
        }
        
        [HttpPost]
        public IActionResult Update(URL URL) 
        {
            _repository.Update(URL);
            return Redirect("Index");
        }
    }
}