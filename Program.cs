using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {


        public static int[] TwoSum(int[] nums, int target)
        {
            var arlength = nums.Length;
            var result = new int[2];
            int i, j;
            for (i = 0; i < arlength; i++)
            {
                for (j = i + 1; j < arlength; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }

        public static int MaxSubArray(int[] nums)
        {
            var tempMax = nums[0];
            int currentMax = tempMax;
            for (int i = 1; i < nums.Length; i++)
            {
                currentMax = nums[i] > currentMax + nums[i] ? nums[i] : currentMax + nums[i];
                tempMax = currentMax > tempMax ? currentMax : tempMax;
            }
            return tempMax;
        }

        public static IList<int> SpiralOrder(int[,] matrix)
        {
            int i = 0, j = 0, temp = 0;
            List<int> result = new List<int>();
            while (result.Count() < (matrix.GetLength(0) * matrix.GetLength(1)))
            {
                result.Add(matrix[i, j]);
                if (i == 0 || j < matrix.GetLength(1) - 1)
                    j++;
                else if (i < matrix.GetLength(0) - 1)
                    i++;
            }
            return result;
        }

        public static void MoveZeroes(int[] nums)
        {
            int freespace = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    count++;
                }
                else
                {
                    nums[freespace] = nums[i];
                    freespace++;
                }
            }
            for (int i = nums.Length - 1; i >= (nums.Length - count); i--)
            {
                nums[i] = 0;
            }
            foreach (var num in nums)
            {
                Console.Write(num);
            }
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            return nums.Count() > nums.Distinct().Count();
        }

        public static void Rotate(int[] nums, int k)
        {
            for (int i = 0; i < k; i++)
            {
                int temp = nums[nums.Length - 1];
                for (int j = nums.Length - 1; j > 0; j--)
                {
                    nums[j] = nums[j - 1];
                }
                nums[0] = temp;
            }

            foreach (var num in nums)
            {
                Console.Write(num);
            }
        }

        public static string LongestWord(string sen)
        {
            char[] s = sen.ToCharArray();
            string result = "";
            string finalResult = "";
            for (int i = 0; i < sen.Length; i++)
            {
                if (char.IsLetter(s[i]))
                    result = result + sen[i];
                else
                    result = string.Empty;
                if (result.Length > finalResult.Length)
                    finalResult = result;
            }
            return finalResult;

        }

        public static void HastTest()
        {
            Hashtable test = new Hashtable();
            test.Add("Thomas", 26);
            test.Add("James", 23);
            test.Add("Mathew", 55);
            test.Add("Shiny", 51);
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test["Mathew"]);
            test.Remove("James");
            Console.WriteLine(test["James"]);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("test", 24);
            dict.Add("ert", 23);
            Console.WriteLine(dict["test"]);
        }

        public static int? FirstDuplicat(int[] ar)
        {
            string ab = "adigsi";
            Console.WriteLine(ab.ToCharArray().Reverse().ToArray());
            //var test = new Dictionary<int, int>();
            //foreach (var a in ar)
            //{
            //    if (test.ContainsKey(a))
            //        return a;
            //    test.Add(a, 0);
            //}
            //return 0;
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[i] == ar[j])
                        return ar[i];
                }
            }
            return null;
        }

        //public static IList<IList<int>> Sum4(int[] nums, int target)
        //{
        //    int sum = 0, counter = 1;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        var internalList = new List<int>();
        //        internalList.Add(nums[i]);
        //        for (int j = 0; j < nums.Length; j++)
        //        {
        //            if (i == j)
        //                continue;
        //            else
        //            {
        //                internalList.Add(nums[j]);
        //            }
        //        }
        //    }
        //}

        //public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        //{
        //}
        public static long Factorial(int value)
        {
            if (value > 0)
                return value * Factorial(value - 1);
            return 1;
        }

        public static long Fibonacci(int value)
        {
            if (value < 2)
                return value;
            return Fibonacci(value - 1) + Fibonacci(value - 2);
        }

        public static void BubbleSort(int[] arr)
        {
            var timer = DateTime.Now;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            foreach (var a in arr)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Time" + (DateTime.Now - timer).TotalSeconds.ToString());
        }

        public static void SelectionSort(int[] arr)
        {
            var timer = DateTime.Now;
            for (int i = 0; i < arr.Length; i++)
            {
                int index = i;
                var temp = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[index])
                    {
                        index = j;
                    }
                }
                arr[index] = temp;
                arr[i] = arr[index];
            }
            foreach (var a in arr)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Time" + (DateTime.Now - timer).TotalSeconds.ToString());
        }

        public static void InsertionSort(int[] arr)
        {
            var timer = DateTime.Now;
            int n = arr.Length, val, flag;
            for (int i = 1; i < n; i++)
            {
                val = arr[i];
                flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < arr[j])
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        arr[j + 1] = val;
                    }
                    else flag = 1;
                }
            }
            foreach (var a in arr)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Time" + (DateTime.Now - timer).TotalSeconds.ToString());
        }

        public static List<int> MergeSort(List<int> arr)
        {
            if (arr.Count == 1)
            {
                return arr;
            }
            else
            {
                var middle = arr.Count / 2;
                var leftAr = SplitArray(arr, 0, middle);
                var rightAr = SplitArray(arr, middle);

                return Merge(MergeSort(leftAr), MergeSort(rightAr));
            }
        }

        private static List<int> SplitArray(List<int> arr, int start, int? end = null)
        {
            List<int> ar = new List<int>();
            var last = end != null ? end : arr.Count;
            for (int i = start; i < last; i++)
            {
                ar.Add(arr[i]);
            }
            return ar;
        }

        private static List<int> Merge(List<int> larr, List<int> rarr)
        {
            int leftindex = 0, rightindex = 0;
            List<int> result = new List<int>();
            while (leftindex < larr.Count && rightindex < rarr.Count)
            {
                if (larr[leftindex] < rarr[rightindex])
                {
                    result.Add(larr[leftindex]);
                    leftindex++;
                }
                else
                {
                    result.Add(rarr[rightindex]);
                    rightindex++;
                }
            }
            return result.Concat(SplitArray(larr, leftindex)).Concat(SplitArray(rarr, rightindex)).ToList();
        }

        static void Main(string[] args)
        {
            int[] a = new int[] { 0, 9, 9, 0, 3, 2, 1, 7, 4, 5, 92, 2, 4, 78, 35, 754, 822, 745, 655, 310, 390, 99 };
            //BubbleSort(a);
            //SelectionSort(a);
            //InsertionSort(a);
            var timer = DateTime.Now;
            List<int> result = MergeSort(a.ToList());
            Console.WriteLine("Time" + (DateTime.Now - timer).TotalSeconds.ToString());
            foreach (var r in result)
                Console.WriteLine(r);
            //var test = ContainsDuplicate(a);
            //Rotate(a, 4);
            //Console.Write(FirstDuplicat(a));
            //HastTest();
            //Console.Write(test);
            //MoveZeroes(a);
            //var test = TwoSum(a, 26);
            //Console.WriteLine(MaxSubArray(a));
            //Console.Read();
            //var matrix = new int[3, 3]
            //{
            //    {1,2,3 },
            //    { 4,5,6},
            //    {7,8,9 }
            //};

            //var result = SpiralOrder(matrix);
            //foreach (var r in result)
            //    Console.WriteLine(r);
            //SinglyLinkedList
            //var test = new LinkedListUser(10);
            //test.Append(5);
            //test.Append(11);
            //test.Append(13);
            //test.Append(45);
            //test.Append(552);
            //test.Prepend(0);
            //test.Insert(3, 4);
            //var test1 = new LinkedListUser(15);
            //test1.Append(5);
            //test1.Append(532);
            //test.Remove(5);
            //var test2 = new LinkedListUser(new List<int> { 3, 6, 2, 7, 2, 78 });
            //test.Print();
            //Console.WriteLine("Length " + test.GetLength());
            //test1.Print();
            //Console.WriteLine("Length " + test1.GetLength());
            //test2.Reverse();
            //test2.Print();
            //Console.WriteLine("Length " + test2.GetLength());


            ////DoublyLinkedList
            //var dtest = new DoublyLinkedListUser(34);
            //dtest.Append(35);
            //dtest.Append(5);
            //dtest.Append(435);
            //dtest.Print();
            //Console.WriteLine("Length " + dtest.GetLength());

            //var dtest1 = new DoublyLinkedListUser(new List<int> { 3, 5, 82, 233 });
            //dtest1.Prepend(47);
            //dtest1.Insert(2, 90);
            //dtest1.Remove(3);
            //dtest1.Print();
            //Console.WriteLine("Length " + dtest1.GetLength());

            //var stest = new StackUser();
            //stest.Push(100);
            //stest.Push(12);
            //stest.Push(3);
            //stest.Pop();
            //Console.WriteLine(stest.Peek());

            //var test = new BinarySearchTree();
            //test.Insert(5);
            //test.Insert(48);
            //test.Insert(78);
            //test.Insert(2);
            //test.Insert(67);
            //test.Insert(1);
            //test.Insert(-23);
            //test.Insert(45);
            //test.Insert(0);
            //var look = test.Lookup(45);

            //var test = new UserGraph();
            //test.AddVertex(0);
            //test.AddVertex(1);
            //test.AddVertex(2);
            //test.AddVertex(3);
            //test.AddVertex(4);
            //test.AddVertex(5);
            //test.AddVertex(6);
            //test.AddEdges(6, 5);
            //test.AddEdges(5, 4);
            //test.AddEdges(4, 3);
            //test.AddEdges(1, 3);
            //test.AddEdges(1, 2);
            //test.AddEdges(1, 0);
            //test.AddEdges(2, 4);
            //test.AddEdges(2, 0);

            //Console.WriteLine(Factorial(5));
            //Console.WriteLine(Fibonacci(5));

            Console.Read();

        }
    }
}
