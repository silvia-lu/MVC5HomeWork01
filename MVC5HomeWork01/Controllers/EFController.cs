using MVC5HomeWork01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HomeWork01.Controllers
{
    public class EFController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        // GET: EF
        public ActionResult Index()
        {
            var customer = db.vw_CustomerCount.Take(10);
            return View(customer);
        }
    }
}