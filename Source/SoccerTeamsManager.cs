using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {

        private List<Team> teams = new List<Team>();
        private List<Player> players = new List<Player>();
        public SoccerTeamsManager()
        {
        }
        private Team GetTeam(long teamId)
        {
            foreach (Team team in teams)
            {
                if (team.Id == teamId)
                {
                    return team;
                }
                
            }

            return null;
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if (teams.Any(team => team.Id == id))
                throw new UniqueIdentifierException();

            teams.Add(new Team(id, name, createDate, mainShirtColor, secondaryShirtColor));
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if (players.Any(player => player.Id == id))
                throw new UniqueIdentifierException();

            if (!teams.Any(team => team.Id == teamId))
                throw new TeamNotFoundException();

            players.Add(new Player(id, teamId, name, birthDate, skillLevel, salary));
        }

        public void SetCaptain(long playerId)
        {

            if (!PlayerExists(playerId))
            {
                throw new PlayerNotFoundException();
            }

            foreach (Player player in players)
            {
                player.Capitain = player.Id == playerId;
            }
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!TeamExists(teamId))
            {
                throw new TeamNotFoundException();
            }

            foreach (Player player in players)
            {
                if (player.Capitain)
                {
                    return player.Id;
                }
            }
            throw new CaptainNotFoundException();
        }

        public string GetPlayerName(long playerId)
        {
            if (!players.Any(player => player.Id == playerId))
                throw new PlayerNotFoundException();

            return players.Find(player => player.Id == playerId).Name;
        }

        public string GetTeamName(long teamId)
        {
            if (!teams.Any(team => team.Id == teamId))
                throw new TeamNotFoundException();

            return teams.Find(team => team.Id == teamId).Name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!teams.Any(team => team.Id == teamId))
                throw new TeamNotFoundException();

            return players
              .FindAll(player => player.TeamId == teamId)
              .OrderBy(player => player.Id)
              .ToList()
              .ConvertAll(player => player.Id);
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (!teams.Any(team => team.Id == teamId))
                throw new TeamNotFoundException();

            return players
              .FindAll(player => player.TeamId == teamId)
              .OrderByDescending(player => player.SkillLevel)
              .ThenBy(player => player.Id)
              .ToList()[0].Id;
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!teams.Any(team => team.Id == teamId))
                throw new TeamNotFoundException();

            return players
              .FindAll(player => player.TeamId == teamId)
              .OrderBy(player => player.BirthDate)
              .ToList()[0].Id;
        }


        public List<long> GetTeams()
        {
            if (teams.Count == 0) return new List<long>();

            return teams
              .OrderBy(team => team.Id)
              .ToList()
              .ConvertAll(team => team.Id);
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (!teams.Any(team => team.Id == teamId))
                throw new TeamNotFoundException();

            return players
              .FindAll(player => player.TeamId == teamId)
              .OrderByDescending(player => player.Salary)
              .ToList()[0].Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            if (!PlayerExists(playerId))
            {
                throw new PlayerNotFoundException();
            }

            foreach (Player player in players)
            {
                if (player.Id == playerId)
                {
                    return player.Salary;
                }
            }
            return 0;
        }

        public List<long> GetTopPlayers(int top)
        {
            if (players.Count == 0) return new List<long>();

            return players
              .OrderByDescending(player => player.SkillLevel)
              .ThenBy(player => player.Id)
              .ToList()
              .ConvertAll(player => player.Id).Take(top).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            Team home = GetTeam(teamId);
            Team visitor = GetTeam(visitorTeamId);

            if (home == null || visitor == null)
                throw new TeamNotFoundException();

            return home.MainShirtColor == visitor.MainShirtColor ?
                visitor.SecondaryShirtColor :
                visitor.MainShirtColor;
        }

       
        private bool TeamExists(long teamId)
        {
            foreach (Team team in teams)
            {
                if (team.Id == teamId)
                {
                    return true;
                }
            }

            return false;
        }

        private bool PlayerExists(long playerId)
        {
            foreach (Player player in players)
            {
                if (player.Id == playerId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}