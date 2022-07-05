using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FootballTeamGenerator
{
    
    public class StartUp
    {
   
        static void Main(string[] args)
        {


            List<Team> teams = new List<Team>();
        string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {
                    string[] cmdArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string action = cmdArgs[0];
                    string teamName = cmdArgs[1];
                    if (action == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (action == "Add")
                    {
                        string playerName = cmdArgs[2];
                        Stats playerStats = GeneratePlayerStats(cmdArgs.Skip(3).ToArray());
                        var team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team == null)
                        {
                            throw new InvalidOperationException(ErrorMessages.TeamDoesNotExist);
                        }
                        Player player = new Player(playerName, playerStats);
                        team.AddPlayer(player);
                    }
                    else if (action == "Remove")
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team == null)
                        {
                            throw new InvalidOperationException(ErrorMessages.PlayerNotInTeam);
                        }
                        team.RemovePlayer(teamName);
                    }
                    else if (action == "Rating")
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);
                        if (team == null)
                        {
                            throw new InvalidOperationException(ErrorMessages.PlayerNotInTeam);
                        }
                        team.RemovePlayer(teamName);

                    }

                    command = Console.ReadLine();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void ProcessInput(List<Team> list, string[] arr)
        {
            //string[] cmdArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            //string action = cmdArgs[0];
            //string teamName = cmdArgs[1];
            //if (action == "Team")
            //{
            //    Team team = new Team(teamName);
            //    teams.Add(team);
            //}
        }

        static Stats GeneratePlayerStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);

            Stats allStatsCombined = new Stats(endurance, sprint, dribble, passing, shooting);
            return allStatsCombined;
        }
    }
}
