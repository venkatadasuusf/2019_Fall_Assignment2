/*
    Author: Venkata Dasu, Syam Godavarthi, Yunus Rouhan
    Date: 10/6/2019
    Assignment: ISM 6225 Distributed Information systems F19 Assignment 2
    Comments: This project provides the code for Assignment 2.
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
               Use the try catch block to validate user input.
               If the user provides bad input, the catch block
               will handle the error.
            */
            try
            {
                // START Question # 1

                /* Mark gives Sherlock an array of distinct sorted integers (sorted in ascending order) along with a target value. 
                   His challenge is to return the index of the target if it is found in the array. In case he is not able to find the target, 
                   he will return the index where the target could be inserted so as the array still remains sorted
                */

                int target = 9;
                int[] nums = { 1, 3, 5, 7, 9, 11, 12, 14 };

                Console.WriteLine("***** Question # 1 Output *****");
                Console.WriteLine("");
                Console.Write("Input array is: ");
                DisplayArray(nums);
                Console.WriteLine("");
                Console.WriteLine("Input array size is: " + nums.Length);
                Console.WriteLine("Target number is: " + target);

                /*
                Execute the SearchInsert method and pass the input array and target number as inputs.
                This is a static value return method. The method returns an integer. 
                */
                Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

                // END Question # 1

                // START Question # 2

                // Given two arrays nums1 and nums2, write a function to compute their intersection                

                int[] nums1 = { 3, 6, 6 };
                int[] nums2 = { 6, 3, 1, 7, 3 };

                Console.WriteLine("***** Question # 2 Output *****");
                Console.WriteLine("");
                Console.Write("Input array 1 is: ");
                DisplayArray(nums1);
                Console.WriteLine("");
                Console.Write("Input array 2 is: ");
                DisplayArray(nums2);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Intersection of two arrays is: ");

                /*
                Execute the Intersect method and pass the two arrays inputs.
                This is a static value return method. The method returns an array of integers. 
                */
                int[] intersect = Intersect(nums1, nums2);

                DisplayArray(intersect);
                Console.WriteLine("\n");

                // END Question # 2

                // START Question # 3

                /* Given an array of integers A, return the largest integer that only occurs once.
                   If no integer occurs once, return -1
                */

                int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };

                Console.WriteLine("***** Question # 3 Output *****");
                Console.WriteLine("");
                Console.Write("Input array A is: ");
                DisplayArray(A);
                Console.WriteLine("");
                Console.WriteLine("");

                /*
                Execute the LargestUniqueNumber method and pass the input array.
                This is a static value return method. The method returns the
                largest integer that only occurs once. 
                */
                Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

                // END Question # 3

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
                if (ValidPalindrome(s))
                {
                    Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
                }
                else
                {
                    Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
                }

            }   // End of try

            catch
            {
                Console.WriteLine("Exception occured while running the Assignment 2 methods");
                Console.ReadKey(true);
            }   // End of catch            

        }   // End of Main

        /*
            This method prints the values of an integer array. 
        */
        public static void DisplayArray(int[] a)
        {
            Console.Write("[");
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
            Console.Write("]");
        }
        // End of DisplayArray

        /*
            This method prints the values of an 2D integer array. 
        */
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
        // End of Display2DArray

        /*
            This is a static value return method that expects one array as input 
            The method searches (binary search algorithm) for the target number in the input array. 
            This method returns the index of the target if it is found in the array. 
            In case target is not found, will return the index where the target 
            could be inserted so as the array still remains sorted
            The method returns an integer. 
            The time complexity of this method is less than O(n).
        */
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // get_middle will be used to get the element in the middle of the array. Initialize to 0 for now.
                int get_middle = 0;
                // This is the lower element of the array. Initialize to 0 for now. 
                int low = 0;
                // This is the upper element of the array
                int high = (nums.Length) - 1;
                // This is the middle of the array. mid is rounded down automatically if (low + high) is not an even number
                int mid = (low + high) / 2;
                // This variable is used to track where the middle is. You will later in this code how this prevents an infinite loop in the Binary Search
                int track_middle = 0;
                // This variable is calculate the time complexity (number of steps)
                int loopCount = 0;

                // Here is the Binary Search Algorithm. The time complexity is O(log n)
                while (low <= high)
                {
                    //increment loopcount each time while loop is executed
                    loopCount++;
                    // Reset mid each time the while iterates
                    mid = (low + high) / 2;
                    // Get the middle element in the binary_search array
                    // Reset get middle each time the while loop iterates
                    get_middle = nums[mid];
                    // This will test to true if the match in the Binary Search is found
                    if (get_middle == target)
                    {
                        Console.WriteLine("Method completed in " + loopCount + " steps.");
                        Console.WriteLine("");
                        //if target number is found, the index is mid
                        return mid;
                    }
                    // The && get_middle != track_middle test is conducted in case an integer is entered by the user that does not exist in the array
                    // Also, this if statement is used to re-assign the value of high if needed 
                    if (get_middle > target && get_middle != track_middle)
                    {
                        high = mid - 1;
                        // Keep track of the middle by assigning the current middle value (get_middle) to track_middle
                        track_middle = get_middle;
                    }
                    // This re-assigns the value of low as needed in the loop
                    else
                    {
                        // If no match is found, low will continue to increase 1 more until it exceeds high (as tested in the while loop), then the loop will stop
                        // Otherwise, low will be used to continue the search
                        low = mid + 1;
                    }

                }   // End of while

                // If a match is not found in the while loop about, this means that the value of low has exceeded high.
                // The value of low is tracked in the else statement within the while loop above
                if (low > high)
                {
                    Console.WriteLine("Method completed in " + loopCount + " steps.");
                    Console.WriteLine("");

                    //if target number is NOT found, the index is low where the target should be inserted
                    return low;
                }

            }   // End of try

            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }   // End of catch

            return 0;
        }
        // End of SearchInsert

        /*
            This is a static value return method that expects two arrays as inputs 
            The method computes the intersection and returns the elements in the results as many
            times as they show in both arrays.            
            The method returns an integer array.
            The time complexity of this method is O(n).
        */
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                //using the dictionary to store the elements of one array
                Dictionary<int, int> numbers1 = new Dictionary<int, int>();

                // This list will store the final result
                List<int> intersect_list = new List<int>();

                /*  Moving the elements from array nums1 to Dictionary numbers1
                    If the key (element from array nums1) already exists, incrementing the value count
                    to track if the element exists more than once in array nums1
                    Time complexity O(n)
                */
                foreach (int element in nums1)
                {
                    if (numbers1.ContainsKey(element))
                    {
                        numbers1[element]++;
                    }
                    else
                    {
                        numbers1.Add(element, 1);
                    }
                }   // End foreach

                /*  Searching for intersecting numbers between array nums2 with Dictionary numbers1
                    Each time the element from array nums2 is found in Dictionary numbers1, decreasing the 
                    element count by 1
                    Time complexity O(n)
                */
                foreach (int element in nums2)
                {
                    if (numbers1.ContainsKey(element) && numbers1[element] > 0)
                    {
                        intersect_list.Add(element);
                        numbers1[element]--;
                    }
                }   // End foreach

                //returning the array of intersecting elements to main method
                return intersect_list.ToArray();

            }   // End of try

            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
                return null;
            }   // End of catch

        }
        // End of Intersect

        /*
            This is a static value return method that expects one array as input 
            This method returns the largest integer that only occurs once.
            If no integer occurs once, return -1
            The method returns an integer. 
            The time complexity of this method is less than O(n).
        */
        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                //using the dictionary to store the elements of the array
                Dictionary<int, int> A_dict = new Dictionary<int, int>();

                // Using variable largest_integer and assigning a default value of -1
                int largest_integer = -1;
                int first_iteration = 1;

                /*  Moving the elements from array A to Dictionary A_dict
                    If the key (element from array A) already exists, incrementing the value count
                    to track if the element exists more than once in array A
                    Time complexity O(n)
                */
                foreach (int element in A)
                {
                    if (A_dict.ContainsKey(element))
                    {
                        A_dict[element]++;
                    }
                    else
                    {
                        A_dict.Add(element, 1);
                    }
                }

                foreach (var element in A_dict)
                {
                    //Assigning the first value of the dictionary as largest integer 
                    if ((first_iteration == 1) && (element.Value == 1))
                    {
                        largest_integer = element.Key;
                        first_iteration = 0;
                    }
                    //Checking for largets integer as long as it exists only once
                    else if ((element.Key > largest_integer) && (element.Value == 1))
                    {
                        largest_integer = element.Key;
                    }
                }

                return largest_integer;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");

            }

            return -1;
        }
        // End of LargestUniqueNumber

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
                //int c = 0;

                char[] lstc = word.ToCharArray();

                //int c = 0;
                int klen = keyboard.Length - 1;

                Dictionary<String, String> d = new Dictionary<string, string>();
                if (keyboard.Any(char.IsLower) && keyboard.Length == 26 && word.Any(char.IsLower) && (word.Length <= 10 || word.Length >= 1))
                {
                    Dictionary<char, int> dict = new Dictionary<char, int>();

                    int char_value = 0;

                    foreach (char c in keyboard)
                    {
                        dict.Add(c, char_value++);
                    }

                    int time = 0;
                    int prev_char_value = 0;

                    foreach (char c in word)
                    {
                        //Console.WriteLine(c);
                        if (dict[c] > prev_char_value)
                        {
                            time = time + (dict[c] - prev_char_value);
                        }
                        else if (dict[c] < prev_char_value)
                        {
                            time = time + (prev_char_value - dict[c]);
                        }
                        else { }
                        prev_char_value = dict[c];
                    }
                    Console.WriteLine("");
                    Console.WriteLine(time);
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
                int n = A.Length;
                // first dived array into part negative and positive  
                int k;
                for (k = 0; k < n; k++)
                {
                    if (A[k] >= 0)
                        break;
                }
                // Now do the same process that we learn  
                // in merge sort to merge to two sorted array  
                // here both two half are sorted and we traverse  
                // first half in reverse meaner because  
                // first half contains negative element  
                int i = k - 1; // Initial index of first half  
                int j = k; // Initial index of second half  
                int ind = 0; // Initial index of temp array

                int[] temp = new int[n];
                while (i >= 0 && j < n)
                {
                    if (A[i] * A[i] < A[j] * A[j])
                    {
                        temp[ind] = A[i] * A[i];
                        i--;
                    }
                    else
                    {
                        temp[ind] = A[j] * A[j];
                        j++;
                    }
                    ind++;
                }
                while (i >= 0)
                {
                    temp[ind++] = A[i] * A[i];
                    i--;
                }
                while (j < n)
                {
                    temp[ind++] = A[j] * A[j];
                    j++;
                }

                // copy 'temp' array into original array  
                for (int x = 0; x < n; x++)
                    A[x] = temp[x];
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
