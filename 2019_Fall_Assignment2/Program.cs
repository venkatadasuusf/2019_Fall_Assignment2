using System;
using System.Linq;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] matrix = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(matrix);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if(ValidPalindrome(s)) {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach(int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                //Console.WriteLine("Please enter keyboard letters :");
                //string K = Console.ReadLine();
                //Console.WriteLine("Please enter word : ");
                //string w = Console.ReadLine();
                //Checking for constriants
                
                //initializing count c
                int c = 0;
                
                if(keyboard.Any(char.IsLower) &&  keyboard.Length == 26 && word.Any(char.IsLower) && (word.Length <= 10 || word.Length >= 1))
                {
                    //Only one for loop, Hence satisfying the time complexity of O(n)
                    for (int i = 0; i < word.Length; i++)
                    {
                        //Checking and adding the sum
                        c += keyboard.IndexOf(word[i]);
                    }
                    Console.WriteLine("Count is : " + c);
                }
                else
                {
                Console.WriteLine("Please enter valid Input");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] matrix)
        {
            try
            {
                int rlen = matrix.GetLength(0);
                int clen = matrix.GetLength(1);

                //Console.WriteLine(rlen);
                //Checking for rows then columns.
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        //put a single value
                        //Console.Write(string.Format("{0} ", matrix[i, j]));
                        //Console.WriteLine();
                        //checking for constraints
                        if((rlen <= 20 || rlen >= 1) && (matrix[i,j] == 0 || matrix[i,j] == 1))
                        {
                            int l = 0, r = matrix.GetLength(1) - 1;
                            var t = matrix[i, l];

                            while (l < r)
                            {
                            matrix[i, l] = matrix[i, r];
                            matrix[i, r] = t;
                            l++; r--;
                            }
                            //Replacing the values
                            if (matrix[i,j] == 1)
                            {
                                matrix[i, j] = 0;
                            }
                            else
                            {
                                matrix[i, j] = 1;
                            }

                            //Console.WriteLine(matrix[i, j]);

                            Console.Write(matrix[i, j]);
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid Input");
                        }


                    }
                    //to print the output in matrix format
                    Console.Write(Environment.NewLine + Environment.NewLine);
   
                }
                            
                      
                                    
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                int[] start = new int[(intervals.Length) / 2];
                int[] end = new int[(intervals.Length) / 2];

                //Initializing start and end timings.
                for (int i = 0; i < (intervals.Length) / 2; i++)
                {
                    start[i] = intervals[i, 0];
                    end[i] = intervals[i, 1];

                }


                //Sorting two arrays
                Array.Sort(start);
                Array.Sort(end);

                //Dictionary to get minimum no of rooms
                Dictionary<int, int> minrooms = new Dictionary<int, int>();

                minrooms.Add(1, end[0]);

                int room = 0;

                for (int i = 1; i < start.Length; i++)
                {
                    //checking constraint
                    if (start[i] >= end[i])
                    {
                                Console.WriteLine("Invalid Input");
                    }
                    else
                    {
                        room = 0;
                        for (int j = 1; j <= (minrooms.Count); j++)
                        {
                            if (start[i] > minrooms[j])
                            {                            
                                minrooms[j] = end[i];
                                room = 1;
                                break;
                            
                            }
                        }
                    }

                    if (room == 0)
                    {
                        minrooms.Add((minrooms.Count + 1), end[i]);
                    }

                }

                Console.WriteLine(minrooms.Count);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
