using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoMeter.vendor.StartupCreator
{
    interface StartupCreator
    {
        bool IsInStartup();
        bool RunOnStartup();

        bool RemoveFromStartup();
    }
}
