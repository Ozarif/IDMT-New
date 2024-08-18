//using Azure.Core;
//using IDMT.Application.Features.Implementations;
//using IDMT.Application.Features.Interfaces;
//using IDMT.Application.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace IDMT.Web.Controllers
//{
//	public class EmployeesController : IdmtBaseController
//	{
//		public EmployeesController(IServiceManager serviceManager) : base(serviceManager)
//		{}

//		public IActionResult Index()
//		{
//			return View();
//		}

//		public IActionResult Create()
//		{
//			return View();
//		}
//		public IActionResult Edit(string employeeId)
//		{
//			return View();
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

//			var pagedResponse = await _serviceManager.EmployeeService.GetAll(paginationParam);
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