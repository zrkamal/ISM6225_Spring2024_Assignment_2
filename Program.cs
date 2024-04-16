﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

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
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
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
                if (nums == null || nums.Length < 1 || nums.Length > 312) //Consrtaint for array length
                {
                    throw new Exception("Array does not match criteria; Array length must be equal to or larger than 1 AND smaller than or equal to 312"); //Exeption error message
                }

                int uniqueK = 1; //Intializing the K value as the first value is always unique

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] >= -100 && nums[i] <= 100 && nums[i] != nums[uniqueK - 1]) //loop and constraint for array value
                    {
                        nums[uniqueK] = nums[i];
                        uniqueK++;
                    }
                }
                return uniqueK; ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); //Exeption error message
                throw;
            }
        }

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
                if (nums == null || nums.Length < 1 || nums.Length > 104) //Consrtaint for array length
                {
                    throw new Exception("Array does not match criteria; Array length must be equal to or larger than 1 AND smaller than or equal to 104"); //Exeption error message
                }

                int index = 0;

                for (int i = 0; i < nums.Length; i++) //loop on array
                {
                    if (nums[i] < -231 || nums[i] > 230) //Consrtaint for array value
                    {
                        throw new Exception("Array does not match criteria; Array value must be equal to or larger than -231 AND smaller than or equal to 230."); //Exeption error message
                    }

                    if (nums[i] != 0) // check if value is not 0
                    {
                        nums[index++] = nums[i]; //add value back to the array then incrament the index
                    }
                }

                while (index < nums.Length)
                {
                    nums[index++] = 0; //fill values with 0
                }

                return nums; //return new array
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); //Exeption error message
                throw;
            }
        }

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
                if (nums == null || nums.Length < 3 || nums.Length > 3000) //Consrtaint for array length
                {
                    throw new Exception("Array does not match criteria; Array length must be equal to or larger than 3 AND smaller than or equal to 3000");
                }

                foreach (var num in nums)
                {
                    if (num < -105 || num > 105) //Consrtaint for array value
                    {
                        throw new Exception("Array does not match criteria; Array value must be equal to or larger than -105 AND smaller than or equal to 105");
                    }
                }

                IList<IList<int>> result = new List<IList<int>>();

                Array.Sort(nums); //sort the array

                for (int i = 0; i < nums.Length - 2; i++) //Go through combinations of triplets
                {
                    if (i > 0 && nums[i] == nums[i - 1])  //skip the first element
                        continue;

                    for (int j = i + 1; j < nums.Length - 1; j++)
                    {
                        if (j > i + 1 && nums[j] == nums[j - 1]) //skip the second element
                            continue;

                        for (int k = j + 1; k < nums.Length; k++)
                        {
                            if (k > j + 1 && nums[k] == nums[k - 1]) //skip the third element
                                continue;

                            if (nums[i] + nums[j] + nums[k] == 0)//if triplet is found
                            {
                                List<int> triplet = new List<int> { nums[i], nums[j], nums[k] };
                                result.Add(triplet); //add to result
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); //Error message
                throw;
            }
        }

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
                if (nums == null || nums.Length < 1 || nums.Length > 105) //Consrtaint for array length
                {
                    throw new Exception("Array does not match criteria; Array length must be equal to or larger than 1 AND smaller than or equal to 105");
                }

                int maxOnes = 0; //intialize max count

                int currentCount = 0; //intilaize current count

                foreach (var num in nums)
                {
                    if (num < 0 || num > 1) //Consrtaint for array value
                    {
                        throw new Exception("Array does not match criteria; Array value must be equal to or larger than 0 AND smaller than or equal to 1");
                    }

                    if (num == 1) //check if value is 1
                    {
                        currentCount++; //Increment current count
                    }
                    else
                    {
                        if (currentCount > maxOnes) //check if current count is bigger than maxOnes
                        {
                            maxOnes = currentCount; //set maxOnes to CurrentCount
                        }

                        currentCount = 0; //reset current count
                    }
                }

                if (currentCount > maxOnes) //check if current count is bigger than maxOnes
                {
                    maxOnes = currentCount; //set maxOnes to currentCount
                }

                return maxOnes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); //Error message
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
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
                if (binary < 1 || binary > 1000000000) //Consrtaint for array value
                {
                    throw new Exception("Value does not match criteria; Value must be equal to or larger than 1 AND smaller than or equal to 1000000000"); //Error message
                }

                int decimalValue = 0;
                int baseValue = 1;

                while (binary > 0)
                {
                    int lastDigit = binary % 10; //find the last digit of the value
                    binary = binary / 10; //remove the last digit

                    decimalValue += lastDigit * baseValue; //calculate the decimal value of the current binary digit position

                    baseValue *= 2; //increment
                }

                return decimalValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); //Error message
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
                if (nums == null || nums.Length < 1 || nums.Length > 105) //Constraint
                {
                    throw new Exception("Array does not match criteria; Array length must be equal to or larger than 1 AND smaller than or equal to 105");
                }

                foreach (int num in nums)
                {
                    if (num < 0 || num > 109)  //Constraint
                    {
                        throw new Exception("Value does not match criteria; Value  must be equal to or larger than 1 AND smaller than or equal to 109");
                    }
                }

                int maxDiff = 0;

                for (int i = 1; i < nums.Length; i++)
                {
                    int diff = nums[i] - nums[i - 1];
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }

                return maxDiff;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

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
                if (nums == null || nums.Length < 3 || nums.Length > 104) //Constraint
                {
                    throw new Exception("Array does not match criteria; Array length must be equal to or larger than 3 AND smaller than or equal to 104");
                }


                foreach (int num in nums)
                {
                    if (num < 1 || num > 1000000) //Constraint
                    {
                        throw new ArgumentException("Array does not match criteria; Array value must be equal to or larger than 0 AND smaller than or equal to 1");
                    }
                }

                Array.Sort(nums); //sort

                int largestPerimeter = 0;

                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    int a = nums[i - 2];

                    int b = nums[i - 1];

                    int c = nums[i];

                    if (a + b > c)
                    {

                        int perimeter = a + b + c; //calculate the perimeter of the triangle

                        if (perimeter > largestPerimeter)
                        {
                            largestPerimeter = perimeter;
                        }
                    }
                }

                return largestPerimeter;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"); //Error message
                throw;
            }
        }

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
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
             int index =0;
             int pleng = part.Length;
             int sleng = s.length;
             string result = "";
             
             while (index <= sleng - pleng)
             {
              bool found = true;
             for (int i = 0; i < pleng; i++)
             {
                if (s[index + i] != part[i])
                {
                    found = false;
                    break;
                }
             }
              if (found)
            {
                index += pleng; 
            }
            else
            {
               
                result += s[index];
                index++;
            }
             while (index < sleng)
        {
            result += s[index];
            index++;
        }
             }
             return result;
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
