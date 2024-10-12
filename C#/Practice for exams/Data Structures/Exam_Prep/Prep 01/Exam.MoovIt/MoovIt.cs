using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {

        Dictionary<string,Route> routesById = new Dictionary<string, Route>();
        //Dictionary<string,Route> routesByLocationPoints = new Dictionary<string, Route>();

        public int Count => routesById.Count;

        public void AddRoute(Route route)
        {
            if (routesById.ContainsKey(route.Id))
            {
                throw new ArgumentException();
            }

            // if (CheckIfIsTheSameRoute(routesById, route))
            // {
            //     throw new ArgumentException();
            // }

            routesById.Add(route.Id, route);

        }

        private bool CheckIfIsTheSameRoute(Dictionary<string, Route> routesById, Route route)
        {
            var sameRoute = routesById.Values.Any(r => 
            r.LocationPoints[0].Equals(route.LocationPoints[0]) 
            && r.LocationPoints[r.LocationPoints.Count - 1].Equals(route.LocationPoints[route.LocationPoints.Count -1]) 
            && r.Distance == route.Distance);

            return sameRoute;
        }

        public void ChooseRoute(string routeId)
        {
           if (!routesById.ContainsKey(routeId))
           {
                throw new ArgumentException();
           }

           routesById[routeId].Popularity++;
        }

        public bool Contains(Route route)
        {
            return routesById.ContainsKey(route.Id) || CheckIfIsTheSameRoute(routesById, route);
        }

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
        {
            var favoriteRoutes = routesById.Values
            .Where(r => r.IsFavorite == true && r.LocationPoints.Contains(destinationPoint) && !r.LocationPoints[0].Equals(destinationPoint))
            .OrderBy(r => r.Distance)
            .ThenByDescending(r => r.Popularity)
            .ToArray();

            // if (favoriteRoutes.Length == 0)
            // {
            //     return new List<Route>();
            // }

            return favoriteRoutes;
        }

        public Route GetRoute(string routeId)
        {
            if (!routesById.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            return routesById.GetValueOrDefault(routeId);
        }

        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
        { 
           var sortedRoutes = routesById.Values
                .OrderByDescending(r => r.Popularity)
                .ThenBy(r => r.Distance)
                .ThenBy(r => r.LocationPoints.Count)
                .Take(5)
                .ToArray();

            // if (sortedRoutes.Length == 0)
            // {
            //     return new List<Route>();
            // }

            return sortedRoutes;

        }

        public void RemoveRoute(string routeId)
        {
            if (!routesById.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            routesById.Remove(routeId);
        }

        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
        {
            var routes = routesById.Values
                .Where(r => r.LocationPoints.Contains(startPoint) && r.LocationPoints.Contains(endPoint))
                .OrderByDescending(r => r.IsFavorite)
                .ThenBy(r => r.CalculateDistanceBetweenPoints(r.LocationPoints, startPoint, endPoint))
                .ThenByDescending(r => r.Popularity)
                .ToArray();

            // if (routes.Length == 0)
            // {
            //     return new List<Route>();
            // }

            return routes;
        }
    }
}
