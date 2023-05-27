import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        var sol = new Solution();
        System.out.println(Arrays.toString(sol.twoSum(new int []{2,7,11,15},9)));
        System.out.println(Arrays.toString(sol.twoSum(new int []{3,2,4},6)));
        System.out.println(Arrays.toString(sol.twoSum(new int []{3,3},6)));
        }
    }
class Solution {
    public int[] twoSum(int[] nums, int target) {
        var result = new int [2];
        for(int i=0;i< nums.length - 1; i++){
            for (int j = i + 1;j <nums.length; j++){
                if(nums[i]+nums[j] == target)
                    result= new int[]{nums[i], nums[j]};
            }
        }
        return result;
    }
}