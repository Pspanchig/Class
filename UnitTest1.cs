namespace code;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test(){
        var heap = new BinaryHeap<int>{};
        heap.Add(3);
        heap.Add(2);
        heap.Add(1);
        Assert.That(heap.Count, Is.EqualTo(3));
        Assert.That(heap.RemoveMin(), Is.EqualTo(1));
        Assert.That(heap.RemoveMin(), Is.EqualTo(2));
        Assert.That(heap.RemoveMin(), Is.EqualTo(3));

    }

    [Test]
    public void HeapifyDemo()
    {
        var heap = new BinaryHeap<int>{new int []{1,2,3,1,2,3}};
        Assert.That(heap.RemoveMin(), Is.EqualTo(1));
        Assert.That(heap.RemoveMin(), Is.EqualTo(2));
        Assert.That(heap.RemoveMin(), Is.EqualTo(3));
        Assert.That(heap.RemoveMin(), Is.EqualTo(1));
        Assert.That(heap.RemoveMin(), Is.EqualTo(2));
        Assert.That(heap.RemoveMin(), Is.EqualTo(3));
    }
}

public class BinaryHeap<T> where T: IComparable<T>{

    
    private List<T> values;
    // private List<T> values = new List<T>(default);
    private void Heapify(){
        for(int i = (values.Count-1)/2; i >= 0; i++){
            ShiftDown(i)
        }
    }
    public BinaryHeap(IEnumerable<T> initialValues){
        values.AddRange(initialValues);
    }
    public BinaryHeap(){
        
    }
    public void Add(T value){
        values.Add(value);
        BubbleUp(values.Count -1);
    }
    private void BubbleUp(int count){
        if(count < 2) return;
        int parentIndex = count/2;
        // if(values[count])
    }
    private int GetLastChildIndex(int index){
        int LeftChildIndex = index * 2;
        int RightChildIndex = LeftChildIndex + 1;
        if(LeftChildIndex >= values.Count){
            return-1;
        }
        else if(LeftChildIndex == values.Count){
            return LeftChildIndex;
        }
        
        if(values[LeftChildIndex].CompareTo(values[RightChildIndex]) < 0){
            return LeftChildIndex;
        }
        else{
            return RightChildIndex;
        }
    }
    public int Count()
    {
        return values.Count - 1;
    }

    private void Sawp(int i, int j){
        T oldAtI = values[i];
        values[i] = values [j];
        values[j] = oldAtI;
    }

    public T RemoveMin(){
        var minvalue = values[1];
        values.RemoveAt(values.Count - 1);
        // values.RemoveAt.values.Count - 1; 
        ShiftDown(1);
        return minvalue;
    }
    private void ShiftDown(int i){
        var leastChildrenIndex = GetLastChildIndex(i);
        if(leastChildrenIndex >= 0 && values[i].CompareTo(values[leastChildrenIndex]) > 0){
            Sawp(i, leastChildrenIndex);
            ShiftDown(leastChildrenIndex);
        }
        
    }

}