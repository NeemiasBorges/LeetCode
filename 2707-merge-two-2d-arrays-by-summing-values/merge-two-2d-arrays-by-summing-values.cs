public class Solution {
    public int[][] MergeArrays(int[][] nums1, int[][] nums2) {
        Dictionary<int, int> mergedDict = new Dictionary<int, int>();
        
        foreach (var pair in nums1) {
            mergedDict[pair[0]] = pair[1];
        }
        
        foreach (var pair in nums2) {
            if (mergedDict.ContainsKey(pair[0])) {
                mergedDict[pair[0]] += pair[1];
            } else {
                mergedDict[pair[0]] = pair[1];
            }
        }
        
        int[][] result = new int[mergedDict.Count][];
        int index = 0;
        
        foreach (var kvp in mergedDict.OrderBy(x => x.Key)) {
            result[index] = new int[] { kvp.Key, kvp.Value };
            index++;
        }
        
        return result;
    }
}