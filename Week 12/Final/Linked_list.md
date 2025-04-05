# Linked Lists in C#

## Introduction to Linked Lists

A **linked list** is a data structure where each element, called a **node**, is connected to the next through **pointers**. Unlike arrays, linked lists do not store data in contiguous memory locations. Instead, each node contains:

1. **Data** – The actual value stored in the node.
2. **Pointer** – A reference to the next node in the list.

This structure makes it easy to **insert or remove** elements without shifting other elements in memory. Since each node points to the next, linked lists form a **chain-like structure** that can be traversed from start to end.

The **first node** in a linked list is called the **head**. If you have access to the head, you can traverse the entire list by following the pointers.

## Types of Linked Lists

1. **Singly Linked List** – Each node has a pointer to the next node, but not to the previous one.
2. **Doubly Linked List** – Each node has pointers to both the next and previous nodes, allowing traversal in both directions.
3. **Circular Linked List** – The last node points back to the first node, forming a circular structure.

Each type of linked list has its optimal use case, depending on what you are trying to accomplish.

---

## Common Operations

### Inserting

- **InsertHead(value)** – Adds a node at the beginning of the list. **O(1)**
- **InsertTail(value)** – Adds a node at the end of the list. **O(1)**
- **Insert(node, value)** – Inserts a node after a specific node. **O(n)**

### Deleting

- **RemoveHead()** – Removes the first node. **O(1)**
- **RemoveTail()** – Removes the last node. **O(n)** (since traversal is needed)
- **Remove(node)** – Removes a specific node. **O(n)** (finding the node takes O(n))

### List Operations

- **Size()** – Returns the number of nodes. **O(n)**
- **Empty()** – Checks if the list is empty. **O(1)**

---

## Example Problem: Reverse a String Using a Circular Linked List

### Problem Statement

Implement a **circular linked list** to store the characters of a string and then reverse it.

---

### C# Implementation

```csharp
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
        string input = "hello";

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
```

### Code explanation

```csharp
class CircularLinkedList {
    private Node tail;

    public CircularLinkedList() {
        tail = null;
    }
```

This is the start of our `CircularLinkedList` class.

`tail` keeps track of the **last node** in the list.

When we create a new list, we set `tail` to `null` because the list is empty at first.

```csharp
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
```

This method adds a character to the list.

If the list is empty (`tail == null`), we create a node that points to itself to make it circular.

If not empty, we:

- Point the new node to the head (`tail.Next`).

- Connect the current tail to the new node.

- Update the tail to the new node.

```csharp
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
```

This method reads the circular list and builds the reversed string.

- It starts from the head (just after the tail).

- It loops through each node **once** using `do-while` (because it's a circle).

- For each character, it adds it to the **front** of the result string (`reversed = current.Data + reversed`), which reverses the order.

```csharp
class Program {
    static void Main() {
        CircularLinkedList list = new CircularLinkedList();
        string input = "hello";

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
```

This is the main program that runs everything.

- We create a circular linked list.

- We insert each character of the word `"hello"` into the list.

- Then we call `Reverse()` to get the reversed string.

- Finally, we print both the original and reversed versions.

### Student Problem


Write a program that uses a **circular linked list** to determine whether a word is a **palindrome**.

A **palindrome** is a word that reads the same backward as forward (e.g., `madam`, `racecar`, `level`).

```csharp
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

```
