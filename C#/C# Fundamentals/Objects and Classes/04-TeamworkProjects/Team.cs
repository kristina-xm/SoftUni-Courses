using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects
{
    public class Team
    {
        public Team(string teamName, string creatorName)
        {
            this.Name = teamName;
            this.Creator = creatorName;
            this.Members = new List<string>();
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            this.Members.Add(member);
        }
    }
}
