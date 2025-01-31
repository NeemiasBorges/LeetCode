public class Solution {
    private int n;
    private Dictionary<int, int> areas;
    private int[] dx = {-1, 1, 0, 0};
    private int[] dy = {0, 0, -1, 1};

    public int LargestIsland(int[][] grid) {
        n = grid.Length;
        areas = new Dictionary<int, int>();
        int islandId = 2;
        int maxArea = 0;
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    int area = DFS(grid, i, j, islandId);
                    areas[islandId] = area;
                    maxArea = Math.Max(maxArea, area);
                    islandId++;
                }
            }
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) {
                    HashSet<int> neighbors = new HashSet<int>();
                    int totalArea = 1;

                    for (int k = 0; k < 4; k++) {
                        int ni = i + dx[k];
                        int nj = j + dy[k];
                        
                        if (IsValid(ni, nj) && grid[ni][nj] > 1) {
                            int id = grid[ni][nj];
                            if (!neighbors.Contains(id)) {
                                neighbors.Add(id);
                                totalArea += areas[id];
                            }
                        }
                    }
                    maxArea = Math.Max(maxArea, totalArea);
                }
            }
        }

        return maxArea == 0 ? n * n : maxArea;
    }

    private int DFS(int[][] grid, int i, int j, int islandId) {
        if (!IsValid(i, j) || grid[i][j] != 1) return 0;
        
        grid[i][j] = islandId;
        int area = 1;

        for (int k = 0; k < 4; k++) {
            area += DFS(grid, i + dx[k], j + dy[k], islandId);
        }

        return area;
    }

    private bool IsValid(int i, int j) {
        return i >= 0 && i < n && j >= 0 && j < n;
    }
}