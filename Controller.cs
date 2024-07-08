
// this file represents the controller which handles the Jquery GET request, 
// grabs the data (from database or otherwise), creates the expected JSON,
// sends it to the Jquery GET call. 

using System;
using System.Web.Mvc;
using MyMVC.Models;			// replace with your namespace which encapsulates the models

namespace MyMVC.Controllers				// replace with your namespace which encapsulates the controllers
{
	public class HomeController : Controller
	{
		private ApiModel m_apiModel = new();
		
		[HttpGet]
		public JsonResult GetData(DataTableAjaxPostModel model, string searchString, int customValue)
		{
			// get data from the model class. (here a private instance of a class called "m_apiModel"
			var result = m_apiModel.GetDataForDatatable(model, searchString, customValue );
			
			// send back to Jquery as jSON
			return Json(new
			{
				draw = model.draw,
				recordsTotal = result.TotalResultsCount,
				recordsFiltered = result.FilteredResultsCount,
				data = result.ProjectCodesList,
			},
			JsonRequestBehavior.AllowGet);
		}
	}
}
