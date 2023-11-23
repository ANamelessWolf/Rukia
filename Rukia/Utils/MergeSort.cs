using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
   
    public class MergeSort
    {
        public void Sort(string[] arr)
        {
            if (arr.Length < 2) return; // base condition

            // divide the array into two halves
            int mid = arr.Length / 2;
            string[] leftArray = new string[mid];
            string[] rightArray = new string[arr.Length - mid];

            // populate the left and right arrays
            for (int i = 0; i < mid; i++)
                leftArray[i] = arr[i];
            for (int i = mid; i < arr.Length; i++)
                rightArray[i - mid] = arr[i];

            Sort(leftArray); // sort the left half
            Sort(rightArray); // sort the right half
            Merge(arr, leftArray, rightArray); // merge the two halves
        }

        void Merge(string[] arr, string[] leftArray, string[] rightArray)
        {
            int leftSize = leftArray.Length;
            int rightSize = rightArray.Length;
            int i = 0, j = 0, k = 0;

            // merge the left and right arrays into arr[]
            while (i < leftSize && j < rightSize)
            {
                if (leftArray[i].CompareTo(rightArray[j]) < 0)
                    arr[k++] = leftArray[i++];
                else
                    arr[k++] = rightArray[j++];
            }

            // copy any remaining elements of the left array
            while (i < leftSize)
                arr[k++] = leftArray[i++];

            // copy any remaining elements of the right array
            while (j < rightSize)
                arr[k++] = rightArray[j++];
        }

    }
}
