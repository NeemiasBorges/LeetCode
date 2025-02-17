public class Solution {
    public int NumTilePossibilities(string tiles) {
        HashSet<string> sequences = new HashSet<string>();
        bool[] used = new bool[tiles.Length];
        char[] chars = tiles.ToCharArray();
        Array.Sort(chars);
        
        DFS("", chars, used, sequences);
        
        return sequences.Count;
    }
    
    private void DFS(string current, char[] tiles, bool[] used, HashSet<string> sequences) {
        if (current.Length > 0) {
            sequences.Add(current);
        }
        
        for (int i = 0; i < tiles.Length; i++) {
            if (used[i]) continue;
            
            if (i > 0 && tiles[i] == tiles[i - 1] && !used[i - 1]) continue;
            
            used[i] = true;
            DFS(current + tiles[i], tiles, used, sequences);
            used[i] = false;
        }
    }
}