using IDMT.Application.Features.Employees.GetListOfEmployees;
using IDMT.Application.Features.HrJobs.CreateHrJob;
using IDMT.Application.Features.HrJobs.DeleteHrJob;
using IDMT.Application.Features.HrJobs.GetHrJob;
using IDMT.Application.Features.HrJobs.GetListOfHrJobs;
using IDMT.Application.Features.HrJobs.UpdateHrJob;
using IDMT.Application.Features.SupportGroups.CreateSupportGroup;
using IDMT.Application.Features.SupportGroups.DeleteSupportGroup;
using IDMT.Application.Features.SupportGroups.GetListOfSupportGroups;
using IDMT.Application.Features.SupportGroups.GetSupportGroup;
using IDMT.Application.Features.SupportGroups.UpdateSupportGroup;
using IDMT.Web.Models;
using IDMT.Web.ViewModels.HrJobs;
using IDMT.Web.ViewModels.SupportGroups;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDMT.Web.Controllers.HrJobs
{
	public class HrJobsController : Controller
	{
		private readonly ISender _sender;

		public HrJobsController(ISender sender)
		{
			_sender = sender;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(HrJobModel model)
		{
			if (ModelState.IsValid)
			{
				var hrJobResponse = await _sender.Send(new CreateHrJobCommand(model.Name));
				if (hrJobResponse.IsSuccess)
				{
					TempData["success"] = $"HR job {model.Name} has been created successfully.";
					return RedirectToAction(nameof(Index));
				}
				else
				{
					TempData["error"] = $"Creating HR job {model.Name} is failed. {hrJobResponse.Error.Name}";
					return View();
				}

			}

			return View();
		}

		public async Task<IActionResult> Edit(Guid hrJobId)
		{
			var result = await _sender.Send(new GetHrJobQuery(hrJobId));
			var hrJobToEdit = new HrJobModel()
			{
				Id = result.Value.Id,
				Name = result.Value.Name
			};
			return View(hrJobToEdit);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(HrJobModel model)
		{
			if (ModelState.IsValid)
			{

				var result = await _sender.Send(new UpdateHrJobCommand(model.Id.Value,model.Name));

				if (result.IsSuccess)
				{
					TempData["success"] = $"The HR job {model.Name} has been updated successfully.";
					return RedirectToAction(nameof(Index));
				}

				TempData["error"] = $"Updating HR job {model.Name} is failed.";
				ModelState.AddModelError("", result.Error.Name);
				return View("Edit", model);


			}

			return View("Edit", model);
		}

		public async Task<IActionResult> Delete(Guid hrJobId)
		{
			var result = await _sender.Send(new GetHrJobQuery(hrJobId));
			var hrJobToEdit = new HrJobModel()
			{
				Id = result.Value.Id,
				Name = result.Value.Name
			};
			return View(hrJobToEdit);
		}
		[HttpPost]
		public async Task<IActionResult> Delete(HrJobModel model)
		{

			var result = await _sender.Send(new DeleteHrJobCommand(model.Id.Value));

			if (result.IsSuccess)
			{
				TempData["success"] = $"The HR job {model.Name} has been deleted successfully.";
				return RedirectToAction(nameof(Index));
			}

			TempData["error"] = $"Deleting HR job {model.Name} is failed.";
			ModelState.AddModelError("", result.Error.Name);
			return View("Delete", model);
		}

		protected DataTableParam GetDataTableParams(HttpRequest request)
		{
			return new()
			{
				Draw = Request.Form["draw"].FirstOrDefault(),
				PageSize = int.Parse(Request.Form["length"]),
				Skip = int.Parse(Request.Form["start"]),
				SearchValue = Request.Form["search[value]"],
				SortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")],
				SortColumnDirection = Request.Form["order[0][dir]"]
			};
		}

		[HttpPost]
		public async Task<IActionResult> GetAll()
		{

			var dataTableParams = GetDataTableParams(Request);

			GetHrJobsInPagedListQuery paginationParam = new()
			{
				PageSize = dataTableParams.PageSize,
				PageNumber = dataTableParams.Skip + 1,
				Search = dataTableParams.SearchValue,
				SortColumn = dataTableParams.SortColumn,
				SortDirection = dataTableParams.SortColumnDirection
			};

	var pagedResponse = await _sender.Send(paginationParam);


			if (pagedResponse.IsSuccess)
			{
				var hrJobResponse = pagedResponse.Value;

				var metadata = new
				{
					hrJobResponse.TotalCount,
					hrJobResponse.PageSize,
					hrJobResponse.CurrentPage,
					hrJobResponse.TotalPages,
					hrJobResponse.HasNext,
					hrJobResponse.HasPrevious
				};

				return Json(new { draw = dataTableParams.Draw, recordsFiltered = hrJobResponse.TotalCount, recordsTotal = hrJobResponse.TotalCount, data = hrJobResponse });
			}

			return Json(new { draw = dataTableParams.Draw, recordsFiltered = 0, recordsTotal = 0, data = pagedResponse.Value });
		}
	}
}
