
public class Solution {
    public long ColoredCells(int n) {
        if (n <= 0) return 0;
        
        long blueCount = 1L;
        long previousBoundary = 1L;
        long currentBoundary = 4L;
        
        for (int minute = 2; minute <= n; minute++) {
            blueCount += currentBoundary;
            previousBoundary = currentBoundary;
            currentBoundary = previousBoundary + 4;
        }
        
        return blueCount;
    }
}