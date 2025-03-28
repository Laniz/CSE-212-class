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
        redoStack.Clear();
        text += newText;
    }

    static void Undo()
    {
        if (undoStack.Count > 0)
        {
            redoStack.Push(text);
            text = undoStack.Pop();
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }

    static void Redo()
    {
        if (redoStack.Count > 0)
        {
            undoStack.Push(text);
            text = redoStack.Pop();
        }
        else
        {
            Console.WriteLine("Nothing to redo.");
        }
    }

    static void Main()
    {
        Type("Hello");
        Console.WriteLine($"Text: {text}");

        Type(" World");
        Console.WriteLine($"Text: {text}");

        Undo();
        Console.WriteLine($"After Undo: {text}");

        Redo();
        Console.WriteLine($"After Redo: {text}");

        Undo();
        Undo();
        Console.WriteLine($"After two Undos: {text}");

        Redo();
        Console.WriteLine($"After Redo: {text}");

        Undo();
        Undo();
        Undo();
        Console.WriteLine($"After multiple Undos: {text}");

        Redo();
        Console.WriteLine($"After Redo on empty redo stack: {text}");

        Type("New Start");
        Console.WriteLine($"Text: {text}");

        Redo();
        Console.WriteLine($"After Redo (should not restore old text): {text}");
    }
}
