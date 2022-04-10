
using ByteXecom.DataAccess;
using ByteXecom.DataAccess.Repository.IRepository;
using ByteXecom.Models;
using Microsoft.AspNetCore.Mvc;

namespace ByteXecomWeb.Controllers
{
    [Area("Administrator")]
    public class ProductBrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductBrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IList<ProductBrand> objList = _unitOfWork.ProductBrand.GetAll();
            return View(objList);
        }

        //GET Action
        public IActionResult Create()
        {
            return View();
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductBrand obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductBrand.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Brand Created Successfully";
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
            var productBrandFromDbFirst = _unitOfWork.ProductBrand.GetFirstOrDefault(u => u.Id == id);
            if(productBrandFromDbFirst == null)
            {
                return NotFound();
            }
            return View(productBrandFromDbFirst);
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductBrand obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ProductBrand.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Brand Updated Successfully";
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
            var productBrandFromDbFirst = _unitOfWork.ProductBrand.GetFirstOrDefault(u => u.Id == id);
            if (productBrandFromDbFirst == null)
            {
                return NotFound();
            }
            return View(productBrandFromDbFirst);
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var productBrandFromDbFirst = _unitOfWork.ProductBrand.GetFirstOrDefault(u => u.Id == id);
            if (productBrandFromDbFirst == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductBrand.Remove(productBrandFromDbFirst);
            _unitOfWork.Save();
            TempData["success"] = "Product Brand Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
