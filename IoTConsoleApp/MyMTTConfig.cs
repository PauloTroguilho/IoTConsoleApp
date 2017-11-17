using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Configuration;

namespace IoTConsoleApp
{
    class MyMTTConfig : ConfigurationSetting
    {
        public MyMTTConfig() : base("ws://192.168.47.1:1883") { }
    }
}
