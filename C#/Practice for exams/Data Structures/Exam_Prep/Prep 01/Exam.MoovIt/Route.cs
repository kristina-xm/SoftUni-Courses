using System;
using System.Collections.Generic;
using System.Reflection;

namespace Exam.MoovIt
{
    public class Route
    {
        public string Id { get; set; }

        public double Distance { get; set; }

        public int Popularity { get; set; }

        public bool IsFavorite { get; set; }

        public List<string> LocationPoints { get; set; } = new List<string>();

        public Route(string id, double distance, int popularity, bool isFavorite, List<string> locationPoints)
        {
            this.Id = id;
            this.Distance = distance;
            this.Popularity = popularity;
            this.IsFavorite = isFavorite;
            this.LocationPoints = locationPoints;
        }

        public double CalculateDistanceBetweenPoints(List<string> locationPoints, string startPoint, string endPoint)
        {
            var startIndex = locationPoints.IndexOf(startPoint);
            var endIndex = locationPoints.IndexOf(endPoint);

            return Math.Abs(startIndex - endIndex);
        }
    }
}
