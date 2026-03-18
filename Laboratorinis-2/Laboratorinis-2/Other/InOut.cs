using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Xml;

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
            using (StringReader reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 2)
                    {
                        string name = parts[0].Trim();
                        int population;
                        if (int.TryParse(parts[1].Trim(), out population))
                        {
                            city.Append(new City(name, population));
                        }
                    }
                }
            }
            return city;
        }

        public static LListRoad ReadRoad(string text)
        {
            LListRoad road = new LListRoad();
            using (StringReader reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 3)
                    {
                        string start = parts[0].Trim();
                        string destination = parts[1].Trim();
                        int distance;
                        if (int.TryParse(parts[2].Trim(), out distance))
                        {
                            road.Append(new Road(start, destination, distance));
                        }
                    }
                }
            }
            return road;
        }

    }
}