using System;
using UnityEngine;

public static class RandomPlus
{
    //used for many random functions that i dont want to put in random places of the code
    public static int[] GenerateUniqueRandomNumbers(int min, int max, int count)
    {
        if (max - min + 1 < count)
        {
            Debug.LogError("Range is too small!");
            return null;
        }

        // Create an array of all possible numbers
        int[] numbers = new int[max - min + 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = min + i;
        }

        // Fisher-Yates shuffle (modern version)
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int j = UnityEngine.Random.Range(i, numbers.Length);
            // Swap
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }

        // Take the first 'count' elements
        int[] result = new int[count];
        Array.Copy(numbers, result, count);
        return result;
    }
}
