namespace EternalQuest.Models
{
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public override void RecordProgress()
        {
            Points = -Points;
        }

        public override bool IsComplete() => false;
    }
}
