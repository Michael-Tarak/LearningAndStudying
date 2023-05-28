public class Solution {
    public int lengthOfLongestSubstring(String s) {
        if(s.length() == 0)
            return 0;
        int longestWordLength = 1;

        char[] symbols = new char[s.length()];
        for (int i = 0;i < s.length(); i++){
            symbols[i] = s.charAt(i);
        }
        String currentWord = String.valueOf(symbols[0]);

        for (int i = 1; i < s.length(); i++){
            if (currentWord.contains(String.valueOf(symbols[i]))){
                if(currentWord.length() != 1)
                    currentWord = currentWord.substring(currentWord.lastIndexOf(symbols[i]) + 1) + (symbols[i]);
            }
            else {
                currentWord += String.valueOf(symbols[i]);
            }
            if (currentWord.length() > longestWordLength)
                longestWordLength = currentWord.length();
        }
        return longestWordLength;
    }
}