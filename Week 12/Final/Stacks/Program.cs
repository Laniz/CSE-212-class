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