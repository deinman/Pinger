using System;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace Pinger
{
    class Program
    {
        // args[] can be IP or hostname
        static void Main(string[] args)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;
            

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            PingReply reply = pingSender.Send(args[0], timeout, buffer, options);

            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address {0}", reply.Address.ToString());
                Console.WriteLine("RoundTripTime: {0}", reply.RoundtripTime);
                //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                //Console.WriteLine("Don't fragement: {0}", reply.Options.DontFragment);
                //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
        }
    }
}
