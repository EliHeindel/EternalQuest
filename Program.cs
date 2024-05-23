using System;
using EternalQuest.Models;
class Program
{
    static void Main()
    {
        var goalTracker = new GoalTracker();

        goalTracker.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        goalTracker.AddGoal(new EternalGoal("Read Scriptures", 100));
        goalTracker.AddGoal(new ChecklistGoal("Attend Temple", 50, 10, 500));
        goalTracker.AddGoal(new ProgressiveGoal("Lose 5lbs", 10, 100));
        goalTracker.AddGoal(new NegativeGoal("Eat Junk Food", -50));
        goalTracker.AddGoal(new TimedGoal("Finish Project", 500, DateTime.Now.AddDays(30)));

        while (true)
        {
            Console.Clear();
            goalTracker.DisplayScore();
            goalTracker.DisplayGoals();
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Record Event");
            Console.WriteLine("2. Save");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Exit");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name to record: ");
                    var goalName = Console.ReadLine();
                    goalTracker.RecordEvent(goalName);
                    break;
                case "2":
                    goalTracker.Save("goals.json");
                    break;
                case "3":
                    goalTracker.Load("goals.json");
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
