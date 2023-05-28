public class Main {
    public static void main(String[] args) {
        System.out.println(new Solution().findMedianSortedArrays(new int []{1,2},new int []{3,4}));
        System.out.println(new Solution().findMedianSortedArrays(new int []{2},new int []{1,3}));
        System.out.println(new Solution().findMedianSortedArrays(new int []{1,2,3,4,5},new int []{7,8,9,10}));
        System.out.println(new Solution().findMedianSortedArrays(new int []{0,0},new int []{0,0}));
    }
}