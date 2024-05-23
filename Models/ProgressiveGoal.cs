namespace EternalQuest.Models
{
    public class ProgressiveGoal : Goal
    {
        public int Target { get; set; }
        public int Progress { get; private set; }

        public ProgressiveGoal(string name, int points, int target)
        {
            Name = name;
            Points = points;
            Target = target;
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
