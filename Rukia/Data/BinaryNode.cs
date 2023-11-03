using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Data
{
    public class BinaryNode<T>
    {
        public T Value { get; set; }
        public BinaryNode(T value)
        {
            this.Value = value;
        }
        public BinaryNode<T>[] Parent { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }

        public bool IsRoot { get => this.Parent == null; }
        public bool IsLeaf { get => this.Left == null && this.Right == null; }

        public void AddParent(BinaryNode<T> node)
        {
            if (this.Parent == null)
                this.Parent = new BinaryNode<T>[] { node };
            else
                this.Parent = new BinaryNode<T>[] { this.Parent[0], node };
        }

        public override string ToString()
        {
            string value = "", lft = "", rgt = "";
            if (this.Value != null)
                value = "N: " + this.Value.ToString();
            if (this.Left != null && this.Left.Value != null)
                lft = "L: " + this.Left.Value.ToString();
            if (this.Right != null && this.Right.Value != null)
                rgt = "R: " + this.Right.Value.ToString();

            return $"{value} {lft} {rgt}";
        }


    }
}
