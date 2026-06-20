using System;

public class BinarySearch
{
    public static Product Search(Product[] products, string name)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            int comparison = string.Compare(products[mid].ProductName, name, true);

            if (comparison == 0)
                return products[mid];

            else if (comparison < 0)
                left = mid + 1;

            else
                right = mid - 1;
        }

        return null;
    }
}