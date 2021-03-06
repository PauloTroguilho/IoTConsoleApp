﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Configuration;

namespace IoTConsoleApp
{ /// <summary>
  /// Uncomment/Copy the contrstructor you want to use and change the settings
  /// </summary>
    public class MyFirstConfig : ConfigurationSetting
    {
        /// <summary>
        /// Sample configuration where mydomain.com:4502 is the public Uri that clients connect to.
        /// Then our firewall will do a port forward to the machine 192.168.1.4 and port 4503
        /// </summary>
        /*public MyFirstConfig() : base(new Uri("ws://mydomain.com:4502"), new Uri("ws://192.168.1.4:4503")){}*/

        /// <summary>
        /// If you want to setup a certificae or change other parameters, do that inside the constructor
        /// </summary>
        /*public MyFirstConfig() : base("ws://127.0.0.1:4502")
        {
            this.Certificate = new X509Certificate2("mycert.file","mypassword");
        }*/
        /// <summary>
        /// Sample where we setup the server to run on localhost port 4506.
        /// We can of course replace the IP with host name for example mydomain.com:4506
        /// </summary>
        public MyFirstConfig() : base("ws://192.168.47.1:1883") { }
    }
}
