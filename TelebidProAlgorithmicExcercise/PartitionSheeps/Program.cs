namespace PartitionSheeps
{
    internal class Program
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++) sum += nums[i];
            if (sum % 2 == 1) return false; //if sum is odd we cant split array into two equal halves

            int[] array = new int[(sum / 2) + 1];
            array[0] = 1;
            for (int i = 0; i < nums.Length; i++)
                for (int weight = sum / 2; weight >= 0; weight--)
                {
                    if (weight - nums[i] < 0) break;
                    if (array[weight - nums[i]] == 1) array[weight] = 1;
                }
            if (array[sum / 2] == 1) return true;
            return false;
        }

        static void Main(string[] args)
        {
            int[] goatsAndCourses = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int goats = goatsAndCourses[0];
            int courses = goatsAndCourses[1];
            int goatsWeightSum = 0;// 30 10 5 7 4 15 

            int[] weights = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).ToArray();

            int raft = (goatsWeightSum + weights[goats - 1]) / 2;
            int low = weights.Max(), high = weights.Sum();
            Console.WriteLine($"high: {high}\n high / 3 = {high / 3}");

            foreach (int t in weights)
            {
                if (t == target)
                {
                    return true;

                }
                if (previousElement + t == target)
                {
                    return true;
                }
            }
        }
    }
}
