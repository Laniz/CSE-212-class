using System;

class Node {
    public char Data;
    public Node Next;

    public Node(char data) {
        Data = data;
        Next = null;
    }
}

class CircularLinkedList {
    private Node tail;

    public CircularLinkedList() {
        tail = null;
    }

    // Inserts a new node at the end
    public void Insert(char data) {
        Node newNode = new Node(data);
        if (tail == null) {
            tail = newNode;
            tail.Next = tail; // Points to itself (circular)
        } else {
            newNode.Next = tail.Next;
            tail.Next = newNode;
            tail = newNode; // Update tail
        }
    }

    // Reverses the stored characters
    public string Reverse() {
        if (tail == null) return "";

        Node current = tail.Next; // Start from head
        string reversed = "";

        do {
            reversed = current.Data + reversed; // Prepend characters
            current = current.Next;
        } while (current != tail.Next); // Stop when we return to head

        return reversed;
    }
}

class Program {
    static void Main() {
        CircularLinkedList list = new CircularLinkedList();
        string input = "hello world";

        // Insert each character into the circular list
        foreach (char c in input) {
            list.Insert(c);
        }

        // Reverse the string using the linked list
        string reversed = list.Reverse();

        Console.WriteLine($"Original: {input}");
        Console.WriteLine($"Reversed: {reversed}");
    }
}