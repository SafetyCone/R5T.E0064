using System;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using R5T.T0132;


namespace R5T.E0064.W001
{
	[DraftFunctionalityMarker]
	public partial interface IParameterViewOperator : IDraftFunctionalityMarker
	{
		public void WriteAllNamesToConsole(
			ParameterView parameters)
		{
			foreach (var parameter in parameters)
			{
				Console.WriteLine(parameter.Name);
			}
		}

        public void WriteAllToConsole(
            ParameterView parameters)
        {
            foreach (var parameter in parameters)
            {
                Console.WriteLine($"{parameter.Name}: {parameter.Value} (cascading: {parameter.Cascading })");
            }
        }
    }
}