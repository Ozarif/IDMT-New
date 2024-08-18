using IDMT.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDMT.Web.Controllers.Positions
{
    public class PositionsController : IdmtBaseController
    {
        public PositionsController(ISender sender) : base(sender)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var CreatedId = await _serviceManager.PositionService.Create(position);
        //        TempData["success"] = $"Position {position.Name} has been created successfully.";
        //        return RedirectToAction(nameof(Edit), new { positionId = CreatedId });
        //    }

        //    return View();
        //}

        //public async Task<IActionResult> Edit(Guid positionId)
        //{
        //	var positionToEdit = await _serviceManager.PositionService.Get(positionId);
        //	var activeApplicationsInDb = await _serviceManager.ApplicationService.GetAllExcludingPosition(positionId);
        //	var positionApplicationsInDb = await _serviceManager.ApplicationService.GetAllByPosition(positionId);

        //	//List<string> positionApplicationsIds = new List<string>();
        //	//if (positionApplicationsInDb is not null && positionApplicationsInDb.Count() > 0)
        //	//{

        //	//	foreach (var item in positionApplicationsInDb)
        //	//	{
        //	//		positionApplicationsIds.Add(item.Id.ToString());
        //	//	}
        //	//}



        //	var model = new EditPositionVM() {
        //		Position = positionToEdit,
        //		Applications = activeApplicationsInDb,
        //		PositionApplications = positionApplicationsInDb
        //	};

        //	return View(model);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(EditPositionVM model)
        //{
        //	//var selectedTargetItems = model.SelectedTargetItems?.Split(',').ToList() ?? new List<string>();

        //	if (ModelState.IsValid)
        //	{
        //		List<PositionApplicationDto> positionApplications = new();

        //		foreach(var app in model.SelectedApplications)
        //		{
        //			var positionApp = new PositionApplicationDto()
        //			{
        //				ApplicationId = Guid.Parse(app),
        //				PositionId = model.Position.Id
        //			};
        //			positionApplications.Add(positionApp);
        //		}
        //		model.Position.Applications = positionApplications;

        //		await _serviceManager.PositionService.Update(model.Position);
        //		TempData["success"] = $"The Position {model.Position.Name} has been updated successfully.";
        //		return RedirectToAction(nameof(Index));
        //	}

        //	return View(model);
        //}

        //public async Task<IActionResult> Delete(Guid positionId)
        //{
        //	var positionToDelete = await _serviceManager.PositionService.Get(positionId);
        //	return View(positionToDelete);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(PositionDto position)
        //{
        //	await _serviceManager.PositionService.Delete(position.Id);
        //	TempData["success"] = "The position has been deleted successfully.";
        //	return RedirectToAction(nameof(Index));

        //}


        //[HttpPost]
        //public async Task<IActionResult> GetAll()
        //{

        //	var dataTableParams = GetDataTableParams(Request);

        //	PaginationParam paginationParam = new()
        //	{
        //		PageSize = dataTableParams.PageSize,
        //		PageNumber = dataTableParams.Skip,
        //		Search = dataTableParams.SearchValue,
        //		SortColumn = dataTableParams.SortColumn,
        //		SortDirection = dataTableParams.SortColumnDirection
        //	};

        //	paginationParam.IsActive = true;

        //	var pagedResponse = await _serviceManager.PositionService.GetAll(paginationParam);
        //	var metadata = new
        //	{
        //		pagedResponse.TotalCount,
        //		pagedResponse.PageSize,
        //		pagedResponse.CurrentPage,
        //		pagedResponse.TotalPages,
        //		pagedResponse.HasNext,
        //		pagedResponse.HasPrevious
        //	};


        //	return Json(new { draw = dataTableParams.Draw, recordsFiltered = pagedResponse.TotalCount, recordsTotal = pagedResponse.TotalCount, data = pagedResponse.PagedList });
        //}
    }
}
