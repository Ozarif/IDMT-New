using IDMT.Application.Features.SupportGroups.CreateSupportGroup;
using IDMT.Application.Features.SupportGroups.DeleteSupportGroup;
using IDMT.Application.Features.SupportGroups.GetListOfSupportGroups;
using IDMT.Application.Features.SupportGroups.GetSupportGroup;
using IDMT.Application.Features.SupportGroups.Shared;
using IDMT.Application.Features.SupportGroups.UpdateSupportGroup;
using IDMT.Domain.Abstractions;
using IDMT.Domain.SupportGroups;
using IDMT.Web.Models;
using IDMT.Web.ViewModels.SupportGroups;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IDMT.Web.Controllers
{
	public class SupportGroupsController : Controller
	{
		private readonly ISender _sender;
		public SupportGroupsController(ISender sender) 
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
		public async Task<IActionResult> Create(SupportGroupModel model)
		{
			if (ModelState.IsValid)
			{
				var supportGroupResponse = await _sender.Send(new CreateSupportGroupCommand(model.Name, model.Email));
				if (supportGroupResponse.IsSuccess)
				{
					TempData["success"] = $"Support group {model.Name} has been created successfully.";
					return RedirectToAction(nameof(Index));
				}
				else
				{
					TempData["error"] = $"Creating Support group {model.Name} is failed.";
					return View();
				}

			}

			return View();
		}

		public async Task<IActionResult> Edit(Guid supportGroupId)
		{
			var result = await _sender.Send(new GetSupportGroupQuery(supportGroupId));
			var supportGroupToEdit = new SupportGroupModel()
			{
				Id = result.Value.Id,
				Name = result.Value.Name,
				Email = result.Value.Email
			};
			return View(supportGroupToEdit);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(SupportGroupModel model)
		{
			if (ModelState.IsValid)
			{

				var result = await _sender.Send(new UpdateSupportGroupCommand(model.Id.Value, model.Name, model.Email));

				if (result.IsSuccess)
				{
					TempData["success"] = $"The support group {model.Name} has been updated successfully.";
					return RedirectToAction(nameof(Index));
				}

				TempData["error"] = $"Updating support group {model.Name} is failed.";
				ModelState.AddModelError("", result.Error.Name);
				return View("Edit", model);


			}

			return View("Edit", model);
		}

		public async Task<IActionResult> Delete(Guid supportGroupId)
		{
			var result = await _sender.Send(new GetSupportGroupQuery(supportGroupId));
			var supportGroupToEdit = new SupportGroupModel()
			{
				Id = result.Value.Id,
				Name = result.Value.Name,
				Email = result.Value.Email
			};
			return View(supportGroupToEdit);
		}
		[HttpPost]
		public async Task<IActionResult> Delete(SupportGroupModel model)
		{

				var result = await _sender.Send(new DeleteSupportGroupCommand(model.Id.Value));

				if (result.IsSuccess)
				{
					TempData["success"] = $"The support group {model.Name} has been deleted successfully.";
					return RedirectToAction(nameof(Index));
				}

				TempData["error"] = $"Deleting support group {model.Name} is failed.";
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

			GetSupportGroupsInPagedListQuery paginationParam = new()
			{
				PageSize = dataTableParams.PageSize,
				PageNumber = dataTableParams.Skip + 1,
				Search = dataTableParams.SearchValue,
				SortColumn = dataTableParams.SortColumn,
				SortDirection = dataTableParams.SortColumnDirection
			};


			var pagedResponse = await _sender.Send(paginationParam);

			if(pagedResponse.IsSuccess)
			{
				var supportGroupResponse = pagedResponse.Value;

				var metadata = new
				{
					supportGroupResponse.TotalCount,
					supportGroupResponse.PageSize,
					supportGroupResponse.CurrentPage,
					supportGroupResponse.TotalPages,
					supportGroupResponse.HasNext,
					supportGroupResponse.HasPrevious
				};

				return Json(new { draw = dataTableParams.Draw, recordsFiltered = supportGroupResponse.TotalCount, recordsTotal = supportGroupResponse.TotalCount, data = supportGroupResponse });
			}
		
			return Json(new { draw = dataTableParams.Draw, recordsFiltered = 0, recordsTotal = 0, data = pagedResponse.Value });
		}
	}
}
