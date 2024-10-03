using WTD.E3.Extensions.Windows.Diagnostics;
using WTD.E3.Extensions.Windows.Diagnostics.Abstractions;

namespace wpfPocAPI.Interceptors
{
    public class PocProcessWatcher //: ProcessWatcher
    {
        private static ProcessWatchSettings _watchSettings = new ProcessWatchSettings() { WatchOptions = ProcessWatchOptions.All };

        public PocProcessWatcher() //: base(_watchSettings, )
        {
        }        
    }
}
