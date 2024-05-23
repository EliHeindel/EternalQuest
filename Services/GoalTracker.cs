using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using EternalQuest.Models;

public class GoalTracker
{
    private List<Goal> goals;
    private int score;
    private int level;
    private int experience;

    public GoalTracker()
    {
        goals = new List<Goal>();
        score = 0;
        level = 1;
        experience = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordProgress();
                int pointsEarned = goal.Points;
                score += pointsEarned;
                experience += pointsEarned;
                CheckLevelUp();
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    score += checklistGoal.Bonus;
                    experience += checklistGoal.Bonus;
                    CheckLevelUp();
                }
                break;
            }
        }
    }

    private void CheckLevelUp()
    {
        while (experience >= level * 100)
        {
            experience -= level * 100;
            level++;
            Console.WriteLine($"Congratulations! You reached Level {level}!");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
        Console.WriteLine($"Level: {level}, XP: {experience}/{level * 100}");
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{goal.Name}: {checklistGoal.Progress}/{checklistGoal.Target} - {(checklistGoal.IsComplete() ? "[X]" : "[ ]")}");
            }
            else
            {
                Console.WriteLine($"{goal.Name}: {(goal.IsComplete() ? "[X]" : "[ ]")}");
            }
        }
    }

    public void Save(string filePath)
    {
        var data = JsonSerializer.Serialize(new { Goals = goals, Score = score, Level = level, Experience = experience });
        File.WriteAllText(filePath, data);
    }

    public void Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            var data = File.ReadAllText(filePath);
            var loadedData = JsonSerializer.Deserialize<Dictionary<string, object>>(data);
            score = (int)loadedData["Score"];
            level = (int)loadedData["Level"];
            experience = (int)loadedData["Experience"];
            // Deserialize goals from loadedData["Goals"]
            var goalsData = JsonSerializer.Deserialize<List<Goal>>(loadedData["Goals"].ToString());
            goals = goalsData ?? new List<Goal>();
        }
        else
        {
            Console.WriteLine("Save file not found, initializing new goals list.");
            goals = new List<Goal>();
        }
    }
}
