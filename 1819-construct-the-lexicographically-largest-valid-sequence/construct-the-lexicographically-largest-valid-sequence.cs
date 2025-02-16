public class Solution {
    public int[] ConstructDistancedSequence(int n) {
        int[] result = new int[2 * n - 1];
        bool[] used = new bool[n + 1];
        Backtrack(0, result, used, n);
        return result;
    }

    private bool Backtrack(int pos, int[] result, bool[] used, int n) {
        if (pos == result.Length) 
            return true;
            
        if (result[pos] != 0) 
            return Backtrack(pos + 1, result, used, n);
            
        for (int i = n; i >= 1; i--) {
            if (used[i]) 
                continue;
                
            if (i == 1) {
                result[pos] = i;
                used[i] = true;
                if (Backtrack(pos + 1, result, used, n)) 
                    return true;
                used[i] = false;
                result[pos] = 0;
            }
            else {
                if (pos + i >= result.Length || result[pos + i] != 0) 
                    continue;
                    
                result[pos] = i;
                result[pos + i] = i;
                used[i] = true;
                
                if (Backtrack(pos + 1, result, used, n)) 
                    return true;
                    
                used[i] = false;
                result[pos] = 0;
                result[pos + i] = 0;
            }
        }
        
        return false;
    }
}