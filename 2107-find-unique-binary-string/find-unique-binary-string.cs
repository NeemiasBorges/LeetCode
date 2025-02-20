public class Solution {
    public string FindDifferentBinaryString(string[] nums) {
        StringBuilder result = new StringBuilder();
        
        for (int i = 0; i < nums.Length; i++) {
            result.Append(nums[i][i] == '0' ? '1' : '0');
        }
        
        return result.ToString();
    }
}