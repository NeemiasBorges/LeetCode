public class Solution {
    public long CountBadPairs(int[] nums) {
        Dictionary<int, long> freq = new Dictionary<int, long>();
        long totalPairs = (long)nums.Length * (nums.Length - 1) / 2;
        long goodPairs = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            int key = nums[i] - i;
            if (freq.ContainsKey(key)) {
                goodPairs += freq[key];
                freq[key]++;
            } else {
                freq[key] = 1;
            }
        }
        
        return totalPairs - goodPairs;
    }
}
