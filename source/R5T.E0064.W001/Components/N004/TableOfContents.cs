using System;
using System.Collections.Generic;


namespace R5T.E0064.W001.N004
{
    public class TableOfContents
    {
        public TableOfContentsNode PriorNode { get; private set; }

        public List<TableOfContentsNode> Nodes { get; } = new List<TableOfContentsNode>();


        public void AddNode(TableOfContentsNode node)
        {
            if (this.PriorNode is null)
            {
                this.Nodes.Add(node);
            }
            else
            {
                // If the node has a greater level than the prior node, add it as a child of the prior node.
                if (this.PriorNode.Level < node.Level)
                {
                    this.PriorNode.AddChild(node);
                }
                else
                {
                    // If the node has a lower level than the prior node, move up the prior nodes parents until you find a higher level node (or null parent), then add as a child.
                    if (this.PriorNode.Level > node.Level)
                    {
                        var parent = this.PriorNode.Parent;
                        while ((parent?.Level ?? 0) >= node.Level)
                        {
                            parent = parent.Parent;
                        }

                        if (parent is null)
                        {
                            // A new top-level child.
                            // Null parent is expected.
                            this.Nodes.Add(node);
                        }
                        else
                        {
                            parent.AddChild(node);
                        }
                    }
                    else
                    {
                        // If the node has the same level as the prior node, add it as a child of the parent.
                        this.PriorNode.Parent.AddChild(node);
                    }
                }
            }

            this.PriorNode = node;
        }

        public void Reset()
        {
            this.PriorNode = null;
            this.Nodes.Clear();
        }
    }
}
