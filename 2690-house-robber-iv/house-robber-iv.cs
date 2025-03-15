public class Solution {
    public int MinCapability(int[] nums, int k) {
        int left = 1;
        int right = 1000000000;
        
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (CanRobAtLeastK(nums, mid, k)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
    
    private bool CanRobAtLeastK(int[] nums, int capability, int k) {
        int count = 0;
        int i = 0;
        
        while (i < nums.Length) {
            if (nums[i] <= capability) {
                count++;
                i += 2;
            } else {
                i++;
            }
        }
        
        return count >= k;
    }
}