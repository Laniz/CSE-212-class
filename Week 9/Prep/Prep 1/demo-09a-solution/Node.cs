namespace demo_09a;

public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    /// <summary>
    /// This function will look for a place to insert a node
    /// with 'value' inside of it. The current subtree is
    /// represented by this instance of Node. This function
    /// is intended to be called the first time by the
    /// BinarySearchTree.Insert function.
    /// </summary>
    public void Insert(int value) {
        if (value < Data) {
            // The value belongs on the left side
            if (Left is null) {
                // We found an empty spot
                Left = new Node(value);
            }
            else {
                // Need to keep looking; Call Insert
                // recursive on the left subtree
                Left.Insert(value);
            }
        }
        else {
            // The value belongs on the right side
            if (Right is null) {
                // We found an empty spot
                Right = new Node(value);
            }
            else {
                // Need to keep looking; Call Insert
                // recursive on the right subtree
                Right.Insert(value);
            }
        }
    }
}