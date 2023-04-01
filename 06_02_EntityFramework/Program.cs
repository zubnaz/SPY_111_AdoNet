﻿using System;
using System.Linq;
using _06_02_EntityFramework.Entities;

namespace _06_02_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext context = new AirplaneDbContext();
            context.Clients.Add(new Client
            {
                Name = "Volodia",
                Birthdate = new DateTime(2006, 7, 9),
                Email = "volodia@gmail.com"
            });
            //context.SaveChanges();

            foreach (var c in context.Clients)
            {
                Console.WriteLine($"Client : {c.Name}  {c.Email}  {c.Birthdate}");
            }

            var res = context.Flights.Where(f => f.ArrivelCity == "Lviv").OrderBy(f => f.DepartureTime);

            foreach (var f in res)
            {
                Console.WriteLine($"Flight : {f.Number}  {f.DepartureCity}  {f.ArrivelCity}");
            }
            var client = context.Clients.Find(1);
            context.Entry(client).Collection(c => c.Flights).Load();
            Console.WriteLine($"Client : {client.Id} {client.Name} Flights : {client.Flights.Count}");
            foreach (var item in client.Flights)
            {
                Console.WriteLine($"{item.Number} {item.DepartureCity} {item.ArrivelCity} {item.ArrivelTime.ToShortDateString()} {item.DepartureTime.ToShortDateString()}");
            }
        }
    }
}
