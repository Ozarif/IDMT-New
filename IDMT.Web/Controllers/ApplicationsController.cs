//using IDMT.Web.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace IDMT.Web.Controllers
//{
//	public class ApplicationsController : IdmtBaseController
//	{
//        public ApplicationsController() : base()
//		{
				
//        }
//        public IActionResult Index()
//		{
//			return View();
//		}
//		public async Task<IActionResult> Create()
//		{
//			var supportGroupsList = await _serviceManager.SupportGroupService.GetAll(true);
//			var model = new ApplicationVM()
//			{
//				SupportGroups = supportGroupsList.Select(u => new SelectListItem
//				{
//					Text = u.Name,
//					Value = u.Id.ToString()
//				})
//			};

//			return View(model);
//		}
//		[HttpPost]
//		public async Task<IActionResult> Create(ApplicationVM model)
//		{
//			if (ModelState.IsValid)
//			{
//				await _serviceManager.ApplicationService.Create(model.Application);
//				TempData["success"] = $"Application {model.Application.Name} has been created successfully.";
//				return RedirectToAction(nameof(Index));
//			}

//			return View();
//		}

//		public async Task<IActionResult> Edit(Guid applicationId)
//		{
//			var applicationToEdit = await _serviceManager.ApplicationService.Get(applicationId);
//			var supportGroupsList = await _serviceManager.SupportGroupService.GetAll(true);

//			var model = new ApplicationVM()
//			{
//				Application = applicationToEdit,
//				SupportGroups = supportGroupsList.Select(u => new SelectListItem
//				{
//					Text = u.Name,
//					Value = u.Id.ToString()
//				})
//			};
//			return View(model);
//		}
//		[HttpPost]
//		[ValidateAntiForgeryToken]
//		public async Task<IActionResult> Update(ApplicationVM model)
//		{
//			if (ModelState.IsValid)
//			{
//				await _serviceManager.ApplicationService.Update(model.Application);
//				TempData["success"] = $"The Application {model.Application.Name} has been updated successfully.";
//				return RedirectToAction(nameof(Index));
//			}

//			return View("Edit", model);
//		}

//		public async Task<IActionResult> Delete(Guid applicationId)
//		{
//			var applicationToDelete = await _serviceManager.ApplicationService.Get(applicationId);
//			return View(applicationToDelete);
//		}
//		[HttpPost]
//		public async Task<IActionResult> Delete(ApplicationDto application)
//		{
//			await _serviceManager.ApplicationService.Delete(application.Id);
//			TempData["success"] = "The application has been deleted successfully.";
//			return RedirectToAction(nameof(Index));

//		}
//		[HttpPost]
//		public async Task<IActionResult> GetAll()
//		{

//			var dataTableParams = GetDataTableParams(Request);

//			PaginationParam paginationParam = new()
//			{
//				PageSize = dataTableParams.PageSize,
//				PageNumber = dataTableParams.Skip,
//				Search = dataTableParams.SearchValue,
//				SortColumn = dataTableParams.SortColumn,
//				SortDirection = dataTableParams.SortColumnDirection
//			};

//			paginationParam.IsActive = true;

//			var pagedResponse = await _serviceManager.ApplicationService.GetAll(paginationParam);
//			var metadata = new
//			{
//				pagedResponse.TotalCount,
//				pagedResponse.PageSize,
//				pagedResponse.CurrentPage,
//				pagedResponse.TotalPages,
//				pagedResponse.HasNext,
//				pagedResponse.HasPrevious
//			};


//			return Json(new { draw = dataTableParams.Draw, recordsFiltered = pagedResponse.TotalCount, recordsTotal = pagedResponse.TotalCount, data = pagedResponse.PagedList });
//		}
//	}
//}
