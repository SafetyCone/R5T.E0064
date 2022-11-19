using System;


namespace R5T.E0064.W001
{
	public class ParameterViewOperator : IParameterViewOperator
	{
		#region Infrastructure

	    public static IParameterViewOperator Instance { get; } = new ParameterViewOperator();

	    private ParameterViewOperator()
	    {
        }

	    #endregion
	}
}