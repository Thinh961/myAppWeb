using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;

namespace MyAppWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.categories = _unitOfWork.Category.GetAll();
            return View(categoryVM);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Category.Add(category);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Category created done!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
        //}

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM categoryVm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(categoryVm);
            }
            else
            {
                categoryVm.Category = _unitOfWork.Category.GetT(x => x.Id == id);
                if (categoryVm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(categoryVm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                if(categoryVM.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(categoryVM.Category);
                    TempData["success"] = "Category created done!";
                }
                else
                {
                    _unitOfWork.Category.Update(categoryVM.Category);
                    TempData["success"] = "Category updated done!";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetT(X => X.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitOfWork.Category.GetT(X => X.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted done!";
            return RedirectToAction("Index");
        }
    }
}
