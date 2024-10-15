using System;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinarySearchTree
{
    public TreeNode root;

    public void Operate(TreeNode node, int val, string operation)
    {
        if (root == null)
        {
            root = new TreeNode(val);
            return;
        }

        if (operation == "insert")
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
        else if (operation == "search")
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
        else if (operation == "inOrder")
        {
            if (node != null)
            {
                Operate(node.left, val, operation);
                Console.Write($"{node.val} ");
                Operate(node.right, val, operation);
            }
        }
        else if (operation == "preOrder")
        {
            if (node != null)
            {
                Console.Write($"{node.val} ");
                Operate(node.left, val, operation);
                Operate(node.right, val, operation);
            }
        }
        else if (operation == "postOrder")
        {
            if (node != null)
            {
                Operate(node.left, val, operation);
                Operate(node.right, val, operation);
                Console.Write($"{node.val} ");
            }
        }
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
