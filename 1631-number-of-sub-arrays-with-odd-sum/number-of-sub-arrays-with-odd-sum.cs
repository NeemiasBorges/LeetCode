public class Solution {
    public int NumOfSubarrays(int[] arr) {
        const int MOD = 1000000007;
        
        int totalCount = 0;
        int currentSum = 0;
        int evenCount = 1;
        int oddCount = 0;
        
        foreach (int num in arr) {
            currentSum += num;
            
            if (currentSum % 2 == 0) {
                totalCount = (totalCount + oddCount) % MOD;
                evenCount++;
            } else {
                totalCount = (totalCount + evenCount) % MOD;
                oddCount++;
            }
        }
        
        return totalCount;
    }
}