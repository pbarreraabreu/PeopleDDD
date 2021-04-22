using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.ViewModels;
using System;
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
            try
            {
                return View(await peopleAppService.GetAll());
            }
            catch(Exception)
            {
                //log here
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: PeopleController/Details/5
        public async Task<ActionResult<PeopleViewModel>> Details(int? id)
        {
            try
            {
                if (!id.HasValue) return NotFound();

                PeopleViewModel viewModel = await peopleAppService.GetById(id.Value);
                if (viewModel == null) return NotFound();

                return View(viewModel);
            }
            catch (Exception)
            {
                //log here
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: PeopleController/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                //log here
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
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
            catch(Exception)
            {
                //log here
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: PeopleController/Edit/5
        public async Task<ActionResult<PeopleViewModel>> Edit(int? id)
        {
            try
            {
                if (!id.HasValue) return NotFound();

                PeopleViewModel viewModel = await peopleAppService.GetById(id.Value);

                if (viewModel == null) return NotFound();

                return View(viewModel);
            }
            catch (Exception)
            {
                //log here
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
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
            catch (Exception)
            {
                //log here
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: PeopleController/Delete/5
        public async Task<ActionResult<PeopleViewModel>> Delete(int? id)
        {
            try
            {
                if (!id.HasValue) return NotFound();

                PeopleViewModel viewModel = await peopleAppService.GetById(id.Value);

                if (viewModel == null) return NotFound();

                return View(viewModel);
            }
            catch (Exception)
            {
                //log here
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
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
            catch (Exception)
            {
                return View();
            }
        }
    }
}
