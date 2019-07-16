using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layouts.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// functions inside controllers are refered to as actions
        /// when u'll run a layout page will be added by default, u can delete it and make custom layout page, this is 
        /// the placre where u can add footer and header, layouts are kept in shared folder inside vieew folder,
        /// name of view inside shared folder should be like _Layout, add _ViewStart name view inside view folder that
        /// will tell from which layout it has to run, another important thing is to add render body metrhod inside 
        /// layout, this method will tell that we have to render different views inside layout, so add this method 
        /// wherever u want to put view, if controller is same for different pages then simply add view via 
        /// HomeController using ActionResult, now to lik them there are many methods but we'll discuss only 3 of them
        /// 1-a anchor tag just like html link href = "/Controller/View"
        /// 2-url action href = @url.Action("View", "Controller")
        /// 3-html action link mostly used same 3 parameter as a tag @Html.ActionLink("text", "view", "controller")
        /// when creating category view, there are 2 mostly used properties, httpget and httppost, we use get when we 
        /// have to attach any view with our action, when we have to bring something from view to controller then in 
        /// this case we may apply create, update or delete function then in such case we'll use post
        /// now lets fetch whatever is typed inside form using httppost, see modifactions done in form, to fetch 
        /// args name should match with name of fields, to see howq we can design form in mvc go to create view and see
        /// suppose u have a lot of fields then it'll not be suitable to catch them via args, we'l see alternative for 
        /// this soon
        /// </summary>
        /// <returns></returns>

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: About Us
        public ActionResult About()
        {
            return View();
        }
        // GET: Contact Us
        public ActionResult Contact()
        {
            return View();
        }
        // GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Category category)
        {
            //view to controller, currently we're using args but later we'll see better way
            //controller to view, 3 ways ViewBag, ViewData, TempData
            //ViewBag.Name = name;
            //ViewBag.Desc = description;
            WebAppDbContext db = new WebAppDbContext();
            db.tbl_Category.Add(category);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            WebAppDbContext db = new WebAppDbContext();
            var list = db.tbl_Category.ToList();
            
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            WebAppDbContext db = new WebAppDbContext();
            var category = db.tbl_Category.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(tbl_Category category)
        {
            WebAppDbContext db = new WebAppDbContext();
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}