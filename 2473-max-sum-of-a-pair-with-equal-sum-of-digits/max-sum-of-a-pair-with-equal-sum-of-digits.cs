
public class Solution {
    public int MaximumSum(int[] nums) {
        Dictionary<int, int> digitSumMap = new Dictionary<int, int>();
        int maxSum = -1;

        foreach (int num in nums) {
            int digitSum = GetDigitSum(num);

            if (digitSumMap.ContainsKey(digitSum)) {
                maxSum = Math.Max(maxSum, digitSumMap[digitSum] + num);
                digitSumMap[digitSum] = Math.Max(digitSumMap[digitSum], num);
            } else {
                digitSumMap[digitSum] = num;
            }
        }

        return maxSum;
    }

    private int GetDigitSum(int num) {
        int sum = 0;
        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}
