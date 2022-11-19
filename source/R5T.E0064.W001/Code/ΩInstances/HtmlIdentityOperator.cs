using System;


namespace R5T.E0064.W001
{
	public class HtmlIdentityOperator : IHtmlIdentityOperator
	{
		#region Infrastructure

	    public static IHtmlIdentityOperator Instance { get; } = new HtmlIdentityOperator();

	    private HtmlIdentityOperator()
	    {
        }

	    #endregion
	}
}