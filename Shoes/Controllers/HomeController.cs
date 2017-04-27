using Dao;
using Dao.Model;
using Dao.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShoesModel = Dao.Model.Shoes;

namespace Shoes.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ShoesContext _context = new ShoesContext();
        public ShoesRepository ShoesRepository { get; set; }
        public UserRepository UserRepository { get; set; }

        public HomeController()
        {
            _context = new ShoesContext();
            ShoesRepository = new ShoesRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var models = ShoesRepository.GetAll();
            return View(models);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            user = UserRepository.Login(user);
            if (user != null) {
                FormsAuthentication.SetAuthCookie(user.Name, true);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Remove(long id)
        {
            var shoes = ShoesRepository.Get(id);
            var path = Server.MapPath(shoes.ImageUrl);
            ShoesRepository.Remove(id);
            System.IO.File.Delete(path);
            
            return RedirectToAction("Index");
        }

        public ActionResult AddShoes()
        {
            var model = new ShoesModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddShoes(ShoesModel shoes, HttpPostedFile image)
        {
            if (ModelState.IsValid) {
                shoes = ShoesRepository.Save(shoes);
                if (Request.Files.Count > 0) {
                    var file = Request.Files[0];
                    var fileName = shoes.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(GetPathToImg(fileName));
                    shoes.ImageUrl = Url.Content("~/Content/img/" + fileName);
                    shoes = ShoesRepository.Save(shoes);
                }
            }

            return View(shoes);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        private string GetPathToImg(string fileName)
        {
            var serverPath = Server.MapPath("~");
            return Path.Combine(serverPath, "Content", "img", fileName);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
