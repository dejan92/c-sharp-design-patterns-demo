using System;
using System.Collections.Generic;

namespace BuilderPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var livingRoomBuilder = new LivingRoomBuilder();
            var livingRoomDirector = new RoomDirector(livingRoomBuilder);
            livingRoomDirector.ConstructRoom(size: 20, "blue", "carpet", "chandelier", new string[] { "fireplace" });
            var livingRoom = livingRoomBuilder.GetResult();
            OutputRoomProperties(livingRoom);

            var bedroomBuilder = new BedroomBuilder();
            var bedroomDirector = new RoomDirector(bedroomBuilder);
            bedroomDirector.ConstructRoom(size: 15, "green", "hardwood", "ceiling fan", new string[] { "walk-in closet", "bedroom TV" });
            var bedroom = bedroomBuilder.GetResult();
            OutputRoomProperties(bedroom);

            var bathroomBuilder = new BathroomBuilder();
            var bathroomDirector = new RoomDirector(bathroomBuilder);
            bathroomDirector.ConstructRoom(size: 10, "white", "tile", "recessed lights", new string[] { "double sink" });
            var bathroom = bathroomBuilder.GetResult();
            OutputRoomProperties(bathroom);


            Console.ReadLine();
        }

        public static void OutputRoomProperties(Room room)
        {
            Console.WriteLine($"Room size: {room.Size}");
            Console.WriteLine($"Room color: {room.Color}");
            Console.WriteLine($"Room flooring: {room.Flooring}");
            Console.WriteLine($"Room lighting: {room.Lighting}");

            if (room.OptionalFeatures.Count > 0)
            {
                Console.WriteLine("Optional features:");
                foreach (var feature in room.OptionalFeatures)
                {
                    Console.WriteLine($"- {feature}");
                }
            }
            else
            {
                Console.WriteLine("No optional features.");
            }

            Console.WriteLine("- - - - - - -");
        }

    }
}
