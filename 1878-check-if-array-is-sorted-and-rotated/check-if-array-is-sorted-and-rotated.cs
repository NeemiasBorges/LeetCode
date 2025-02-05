public class Solution {
    public bool Check(int[] nums) {
        int n = nums.Length;
        int rotations = 0;
        
        for (int i = 1; i < n; i++) {
            if (nums[i - 1] > nums[i]) {
                rotations++;
            }
        }
        
        if (nums[n - 1] > nums[0]) {
            rotations++;
        }
        
        return rotations <= 1;
    }
}