using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using XSockets.Controllers;
using XSockets.Core.Common.Socket;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Core.XSocket.Model;
using XSockets.Protocol.Mqtt.Extensions;
using XSockets.Protocol.Mqtt.Modules.Controller;

namespace IoTConsoleApp
{

    public class MyMqttBride : MqttBridge
    {
        //We just use the generic controller, but we can use any controller
        private IXSocketController generic;
        public MyMqttBride()
        {
            generic = new Generic();
        }
        public override bool OnPublish(MqttClient client, MqttMsgPublishEventArgs message)
        {
            //Extract the message (we assume that it is JSON being sent in this sample)
            var json = System.Text.Encoding.UTF8.GetString(message.Message);
            //Create an IMessage object
            var m = new Message(json, message.Topic);
            //Send the message to XSockets clients on a specific controller (foo).
            generic.InvokeToAll<Foo>(m);
            // Allow the message to be published to MQTT clients
            return true;
        }
        //public override bool VerifyConnection(MqttMsgConnect message, MqttClient client)
        //{
        //    if (message.Password == "secret4you" && message.Username == "ron-burgundy")
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }

    public class Foo : XSocketController
    {
        public async Task Bar()
        {
            //Do some stuff

            //Publish to MQTT clients
            this.MqttPublish("baz", new { Name = "Steve", Age = 42 });
            //Do some other stuff
        }
    }
}
