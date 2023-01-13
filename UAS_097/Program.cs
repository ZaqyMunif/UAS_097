using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_097
{
    class Node
    {
        public int nim;
        public string nama;
        public string jk;
        public string kls;
        public string kota;
        public Node next;
        public Node prev;

    }
    class DoubleLinkedList
    {
        Node START;

        public void addData()
        {
            int nim;
            string nama;
            string jk;
            string kls;
            string kota;
            Console.WriteLine("\nMasukan NIM : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukan Nama : ");
            nama = Console.ReadLine();
            Console.WriteLine("\nMasukan Jenis Kelamin : ");
            jk = Console.ReadLine();
            Console.WriteLine("\nMasukan Kelas : ");
            kls = Console.ReadLine();
            Console.WriteLine("\nMasukan Asal Kota : ");
            kota = Console.ReadLine();
            Node newNode = new Node();
            newNode.nim = nim;
            newNode.nama = nama;
            newNode.jk = jk;
            newNode.kls = kls;
            newNode.kota = kota;

            if (START == null || nim <= START.nim)
            {
                if ((START != null) && (nim == START.nim))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null) START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for ( current = previous = START;
                current != null && nim >= current.nim;
                previous = current, current = current.next)
            {
                if (nim == current.nim)
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            current.next = newNode;
        }
        public bool Search(string kotaAsal, ref Node previous, ref Node current)
        {
            previous = current = START;
            while ( current != null && kotaAsal != current.kota)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList Kosong");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of " + "Roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.nim + currentNode.nama + "\n");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + "Roll number are:\n");
                Node currentNode;
                //membawa currentNode ke node paling belakang
                currentNode = START;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                //membaca data dari last node ke first node
                while (currentNode != null)
                {
                    Console.Write(currentNode.nim + " " + currentNode.nama + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Masukan Data");
                    Console.WriteLine("2. Mencari Data berdasarkan kota");
                    Console.WriteLine("3. Ascending");
                    Console.WriteLine("4. Descending ");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addData();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nData tidak ada");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nMasukan kota : ");
                                String kota = Convert.ToString(Console.ReadLine());
                                if (obj.Search(kota, ref prev, ref curr) == false)
                                    Console.WriteLine("\nTidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nDitemukan");
                                    Console.WriteLine("\nNIM :" + curr.nim);
                                    Console.WriteLine("\nNama :" + curr.nama);
                                    Console.WriteLine("\nJenis Kelamin :" + curr.jk);
                                    Console.WriteLine("\nKelas :" + curr.kls);
                                    Console.WriteLine("\nAsal Kota :" + curr.kota);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("invalid option");
                            }
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }
    }
}

/* 2. doublelinkedlist, karena mudah dalam mengurutkan data */
/* 3. EnQueue DeQueue*/
/* 4. */
/* 5. a. 20 parent, children = 10, 15, 10, 15, 20,20
      b. post order*/