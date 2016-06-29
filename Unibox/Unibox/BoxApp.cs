using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibox
{
    abstract class BoxApp
    {
        public class Meta
        {
            public Dictionary<int, int> Pattern = new Dictionary<int, int>();
            public Dictionary<int, IEnumerable<string>> Data
                = new Dictionary<int, IEnumerable<string>>();
            public static Meta operator +(Meta lVal, Meta rVal)
            {
                var ans = (Meta)lVal.MemberwiseClone();
                foreach (var i in rVal.Pattern)
                    if (ans.Pattern.ContainsKey(i.Key))
                        ans.Pattern[i.Key] += i.Value;
                    else
                        ans.Pattern.Add(i.Key, i.Value);
                foreach(var i in rVal.Data)
                {
                    if (ans.Data.ContainsKey(i.Key))
                        ans.Data[i.Key] = ans.Data[i.Key].Concat(i.Value);
                    else
                        ans.Data[i.Key] = i.Value;
                }
                return ans;
            }
        }
        public abstract Meta GetMeta(string word);
        public Meta GetMeta(IEnumerable<string> words)
        {
            var ans = new Meta();
            foreach (string word in words) ans += GetMeta(word);
            return ans;
        }
    }
}
