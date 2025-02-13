public class Solution {
    public int MinOperations(int[] nums, int k) {
        PriorityQueue<long, long> pq = new();
        
        foreach (int num in nums) {
            pq.Enqueue(num, num);
        }
        
        int operations = 0;
        
        while (pq.Count >= 2 && pq.Peek() < k) {
            long x = pq.Dequeue();
            long y = pq.Dequeue();
            
            long newValue = Math.Min(x, y) * 2 + Math.Max(x, y);
            pq.Enqueue(newValue, newValue);
            
            operations++;
        }
        
        return operations;
    }
}