public class Solution {
    public int MaximumCount(int[] nums) {
        int negCount = 0;
        int posCount = 0;
        
        foreach (int num in nums) {
            if (num < 0) {
                negCount++;
            } else if (num > 0) {
                posCount++;
            }
        }
        
        return Math.Max(negCount, posCount);
    }
}