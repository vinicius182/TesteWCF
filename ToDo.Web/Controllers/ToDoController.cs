using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Web.Models;

namespace ToDo.Web.Controllers
{
    public class ToDoController : Controller
    {
        ToDoReference.TodoServiceClient tdService = new ToDoReference.TodoServiceClient();
        public ActionResult Index()
        {
            List<Task> tkList = new List<Task>();

            var tasks = tdService.GetTasks();

            foreach (var task in tasks)
            {
                Task tk = new Task();
                tk.id = task.id;
                tk.title = task.title;

                tkList.Add(tk);
            }

            return View(tkList);
        }

        public ActionResult Details(int id)
        {
            var tdList = tdService.GetTaskById(id);
            Task tk = new Task();
            tk.id = tdList.id;
            tk.title = tdList.title;

            if (tk == null)
            {
                return HttpNotFound();
            }
            return View(tk);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task tkModel)
        {
            Task tk = new Task();
            tk.title = tkModel.title;

            tdService.AddTask(tk.title);

            return RedirectToAction("Index", "ToDo");
        }

        public ActionResult Delete(int id)
        {
            int retVal = tdService.DeleteTaskById(id);

            if(retVal > 0)
            {
                return RedirectToAction("Index", "ToDo");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var tdList = tdService.GetTaskById(id);
            Task tk = new Task();
            tk.id = tdList.id;
            tk.title = tdList.title;

            if(tk == null)
            {
                return HttpNotFound();
            }

            return View(tk);
        }

        [HttpPost]
        public ActionResult Edit(Task tkModel)
        {
            Task tk = new Task();
            tk.id = tkModel.id;
            tk.title = tkModel.title;

            int retVal = tdService.UpdateTask(tk.id, tk.title);
            if(retVal > 0)
            {
                return RedirectToAction("Index", "ToDo");
            }

            return View();
        }
    }
}