using IDMT.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IDMT.Web.Controllers
{
	public abstract class IdmtBaseController : Controller
	{

		protected readonly ISender _sender;
		protected IdmtBaseController(ISender sender)
		{
			_sender = sender;
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
	}
}
