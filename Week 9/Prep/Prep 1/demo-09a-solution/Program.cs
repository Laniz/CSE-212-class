using demo_09a;

BinarySearchTree tree = new BinarySearchTree();

tree.Insert(5);
tree.Insert(3);
tree.Insert(7);
tree.Insert(10);
tree.Insert(1);

foreach (var item in tree) {
    Console.WriteLine(item);
}