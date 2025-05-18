using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class InfirmierController : Controller
    {
        IServiceInfirmier si;
        IServiceLaboratoire sl;

        public InfirmierController(IServiceInfirmier si, IServiceLaboratoire sl)
        {
            this.si = si;
            this.sl = sl;
        }

        // GET: InfirmierController
        public ActionResult Index()
        {
            return View(si.GetMany());
        }
        // GET: Infirmier/Patient/5
        public ActionResult Patient(int id)
        {
            var infirmier = si.GetById(id);
            if (infirmier == null)
            {
                return NotFound();
            }

            var patients = (infirmier.Bilans ?? new List<Bilan>())
                .Select(b => b.Patient)
                .Where(p => p != null)
                .Distinct()
                .ToList();

            return View(patients);
        }



        // GET: InfirmierController/Details/5
        public ActionResult Details(int id)
        {
            return View(si.GetById(id));
        }

        // GET: InfirmierController/Create
        public ActionResult Create()
        {
            ViewBag.lsLabo = new SelectList(sl.GetMany(), "LaboratoireId", "Intitule");
            return View();
        }

        // POST: InfirmierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Infirmier collection)
        {
            try
            {
                si.Add(collection);
                si.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InfirmierController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.lsLabo = new SelectList(sl.GetMany(), "LaboratoireId", "Intitule");

            return View(si.GetById(id));
        }

        // POST: InfirmierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Infirmier collection)
        {
            try
            {
                si.Update(collection);
                si.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InfirmierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(si.GetById(id));
        }

        // POST: InfirmierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Infirmier collection)
        {
            try
            {
                si.Delete(si.GetById(id));
                si.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
