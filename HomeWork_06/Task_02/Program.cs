namespace Task_02
{
    internal class Program
    {
        public static int Сandy(int[] ratings)
        {
            if (ratings == null || ratings.Length == 0)
            {
                return 0;
            }

            int start = 0;
            int sum = 0;

            while (start < ratings.Length)
            {
                if (start + 1 < ratings.Length && ratings[start] == ratings[start + 1])
                {
                    sum += 1;
                    start++;
                    continue;
                }
                int left = 0;
                int right = 0;

                while (start + 1 < ratings.Length && ratings[start] < ratings[start + 1])
                {
                    start++;
                    left++;
                }

                while (start + 1 < ratings.Length && ratings[start] > ratings[start + 1])
                {
                    start++;
                    right++;
                }

                if (left == 0 && right == 0)
                {
                    sum += 1;
                    break;
                }

                int max = Math.Max(left, right) + 1;
                int leftSum = (1 + left) * left / 2;
                int rightSum = (1 + right) * right / 2 - 1;
                sum += max + leftSum + rightSum;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int[] ratings = { 1, 2, 2 };

            Console.WriteLine(Сandy(ratings));
        }
    }
}

//There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.

//You are giving candies to these children subjected to the following requirements:

//Each child must have at least one candy.
//Children with a higher rating get more candies than their neighbors.
//Return the minimum number of candies you need to have to distribute the candies to the children.


//Input: ratings = [1, 2, 2]
//Output: 4
