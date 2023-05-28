import java.util.ArrayList;

public class Solution {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        ArrayList<Integer> merged = new ArrayList<>();
        var firstIterator = 0;
        var secondIterator = 0;
        while (nums1.length > firstIterator || nums2.length > secondIterator){
            if (nums1.length > firstIterator && nums2.length > secondIterator) {
                if (nums1[firstIterator] >= nums2[secondIterator]) {
                    merged.add(nums2[secondIterator]);
                    secondIterator++;
                } else {
                    merged.add(nums1[firstIterator]);
                    firstIterator++;
                }
                continue;
            }
            if (nums1.length <= firstIterator){
                merged.add(nums2[secondIterator]);
                secondIterator++;
            }
            if (nums1.length > firstIterator){
                merged.add(nums1[firstIterator]);
                firstIterator++;
            }
        }

        if (merged.size() % 2 == 1)
            return merged.get(merged.size()/2 );
        else {
            return ((double) merged.get(merged.size()/2 - 1) + (double) merged.get(merged.size()/2)) / 2;
        }
    }
}