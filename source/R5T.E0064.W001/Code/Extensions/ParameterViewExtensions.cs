using System;

using Microsoft.AspNetCore.Components;


namespace R5T.E0064.W001
{
    public static class ParameterViewExtensions
    {
        public static void WriteAllNamesToConsole(this ParameterView parameters)
        {
            ParameterViewOperator.Instance.WriteAllNamesToConsole(parameters);
        }

        public static void WriteAllToConsole(this ParameterView parameters)
        {
            ParameterViewOperator.Instance.WriteAllToConsole(parameters);
        }
    }
}
