using System.Diagnostics;
using ContactBook.Interface;
using ContactBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult AddContact(ContactBook.Entities.Contact contact)
        {
            _contactService.Add(contact);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null || contact.Id == 0)
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null || contact.Id == 0)
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactBook.Entities.Contact contact)
        {
            _contactService.Update(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}