
// this file represents a model class. In this example used to get data from database
// based on settings requested by Jquery and return a SearchRec which contains all rows 

namespace MyMVC.Models
{
	public class ApiModel
	{
		internal TemplateSearchRec GetDataForDatatable(DataTableAjaxPostModel model, string searchString, int customValue)
		{
			var result = new TemplateSearchRec();
		
			try
			{
				int frc;
				int trc;
		
				//var searchBy = (model.search != null) ? model.search.value : null;
				var take = model.length;
				var skip = model.start;
		
				string sortBy = "";
				bool sortDir = true;
		
				if (model.order != null)
				{
					// in this example we just default sort on the 1st column
					sortBy = model.columns[model.order[0].column].data;
		
					if (model.order[0].dir == null)
					{
						sortDir = true;
					}
					else
					{
						sortDir = model.order[0].dir.ToLower() == "asc";
					}
				}
				var list = GetDataFromDatabase(take, skip, searchString, out frc, out trc, customValue);
		
				foreach (var data in list)
				{
					// Add to result a simple remapping adding extra info to found dataset
					result.List.Add(data);
				};
		
				result.FilteredResultsCount = frc;
				result.TotalResultsCount = trc;
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.WriteLine($"error : {exc.Message} ");
			}
			return result;
		}
		
		private List<DatabaseObj> GetDataFromDatabase(int take, int skip, string searchString, out int frc, out int trc, int customValue)
		{
			var result = new List<DatabaseObj>();
			
			// connect to your database and query using LINQ. My example looks similar to this
			// although yours could look very different depending on how your getting data from database
			
			/*   result = YourDatabaseConnection.Query<DatabaseObj>
					.Take(skip, take)
					.Where(p => p.Field.Contains(searchString) && p.Field == customValue)
					.ToList();
				
				frc = YourDatabaseConnection.Query<DatabaseObj>
					.Take(skip, take)
					.Where(p => p.Field.Contains(searchString) && p.Field == customValue)
					.GetCount();
					
				trc = YourDatabaseConnection.Query<DatabaseObj>()
					.GetCount();
			*/
			
			return result;
		}
	}
}
