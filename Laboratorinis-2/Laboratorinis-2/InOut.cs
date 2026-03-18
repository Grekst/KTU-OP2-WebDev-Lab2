using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Laboratorinis_2
{
    public class InOut
    {
        public static string ReadFileData(string path)
        {
            string content;

            using (StreamReader reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }

            return content;
        }

        public static LListCity ReadCity(string text)
        {
            LListCity city = new LListCity();

            using (StreamReader reader = new StreamReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                    string name = parts[0];
                    int population = int.Parse(parts[1]);

                    city.Append(new City(name, population));
                }
            }

            return city;
        }

        public static LListRoad ReadRoad(string text)
        {
            LListRoad road = new LListRoad();

            using (StreamReader reader = new StreamReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                    string start = parts[0];
                    string destination = parts[1];
                    int distance = int.Parse(parts[2]);


                    road.Append(new Road(start, destination, distance));
                }
            }

            return road;
        }

    }
}