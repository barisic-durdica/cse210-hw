// Enhancement:
// I implemented a dynamic player ranking system based on the user's total score.
// As users earn more points, they progress through the ranks:
// Beginner, Explorer, Achiever, Champion, and Legend.
//
// Additionally, the program displays a "LEVEL UP!" message whenever
// the user reaches a new rank, making the goal tracker more engaging
// and encouraging continued progress.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}