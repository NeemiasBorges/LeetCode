
public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        int maxLength = 1;
        int currentIncreasing = 1;
        int currentDecreasing = 1;
        
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i-1]) {
                currentIncreasing++;
                currentDecreasing = 1;
            }
            else if (nums[i] < nums[i-1]) {
                currentDecreasing++;
                currentIncreasing = 1;
            }
            else {
                currentIncreasing = 1;
                currentDecreasing = 1;
            }
            
            maxLength = Math.Max(maxLength, Math.Max(currentIncreasing, currentDecreasing));
        }
        
        return maxLength;
    }
}
