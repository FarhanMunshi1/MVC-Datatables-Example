
// this file contains all of the necessary object classes needed to
// populate a datatable. These objects will be created and sent as JSON
// to the Javascript file

public class DataTableAjaxPostModel
{
    /// <summary>
    /// Note. Properties are not capital due to json mapping
    /// </summary>
    public int draw { get; set; }
    public int start { get; set; }
    public int length { get; set; }
    public List<Column> columns { get; set; }
    public Search search { get; set; }
    public List<Order> order { get; set; }
}

// column of the table
public class Column
{
    public string data { get; set; }
    public string name { get; set; }
    public bool searchable { get; set; }
    public bool orderable { get; set; }
    public Search search { get; set; }
}

public class Order
{
    public int column { get; set; }
    public string dir { get; set; }
}

public class Search
{
    public string value { get; set; }
    public string regex { get; set; }
}

public class TemplateSearchRec
{
    public List<DatabaseObj> List { get; set; }		// rows
    public int FilteredResultsCount { get; set; }	
    public int TotalResultsCount { get; set; }
	
	// constructor
    public TemplateSearchRec()
    {
        this.List = new List<DatabaseObj>();
        FilteredResultsCount = 0;
        TotalResultsCount = 0;
    }
}
