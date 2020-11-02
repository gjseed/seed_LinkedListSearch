using System;
using System.Text;

namespace DLL
{
    class LinkedList
    {
        private Node head;
        public int counter = 0;
        public int fcounter = 0;
        public int mcounter = 0;
        private Node tail;
        private Node mid;
        private Node slowPointer;
        private Node fastPointer;

        public void Add(Node node)
        {
            Console.WriteLine("\n" + counter + node.fullname + "\n");
            // check for empty list. If empty add to head
            if (head == null)
            {
                head = node;
                mcounter += node.Mf == 'M' ? 1 : 0;
                fcounter += node.Mf == 'F' ? 1 : 0;
                counter++;
                return;
                //return head;
            }

            Node current = head;

            // if not empty, search the list for insert point
            while (current != null)
            {
                Node next = current.Next;
                // handle null tail

                // handle new head
                if (current.fullname.CompareTo(node.fullname) > 0)
                {
                    if (next == null)
                    {
                        current.Next = node;
                        node.Previous = current;
                        tail = current.Next;
                        mcounter += node.Mf == 'M' ? 1 : 0;
                        fcounter += node.Mf == 'F' ? 1 : 0;
                        counter++;
                        return;
                    }
                    else if (next.fullname.CompareTo(node.fullname) > 0)// insert in middle
                    {
                        current = current.Next;
                    }
                    else if (next.fullname.CompareTo(node.fullname) < 0)
                    {
                        Node temp = new Node();
                        temp = next;
                        current.Next = node;
                        node.Previous = current;
                        node.Next = temp;
                        mcounter += node.Mf == 'M' ? 1 : 0;
                        fcounter += node.Mf == 'F' ? 1 : 0;
                        counter++;
                        return;
                    }
                }
                else if (current.fullname.CompareTo(node.fullname) < 0)
                {
                    head = node;
                    head.Next = current;
                    current.Previous = head;
                    if (current.Next == null)
                    {
                        tail = current;
                    }
                    mcounter += node.Mf == 'M' ? 1 : 0;
                    fcounter += node.Mf == 'F' ? 1 : 0;
                    counter++;
                    return;
                }
                else
                {
                    if (current.Next == null)
                    {
                        current.Next = node;
                        tail = current.Next;
                        node.Previous = current;
                        node.fullname = node.fullname + "_1";
                        mcounter += node.Mf == 'M' ? 1 : 0;
                        fcounter += node.Mf == 'F' ? 1 : 0;
                        counter++;
                        return;
                    }
                    else
                    {
                        Node temp = new Node();
                        temp = next;
                        current.Next = node;
                        node.Previous = current;
                        node.fullname = node.fullname + "_1";
                        mcounter += node.Mf == 'M' ? 1 : 0;
                        fcounter += node.Mf == 'F' ? 1 : 0;
                        counter++;
                        return;
                    }
                }
            }
        }

        public Node midNode()
        {
            slowPointer = head;
            fastPointer = head;
            for (int i = 0; i < counter; i++)
            {
                if(slowPointer.Next != null)
                {
                    slowPointer = slowPointer.Next;
                    fastPointer = fastPointer.Next.Next;
                    if(fastPointer == null || fastPointer == tail)
                    {
                        mid = slowPointer;
                        return slowPointer;
                    }
                }
                else
                {
                    mid = slowPointer;
                    return slowPointer;
                }
            }
            mid = slowPointer;
            return mid;
        }

        public Node Search(string fullname)
        {
            // search for node by name;
            // return reference to first node found; else null node
            Node current = midNode();
            if (head == null)
            {
                return null;
            }
            // if not empty, search the list for insert point
            while (current != null)
            {
                //insert node after this node
                if (fullname == current.fullname)
                {
                    return mid;
                }
                //set mid node to tail and start loop over
                else if (fullname.CompareTo(current.fullname) < 0)
                {
                    tail = mid;
                    mid.Next = null;
                    if(mid.Previous == head)
                    {
                        if(fullname.CompareTo(head.fullname) == 0)
                        {
                            return head;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                //set mid node to head and start loop over
                else
                {
                    head = mid;
                    if (mid.Next == tail)
                    {
                        if (fullname.CompareTo(tail.fullname) == 0)
                        {
                            return tail;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                current = midNode();
            }
            return current;
        }
    }
}
