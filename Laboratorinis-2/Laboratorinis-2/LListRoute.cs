using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_2
{
    public class LListRoute
    {
        private sealed class Node
        {
            public Route Data { get; set; }
            public Node Link { get; set; }
            public Node(Route data, Node link) { Data = data; Link = link; }
        }

        private Node head, tail, last, current;

        public LListRoute()
        {
            tail = new Node(null, null);
            head = new Node(null, tail);
            last = head;
        }

        public void Append(Route route)
        {
            last.Link = new Node(route, tail);
            last = last.Link;
        }

        public void Begin() => current = head.Link;
        public void Next() => current = current.Link;
        public bool Exist() => current != tail;
        public Route Get() => current.Data;

        // Rikiavimas: pagal ilgį (didėjančiai) ir pirmo miesto pavadinimą
        public void Sort()
        {
            for (Node i = head.Link; i != tail; i = i.Link)
            {
                for (Node j = i.Link; j != tail; j = j.Link)
                {
                    string nameI = i.Data.Cities.GetFirstCityName(); // Reikės metodo LListCity
                    string nameJ = j.Data.Cities.GetFirstCityName();

                    if (i.Data.TotalDistance > j.Data.TotalDistance ||
                       (i.Data.TotalDistance == j.Data.TotalDistance && string.Compare(nameI, nameJ) > 0))
                    {
                        Route temp = i.Data;
                        i.Data = j.Data;
                        j.Data = temp;
                    }
                }
            }
        }
    }
}