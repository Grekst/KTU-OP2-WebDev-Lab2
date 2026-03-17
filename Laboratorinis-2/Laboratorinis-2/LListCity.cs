using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        private Node pointer;

        public LListCity()
        {
            tail = new Node(new City(), null);
            head = new Node(new City(), tail);
        }
    }
}