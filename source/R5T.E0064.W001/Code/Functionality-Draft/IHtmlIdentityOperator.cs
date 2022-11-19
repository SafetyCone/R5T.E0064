using System;

using R5T.T0132;


namespace R5T.E0064.W001
{
	[DraftFunctionalityMarker]
	public partial interface IHtmlIdentityOperator : IDraftFunctionalityMarker
	{
        /// <summary>
        /// Gets the identity 
        /// </summary>
        /// <remarks>
        /// ID and NAME tokens must begin with a letter ([A-Za-z]) and may be followed by any number of letters, digits ([0-9]), hyphens ("-"), underscores ("_"), colons (":"), and periods (".").
        /// Source: https://www.w3.org/TR/html4/types.html#:~:text=ID%20and%20NAME%20tokens%20must,periods%20(%22.%22).
        /// </remarks>
        public string GetHeadingIdentity(string headingValue)
		{
            // For now, just return the heading value with spaces exchanged for dashes.
            var output = headingValue.Replace(' ', '-');
            return output;
		}
	}
}