using RemotingServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemotingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //create channel with port
            HttpChannel c1 = new HttpChannel(8002);

            //register channel
            ChannelServices.RegisterChannel(c1);

            //create a service class object
            Service service = (Service)Activator.GetObject(typeof(Service),
                "http://localhost:85/OurFirstRemoteService");

            //"tcp://localhost:8089/OurFirstRemoteService"
            //start calling the functions of the service class
            Console.WriteLine(service.SayHello("  Remote"));
            
            Console.Read();
        }
    }
}
