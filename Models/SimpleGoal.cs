namespace EternalQuest.Models
{
    public class SimpleGoal : Goal
    {
        public bool Completed { get; private set; }

        public SimpleGoal(string name, int points)
        {
            Name = name;
            Points = points;
            Completed = false;
        }

        public override void RecordProgress()
        {
            if (!Completed)
            {
                Completed = true;
            }
        }

        public override bool IsComplete() => Completed;
    }
}
