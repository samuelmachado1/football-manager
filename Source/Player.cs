using System;

namespace Codenation.Challenge
{
    internal class Player
    {
        
        private string name;
        private DateTime birthDate;
        private int skillLevel;
        private decimal salary;
        private bool captain;   

        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            Id = id;
            TeamId = teamId;
            Name = name;
            BirthDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
        }

        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary, bool captain) : this(id, teamId, name, birthDate, skillLevel, salary)
        {
            Id = id;
            TeamId = teamId;
            Capitain = captain;
            this.name = name;
            this.birthDate = birthDate;
            this.skillLevel = skillLevel;
            this.salary = salary;
        }



        public long Id { get; internal set; }
        public bool Capitain { get; internal set; }
        public long TeamId { get; internal set; }
        public string Name { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public int SkillLevel { get; internal set; }
        public decimal Salary { get; internal set; }
    }
}