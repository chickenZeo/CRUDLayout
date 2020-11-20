using CRUDLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDLayout.Controllers
{
    public class AdminController : Controller
    {
        Sendo _db = new Sendo();
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(string userName, string pass)
        {
            var user = _db.Users.SingleOrDefault(x => x.username == userName);
            if(user != null)
            {
                if(user.password == pass)
                    return Content("<script>alert('Login successful!'); window.location.href='/Admin/ShowAll' </script>");
                return Content("<script>alert('Wrong password!'); window.location.href='/Admin/UserLogin'</script>");

            }
            return Content("<script>alert('Wrong user's name!'); window.location.href='/Admin/UserLogin'</script>");
        }
        public ActionResult ShowAll()
        {
            IEnumerable<Product> model = _db.Products.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category = _db.Categories;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid || product.id == 0)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            ViewBag.Category = _db.Categories;
            return View(product);
            
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Category = _db.Categories;
            Product product = _db.Products.SingleOrDefault(x => x.id == id);
            if (product == null) return HttpNotFound();

            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                Product pro = _db.Products.SingleOrDefault(x => x.id == product.id);
                pro.name = product.name;
                pro.imgurl = product.imgurl;
                pro.price = product.price;
                pro.description = product.description;
                pro.idcategory = product.idcategory;
                _db.SaveChanges();
                return RedirectToAction("ShowAll");
            }    
            ViewBag.Category = _db.Categories;
            return View(product);

            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Product pro = _db.Products.SingleOrDefault(x => x.id == id);
            return View(pro);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            Product product = _db.Products.SingleOrDefault(x => x.id == id);
            if (product == null) return HttpNotFound();
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("ShowAll","Admin");
        }
       
    }
}