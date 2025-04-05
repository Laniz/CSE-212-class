using System;
using System.Collections.Generic;

class Node {
    public char Data;
    public Node? Next;  // Nullable

    public Node(char data) {
        Data = data;
        Next = null;
    }
}

class CircularLinkedList {
    private Node? tail;  // Nullable

    public CircularLinkedList() {
        tail = null;
    }

    public void Insert(char data) {
        Node newNode = new Node(data);

        if (tail == null) {
            tail = newNode;
            tail.Next = tail;
        } else {
            newNode.Next = tail.Next;
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public bool IsPalindrome() {
        if (tail == null) return true;

        List<char> chars = new List<char>();
        Node? current = tail.Next;

        if (current == null) return true;

        do {
            chars.Add(current.Data);
            current = current.Next;
        } while (current != tail.Next);

        int left = 0;
        int right = chars.Count - 1;

        while (left < right) {
            if (chars[left] != chars[right]) return false;
            left++;
            right--;
        }

        return true;
    }
}

class Program {
    static void Main() {
        List<string> words = new List<string> {
            "racecar",
            "apple",
            "madam",
            "banana",
            "level",
            "robot",
            "noon"
        };

        foreach (string word in words) {
            CircularLinkedList list = new CircularLinkedList();

            foreach (char c in word) {
                list.Insert(c);
            }

            if (list.IsPalindrome()) {
                Console.WriteLine($"{word} is a palindrome.");
            } else {
                Console.WriteLine($"{word} is NOT a palindrome.");
            }
        }
    }
}
