using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace = false;
        private ICollection<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get
            {
                return raceName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format("Invalid race name: {0}.", value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return numberOfLaps;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format("Invalid lap numbers: {0}.", value));
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get => tookPlace;
            set => tookPlace = value;

        }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return pilots;
            }
            set
            {
                pilots = value;
            }
        }

        public void AddPilot(IPilot pilot)
        {
            this.Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            if (this.TookPlace == true)
            {
                return $"The {this.RaceName} race has:{Environment.NewLine}Participants: {this.Pilots.Count}{Environment.NewLine}Number of laps: {this.NumberOfLaps}{Environment.NewLine}Took place: Yes";
            }
            else
            {
                return $"The {this.RaceName} race has:{Environment.NewLine}Participants: {this.Pilots.Count}{Environment.NewLine}Number of laps: {this.NumberOfLaps}{Environment.NewLine}Took place: No";
            }
           
        }
    }
}
