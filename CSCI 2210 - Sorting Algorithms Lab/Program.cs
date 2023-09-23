using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Concurrent;
using System.IO.Pipes;

string filePath = "RandomOrder_10000.csv";

using (StreamReader sr = new StreamReader(filePath))
{
    string line;
    while ((line = sr.ReadLine()) != null)
    {
        string[] values = line.Split(',');
        int[] integers = new int[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            if (int.TryParse(values[i], out int intValue))
            {
                integers[i] = intValue;
            }
            else
            {
                Console.WriteLine($"Invalid integer: {values[i]}");
            }
        }

        Console.WriteLine("Which sorting method would you like to see (insertion or selection)?");
        string answer = Console.ReadLine().ToUpper();
        switch(answer)
        {
            case "INSERTION":
                    InsertionSort(integers);
                Console.WriteLine("Sorted Array:");
                foreach (int num in integers)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
                break;
            case "SELECTION":
                    SelectionSort(integers);
                Console.WriteLine("Sorted Array:");
                foreach (int num in integers)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Invalid answer. Please try again.");
                break;
        }
        InsertionSort(integers);

        
    }
}

void SelectionSort(int[] arr)//4.346
{
    int n = arr.Length;

    for (int i = 0; i < n - 1; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < n; j++)
        {
            if (arr[j] < arr[minIndex])
            {
                minIndex = j;
            }
        }

        int temp = arr[i];
        arr[i] = arr[minIndex];
        arr[minIndex] = temp;
    }
}
static void InsertionSort(int[] arr)//2.568
{
    for (int i = 1; i < arr.Length; i++)
    {
        int key = arr[i];
        int j = i - 1;

        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j = j - 1;
        }

        arr[j + 1] = key;

    }
}