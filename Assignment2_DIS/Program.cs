/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,,,,,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100  
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                List<int> common = new List<int>();
                for (int i = 0; i < nums.Length; i++) // started the loop
                {
                    if (!common.Contains(nums[i])) // Checking the element presence in the list
                    {
                        common.Add(nums[i]); // adding it to the list.
                    }
                }
                return common.Count; // Returning the count
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
       Self-Reflection:
       1. This code is used to remove the duplicates from the given input and keeping the unique elements.
       2. HashSet instead of a List can be a better choice for better performance.
        */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // creating an empty list
                List<int> i = new List<int>();

                // defining ct variable to store the count value
                int ct = 0;

                foreach (int num in nums)
                {
                    // adding it to the list
                    if (num != 0)
                        i.Add(num);
                    else
                        ct++; // adding the count to ct
                }

                i.AddRange(Enumerable.Repeat(0, ct));

                // Returning the list
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /*
        Self-Reflection:
        This code is used to move all non-zero elements to the start the array.

         */


        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.



        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.


        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // creating an list
                IList<IList<int>> x = new List<IList<int>>();


                if (nums == null || nums.Length < 3)
                    return x;

                // Sorting the array
                Array.Sort(nums);


                for (int i = 0; i < nums.Length - 2; i++)
                {

                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    int lt = i + 1;
                    int rt = nums.Length - 1;

                    while (lt < rt)
                    {
                        int sum = nums[i] + nums[lt] + nums[rt];

                        // Adding to the list
                        if (sum == 0)
                        {
                            x.Add(new List<int> { nums[i], nums[lt], nums[rt] });

                            // ignoring the duplicates 
                            while (l < r && nums[lt] == nums[lt + 1])
                                lt++;
                            while (l < r && nums[rt] == nums[rt - 1])
                                rt--;


                            lt++;
                            rt--;
                        }
                        // Incresing the sum
                        else if (sum < 0)
                        {
                            l++;
                        }
                        // Decreasing the sum
                        else
                        {
                            r--;
                        }
                    }
                }

                // Returning the output
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         Self-reflection:
         This code is used to find triplets that sum up to a target value. Also, we ignored duplicates to 
        have unique values in the result.
        
        */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2

        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {

                int a = 0; // storing the maximum 1s
                int b = 0; // tracking the consecutive 1s


                foreach (int num in nums)
                {
                    // Updating the maximum consecutive count
                    if (num == 1)
                    {
                        b++;
                        a = Math.Max(a, b);
                    }
                    else
                    {
                        b = 0;
                    }
                }

                // Returning the list
                return a;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Self-reflection:
        Here we are finding the maximum consecutive 1s in the given array. This approach efficiently
        finds the maximum number of consecutive 1s in the array.
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the Math.Pow function. You will implement a function called BinaryToDecimal which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the BinaryToDecimal function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (<<, >>, &, |, ^) and the Math.Pow function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimal = 0; // defining the decimal 
                int base = 1; // defining the base value

                while (binary > 0) // Iterate through the binary digits
                {
                    int lastvalue = binary % 10; // calculating the last digit 
                    binary = binary / 10; // Removing the last digit 
                    decimal += lastvalue * base; // Multiplying the last digit and adding it to the decimal value
                    base *= 2; // Increasing the base value
                }

                return decimal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.


        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {

                if (nums == null || nums.Length < 2)
                    return 0;

                // Sorting the array 
                Array.Sort(nums);

                int max = 0; // defining the max variable

                // finding the maximum difference 
                for (int i = 1; i < nums.Length; i++)
                {
                    int difference = nums[i] - nums[i - 1];

                    // Updating the difference
                    max = Math.Max(max, difference);
                }

                // Returning the max 
                return max;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        Self-reflection:
        The above code is used to find the maximum difference between two consecutive elements . Sorting the array 
        facilitates the computation of the maximum difference by arranging the elements in ascending order, 
        thereby simplifying the process of identifying the discrepancies between adjacent elements during iteration.        
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {

                if (nums == null || nums.Length < 3)
                    return 0;

                // Sorting the array
                Array.Sort(nums);

                for (int x = nums.Length - 1; x >= 2; x
                {
                    // Checking the possibility to form a triangle
                    if (nums[x - 2] + nums[x - 1] > nums[x])
                        return nums[x - 2] + nums[x - 1] + nums[x]; // Returning the perimeter of a triangle
                }

                return 0; // If the values diesn't meet the criteria, it returns 0
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Self-reflection:
        The above code is used to find the Maximum possible perimeter of a triangle using three 
         lengths from a given array. The triangle inequality theorem is followed here, i.e.,sum of the lengths
        of any two sides of a triangle must be greater than the length of the third side. 
        Initially, the array is sorted and finds the largest valid triangle perimeter efficiently.
         */


        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.



        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // creating a variable
                int loc;
                while ((loc = s.IndexOf(part)) != -1)
                {
                    // Identifying the leftmost occurrence and removing it from the original
                    s = s.Remove(loc, part.Length);
                }
                return s; // Returning the string 
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
/*
Self-reflection:
This code is used to removes occurrences of a substring from a given string until no more occurrences are left. 
This code uses the IndexOf method to find the leftmost occurrence of the substring and removes it using the Remove method. 
*/