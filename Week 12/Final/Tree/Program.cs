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
    
    // Helper method to insert values into the BST
    public void Insert(int value) {
        Root = InsertRec(Root, value);
    }
    
    private TreeNode InsertRec(TreeNode? node, int value) {
        if (node == null) {
            return new TreeNode(value);
        }
        
        if (value < node.Value) {
            node.Left = InsertRec(node.Left, value);
        }
        else if (value > node.Value) {
            node.Right = InsertRec(node.Right, value);
        }
        
        return node;
    }
    
    // Finds the smallest value (leftmost node)
    public int FindSmallest() {
        if (Root == null) {
            throw new InvalidOperationException("Tree is empty.");
        }
        
        TreeNode current = Root;
        while (current.Left != null) {
            current = current.Left;
        }
        return current.Value;
    }
    
    // Finds the largest value (rightmost node)
    public int FindLargest() {
        if (Root == null) {
            throw new InvalidOperationException("Tree is empty.");
        }
        
        TreeNode current = Root;
        while (current.Right != null) {
            current = current.Right;
        }
        return current.Value;
    }
    
    // Returns a tuple (smallest, largest)
    public (int smallest, int largest) GetMinMax() {
        return (FindSmallest(), FindLargest());
    }
}

class Program {
    static void Main() {
        BST tree = new BST();
        tree.Insert(40);
        tree.Insert(5);
        tree.Insert(50);
        tree.Insert(2);
        tree.Insert(10);
        tree.Insert(60);
        
        var (smallest, largest) = tree.GetMinMax();
        Console.WriteLine($"Smallest value: {smallest}");  // Output: 2
        Console.WriteLine($"Largest value: {largest}");    // Output: 60
    }
}
