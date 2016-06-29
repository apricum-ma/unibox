using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unibox.Core
{
    public abstract class BoxAppBase
    {
        public abstract Meta GetMeta(string word);
        public Meta GetMetas(IEnumerable<string> words) //using injection of components
        {
            Meta ans = new Meta();
            foreach (string word in words) ans += this.GetMeta(word);
            return ans;
        }
    }
}
