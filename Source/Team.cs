using System;

namespace Codenation.Challenge
{
    internal class Team
    {
        private string name;
        private DateTime createDate;
        private string mainShirtColor;
        private string secondaryShirtColor;

        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            Id = id;
            Name = name;
            CreateDate = createDate;
            MainShirtColor = mainShirtColor;
            SecondaryShirtColor = secondaryShirtColor;
        }

        public long Id { get; internal set; }
        public string Name { get; internal set; }
        public DateTime CreateDate { get; internal set; }
        public string MainShirtColor { get; internal set; }
        public string SecondaryShirtColor { get; internal set; }
    }
}


