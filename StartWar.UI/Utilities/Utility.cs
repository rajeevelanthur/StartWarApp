using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartWar.UI.Utilities
{
    public static class Utility
    {
        public static string GetURLPart(string url)
        {
            string ss =  url.Replace(Constant.BaseURL, string.Empty);
            return ss;
        }
    }
}
