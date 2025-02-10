public class Solution {
    public string ClearDigits(string s) {
        List<char> chars = s.ToList();
        
        while (true) {
            int digitIndex = -1;
            for (int i = 0; i < chars.Count; i++) {
                if (char.IsDigit(chars[i])) {
                    digitIndex = i;
                    break;
                }
            }
            
            if (digitIndex == -1) break;
            
            int leftCharIndex = -1;
            for (int i = digitIndex - 1; i >= 0; i--) {
                if (!char.IsDigit(chars[i])) {
                    leftCharIndex = i;
                    break;
                }
            }
            
            if (leftCharIndex >= 0) {
                chars.RemoveAt(digitIndex);
                chars.RemoveAt(leftCharIndex);
            } else {
                chars.RemoveAt(digitIndex);
            }
        }
        
        return new string(chars.ToArray());
    }
}