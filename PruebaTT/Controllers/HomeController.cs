using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTT.Models;
using PruebaTT.Models.Data;

namespace PruebaTT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(Singleton.Instance.facturaList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var NewFactura = new Factura
                {
                    Id = Singleton.Instance.facturaList.Count() + 1,
                    Code = Convert.ToInt32(collection["Code"]),
                    Name = collection["Name"],
                    NIT = collection["NIT"],
                    Desc = collection["Desc"],
                    Qty = Convert.ToInt32(collection["Qty"]),
                    Price = Convert.ToDecimal(collection["Price"]),
                    Total = Convert.ToDecimal(collection["Price"]) * Convert.ToDecimal(collection["Qty"]),
                    Date = DateTime.Now
                };
                Singleton.Instance.facturaList.Add(NewFactura);
                return RedirectToAction(nameof(List));
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(Singleton.Instance.facturaList.Find(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var DeleteFactura = Singleton.Instance.facturaList.Find(x => x.Id == id);
            Singleton.Instance.facturaList.RemoveAt(Singleton.Instance.facturaList.IndexOf(DeleteFactura));
            return RedirectToAction(nameof(List));
        }

        public ActionResult Edit(int id)
        {
            return View(Singleton.Instance.facturaList.Find(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var EditFactura = Singleton.Instance.facturaList.Find(x => x.Id == id);
            int i = Singleton.Instance.facturaList.IndexOf(EditFactura);
            Singleton.Instance.facturaList[i].Code = Convert.ToInt32(collection["Code"]);
            Singleton.Instance.facturaList[i].Name = collection["Name"];
            Singleton.Instance.facturaList[i].NIT = collection["NIT"];
            Singleton.Instance.facturaList[i].Desc = collection["Desc"];
            Singleton.Instance.facturaList[i].Qty = Convert.ToInt32(collection["Qty"]);
            Singleton.Instance.facturaList[i].Price = Convert.ToDecimal(collection["Price"]);
            Singleton.Instance.facturaList[i].Total = Convert.ToDecimal(collection["Price"]) * Convert.ToDecimal(collection["Qty"]);
            return RedirectToAction(nameof(List));
        }

        public ActionResult Details(int id)
        {
            return View(Singleton.Instance.facturaList.Find(x => x.Id == id));
        }
    }
}