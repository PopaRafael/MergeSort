using System;

namespace MergeSort
{
    class Program
    {
        static void Main()
        {
            int[] arr = GenerateRandomArray(10, 10, 1000);

            Console.WriteLine("Original Array:");
            PrintArray(arr);

            MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine("\nSorted Array:");
            PrintArray(arr);
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                // Recursively divide the array into two halves.
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                // Merge the two sorted halves.
                Merge(arr, left, middle, right);
            }
        }

        static void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temporary arrays to hold the two halves.
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Copy data to the temporary arrays.
            for (int i = 0; i < n1; i++)
                leftArray[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                rightArray[j] = arr[middle + 1 + j];

            int x = 0, y = 0, k = left;

            // Merge the two halves back into the original array.
            while (x < n1 && y < n2)
            {
                if (leftArray[x] <= rightArray[y])
                {
                    arr[k] = leftArray[x];
                    x++;
                }
                else
                {
                    arr[k] = rightArray[y];
                    y++;
                }
                k++;
            }

            // Copy any remaining elements from leftArray and rightArray if needed.
            while (x < n1)
            {
                arr[k] = leftArray[x];
                x++;
                k++;
            }

            while (y < n2)
            {
                arr[k] = rightArray[y];
                y++;
                k++;
            }
        }

        static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] randomArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue + 1);
            }

            return randomArray;
        }

        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }

}
