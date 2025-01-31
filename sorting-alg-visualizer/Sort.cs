using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sorting_alg_visualizer
{
    public class Sort
    {
        public int[] Sorting(int[] array, string sortingAlg, PictureBox displayBox)
        {

            SortingStats.Reset();
            //bubble, selection, insertion, merge, quick, heap, radix, counting, bucket, shell
            switch (sortingAlg)
            {
                case "Bubble": return BubbleSort(array, displayBox);
                case "Selection": return SelectionSort(array, displayBox);
                case "Insertion": return InsertionSort(array, displayBox);
                case "Quick": return QuickSort(array, displayBox);
                case "Heap": return HeapSort(array, displayBox);
                case "Radix": return RadixSort(array, displayBox);
                case "Shell": return ShellSort(array, displayBox);
            } 
            return array;
        }

        // bubble
        private int[] BubbleSort(int[] arr, PictureBox displayBox)
        {
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    SortingStats.Comparisons++;
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        update(displayBox, arr);
                    }
                }
            }

            return arr;
        }

        // selection
        private int[] SelectionSort(int[] arr, PictureBox displayBox)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    SortingStats.Comparisons++;
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if (min != i) { 
                    int temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                    update(displayBox, arr);
                }
            }
            return arr;
        }

        // insertion
        private int[] InsertionSort(int[] arr, PictureBox displayBox)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    SortingStats.Comparisons++;
                    if (key < arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = key;
                        update(displayBox, arr); ;
                    }
                    else flag = 1;
                }
            }
            return arr;
        }

        // quick
        private int[] QuickSort(int[] arr, PictureBox displayBox)
        {
            void Sort(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int pivotIndex = Partition(array, low, high);
                    Sort(array, low, pivotIndex - 1);
                    update(displayBox, arr);
                    Sort(array, pivotIndex + 1, high);
                    update(displayBox, arr);
                }

            }

            int Partition(int[] array, int low, int high)
            {
                int pivot = array[high];
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    SortingStats.Comparisons++; // Increment comparisons

                    if (array[j] <= pivot)
                    {
                        i++;
                        (array[i], array[j]) = (array[j], array[i]);
                        update(displayBox, arr);
                    }
                }

                (array[i + 1], array[high]) = (array[high], array[i + 1]);
                update(displayBox, arr);

                return i + 1;
            }

            Sort(arr, 0, arr.Length - 1);
            return arr;
        }

        // heap
        private int[] HeapSort(int[] arr, PictureBox displayBox)
        {
            if (arr == null || arr.Length <= 1)
                return arr;

            void Heapify(int[] array, int n, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                if (left < n)
                {
                    SortingStats.Comparisons++; 
                    if (array[left] > array[largest])
                        largest = left;
                }

                if (right < n)
                {
                    SortingStats.Comparisons++; 
                    if (array[right] > array[largest])
                        largest = right;
                }

                if (largest != i)
                {
                    (array[i], array[largest]) = (array[largest], array[i]);
                    update(displayBox, arr);
                    Heapify(array, n, largest);
                }
            }

            void Sort(int[] array)
            {
                int n = array.Length;

                // Build max heap
                for (int i = n / 2 - 1; i >= 0; i--)
                    Heapify(array, n, i);

                // Extract elements from heap
                for (int i = n - 1; i > 0; i--)
                {
                    (array[0], array[i]) = (array[i], array[0]);
                    update(displayBox, arr);
                    Heapify(array, i, 0);
                }
            }

            Sort(arr);
            return arr;
        }

        // radix
        private int[] RadixSort(int[] arr, PictureBox displayBox)
        {
            int max = arr.Max();

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                int n = arr.Length;
                int[] output = new int[n];
                int[] count = new int[10];

                for (int i = 0; i < n; i++)
                {
                    SortingStats.Comparisons++; 
                    count[(arr[i] / exp) % 10]++;
                }

                for (int i = 1; i < 10; i++)
                    count[i] += count[i - 1];

                // Building output array
                for (int i = n - 1; i >= 0; i--)
                {
                    output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                    count[(arr[i] / exp) % 10]--;
                }

                // Copy sorted values back to arr[]
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] != output[i]) 
                    {
                        arr[i] = output[i];
                        update(displayBox, arr); 
                    }
                }
            }

            return arr;
        }

        //shell
        private int[] ShellSort(int[] arr, PictureBox displayBox)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;

                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        SortingStats.Comparisons++; 
                        arr[j] = arr[j - gap];
                        update(displayBox, arr); 
                    }

                    SortingStats.Comparisons++; 
                    arr[j] = temp;
                    update(displayBox, arr);
                }
            }
            return arr;
        }

        //sleeps and updates main array
        private void update(PictureBox displayBox, int[] arr)
        {
            SortingStats.Swaps++;
            // sleeps
            if (arr.Length < 500)
            {
                Thread.Sleep(30);
            }
            // updates picturebox
            displayBox.Refresh();
        }
    }
}
