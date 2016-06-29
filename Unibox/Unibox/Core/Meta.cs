using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unibox.Library;

namespace Unibox.Core
{
    public class Meta
    {
        public Dictionary<MetaType, int> Pattern = new Dictionary<MetaType, int>();
        public Dictionary<MetaType, IEnumerable<string>> Data
            = new Dictionary<MetaType, IEnumerable<string>>();

        public static Meta operator +(Meta lVal, Meta rVal)
        {
            var ans = (Meta)lVal.MemberwiseClone();
            foreach (var i in rVal.Pattern)
                if (ans.Pattern.ContainsKey(i.Key))
                    ans.Pattern[i.Key] += i.Value;
                else
                    ans.Pattern.Add(i.Key, i.Value);
            foreach (var i in rVal.Data)
                if (ans.Data.ContainsKey(i.Key))
                    ans.Data[i.Key] = ans.Data[i.Key].Concat(i.Value);
                else
                    ans.Data[i.Key] = i.Value;
            return ans;
        }
 
    }
}
