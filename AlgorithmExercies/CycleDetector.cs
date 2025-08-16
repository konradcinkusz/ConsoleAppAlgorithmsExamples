using ConsoleAppAlgorithmsExamples.Models;

namespace ConsoleAppAlgorithmsExamples.AlgorithmExercises;

internal class CycleDetector
{
    //O(n) -> time
    //O(1) -> space
    public bool HasCycle(Node? head)
    {
        var slow = head;
        var fast = head;

        while (fast != null && fast.Next != null)
        {
            //core logic

            slow = slow.Next;
            fast = fast.Next.Next;

            if (slow == fast)
            {
                return true; //pointers met
            }
        }

        return false;
    }

    //O(n) -> space
    public bool HasCycleWithHashSet(Node? head)
    {
        var seen = new HashSet<Node>();
        while (head != null)
        {
            if (!seen.Add(head)) return true;
            head = head.Next;
        }
        return false;
    }
}
