using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework;
using XSockets.Protocol.Mqtt.Modules.Controller;

namespace IoTConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Composable.GetExport<IXSocketServerContainer>())
            {

                var bride = new MyMqttBride();
                var config = new MyMTTConfig();
                var mqtt = ((MqttManager)Composable.GetExport<IXSocketController>(typeof(MqttManager)));

                container.Start();

                mqtt.Start();

                Console.ReadLine();

                container.Stop();
                mqtt.Stop();
            }


        }
    }
}
