using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DLL;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace seed_LinkedListSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList ll = new LinkedList();
            String line;
            //Pass the file path and file name to the StreamReader constructor
            string filePath = Path.GetFullPath("yob2019.txt");
              StreamReader file = new StreamReader(filePath);
            //Read the file and Continue to read until you reach end of file
            while ((line = file.ReadLine()) != null)
            {
                // use the arrays to make a new node
                string[] partsofNode = line.Split(',');
                Node node = new Node(Convert.ToChar(partsofNode[1]), partsofNode[0], Convert.ToInt32(partsofNode[2]));
                ll.Add(node);//attach the node to the list
                //Console.WriteLine(line);
            }
            //close the file
            file.Close();
            while (true)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine("Options:");
                Console.WriteLine("1) Get count of all Names (S)");
                Console.WriteLine("2) Add a name (A)");
                Console.WriteLine("3) Current Count of Female names (F)");
                Console.WriteLine("4) Current Count of Male names(M)");
                Console.WriteLine("5) Search for Name(I)");
                Console.WriteLine("6) Exit (E)");
                Console.Write("\r\nSelect an option: ");
                ConsoleKeyInfo Choice = Console.ReadKey();
                if (Choice.Key == ConsoleKey.S)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(ll.counter);
                }
                else if (Choice.Key == ConsoleKey.A)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter the name, the Gender (M/F), and the rank. Separated by commas.");
                    string input = Console.ReadLine();
                    string[] partsofNode = input.Split(',');
                    Node node = new Node(Convert.ToChar(partsofNode[0]), partsofNode[1], Convert.ToInt32(partsofNode[2]));
                    ll.Add(node);
                }
                else if (Choice.Key == ConsoleKey.F)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(ll.fcounter);
                }
                else if (Choice.Key == ConsoleKey.M)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(ll.mcounter);
                }
                else if (Choice.Key == ConsoleKey.I)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter the name you are searching for.");
                    string input = Console.ReadLine();
                    Node node = ll.Search(input);
                    if(node != null)
                    {
                        Console.WriteLine("You searched for " + input + "and " + node.fullname + "was found.");
                    }
                }
                else if (Choice.Key == ConsoleKey.E)
                {
                    return;
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10));
            }
            
        }
    }
}
