import java.util.ArrayList;
import java.util.List;

class Solution {
    public String convert(String s, int numRows) {
        if (numRows == 1) {
        return  s;
        }
        List<StringBuilder> words = new ArrayList<>();
        for (int i = 0; i < numRows; i++) {
            words.add(new StringBuilder());
        }

        int [] stages = new int [s.length()];
        var index = 0;
        var increaser = 1;
        for (int i = 0; i < s.length(); i++) {
            stages[i] = index;
            index += increaser;
            if (index == 0 || index == numRows - 1) {
                increaser *= -1;
            }
        }

        for (int i = 0; i < s.length(); i++) {
            words.get(stages[i]).append(s.charAt(i));
        }

        StringBuilder result = new StringBuilder();
        for (StringBuilder word : words) {
            result.append(word.toString());
        }
        return result.toString();
    }
}
