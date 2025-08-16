namespace ConsoleAppAlgorithmsExamples.AlgorithmExercises;

//Model a train where cars can attach/detach from both ends.
internal class TrainComposition
{
    private readonly LinkedList<int> list = new LinkedList<int>();
    public void AttachLeft(int carId)
    {
        list.AddFirst(carId);
    }

    public void AttachRight(int carId)
    {
        list.AddLast(carId);
    }

    public int DetachLeft()
    {
        var left = list.FirstOrDefault();
        list.RemoveFirst();
        return left;
    }

    public int DetachRight()
    {
        var right = list.LastOrDefault();
        list.RemoveLast();
        return right;
    }
}
