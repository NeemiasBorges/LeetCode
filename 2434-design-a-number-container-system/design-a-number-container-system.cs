public class NumberContainers {
    private Dictionary<int, int> indexToNumber;
    private Dictionary<int, SortedSet<int>> numberToIndices;

    public NumberContainers() {
        indexToNumber = new Dictionary<int, int>();
        numberToIndices = new Dictionary<int, SortedSet<int>>();
    }
    
    public void Change(int index, int number) {
        if (indexToNumber.ContainsKey(index)) {
            int oldNumber = indexToNumber[index];
            numberToIndices[oldNumber].Remove(index);
            if (numberToIndices[oldNumber].Count == 0) {
                numberToIndices.Remove(oldNumber);
            }
        }
        
        indexToNumber[index] = number;
        if (!numberToIndices.ContainsKey(number)) {
            numberToIndices[number] = new SortedSet<int>();
        }
        numberToIndices[number].Add(index);
    }
    
    public int Find(int number) {
        return numberToIndices.ContainsKey(number) && numberToIndices[number].Count > 0 ? numberToIndices[number].Min : -1;
    }
}
