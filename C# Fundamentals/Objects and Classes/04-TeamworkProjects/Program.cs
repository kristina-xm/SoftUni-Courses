using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int n = int.Parse(Console.ReadLine());
            RegisterTeams(teams, n);

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joinArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string memberName = joinArgs[0];
                string teamName = joinArgs[1];

                Team searchedTeam = teams.FirstOrDefault(t => t.Name == teamName);

                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsAlreadyMemberOfTeam(teams, memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                if (teams.Any(t => t.Creator == memberName))
                {
                    //Creator of a team cannot be a member of another team
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                searchedTeam.AddMember(memberName);
            }

            List<Team> teamsWithMembers = teams.Where(t => t.Members.Count > 0).OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();

            List<Team> teamsToDisband = teams.Where(t => t.Members.Count == 0).OrderBy(t => t.Name).ToList();

            PrintValidTeams(teamsWithMembers);
            PrintInvalidTeams(teamsToDisband);

        }
        static void RegisterTeams(List<Team> teams, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                string[] teamArgs = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string creatorName = teamArgs[0];
                string teamName = teamArgs[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team newTeam = new Team(teamName, creatorName);
                teams.Add(newTeam);

                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");

            }
        }

        static bool IsAlreadyMemberOfTeam(List<Team> teams, string memberName)
        {
            foreach (Team team in teams)
            {
                //Members is a list
                if (team.Members.Contains(memberName))
                {
                    return true;
                }
            }
            return false;
        }

        static void PrintValidTeams(List<Team> validTeams)
        {
            foreach (Team validTeam in validTeams)
            {
                Console.WriteLine($"{validTeam.Name}\n- {validTeam.Creator}");

                foreach (string member in validTeam.Members.OrderBy(m => m))// string parameter, alphabetically
                {
                    Console.WriteLine($"-- {member}");
                }
            }
        }

        static void PrintInvalidTeams(List<Team> invalidTeams)
        {
            Console.WriteLine("Teams to disband:");

            foreach (Team invalidTeam in invalidTeams)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }
        }
    }
}
