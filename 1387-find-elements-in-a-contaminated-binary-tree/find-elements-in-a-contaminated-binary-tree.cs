public class FindElements {
    private HashSet<int> values;
    private TreeNode root;

    public FindElements(TreeNode root) {
        this.root = root;
        values = new HashSet<int>();
        RecoverTree(root, 0);
    }

    private void RecoverTree(TreeNode node, int value) {
        if (node == null) return;
        
        node.val = value;
        values.Add(value);
        
        RecoverTree(node.left, 2 * value + 1);
        RecoverTree(node.right, 2 * value + 2);
    }
    
    public bool Find(int target) {
        return values.Contains(target);
    }
}