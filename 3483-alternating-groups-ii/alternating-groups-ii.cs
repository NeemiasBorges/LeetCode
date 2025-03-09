public class Solution {
    public int NumberOfAlternatingGroups(int[] colors, int k) {
        int n = colors.Length;
        if (n < k) return 0;
        
        if (k > 2) {
            bool allAlternating = true;
            for (int i = 0; i < n; i++) {
                if (colors[i] == colors[(i + 1) % n]) {
                    allAlternating = false;
                    break;
                }
            }
            
            if (allAlternating) {
                return n;
            }
        }
        
        if (k > 1000 && n > 1000) {
            int[] pattern = new int[2];
            int count = 0;
            
            for (int i = 0; i < n; i++) {
                bool isValid = true;
                pattern[0] = colors[i];
                pattern[1] = 1 - pattern[0]; 
                
                for (int j = 0; j < k; j++) {
                    int expectedColor = pattern[j % 2];
                    int actualColor = colors[(i + j) % n];
                    
                    if (actualColor != expectedColor) {
                        isValid = false;
                        break;
                    }
                }
                
                if (isValid) {
                    count++;
                }
            }
            
            return count;
        }
        
        int[] colorCount = new int[2];
        int validGroups = 0;
        
        bool isFirstValid = true;
        for (int i = 0; i < k - 1; i++) {
            if (colors[i] == colors[i + 1]) {
                isFirstValid = false;
                break;
            }
        }
        
        if (isFirstValid) {
            validGroups++;
        }
        
        for (int i = 1; i < n; i++) {
            int startIdx = i;
            int endIdx = (i + k - 1) % n;
            
            bool isCurrentValid = true;
            for (int j = 0; j < k - 1; j++) {
                int currentIdx = (startIdx + j) % n;
                int nextIdx = (startIdx + j + 1) % n;
                
                if (colors[currentIdx] == colors[nextIdx]) {
                    isCurrentValid = false;
                    break;
                }
            }
            
            if (isCurrentValid) {
                validGroups++;
            }
        }
        
        return validGroups;
    }
}