using System.Collections;

namespace demo_09a;
// CSE 212 Lesson 9A
// Implementation of a basic Binary Search Tree data structure.

public class BinarySearchTree : IEnumerable<int> {
    private Node? _root;

    /// <summary>
    /// Insert 'value' into the BST.  If the BST is empty, then
    /// set the root equal to the new node. Otherwise, use
    /// Node.Insert to recursively find the location to insert.
    /// </summary>
    public void Insert(int value) {
        if (_root is null)
            _root = new Node(value);
        else
            _root.Insert(value); // Start inserting at the root
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the typed version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers) {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values) {
        if (node is not null) {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    public override string ToString() {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}