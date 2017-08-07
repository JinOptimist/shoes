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
            var shoes = ShoesRepository.GetAll().Where(x => x.IsPublic || User.Identity.IsAuthenticated)
                .OrderBy(x => x.OldIdLvl2).OrderBy(x => x.OldId).ToList();
            var materials = MaterialRepository.GetAll();
            var groups = GroupRepository.GetAll();
            var places = PlaceRepository.GetAll();
            var givers = PersonRepository.GetAll();
            var viewModel = new IndexViewModel(shoes, materials, groups, places, givers);
            return View(viewModel);
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

        /* ------------ Shoes ------------ */
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
            var givers = PersonRepository.GetAll();
            var viewModel = new ShoesViewModel(model, materials, groups, places, givers);
            viewModel.Width = 1;
            viewModel.Height = 1;
            viewModel.NumberOfDuplication = 1;

            return View(viewModel);
        }

        public ActionResult Edit(long id)
        {
            var shoes = ShoesRepository.Get(id);
            var materials = MaterialRepository.GetAll();
            var groups = GroupRepository.GetAll();
            var places = PlaceRepository.GetAll();
            var givers = PersonRepository.GetAll();
            var viewModel = new ShoesViewModel(shoes, materials, groups, places, givers);
            return View("AddShoes", viewModel);
        }

        [HttpPost]
        public ActionResult AddShoes(ShoesViewModel shoesViewModel, HttpPostedFile image)
        {
            var isOldIdUniq = ShoesRepository.IsOldIdUniq(shoesViewModel);
            if (isOldIdUniq)
                ModelState.AddModelError("OldId", "Туфелька с номером " + shoesViewModel.OldId + " уже сущесвтует");
            var modelHasError = ModelState.Where(x => x.Key != "image").Any(x => x.Value.Errors.Count > 0);
            if (!modelHasError) {
                var shoes = ShoesRepository.Get(shoesViewModel.Id);
                if (shoes == null)
                    shoes = new ShoesModel();
                shoesViewModel.UpdateModel(shoes);
                shoes.Material = MaterialRepository.Get(shoesViewModel.DropDowns.MaterialId);
                shoes.Group = GroupRepository.Get(shoesViewModel.DropDowns.GroupId);                
                shoes.Giver = PersonRepository.Get(shoesViewModel.DropDowns.GiverId);
                shoes.PlaceOfBuying = PlaceRepository.Get(shoesViewModel.DropDowns.PlaceOfBuyingId);

                if (shoesViewModel.DateOfPurchaseHasFullValue) {
                    shoes.YearOfPurchase = shoes.DateOfPurchase?.Year;                    
                } else {
                    shoes.DateOfPurchase = null;
                }
                if (shoesViewModel.DateOfCreatingHasFullValue) {
                    shoes.YearOfCreating = shoes.DateOfCreating?.Year;
                } else {
                    shoes.DateOfCreating = null;
                }

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

                return RedirectToAction("Index");
            }

            var materials = MaterialRepository.GetAll();
            var groups = GroupRepository.GetAll();
            var places = PlaceRepository.GetAll();
            var givers = PersonRepository.GetAll();
            shoesViewModel.DropDowns = new ListOfDropDown(materials, groups, places, givers, shoesViewModel);

            return View(shoesViewModel);
        }

        /* ------------ Material ------------ */
        public ActionResult Materials()
        {
            var models = MaterialRepository.GetAll();
            return View(models);
        }

        public JsonResult UpdateMaterial(long id, string text)
        {
            var model = MaterialRepository.Get(id);
            if (model == null) {
                model = new Material();
            }
            model.Name = text;
            MaterialRepository.Save(model);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveMaterial(long id)
        {
            MaterialRepository.Remove(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /* ------------ Group ------------ */
        public ActionResult Groups()
        {
            var models = GroupRepository.GetAll();
            return View(models);
        }

        public JsonResult UpdateGroup(long id, string text)
        {
            var model = GroupRepository.Get(id);
            if (model == null) {
                model = new Group();
            }
            model.Name = text;
            GroupRepository.Save(model);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveGroup(long id)
        {
            GroupRepository.Remove(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /* ------------ Place ------------ */
        public ActionResult Places()
        {
            var models = PlaceRepository.GetAll();
            return View(models);
        }

        public JsonResult UpdatePlace(long id, string countryName, string cityName)
        {
            var model = PlaceRepository.Get(id);
            if (model == null) {
                model = new Place();
            }

            model.CountryName = countryName;
            model.CityName = cityName;
            PlaceRepository.Save(model);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemovePlace(long id)
        {
            PlaceRepository.Remove(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        
        /* ------------ Person ------------ */
        public ActionResult Persons()
        {
            var models = PersonRepository.GetAll();
            return View(models);
        }

        public JsonResult UpdatePerson(long id, string lastName, string firstName)
        {
            var model = PersonRepository.Get(id);
            if (model == null) {
                model = new Person();
            }

            model.FirstName = firstName;
            model.LastName = lastName;
            PersonRepository.Save(model);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemovePerson(long id)
        {
            PersonRepository.Remove(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        /* ------------ StaticPages ------------ */
        public ActionResult StaticPages()
        {
            return View();
        }

        public ActionResult AboutCollection()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        /* ------------ Generate data ------------ */
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

        public ActionResult GenerateSeed()
        {
            var groups = new List<Group>();
            groups.Add(new Group() {
                Name = "---"
            });
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
                Name = "---"
            });
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

        public JsonResult UpdateYear()
        {
            var shoeses = ShoesRepository.GetAll();
            foreach(var shoes in shoeses) {
                shoes.YearOfCreating = shoes.DateOfCreating?.Year;
                shoes.YearOfPurchase = shoes.DateOfPurchase?.Year;
            }

            ShoesRepository.Save(shoeses);
            return Json(true, JsonRequestBehavior.AllowGet);
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
