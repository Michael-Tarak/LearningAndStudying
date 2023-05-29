public class Solution {
    public String longestPalindrome(String s) {
        int longestLength = 0;
        var result = new String();
        if(s.length() > 0){
            longestLength = 1;
            if(s.length() > 1){
                var longestPal = new String();
                longestPal = String.valueOf(s.charAt(1));
                for (int i = 1; i < s.length() - 1; i++){
                    var step = 1;
                    while (i - step >=0 && i + step <s.length()){
                        if (s.charAt(i - step) == s.charAt(i + step)){
                            longestPal = s.charAt(i - step) + longestPal + s.charAt(i + step);
                            step++;
                            if (longestPal.length() > longestLength){
                                result = longestPal;
                            }
                        }
                        else {
                            break;
                        }
                    }
                }
                return result;
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