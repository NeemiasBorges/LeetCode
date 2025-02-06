public class Solution {
    public int TupleSameProduct(int[] nums) {
        Dictionary<int, int> productCount = new Dictionary<int, int>();
        int n = nums.Length;
        
        for (int i = 0; i < n - 1; i++) {
            for (int j = i + 1; j < n; j++) {
                int product = nums[i] * nums[j];
                if (!productCount.ContainsKey(product)) {
                    productCount[product] = 0;
                }
                productCount[product]++;
            }
        }
        
        int result = 0;
        foreach (var count in productCount.Values) {
            if (count > 1) {
                result += count * (count - 1) * 4;
            }
        }
        
        return result;
    }
}