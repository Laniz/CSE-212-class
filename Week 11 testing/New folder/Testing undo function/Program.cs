using System;
using System.Collections.Generic;

class TextEditor
{
    static Stack<string> undoStack = new Stack<string>();
    static Stack<string> redoStack = new Stack<string>();
    static string text = "";

    static void Type(string newText)
    {
        undoStack.Push(text);
        text += newText;
        redoStack.Clear();
    }

    static void Undo()
    {
        if (undoStack.Count > 0)
        {
            redoStack.Push(text);
            text = undoStack.Pop();
        }
    }

    static void Redo()
    {
        if (redoStack.Count > 0)
        {
            undoStack.Push(text);
            text = redoStack.Pop();
        }
    }

    static void Main()
    {
     
        Type("Hello");
        Console.WriteLine($"Text: {text}");

        Undo();
        Console.WriteLine($"After Undo: {text}");

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

        Undo();
        Console.WriteLine($"After Undo: {text}");

        Redo();
        Console.WriteLine($"After Redo: {text}");

        Undo();
        Console.WriteLine($"After Undo: {text}");

        Redo();
        Console.WriteLine($"After Redo: {text}");
    
    }
}