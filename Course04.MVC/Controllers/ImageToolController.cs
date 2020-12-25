using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course04.Model.ImageTool;
using System.IO;

namespace Course04.MVC.Controllers
{
    public class ImageToolController : Controller
    {
        // GET: ImageToolController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImageToolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImageToolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageToolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Image64()
        {
           
            return View();
        }

        public JsonResult ResponseImage([FromForm] IFormFileCollection formFiles) 
        {
            var FILE = Request.Form.Files;
            return Json("");
        } 

        // GET: ImageToolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImageToolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageToolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImageToolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
