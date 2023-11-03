using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Data
{
    public class IntBinaryNode : BinaryNode<int>
    {

        public int Total
        {
            get
            {
                if (this.IsRoot)
                    return this.Value;
                else if (this.Parent != null && this.Parent.Length == 1)
                {
                    return (this.Parent[0] as IntBinaryNode).Total + this.Value;
                }
                else if (this.Parent != null && this.Parent.Length == 2)
                {
                    if ((this.Parent[0] as IntBinaryNode).Total > (this.Parent[1] as IntBinaryNode).Total)
                        return this.Value + (this.Parent[0] as IntBinaryNode).Total;
                    else
                        return this.Value + (this.Parent[1] as IntBinaryNode).Total;
                }
                else
                    return 0;
            }
        }

        public IntBinaryNode(int value)
            : base(value)
        {
        }


    }
}
