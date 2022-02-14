using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;

namespace Kattis_Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0,1,2, 3,12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit"};
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is :{0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:

            Console.WriteLine("Question 7:");
            string bulls_string10 = "(){}[]";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();

            //Question 8:

            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            /*Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();*/

            //Question 10:
            /*Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();*/
        }
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int min = 0;                //declaring the integer min
                int max = nums.Length - 1;  //declaring the integer max
                int last = -1;
                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    if (target == nums[mid])  //comparing the target value with the middle number of the array
                    {
                        last = mid;
                        break;
                    }
                    else if (target < nums[mid])
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }

                }
                if (last == -1)//checking if whether we found the target value or not
                {
                    last = min;// this gives the position where the value has to be inserted
                }
                return last;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                string k = "";//Declaring a new string
                foreach (char z in paragraph)//eliminating the special characters from the string
                {
                    if (z != '!' && z != '?' && z != '\'' && z != ';' && z != ',' && z != '.')
                    {
                        k = k + z;
                    }
                    else
                    {
                        k = k + ' ';
                    }
                }
                string a1 = k.ToLower();//converting the new string to lower case
                string[] a2 = a1.Split(" ");//splitting the string with a Space (" ") and storing in the new string
                foreach (string x in a2)//eliminating the spaces created while removing special characters
                {
                    a2 = a2.Where(y => y != "").ToArray();
                }
                foreach (string x in banned)// eliminating the banned elements
                {
                    a2 = a2.Where(y => y != x.ToLower()).ToArray();
                }
                Dictionary<string, int> lookup = new Dictionary<string, int>();//Disctionary has been created to store the values
                foreach (string a in a2.Distinct())// to lookup the distinct strings in the a2 array 
                {
                    int count = 0;
                    foreach (string b in a2)// using this to find the count of each string
                    {
                        if (a == b)
                        {
                            count = count + 1;//incrementing the count value
                        }
                    }
                    lookup.Add(a, count);//adding both the string and count to dictionary
                }
                string final = "";
                foreach (KeyValuePair<string, int> x in lookup)
                {
                    if (x.Value == lookup.Values.Max())
                    {
                        final = x.Key;
                    }
                }
                return final;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static int FindLucky(int[] arr)
        {
            try
            {
                int L = arr.Length;// declaring an integer that defines the lenght of the array
                Array.Sort(arr);
                ArrayList result = new ArrayList();
                int[] distArr = arr.Distinct().ToArray();
                int[] count = new int[distArr.Length]; // declaring the integer array, that stores the count
                for (int i = 0; i < count.Length; i++) 
                {
                    count[i] = arr.Count(s => s == distArr[i]);
                }
                for (int i = 0; i < count.Length; i++)
                {
                    if (distArr[i] == count[i])  //checking if the charecters are the same in both the arrays
                    {
                        result.Add(distArr[i]);
                    }
                }
                int final = -1;        //intialising the integer 'final' to -1
                if (result.Count != 0)
                {
                    final = (int)result[result.Count - 1];
                }

                return final;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string GetHint(string secret, string guess)
        {
            try
            {
                string a1 = ""; 
                string a2 = ""; 
                int b = 0;      //Declaring the integer b
                int c = 0;      //Declaring the integer c
                for (int i = 0; i < secret.Length; i++)
                {
                    if (secret[i] == guess[i])  //checking if anyone of the charecter in the secret string is same as that of the charecters in guess string
                    {
                        b = b + 1;              // this shows the bulls count
                    }
                    else
                    {
                        a1 = a1 + secret[i];    
                        a2 = a2 + guess[i];
                    }
                }
                foreach (char z in a2)
                {
                    int flag = 0;
                    for (int j = 0; j < a1.Length; j++)
                    {
                        if (z == a1[j] & flag == 0)     //Comparing each charecter in both a1 and a2 arrays
                        {
                            a1 = a1.Remove(j, 1);
                            c = c + 1;            // this shows the cows count
                            flag = 1;
                        }
                    }
                }
                string final = b + "A" + c + "B";  //Final output string 
                return final;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int len = s.Length;              //declaring the integer len
                List<int> k = new List<int>();   //creating a list 'z'
                int[] x = new int[26];           //integer array of maximum length 26
                for (int i = len - 1; i >= 0; i--) 
                {
                    if (x[s[i] - 97] == 0)
                    {
                        x[s[i] - 97] = i;
                    }
                }
                int y = 0;
                while (y < len)
                {
                    int a = y;
                    int b = x[s[y] - 97];
                    int c = b - a + 1;
                    for (int t = a; t <= b; t++)
                    {
                        if (x[s[t] - 97] > b)
                        {
                            b = x[s[t] - 97];
                            c = b - a + 1;
                        }
                    }
                    k.Add(c);                        //adding up to the list
                    y = b + 1;
                }
                return k;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int a1 = widths.Length;   //declaring the integer a1
                int a2 = s.Length;        //declaring the integer a2
                Dictionary<char, int> lookup = new Dictionary<char, int>();
                for (int i = 0; i < a1; i++)
                {
                    int temp = i + 97;
                    char x = Convert.ToChar(temp);
                    lookup.Add(x, widths[i]);
                }
                int sum = 0;
                int count = 0;
                for (int i = 0; i < a2; i++)
                {
                    int temp = lookup[s[i]];
                    if (sum + temp > 100)
                    {
                        sum = temp;
                        count = count + 1;
                    }
                    else if (sum + temp == 100 & i != (a2 - 1))
                    {
                        sum = 0;
                        count = count + 1;
                    }
                    else if (sum + temp == 100 & i == (a2 - 1))
                    {
                        sum = sum + temp;
                        count = count + 1;
                    }
                    else
                    {
                        sum = sum + temp;
                    }
                }
                if (sum < 100)
                {
                    count = count + 1;
                }
                List<int> result = new List<int>();
                result.Add(count);
                result.Add(sum);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                int l = bulls_string10.Length;
                ArrayList check = new ArrayList();
                Dictionary<string, string> lookup = new Dictionary<string, string>();
                lookup.Add("}", "{");
                lookup.Add("]", "[");
                lookup.Add(")", "(");
                int counter = -1;
                for (int i = 0; i < l; i++)
                {
                    string a = bulls_string10[i].ToString();
                    if (lookup.ContainsValue(a))
                    {
                        check.Add(a);
                        counter = counter + 1;//getting current size of arraylist
                    }
                    else if (lookup.ContainsKey(a) & counter != -1)
                    {
                        if (lookup[a] == check[counter].ToString())
                        {
                            check.RemoveAt(counter);
                            counter = counter - 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (counter == -1)
                    {
                        return false;
                    }
                }
                if (counter != -1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] lookup = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                int l1 = words.Length;
                string[] final = new string[l1];  //declaring the string
                for (int i = 0; i < l1; i++)
                {
                    string x = words[i];    
                    int l2 = x.Length;
                    string p = "";
                    for (int j = 0; j < l2; j++)
                    {
                        int y = x[j] - 97;
                        p = p + lookup[y];
                    }
                    final[i] = p;
                }
                int count = final.Distinct().Count(); //initialised the integer 'count', to get the count of distinct elements in the final string
                return count;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}