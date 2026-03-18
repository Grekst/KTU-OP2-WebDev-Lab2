using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Laboratorinis_2
{
    public class LListCity
    {
        private sealed class Node
        {
            public City Data { get; set; }
            public Node Link { get; set; }

            public Node(City data, Node link)
            {
                Data = data;
                Link = link;
            }
        }

        private Node head;
        private Node tail;
        private Node last;
        private Node current;

        public LListCity()
        {
            tail = new Node(null, null);
            head = new Node(null, tail);
            last = head;
            current = null;
        }

        public void Append(City city)
        {
            last.Link = new Node(city, tail);
            last = last.Link;
        }

        public void Begin()
        {
            current = head.Link;
        }

        public void Next()
        {
            current = current.Link;
        }

        public bool Exist()
        {
            return current != tail;
        }

        public City GetCity()
        {
            return current.Data;
        }

        public bool Containts(string name, int population)
        {
            for (Begin(); Exist(); Next())
            {
                if (current.Data.Name.Equals(name) && current.Data.Population.Equals(population))
                {
                    return true;
                }
            }

            return false;
        }

        public City Find(string cityName)
        {
            if (string.IsNullOrEmpty(cityName)) return null;
            for (Begin(); Exist(); Next())
            {
                // OrdinalIgnoreCase leidžia rasti "kaunas", net jei faile yra "Kaunas"
                if (current.Data.Name.Trim().Equals(cityName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return current.Data;
                }
            }
            return null;
        }

        public int Count()
        {
            int count = 0;
            for (Begin(); Exist(); Next())
            {
                count++;
            }

            return count;
        }

        public string GetFirstCityName()
        {
            if (head.Link != tail)
            {
                return head.Link.Data.Name;
            }
            return string.Empty;
        }

        public bool ContainsName(string name)
        {
            for (Begin(); Exist(); Next())
            {
                if (current.Data.Name == name) return true;
            }
            return false;
        }

        public void RemoveLast()
        {
            if (head.Link == tail) return;
            Node temp = head;
            while (temp.Link != last) temp = temp.Link;
            temp.Link = tail;
            last = temp;
        }
    }
}