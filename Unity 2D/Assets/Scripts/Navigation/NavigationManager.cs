using System;
using System.Collections.Generic;

namespace Navigation
{
    public static class NavigationManager
    {
        public struct Route
        {
            public string RouteDescription;
            public bool CanTravel;
        }
        
        
        public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>()
        {
            {
                "Overworld", "Who asked?"
            },

            {
                "Construction", "Shits getting built"
            },
        };

        public static String GetRouteInformation(string destination)
        {
            return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
        }

        public static bool CanNavigate(string destination)
        {
            return true;
        }

        public static void NavigateTo(string destination)
        {
            
        }
    }
}