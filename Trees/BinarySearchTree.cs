using System;

public class TreeNode // The structure of Tree node is defined so that we can effectively execute operations on the Tree.
{
    public int val; // Value that is present in the node.
    public TreeNode left; // Refers to the left node of a root node.
    public TreeNode right; // Refers to the right node of a root node.
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) // The deafult atributes of the node would be zero or null.
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinarySearchTree  // This class would use TreeNodes to apply its operations and would acts as a bianry search tree. 
{
    public TreeNode root; 

    public void Operate(TreeNode node, int val, string operation)
    {
        if (root == null)  // If the tree is empty return nothing irrespective of the operation asked to perform. Only the value that is passed in the method will be added to the root.
        {
            root = new TreeNode(val);
            return;
        }

        if (operation == "insert") // Insert the node on the place based on the logic of a binary tree.
        {
            if (node == null)
            {
                node = new TreeNode(val);
                return;
            }
            if (val < node.val)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(val);
                    return;
                }
                Operate(node.left, val, operation);
            }
            else if (val > node.val)
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(val);
                    return;
                }
                Operate(node.right, val, operation);
            }
        }
        else if (operation == "search") // Implementing search logic of binary tree
        {
            if (node == null || node.val == val)
            {
                Console.WriteLine(node != null ? $"Found: {node.val}" : "Not Found");
                return;
            }
            if (val < node.val)
                Operate(node.left, val, operation);
            else
                Operate(node.right, val, operation);
        }
        else if (operation == "inOrder")  // Initiating inOrder traversal
        {
            if (node != null)
            {
                Operate(node.left, val, operation);
                Console.Write($"{node.val} ");
                Operate(node.right, val, operation);
            }
        }
        else if (operation == "preOrder") // Initiating preOrder traversal
        {
            if (node != null)
            {
                Console.Write($"{node.val} ");
                Operate(node.left, val, operation);
                Operate(node.right, val, operation);
            }
        }
        else if (operation == "postOrder") // Initiating postOrder traversal
        {
            if (node != null)
            {
                Operate(node.left, val, operation);
                Operate(node.right, val, operation);
                Console.Write($"{node.val} ");
            }
        }  // In all of these traversals, the movement of root node would be a major indicator in telling which type of traversal is being used. 
    }

    public static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();
        bst.Operate(bst.root, 50, "insert");
        bst.Operate(bst.root, 30, "insert");
        bst.Operate(bst.root, 20, "insert");
        bst.Operate(bst.root, 40, "insert");
        bst.Operate(bst.root, 70, "insert");
        bst.Operate(bst.root, 60, "insert");
        bst.Operate(bst.root, 80, "insert");

        Console.WriteLine("In-order traversal of the given tree:");
        bst.Operate(bst.root, 0, "inOrder");
        Console.WriteLine();
        bst.Operate(bst.root, 0, "preOrder");
        Console.WriteLine();
        bst.Operate(bst.root, 0, "postOrder");
        Console.WriteLine();

        Console.WriteLine("Search for 60:");
        bst.Operate(bst.root, 60, "search");

    }
}

// Link to YouTube video explanation: https://youtu.be/498r2JXzr4Q
