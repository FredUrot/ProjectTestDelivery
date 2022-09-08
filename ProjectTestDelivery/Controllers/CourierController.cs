using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTestDelivery.Models;
namespace ProjectTestDelivery.Controllers
{
    public class CourierController : Controller
    {

        readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        // GET: CourierController
        public ActionResult Index()
        {
            List<Courier> courierList = dbContext.GetAllCouriers().ToList();
            return View(courierList);
        }

        // GET: CourierController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0) return NotFound();
            Courier courier = dbContext.GetCourier(id);
            courier.ItemList = new List<Item>();
            courier.ItemList = dbContext.GetAllItems().Where(i => i.CourierId == id || i.CourierId == null || i.CourierId == 0 ).ToList();
            if (courier == null)
            {
                return NotFound();
            }
            return View(courier);
        }

        // GET: CourierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Courier courier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateCourier(courier);
                    return Redirect("Index");
                }

                return View(courier);
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View();
            }
        }

        // GET: CourierController/Edit/5
        public ActionResult Edit(int id, int? courierId)
        {
            if (id <= 0) return NotFound();
            Courier courier = dbContext.GetCourier(id);
            if (courier == null)
            {
                return NotFound();
            }
            return View(courier);
        }

        // POST: CourierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Courier courier)
        {
            if (id <= 0) return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.UpdateCourier(courier);
                    return RedirectToAction(nameof(Index));
                }

                return View(dbContext);
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View();
            }
        }

        // GET: CourierController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0) return NotFound();
            Courier courier = dbContext.GetCourier(id);
            if (courier == null)
            {
                return NotFound();
            }
            return View(courier);
        }

        // POST: CourierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Courier courier)
        {
            try
            {
                dbContext.DeleteCourier(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View();
            }
        }

        public ActionResult AssignToCourier(int courierId=0, int itemId=0)
        {

            try
            {
                dbContext.AssignToCourier(itemId, courierId);
                return RedirectToAction("Details", new {id= courierId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Something went wrong.";
                return View(ViewBag.ErrorMessage);
            }
        }

    }
}
