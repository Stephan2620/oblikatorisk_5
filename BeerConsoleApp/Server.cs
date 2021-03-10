using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace BeerConsoleApp
{
    internal class Server
    {
        public static void Start()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                var port = 4646;
                var localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");

                    var client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");


                    // Get a stream object for reading and writing
                    var stream = client.GetStream();

                    Stream ns = client.GetStream();

                    var sr = new StreamReader(ns);
                    var sw = new StreamWriter(ns);
                    sw.AutoFlush = true;

                    var message = sr.ReadLine();


                    Console.WriteLine("Client: " + message);

                    if (message.Equals("Getall"))
                    {
                        sw.WriteLine("Get all");
                        sw.WriteLine(JsonConvert.SerializeObject(liste));
                    }
                    else if (message.Equals("Getbyid"))
                    {
                        sw.WriteLine("get by id");
                        sw.WriteLine("skriv dit id");
                        var lineid = sr.ReadLine();
                        var tal = int.Parse(lineid);
                        sw.WriteLine(JsonConvert.SerializeObject(liste.Find(liste => liste.Id == tal)));
                    }
                    else if (message.Equals("Save"))
                    {
                        sw.WriteLine("Save");
                        sw.WriteLine("skriv dit opjekt fx. ");

                        sw.WriteLine(JsonConvert.SerializeObject(liste.Find(liste => liste.Id == 1)));

                        var beer = sr.ReadLine();


                        liste.Add(JsonConvert.DeserializeObject<ModelBeer>(beer));
                    }
                    else
                    {
                        Console.WriteLine("now recognized");
                    }


                    // Shutdown and end connection
                    Console.WriteLine("disconnected");
                    client.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //private static readonly List<ModelBeer> liste = new List<ModelBeer>()
        // {
        // new ModelBeer(1,"øller",22,2),
        // new ModelBeer(2,"øller2",23,3),
        // new ModelBeer(3,"øller3",22,3),
        // };
        private static readonly List<ModelBeer> liste = new List<ModelBeer>
        {
            new ModelBeer {Id = 1, Name = "oller1", Price = 12, Abv = 5},
            new ModelBeer {Id = 2, Name = "oller2", Price = 13, Abv = 6},
            new ModelBeer {Id = 3, Name = "oller3", Price = 14, Abv = 7}
        };
    }
}