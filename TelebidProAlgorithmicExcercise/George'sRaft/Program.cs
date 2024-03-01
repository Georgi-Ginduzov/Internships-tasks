using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] goatsAndCoursesInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int goats = goatsAndCoursesInput[0];
            int courses = goatsAndCoursesInput[1];

            int[] weightsInput = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).ToArray();
            int sum = weightsInput.Sum();
            int sheepTransportingRaftSize = sum / courses;

            if (courses == 1)
            {
                Console.WriteLine(sum);
            }
            else
            {
                var visited = new bool[weightsInput.Length];
                bool canSailTheGoats = Search(weightsInput, courses, sheepTransportingRaftSize, 0, 0, visited);
                if (canSailTheGoats == true)
                {
                    Console.WriteLine(sheepTransportingRaftSize);
                }
            }

        }

        static bool Search(int[] nums, int k, int target, int start, int sum, bool[] visited)
        {
            if (k == 1)
            {
                return true;
            }

            if (sum == target)
            {
                return Search(nums, k - 1, target, 0, 0, visited);
            }

            for (var i = start; i < nums.Length; i++)
            {
                var localSum = nums[i] + sum;
                if (localSum > target || visited[i])
                {
                    continue;
                }
                visited[i] = true;
                if (Search(nums, k, target, i, localSum, visited))
                {
                    return true;
                }
                visited[i] = false;
            }

            return false;
        }
    }
}
