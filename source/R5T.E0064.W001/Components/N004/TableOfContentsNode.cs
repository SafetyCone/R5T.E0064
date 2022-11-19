using System;
using System.Collections.Generic;


namespace R5T.E0064.W001.N004
{
    public class TableOfContentsNode
    {
        /// <summary>
        /// The "HowToSeeMetaTags" in &lt;a href="#HowToSeeMetaTags" &gt;...
        /// </summary>
        public string Identity { get; set; }
        
        /// <summary>
        /// The "How to see Meta tags" in &lt;a&gt;How to see meta tags&lt;/a&gt;
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Goes from 1 (h1) to 6 (h6).
        /// </summary>
        public int Level { get; set; }

        public TableOfContentsNode Parent { get; set; }

        public List<TableOfContentsNode> ChildNodes { get; } = new List<TableOfContentsNode>();


        public void AddChild(TableOfContentsNode node)
        {
            node.Parent = this;

            this.ChildNodes.Add(node);
        }
    }
}
