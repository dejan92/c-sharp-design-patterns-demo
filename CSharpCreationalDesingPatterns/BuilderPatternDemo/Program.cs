using System;
using System.Collections.Generic;

namespace BuilderPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        
            var livingRoomBuilder = new LivingRoomBuilder();
            livingRoomBuilder.SetSize(20);
            livingRoomBuilder.SetColor("blue");
            livingRoomBuilder.SetFlooring("carpet");
            livingRoomBuilder.SetLighting("chandelier");
            livingRoomBuilder.AddOptionalFeature("fireplace");
            var livingRoom = livingRoomBuilder.GetResult();
            OutputRoomProperties(livingRoom);

            var bedroomBuilder = new BedroomBuilder();
            bedroomBuilder.SetSize(15);
            bedroomBuilder.SetColor("green");
            bedroomBuilder.SetFlooring("hardwood");
            bedroomBuilder.SetLighting("ceiling fan");
            bedroomBuilder.AddOptionalFeature("walk-in closet");
            bedroomBuilder.AddOptionalFeature("bedroom TV");
            var bedroom = bedroomBuilder.GetResult();
            OutputRoomProperties(bedroom);

            var bathroomBuilder = new BathroomBuilder();
            bathroomBuilder.SetSize(10);
            bathroomBuilder.SetColor("white");
            bathroomBuilder.SetFlooring("tile");
            bathroomBuilder.SetLighting("recessed lights");
            bathroomBuilder.AddOptionalFeature("double sink");
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
