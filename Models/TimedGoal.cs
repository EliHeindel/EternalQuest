namespace EternalQuest.Models
{
    public class TimedGoal : Goal
    {
        public DateTime Deadline { get; set; }
        public bool Completed { get; private set; }

        public TimedGoal(string name, int points, DateTime deadline)
        {
            Name = name;
            Points = points;
            Deadline = deadline;
            Completed = false;
        }

        public override void RecordProgress()
        {
            if (!Completed && DateTime.Now <= Deadline)
            {
                Completed = true;
            }
        }

        public override bool IsComplete() => Completed;
    }
}
