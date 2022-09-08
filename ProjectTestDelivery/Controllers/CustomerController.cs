using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTestDelivery.Models;

namespace ProjectTestDelivery.Controllers
{
    public class CustomerController : Controller
    {
        readonly ApplicationDbContext dbContext = new ApplicationDbContext();
         
        // GET: CustomerController
        public ActionResult Index()
        {
            List<Customer> customerList = dbContext.GetAllCustomers().ToList();
            return View(customerList);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0) return NotFound();
            Customer customer = dbContext.GetCustomer(id);
            customer.ItemList = new List<Item>();
            customer.ItemList = dbContext.GetAllItems().Where(i => i.CustomerId == id).ToList();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
            
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateCustomer(customer);
                    return Redirect("Index");
                }

                return View(customer);
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0) return NotFound();
            Customer customer = dbContext.GetCustomer(id);
            if (customer == null) 
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            if (id <= 0) return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.UpdateCustomer(customer);
                    return RedirectToAction(nameof(Index));
                }

                return View(customer);
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View(customer);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0) return NotFound();
            Customer customer = dbContext.GetCustomer(id);
            if (customer == null) 
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                dbContext.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View();
            }
        }
    }
}
