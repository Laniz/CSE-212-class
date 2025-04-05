using System;

class TreeNode {
    public int Value { get; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public TreeNode(int value) {
        Value = value;
        Left = null;
        Right = null;
    }
}

class BST {
    public TreeNode? Root { get; private set; }

    public BST() {
        Root = null;
    }

    public void Insert(int value) {
        Root = InsertRec(Root, value);
    }

    private TreeNode InsertRec(TreeNode? node, int value) {
        if (node == null) return new TreeNode(value);

        if (value < node.Value) {
            node.Left = InsertRec(node.Left, value);
        }
        else if (value > node.Value) {
            node.Right = InsertRec(node.Right, value);
        }

        return node;
    }

    public bool Contains(int value) {
        return ContainsRec(Root, value);
    }

    private bool ContainsRec(TreeNode? node, int value) {
        if (node == null) return false;

        if (value == node.Value) {
            return true;
        }
        else if (value < node.Value) {
            return ContainsRec(node.Left, value);
        }
        else {
            return ContainsRec(node.Right, value);
        }
    }
}

class Program {
    static void Main() {
        BST tree = new BST();
        int[] values = { 40, 20, 60, 10, 30, 50, 70 };

        foreach (int val in values) {
            tree.Insert(val);
        }

        Console.WriteLine(tree.Contains(30));  // Output: True
        Console.WriteLine(tree.Contains(25));  // Output: False
        Console.WriteLine(tree.Contains(70));  // Output: True
    }
}
