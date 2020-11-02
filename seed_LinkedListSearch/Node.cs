using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    class Node
    {
        public Node Previous;
        public Node Next;
        public char Mf;
        public string fullname;
        public int Rank;
        public Node()
        {

        }

        public Node(char gender, string name, int rank)
        {
            Next = null;
            Previous = null;
            Mf = gender;
            fullname = name;
            Rank = rank;
        }
    }
}
