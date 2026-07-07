namespace SearchOpti;
 
public static class SearchAlgos
{
    public static int LinearSearch(List<Product> products, int targetId, out long comparisons)
    {
        comparisons = 0;
        for (int i = 0; i < products.Count; i++)
        {
            comparisons++;
            if (products[i].ProductId == targetId)
            {
                return i;
            }
        }
        return -1;
    }
 
    public static int BinarySearch(List<Product> sortedProducts, int targetId, out long comparisons)
    {
        comparisons = 0;
        int low = 0;
        int high = sortedProducts.Count - 1;
 
        while (low <= high)
        {
            comparisons++;
            int mid = low + (high - low) / 2;
            int midId = sortedProducts[mid].ProductId;
 
            if (midId == targetId)
            {
                return mid;
            }
            else if (midId < targetId)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return -1;
    }
}