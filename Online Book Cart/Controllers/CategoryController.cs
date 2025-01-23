using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Book_Cart.Data;
using Online_Book_Cart.Models;

namespace Online_Book_Cart.Controllers
{
    public class CategoryController : Controller
    {
        //To make connection with databse use ApplicationDbContext
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Create Action method to show the categories view from database
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //To show create category view
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost] //To get value from webpage(Create category) and add to database
        //Create action method to get the category object value from create category page using [HttpPost]
        public IActionResult Create(Category obj) 
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name.");
            //}
            //Check if validation then add obj to database
            if(ModelState.IsValid)
            { 
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
                //Redirect to action method index in which show all categories from database
                return RedirectToAction("Index");
            }
            //If validation is false then go to same current view
            return View();
        }

        //To show create category view to edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _db.Categories.Find(id);
            //Category? categoryfromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryfromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();           
            if(categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost] //To get value from webpage(Create category) and add to database
        //Create action method to get the category object value from create category page using [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the name.");
            //}
            //Check if validation then add obj to database
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                //Redirect to action method index in which show all categories from database
                return RedirectToAction("Index");
            }
            //If validation is false then go to same current view
            return View();
        }


        //To show create category view to edit
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _db.Categories.Find(id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost,ActionName("Delete")] //To get value from webpage(Create category) and add to database
        //Create action method to get the category object value from create category page using [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

//03:40:00
