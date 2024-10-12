using System;
using System.Collections.Generic;

namespace Exam.MoovIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var moovit = new MoovIt();

            var locationPoints1 = new List<string>(){"a", "b", "c", "d"};
            var locationPoints2 = new List<string>(){"a", "b", "c", "o", "m", "d"};

            var route1 = new Route("id1", 50, 1, false, locationPoints1);
            var route2 = new Route("id2", 60, 4, true, locationPoints2);

            moovit.AddRoute(route1);
            moovit.AddRoute(route2);
            moovit.ChooseRoute("id2");

            var routeget = moovit.GetRoute("id2");
        }
    }
}