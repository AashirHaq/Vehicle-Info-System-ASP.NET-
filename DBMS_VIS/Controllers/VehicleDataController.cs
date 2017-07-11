using DBMS_VIS.Models;
using DBMS_VIS.ViewModel.VehicleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_VIS.Controllers
{
    public class VehicleDataController : Controller
    {
        // GET: VehicleData
        public ActionResult VehicleData()
        {
            VehicleDataViewModel vdvm = new VehicleDataViewModel();
            List<AppData> ad = vdvm.GetAllData();

            return View(ad);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AppData appdata)
        {
            if (ModelState.IsValid)
            {
                VehicleDataViewModel vdm = new VehicleDataViewModel();
                vdm.AddNewRecord(appdata);

                return RedirectToAction("VehicleData");
            }
            return View();
        }

        public ActionResult Details(int Id)
        {
            VehicleDataViewModel vdm = new VehicleDataViewModel();
            AppData ad = vdm.GetVehicleDetailById(Id); 

            return View(ad);
        }

        public ActionResult Update(int Id)
        {
            VehicleDataViewModel vdm = new VehicleDataViewModel();
            AppData ad = vdm.UpdateVehicleDetailById(Id);

            return View(ad);
        }

        [HttpPost]
        public ActionResult Update(AppData appData)
        {
            if (ModelState.IsValid)
            {
                VehicleDataViewModel vdm = new VehicleDataViewModel();
                vdm.UpdateVehicleDetails(appData);

                return RedirectToAction("VehicleData");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            VehicleDataViewModel vdm = new VehicleDataViewModel();
            vdm.DeleteVehicleDetails(id);

            return RedirectToAction("VehicleData");
        }

    }
}