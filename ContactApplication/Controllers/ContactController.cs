using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace ContactApplication.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactsRepository _repository;

        public ContactController(IContactsRepository repository)
        {
            _repository = repository;
        }

        //[HttpGet]
        public ActionResult Index()
        {
            var contacts = _repository.GetContacts();
            return View(contacts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Contact contact, IFormFile picture)
        {
            if (picture != null && picture.Length > 0)
            {
                var fileName = Path.GetFileName(picture.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                picture.CopyTo(stream);
                contact.Picture = fileName;
            }
            _repository.AddContact(contact);
            //return View();
            return RedirectToAction("Index");
        }
    }
}
