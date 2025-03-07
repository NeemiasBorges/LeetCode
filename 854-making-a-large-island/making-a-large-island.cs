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
                    int area = DFS(grid, i, j, colorIndex);
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
                        int newRow = i + dir[0];
                        int newCol = j + dir[1];
                        
                        if (IsValid(newRow, newCol) && grid[newRow][newCol] > 1) {
                            neighborColors.Add(grid[newRow][newCol]);
                        }
                    }
                    
                    foreach (var color in neighborColors) {
                        totalArea += areaMap[color];
                    }
                    
                    maxArea = Math.Max(maxArea, totalArea);
                }
            }
        }
        
        return maxArea == 0 ? n * n : maxArea;
    }
    
    private int DFS(int[][] grid, int row, int col, int colorIndex) {
        if (!IsValid(row, col) || grid[row][col] != 1) return 0;
        
        grid[row][col] = colorIndex;
        int area = 1;
        
        foreach (var dir in directions) {
            area += DFS(grid, row + dir[0], col + dir[1], colorIndex);
        }
        
        return area;
    }
    
    private bool IsValid(int row, int col) {
        return row >= 0 && row < n && col >= 0 && col < n;
    }
}