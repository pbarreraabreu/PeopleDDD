using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.ViewModels;
using System.Threading.Tasks;

namespace PeopleDDD.UI.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleAppService peopleAppService;

        public PeopleController(IPeopleAppService peopleAppService)
        {
            this.peopleAppService = peopleAppService;
        }

        // GET: PeopleController
        public async Task<IActionResult> Index()
        {
            return View(await peopleAppService.GetAll());
        }

        // GET: PeopleController/Details/5
        public async Task<ActionResult<PeopleViewModel>> Details(int? id)
        {
            if (!id.HasValue) return NotFound();

            PeopleViewModel viewModel = await peopleAppService.GetById(id.Value);

            if (viewModel == null) return NotFound();

            return View(viewModel);
        }

        // GET: PeopleController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PeopleViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(viewModel);
                await peopleAppService.Register(viewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Edit/5
        public async Task<ActionResult<PeopleViewModel>> Edit(int? id)
        {
            if (!id.HasValue) return NotFound();

            PeopleViewModel viewModel = await peopleAppService.GetById(id.Value);

            if (viewModel == null) return NotFound();

            return View(viewModel);
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PeopleViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(viewModel);

                await peopleAppService.Update(viewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Delete/5
        public async Task<ActionResult<PeopleViewModel>> Delete(int? id)
        {
            if (!id.HasValue) return NotFound();

            PeopleViewModel viewModel = await peopleAppService.GetById(id.Value);

            if (viewModel == null) return NotFound();

            return View(viewModel);
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await peopleAppService.Remove(id);
                ViewBag.Sucesso = "Customer Removed!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
