public class Solution {
    private char[] letters = new char[] { 'a', 'b', 'c' };
    private List<string> happyStrings = new List<string>();
    
    public string GetHappyString(int n, int k) {
        GenerateHappyStrings("", n);
        
        happyStrings.Sort();
        
        return k <= happyStrings.Count ? happyStrings[k - 1] : "";
    }
    
    private void GenerateHappyStrings(string current, int n) {
        if (current.Length == n) {
            happyStrings.Add(current);
            return;
        }
        
        foreach (char letter in letters) {
            if (current.Length == 0) {
                GenerateHappyStrings(current + letter, n);
            }
            else if (current[current.Length - 1] != letter) {
                GenerateHappyStrings(current + letter, n);
            }
        }
    }
}