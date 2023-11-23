using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    public static class WordUtils
    {
        public static int WordScore(this string word) =>
            word.ToCharArray().Select(x => (int)x - 64).Sum();
    }
}
