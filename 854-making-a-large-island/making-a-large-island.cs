public class Solution {
    int n;
    Dictionary<int, int> areaMap;
    int[][] directions = new int[][] {
        new int[] {1, 0},
        new int[] {-1, 0},
        new int[] {0, 1},
        new int[] {0, -1}
    };

    public int LargestIsland(int[][] grid) {
        n = grid.Length;
        areaMap = new Dictionary<int, int>();
        int colorIndex = 2;
        int maxArea = 0;
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    int area = ColorIsland(grid, i, j, colorIndex);
                    areaMap[colorIndex] = area;
                    maxArea = Math.Max(maxArea, area);
                    colorIndex++;
                }
            }
        }
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) {
                    HashSet<int> colors = new HashSet<int>();
                    int currentArea = 1;
                    
                    foreach (var dir in directions) {
                        int newRow = i + dir[0];
                        int newCol = j + dir[1];
                        
                        if (IsValid(newRow, newCol) && grid[newRow][newCol] > 1) {
                            colors.Add(grid[newRow][newCol]);
                        }
                    }
                    
                    foreach (int color in colors) {
                        currentArea += areaMap[color];
                    }
                    
                    maxArea = Math.Max(maxArea, currentArea);
                }
            }
        }
        
        return maxArea == 0 ? n * n : maxArea;
    }
    
    private int ColorIsland(int[][] grid, int row, int col, int color) {
        if (!IsValid(row, col) || grid[row][col] != 1) return 0;
        
        grid[row][col] = color;
        int area = 1;
        
        foreach (var dir in directions) {
            area += ColorIsland(grid, row + dir[0], col + dir[1], color);
        }
        
        return area;
    }
    
    private bool IsValid(int row, int col) {
        return row >= 0 && row < n && col >= 0 && col < n;
    }
}