using Dao;
using Dao.Model;
using Dao.Repository;
using Shoes.Models;
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
        private readonly ShoesRepository ShoesRepository;
        private readonly MaterialRepository MaterialRepository;
        private readonly GroupRepository GroupRepository;
        private readonly PlaceRepository PlaceRepository;
        private readonly PersonRepository PersonRepository;
        private readonly UserRepository UserRepository;

        public HomeController()
        {
            _context = new ShoesContext();
            ShoesRepository = new ShoesRepository(_context);
            MaterialRepository = new MaterialRepository(_context);
            GroupRepository = new GroupRepository(_context);
            PlaceRepository = new PlaceRepository(_context);
            PersonRepository = new PersonRepository(_context);
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
            } else {
                ModelState.AddModelError("Name", "Имя или пароль не совпадают");
            }

            return View(user);
        }

        [AllowAnonymous]
        public ActionResult CreateBaseUser()
        {
            var mama = new User {
                Name = "Натали",
                Password = "экономика"
            };
            if (!UserRepository.ExistName(mama.Name)) {
                UserRepository.Save(mama);
            }

            var papa = new User {
                Name = "Сергей",
                Password = "ми-6"
            };
            if (!UserRepository.ExistName(papa.Name)) {
                UserRepository.Save(papa);
            }

            return RedirectToAction("Index");
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
            var materials = MaterialRepository.GetAll();
            var groups = GroupRepository.GetAll();
            var places = PlaceRepository.GetAll();
            var viewModel = new ShoesViewModel(model, materials, groups, places);
            return View(viewModel);
        }

        public ActionResult Edit(long id)
        {
            var shoes = ShoesRepository.Get(id);
            var materials = MaterialRepository.GetAll();
            var groups = GroupRepository.GetAll();
            var places = PlaceRepository.GetAll();
            var viewModel = new ShoesViewModel(shoes, materials, groups, places);
            return View("AddShoes", viewModel);
        }

        public ActionResult StaticPages()
        {
            return View();
        }

        public ActionResult AboutCollection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShoes(ShoesViewModel shoesViewModel, HttpPostedFile image)
        {
            ShoesModel shoes = shoesViewModel as ShoesModel;
            // field File always fail validationshoesViewModel
            var fieldWithError = ModelState.Count(x => x.Value.Errors.Count > 0);
            if (fieldWithError <= 1) {
                shoes = ShoesRepository.Save(shoes);
                if (Request.Files.Count > 0) {
                    var file = Request.Files[0];
                    var fileName = shoes.Id + Path.GetExtension(file.FileName);
                    if (!string.IsNullOrEmpty(file.FileName)) {
                        file.SaveAs(GetPathToImg(fileName));
                        shoes.ImageUrl = Url.Content("~/Content/img/" + fileName);
                        shoes = ShoesRepository.Save(shoes);
                    }
                }
            }

            return View(shoes);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult GenerateSeed()
        {
            var groups = new List<Group>();
            groups.Add(new Group() {
                Name = "оберег"
            });
            groups.Add(new Group() {
                Name = "статуэтка"
            });
            groups.Add(new Group() {
                Name = "копилка"
            });
            GroupRepository.Save(groups);

            var materials = new List<Material>();
            materials.Add(new Material() {
                Name = "фарфор"
            });
            materials.Add(new Material() {
                Name = "керамика"
            });
            materials.Add(new Material() {
                Name = "глина"
            });
            materials.Add(new Material() {
                Name = "пластик"
            });
            materials.Add(new Material() {
                Name = "дерево"
            });
            MaterialRepository.Save(materials);

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
