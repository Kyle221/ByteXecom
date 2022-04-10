
using ByteXecom.DataAccess;
using ByteXecom.DataAccess.Repository.IRepository;
using ByteXecom.Models;
using Microsoft.AspNetCore.Mvc;

namespace ByteXecomWeb.Controllers
{
    [Area("Administrator")]
    public class ProductCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IList<ProductCategory> objCategoryList = _unitOfWork.ProductCategory.GetAll();
            return View(objCategoryList);
        }

        //GET Action
        public IActionResult Create()
        {
            return View();
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategory obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductCategory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Action
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //var productCategoryReturned = _db.ProductCategories.Find(id);
            var productCategoryFromDbFirst = _unitOfWork.ProductCategory.GetFirstOrDefault(u => u.Id == id);
            if(productCategoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(productCategoryFromDbFirst);
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategory obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductCategory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Action
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var productCategoryReturned = _db.ProductCategories.Find(id);
            var productCategoryFromDbFirst = _unitOfWork.ProductCategory.GetFirstOrDefault(u => u.Id == id);
            if (productCategoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(productCategoryFromDbFirst);
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var productCategoryFromDbFirst = _unitOfWork.ProductCategory.GetFirstOrDefault(u => u.Id == id);
            if (productCategoryFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductCategory.Remove(productCategoryFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Product Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
