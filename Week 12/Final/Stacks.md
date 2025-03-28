# Introduction to Stacks

Stacks are a powerful tool that can be used in a variety of applications. Understanding how to use a stack can be a bit challenging.

A stack follows the Last In, First Out (LIFO) principle, meaning that whatever is added last will be the first thing to be removed from the stack. You can imagine it as a pipe: you can add items to the pipe, but once an item has been added, you must remove the one above it first before accessing the ones below. This is the definition of LIFO.

> *I will add an image here to illustrate this concept.*

This property enables interesting functionalities. Recursion is made possible by this property, and you can also perform simple tasks like reversing the letters in a word.

---

Common Operations

## Push

Time complexity (O(1))
Pushing an item onto the stack is done using:

```csharp
stack.Push(x);
```

where `x` can be any value. The first item is added at the bottom of the stack, and any subsequent items are added on top of the previous ones. This allows you to build a sequence of items that can be retrieved in reverse order.

### Pop

Time complexity (O(1))

You can remove items from the stack using:

```csharp
int element = stack.Pop();
```

This will remove and return the topmost item from the stack. If the stack is empty and you try to pop an element, it will throw an error, so it's important to check if the stack has elements before calling `Pop()`.

### Count

Time complexity (O(1))

You can retrieve the number of elements in the stack using:

```csharp
int count = stack.Count;
```

This operation returns the total number of elements currently in the stack. This is useful when you need to check how many items are left before performing operations.

### Clear

Time complexity (O(n))
To remove all elements from the stack, you can use:

```csharp
stack.Clear();
```

This operation removes every element in the stack, effectively resetting it. This is useful when you want to reuse the stack without creating a new one.

# Example Problem

## Problem Statement

You're in an interview, and for the coding portion, you're asked to reverse a string of letters. While there are many ways to solve this problem, arguably the easiest approach is to use a stack. The LIFO principle makes handling this problem much more straightforward.

## Code

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static string ReverseString(string input)
    {
        Stack<char> stack = new Stack<char>();

        // Push all characters onto the stack
        foreach (char c in input)
        {
            stack.Push(c);
        }

        // Pop characters from the stack to form the reversed string
        string reversed = "";
        while (stack.Count > 0)
        {
            reversed += stack.Pop();
        }

        return reversed;
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string reversed = ReverseString(input);
        Console.WriteLine($"Reversed string: {reversed}");
    }
}
```

## Code Breakdown

```csharp
Stack<char> stack = new Stack<char>();
```

This line creates a stack that will store characters from the input string.

```csharp
foreach (char c in input)
{
    stack.Push(c);
}
```

Here, we iterate through each character in the string and push it onto the stack. Since stacks follow the **LIFO** principle, the last character we push will be the first one removed.

```csharp
string reversed = "";
```

We create an empty string variable to store the characters we retrieve from the stack in the next step.

```csharp
while (stack.Count > 0)
{
    reversed += stack.Pop();
}
```

We use a `while` loop to ensure all characters are removed from the stack. By calling `stack.Pop()`, we retrieve characters in reverse order and append them to the `reversed` string.

```csharp
return reversed;
```

Finally, the function returns the reversed string.

## Image Illustration

The image below will illustrate how this works. The example word will be **"Semaphore"**.

*Another image will be added here*

# Problem to Solve

Another common problem that can be efficiently solved using a stack is implementing an **Undo/Redo** functionality. In a simple text editor, users can type characters, undo their last action, and redo it if needed.

## Incomplete Code

```csharp
using System;
using System.Collections.Generic;

class TextEditor
{
    static Stack<string> undoStack = new Stack<string>();
    static Stack<string> redoStack = new Stack<string>();
    static string text = "";

    static void Type(string newText)
    {
        //Add your code here
    }

    static void Undo()
    {
        //Add your code here
    }

    static void Redo()
    {
        //Add your code here
    }

    static void Main()
    {
        Type("Hello");
        Console.WriteLine($"Text: {text}");

        Type(" World");
        Console.WriteLine($"Text: {text}");

        Type(" Goodbye");
        Console.WriteLine($"Text: {text}");

        Type(" See");
        Console.WriteLine($"Text: {text}");

        Type(" You");
        Console.WriteLine($"Text: {text}");

        Type(" Tommorrow");
        Console.WriteLine($"Text: {text}");

        Undo();
        Console.WriteLine($"After Undo: {text}");

        Redo();
        Console.WriteLine($"After Redo: {text}");
    }
}
```

Once you have attempted the above problem you can find the solution by [clicking here](Stacks\Program.cs)
