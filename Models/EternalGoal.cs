namespace EternalQuest.Models
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public override void RecordProgress()
        {
            // Eternal goals never complete but gain points each time.
        }

        public override bool IsComplete() => false;
    }
}
