using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    public class MaximumPathSumII : MaximumPathSum
    {
        public override void InitDigits()
        {
            String[] lines = Resources.Resources.pyramid2.Split('\n');
            lines = CleanLine(lines);
            string[] nums;
            this.Digits = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                nums = lines[i].Split(' ');
                this.Digits[i] = new int[nums.Length];
                for (int j = 0; j < nums.Length; j++)
                    this.Digits[i][j] = int.Parse(nums[j]);
            }
        }

        private string[] CleanLine(string[] lines)
        {
            List<String> listLine = new List<string>();
            String line;
            foreach (String l in lines)
            {
                line = l.Replace("\r", "");
                if (line.Length != 0)
                    listLine.Add(line);
            }
            return listLine.ToArray();
        }


    }
}
