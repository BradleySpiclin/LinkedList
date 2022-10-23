using System;
using static System.Console;

namespace Program
{
    class CustomLinkedList
    {
        Node head;

        public class Node
        {
            public int data;
            public Node next;

            public Node(int d) { data = d; }
        }
        public void deleteBackHalf()
        {
            if (head == null || head.next == null)
            {
                head = null;
            }

            Node slow = head;
            Node fast = head;
            Node previous = null;

            while (fast != null && fast.next != null)
            {
                previous = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            previous.next = null;
        }
        public void displayContents()
        {
            Node current = head;

            while (current != null)
            {
                Console.Write(current.data + "->");
                current = current.next;
            }
        }

        public void deleteNthNodeFromEnd(int n)
        {
            if (head == null || n == 0)
            {
                return;
            }

            Node first = head;
            Node second = head;

            for (int i = 0; i < n; i++)
            {
                second = second.next;
                if (second.next == null)
                {
                    // N >= length of list
                    if (i == n - 1)
                    {
                        head = head.next;
                    }
                    return;
                }
            }
            while (second.next != null)
            {
                first = first.next;
                second = second.next;
            }
            first.next = first.next.next;
        }

        static void Main(string[] args)
        {
            CustomLinkedList linkedList = new CustomLinkedList();
            Node firstNode = new Node(45);
            Node secondNode = new Node(35);
            Node thirdNode = new Node(18);
            Node fourthNode = new Node(9);
            Node fifthNode = new Node(19);
            Node sixthNode = new Node(39);
            Node seventhNode = new Node(49);
            Node eighthNode = new Node(23);

            linkedList.head = firstNode;
            firstNode.next = secondNode;
            secondNode.next = thirdNode;
            thirdNode.next = fourthNode;
            fourthNode.next = fifthNode;
            fifthNode.next = sixthNode;
            sixthNode.next = seventhNode;
            seventhNode.next = eighthNode;

            WriteLine("Contents of the linked list");
            linkedList.displayContents();
            WriteLine();
            linkedList.deleteNthNodeFromEnd(2);
            WriteLine();
            WriteLine("Contents after deleting the 2nd node from the end");
            linkedList.displayContents();
            WriteLine();
            linkedList.deleteBackHalf();
            WriteLine();
            WriteLine("Contents after deleting the back half");
            linkedList.displayContents();

        }
    }
}
