using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_2
{
    public class Route
    {
        public List<string> Cities { get; private set; }
        public int TotalDistance { get; private set; }

        public Route()
        {
            Cities = new List<string>();
            TotalDistance = 0;
        }

        public Route(List<string> cities, int totalDistance)
        {
            Cities = new List<string>(cities);
            TotalDistance = totalDistance;
        }

        public string FirstCity()
        {
            return Cities.Count > 0 ? Cities[0] : "";
        }

        public bool PassesThrough(string cityName)
        {
            for (int i = 1; i < Cities.Count; i++)
            {
                if (Cities[i] == cityName)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Join(" -> ", Cities) + string.Format(" [{0} km]", TotalDistance);
        }
    }
    public sealed class LListRoute
    {
        private sealed class Node
        {
            public Route Data { get; set; }
            public Node Link { get; set; }
            public Node(Route data, Node link) { Data = data; Link = link; }
        }

        private Node head;
        private Node tail;
        private Node headFifo;
        private Node d;

        public LListRoute()
        {
            tail = new Node(new Route(), null);
            head = new Node(new Route(), tail);
            headFifo = head;
            d = null;
        }

        public void Append(Route route)
        {
            headFifo.Link = new Node(route, tail);
            headFifo = headFifo.Link;
        }

        public void Begin() { d = head.Link; }
        public void Next() { d = d.Link; }
        public bool Exist() { return d != tail; }
        public Route GetRoute() { return d.Data; }

        public int Count()
        {
            int count = 0;
            for (Begin(); Exist(); Next()) count++;
            return count;
        }

        public void RemoveRoutesWithCity(string cityName)
        {
            Node prev = head;
            Node curr = head.Link;
            while (curr != tail)
            {
                if (curr.Data.PassesThrough(cityName))
                {
                    prev.Link = curr.Link;
                    if (curr == headFifo)
                        headFifo = prev;
                    curr = prev.Link;
                }
                else
                {
                    prev = curr;
                    curr = curr.Link;
                }
            }
        }

        public void Sort()
        {
            if (head.Link == tail || head.Link.Link == tail) return;

            Node sorted = tail;
            Node curr = head.Link;

            while (curr != tail)
            {
                Node next = curr.Link;
                Node prev = head;
                Node ins = head.Link;

                while (ins != sorted)
                {
                    bool byDist = curr.Data.TotalDistance < ins.Data.TotalDistance;
                    bool sameDist = curr.Data.TotalDistance == ins.Data.TotalDistance;
                    bool byName = string.Compare(curr.Data.FirstCity(), ins.Data.FirstCity()) < 0;

                    if (byDist || (sameDist && byName))
                        break;

                    prev = ins;
                    ins = ins.Link;
                }

                if (ins != curr)
                {
                    // Remove curr from its position
                    Node beforeCurr = head;
                    Node tmp = head.Link;
                    while (tmp != curr)
                    {
                        beforeCurr = tmp;
                        tmp = tmp.Link;
                    }
                    beforeCurr.Link = curr.Link;
                    // Insert curr before ins
                    curr.Link = ins;
                    prev.Link = curr;
                }

                sorted = curr;
                curr = next;
            }
        }
    }
}