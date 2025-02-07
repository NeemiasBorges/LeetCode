public class Solution {
    public int[] QueryResults(int limit, int[][] queries) {
        Dictionary<int, int> ballColors = new Dictionary<int, int>();
        Dictionary<int, int> colorCount = new Dictionary<int, int>();
        int[] result = new int[queries.Length];
        
        for (int i = 0; i < queries.Length; i++) {
            int ball = queries[i][0];
            int color = queries[i][1];
            
            if (ballColors.ContainsKey(ball)) {
                int oldColor = ballColors[ball];
                colorCount[oldColor]--;
                if (colorCount[oldColor] == 0) {
                    colorCount.Remove(oldColor);
                }
            }
            
            ballColors[ball] = color;
            if (!colorCount.ContainsKey(color)) {
                colorCount[color] = 0;
            }
            colorCount[color]++;
            
            result[i] = colorCount.Count;
        }
        
        return result;
    }
}