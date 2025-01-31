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
                    HashSet<int> neighborColors = new HashSet<int>();
                    int totalArea = 1;
                    
                    foreach (var dir in directions) {
                        int ni = i + dir[0];
                        int nj = j + dir[1];
                        
                        if (IsValid(ni, nj) && grid[ni][nj] > 1) {
                            neighborColors.Add(grid[ni][nj]);
                        }
                    }
                    
                    foreach (int color in neighborColors) {
                        totalArea += areaMap[color];
                    }
                    
                    maxArea = Math.Max(maxArea, totalArea);
                }
            }
        }
        
        return maxArea == 0 ? n * n : maxArea;
    }
    
    private int ColorIsland(int[][] grid, int i, int j, int color) {
        if (!IsValid(i, j) || grid[i][j] != 1) return 0;
        
        grid[i][j] = color;
        int area = 1;
        
        foreach (var dir in directions) {
            area += ColorIsland(grid, i + dir[0], j + dir[1], color);
        }
        
        return area;
    }
    
    private bool IsValid(int i, int j) {
        return i >= 0 && i < n && j >= 0 && j < n;
    }
}