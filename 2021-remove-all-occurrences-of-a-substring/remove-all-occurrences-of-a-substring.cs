public class Solution {
    public string RemoveOccurrences(string s, string part) {
        while (s.Contains(part)) {
            s = s.Remove(s.IndexOf(part), part.Length);
        }
        return s;
    }
}