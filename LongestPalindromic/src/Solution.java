public class Solution {
    public String longestPalindrome(String s) {
        int longestLength = 0;
        var result = "";
        if(s.length() > 0){
            longestLength = 1;
            if(s.length() > 1){
                result = String.valueOf(s.charAt(0));
                for (int i = 0; i < s.length() - 1; i++){
                    cycle :for (int j = i + 1; j < s.length(); j++){
                        var currentWord = "";
                        currentWord = s.substring(i, j + 1);
                        for (int k = 0; k < currentWord.length() / 2 + 1; k++){
                            if (currentWord.charAt(k) != currentWord.charAt(currentWord.length() - k - 1)) {
                                continue cycle;
                            }
                        }
                        if (longestLength < currentWord.length()){
                            longestLength = currentWord.length();
                            result = currentWord;
                        }
                    }
                }
                return  result;
            }
            else {
                return s;
            }
        }
        else {
            return "";
        }
    }
}