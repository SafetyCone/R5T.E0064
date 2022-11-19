using System;


namespace R5T.E0064.W001
{
	public class TableOfContentsNodeOperations : ITableOfContentsNodeOperations
	{
		#region Infrastructure

	    public static ITableOfContentsNodeOperations Instance { get; } = new TableOfContentsNodeOperations();

	    private TableOfContentsNodeOperations()
	    {
        }

	    #endregion
	}
}