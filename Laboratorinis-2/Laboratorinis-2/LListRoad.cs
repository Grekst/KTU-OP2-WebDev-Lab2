using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_2
{
    public class LListRoad
    {
        private sealed class Node
        {
            public Road Data { get; set; }
            public Node Link { get; set; }

            public Node(Road data, Node link)
            {
                Data = data;
                Link = link;
            }
        }

        private Node head;
        private Node tail;
        private Node last;
        private Node current;

        public LListRoad()
        {
            tail = new Node(new Road(), null);
            head = new Node(new Road(), tail);
            last = head;
            current = null;
        }

        public void Append(Road road)
        {
            last.Link = new Node(road, tail);
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

        public Road GetRoad()
        {
            return current.Data;
        }

        private Node saved;

        /// <summary>
        /// Išsaugo dabartinę iteratoriaus poziciją prieš rekursiją
        /// </summary>
        public void SavePosition()
        {
            saved = current;
        }

        /// <summary>
        /// Atkuria iteratoriaus poziciją po rekursijos
        /// </summary>
        public void RestorePosition()
        {
            current = saved;
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
    }
}