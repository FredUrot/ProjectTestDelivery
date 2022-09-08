using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjectTestDelivery.Models;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace ProjectTestDelivery.Controllers
{
    public class ItemController : Controller
    {
        readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        private readonly IWebHostEnvironment _hostEnvironment;

        public ItemController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }

        // GET: ItemController
        public ActionResult Index(ItemVM? itemVM)
        {
            if (itemVM == null)
            {
                itemVM = new ItemVM();
            }

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string path = wwwRootPath + "/Files/";
            string httpPath = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/Files/";
            List<Item> itemList = dbContext.GetAllItems().ToList();
            if (!string.IsNullOrEmpty(itemVM.searchCustomerName))
            {
                itemList = itemList.Where(s => s.Customer.LastName.ToLower().Replace(" ","").Contains(itemVM.searchCustomerName.ToLower().Replace(" ", ""))
                                       || s.Customer.FirstName.ToLower().Replace(" ", "").Contains(itemVM.searchCustomerName.ToLower().Replace(" ", ""))).ToList();
            }

            if (!string.IsNullOrEmpty(itemVM.searchCourierName))
            {
                itemList = itemList.Where(s => s.Courier.LastName.ToLower().Replace(" ", "").Contains(itemVM.searchCourierName.ToLower().Replace(" ", ""))
                                       || s.Courier.FirstName.ToLower().Replace(" ", "").Contains(itemVM.searchCourierName.ToLower().Replace(" ", ""))).ToList();
            }

            if (itemVM.status != null)
            {
                itemList = itemList.Where(s => s.StatusType == itemVM.status).ToList();
            }

            if (itemVM.searchByDate != null) {
                itemList = itemList.Where(s => s.CreatedDate.Date == itemVM.searchByDate).ToList();
            }
            itemVM.itemList = itemList;

            return View(itemVM);
        }

        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0) return NotFound();
            Item item = dbContext.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // GET: ItemController/Create
        public ActionResult Create(int? customerId, int? CourierId)
        {
            var item = new Item();
            item.CourierId = CourierId;
            item.CustomerId = customerId;
            item.AssignedCourier = new List<SelectListItem>();
            item.Owner = new List<SelectListItem>();
            List<Courier> courierList = dbContext.GetAllCouriers().ToList();
            
            foreach (var courier in courierList)
            {
                item.AssignedCourier.Add(new SelectListItem { 
                    Text = courier.FirstName + ' ' + courier.LastName,
                    Value = courier.CourierId.ToString()
                });
            }

            List<Customer> customerList = dbContext.GetAllCustomers().ToList();

            foreach (var customer in customerList)
            {
                item.Owner.Add(new SelectListItem
                {
                    Text = customer.FirstName + ' ' + customer.LastName,
                    Value = customer.CustomerId.ToString()
                });
            }

            return View(item);
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (item.ProofFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(item.ProofFile.FileName);
                        string extension = Path.GetExtension(item.ProofFile.FileName);
                        item.ProofName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Files/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await item.ProofFile.CopyToAsync(fileStream);
                        }
                    }

                    dbContext.CreateItem(item);

                    return Redirect("Index");
                }

                return View(item);
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View();
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id, int? courierId)
        {
            if (id <= 0) return NotFound();
            Item item = dbContext.GetItem(id);
            item.AssignedCourier = new List<SelectListItem>();
            item.Owner = new List<SelectListItem>();
            List<Courier> courierList = dbContext.GetAllCouriers().ToList();
            
            foreach (var courier in courierList)
            {
                item.AssignedCourier.Add(new SelectListItem
                {
                    Text = courier.FirstName + ' ' + courier.LastName,
                    Value = courier.CourierId.ToString()
                });
            }

            List<Customer> customerList = dbContext.GetAllCustomers().ToList();
            
            foreach (var customer in customerList)
            {
                item.Owner.Add(new SelectListItem
                {
                    Text = customer.FirstName + ' ' + customer.LastName,
                    Value = customer.CustomerId.ToString()
                });
            }
            if (item == null)
            {
                return NotFound();
            }
            item.StatusType = courierId != null ? 1 : item.StatusType;
            ViewBag.MarkAsDelivered = courierId != null ? true : false;
            return View(item);
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Item item)
        {
            if(id <= 0) return NotFound();
            item.AssignedCourier = new List<SelectListItem>();
            item.Owner = new List<SelectListItem>();
            List<Courier> courierList = dbContext.GetAllCouriers().ToList();

            foreach (var courier in courierList)
            {
                item.AssignedCourier.Add(new SelectListItem
                {
                    Text = courier.FirstName + ' ' + courier.LastName,
                    Value = courier.CourierId.ToString()
                });
            }

            List<Customer> customerList = dbContext.GetAllCustomers().ToList();

            foreach (var customer in customerList)
            {
                item.Owner.Add(new SelectListItem
                {
                    Text = customer.FirstName + ' ' + customer.LastName,
                    Value = customer.CustomerId.ToString()
                });
            }
            try
            {
                if (ModelState.IsValid)
                {
                    if (item.ProofFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(item.ProofFile.FileName);
                        string extension = Path.GetExtension(item.ProofFile.FileName);
                        item.ProofName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Files/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await item.ProofFile.CopyToAsync(fileStream);
                        }
                    }

                    dbContext.UpdateItem(item);
                    return RedirectToAction(nameof(Index));
                }

                return View(item);
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View(item);
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0) return NotFound();
            Item item = dbContext.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Item item)
        {
            if (id <= 0) return NotFound();
            try
            {
                dbContext.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMsg = "Something went wrong.";
                return View(item);
            }
        }

        public ActionResult DownloadFile(string fileName)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(fileName)) return NotFound();
            string path = Path.Combine(wwwRootPath + "/Files/", fileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
