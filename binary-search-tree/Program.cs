internal partial class Program
{
  private static void Main(string[] args)
  {

    BinarySearchTree tree = new BinarySearchTree();

    tree.Insert(8);
    tree.Insert(3);
    tree.Insert(9);
    tree.Insert(1);
    tree.Insert(5);
    tree.Insert(7);
    tree.Insert(2);

    Console.WriteLine($"Tree contains 5: {tree.Contains(5)}");
    Console.WriteLine($"Tree contains 10: {tree.Contains(10)}");

    tree.Remove(5);

    Console.WriteLine($"Tree contains 5: {tree.Contains(5)}");

    System.Console.WriteLine("Print tree in order:");
    tree.PrintTree(tree.Root);

    System.Console.WriteLine("Print tree pre order:");
    tree.PrintTreePreOrder(tree.Root);

    System.Console.WriteLine("Print tree post order:");
    tree.PrintTreePostOrder(tree.Root);

    System.Console.WriteLine("Print tree reverse order:");
    tree.PrintTreeReverseOrder(tree.Root);

    Console.ReadLine();

  }


}

class Node
{
  public int Value { get; set; }
  public Node Left { get; set; }
  public Node Right { get; set; }

  public Node(int value)
  {
    Value = value;
  }
}

class BinarySearchTree
{
  public Node Root { get; set; }

  public void Insert(int value)
  {
    Node node = new Node(value);

    if (Root == null)
    {
      Root = node;
      return;
    }

    Node current = Root;

    while (true)
    {
      // if value is less than current node value, go left
      if (value < current.Value)
      {
        // if there is no left node, insert new node
        if (current.Left == null)
        {
          current.Left = node;
          break;
        }
        // else keep going left by setting current to current.Left
        // the while loop will continue until there is no left node
        else
        {
          current = current.Left;
        }
      }
      // if value is greater than current node value, go right
      else
      {
        // if there is no right node, insert new node
        if (current.Right == null)
        {
          current.Right = node;
          break;
        }
        // else keep going right by setting current to current.Right
        // the while loop will continue until there is no right node
        else
        {
          current = current.Right;
        }
      }
    }
  }

  public bool Contains(int value)
  {
    Node current = Root;

    // keep going left or right until current is null which means
    // we have reached the end of the tree without a matching value
    while (current != null)
    {
      // if value is less than current node value, go left
      if (value < current.Value)
      {
        current = current.Left;
      }
      // if value is greater than current node value, go right
      else if (value > current.Value)
      {
        current = current.Right;
      }
      // if value is equal to current node value, return true
      else
      {
        return true;
      }
    }

    return false;
  }

  public void Remove(int value)
  {
    Root = Remove(Root, value);
  }

  private Node Remove(Node node, int value)
  {
    // If the node is null, return null
    if (node == null)
    {
      return null;
    }

    // If the value is less than the node value, remove from the left
    if (value < node.Value)
    {
      node.Left = Remove(node.Left, value);
    }
    // If the value is greater than the node value, remove from the right
    else if (value > node.Value)
    {
      node.Right = Remove(node.Right, value);
    }
    // Otherwise, we have found the node to remove
    else
    {
      // If the node has no left child, return the right child
      if (node.Left == null)
      {
        return node.Right;
      }
      // If the node has no right child, return the left child
      else if (node.Right == null)
      {
        return node.Left;
      }
      // If the node has two children, find the minimum value in the right subtree
      else
      {
        node.Value = MinValue(node.Right);
        // Remove the minimum value in the right subtree
        // and set the right child to the result
        // (which will be the right child with the minimum value removed)
        // this keeps the tree balanced
        node.Right = Remove(node.Right, node.Value);
      }
    }

    return node;
  }

  private int MinValue(Node node)
  {
    int min = node.Value;

    while (node.Left != null)
    {
      min = node.Left.Value;
      node = node.Left;
    }

    return min;
  }

  // print in order
  public void PrintTree(Node node)
  {
    if (node == null)
    {
      return;
    }

    PrintTree(node.Left);
    Console.WriteLine(node.Value);
    PrintTree(node.Right);
  }

  public void PrintTreePreOrder(Node node)
  {
    if (node == null)
    {
      return;
    }

    Console.WriteLine(node.Value);
    PrintTreePreOrder(node.Left);
    PrintTreePreOrder(node.Right);
  }

  public void PrintTreePostOrder(Node node)
  {
    if (node == null)
    {
      return;
    }

    PrintTreePostOrder(node.Left);
    PrintTreePostOrder(node.Right);
    Console.WriteLine(node.Value);
  }

  public void PrintTreeReverseOrder(Node node)
  {
    if (node == null)
    {
      return;
    }

    PrintTreeReverseOrder(node.Right);
    Console.WriteLine(node.Value);
    PrintTreeReverseOrder(node.Left);
  }
}
