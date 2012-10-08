using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parallax.DataAccess;
using Parallax.Data.Tasks;

namespace Parallax.Web.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
		private EntityLoader EntityLoader { get; set; }
		private EntitySaver EntitySaver { get; set; }

		public ProjectController(EntityLoader entityLoader, EntitySaver entitySaver)
		{
			this.EntityLoader = entityLoader;
			this.EntitySaver = entitySaver;
		}

        public ActionResult Index(int? page)
        {
			int pageSize = 10;
			var projectList = this.EntityLoader.LoadList<Project>(page.GetValueOrDefault(1)-1, pageSize);
            return View(projectList);
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(string id)
        {
			var project = this.EntityLoader.LoadItem<Project>(id);
            return View(project);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Project/Create

        [HttpPost]
        public ActionResult Create(string projectName)
        {
            try
            {
                // TODO: Add insert logic here
				Project project = new Project();
				project.ProjectName = projectName;
				this.EntitySaver.Add(project);
				this.EntitySaver.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Project/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
