using System;

namespace EternalQuest.Models
{
    public abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public abstract void RecordProgress();
        public abstract bool IsComplete();
    }
}
