
public class Main {
    public static void main(String[] args) {
        var sol = new Solution();

        AnswerOutput(sol.addTwoNumbers(
                new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4)))
        ));
        System.out.println();
        AnswerOutput(sol.addTwoNumbers(
                new ListNode(0),
                new ListNode(0)
        ));
        System.out.println();
        AnswerOutput(sol.addTwoNumbers(
                new ListNode(9,new ListNode(9,new ListNode(9,new ListNode(9,new ListNode(9,new ListNode(9,new ListNode(9))))))),
                new ListNode(9,new ListNode(9,new ListNode(9,new ListNode(9))))
        ));
    }

    public static void AnswerOutput (ListNode listNode)
    {
        while (true)
        {
            System.out.print(listNode.val);
            if (listNode.next!=null)
                listNode = listNode.next;
            else
                break;
        }
    }
}

