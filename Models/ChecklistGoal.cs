namespace EternalQuest.Models
{
    public class ChecklistGoal : Goal
    {
        public int Target { get; set; }
        public int Progress { get; private set; }
        public int Bonus { get; set; }

        public ChecklistGoal(string name, int points, int target, int bonus)
        {
            Name = name;
            Points = points;
            Target = target;
            Bonus = bonus;
            Progress = 0;
        }

        public override void RecordProgress()
        {
            if (Progress < Target)
            {
                Progress++;
            }
        }

        public override bool IsComplete() => Progress >= Target;
    }
}
