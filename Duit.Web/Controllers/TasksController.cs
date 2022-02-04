using Duit.DAL;
using Duit.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Duit.Web.Controllers
{
    public class TasksController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        public TasksController(ILogger<HomeController> logger, DuitContext context) : base(context)
        {
            _logger = logger;
        }

        // GET: TasksController
        public ActionResult Index()
        {

            Context.SeedData();

            var toDoTasks = Context.Tasks.ToList();
            return View(toDoTasks);
        }


        // GET: TasksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TasksController/Create
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

        // GET: TasksController/Details/5
        public ActionResult Details(int id)
        {
            var task = Context.Tasks.SingleOrDefault(t => t.Id == id);
            return View(task);
        }

        // GET: TasksController/Edit/5
        public ActionResult Edit(int id)
        {
            var task = Context.Tasks.SingleOrDefault(t => t.Id == id);
            return View(task);
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDosTask task)
        {
            try
            {
                Context.Tasks.Attach(task).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: TasksController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var task = Context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            Context.Tasks.Remove(task);
            Context.SaveChanges();
            return Ok();
        }
    }
}
