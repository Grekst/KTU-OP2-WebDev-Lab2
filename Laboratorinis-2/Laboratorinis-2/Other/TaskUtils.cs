using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_2
{
    public static class TaskUtils
    {
        public static LListRoute FindAllRoutes(LListCity allCities, LListRoad allRoads,
            string startCityName, int maxPop, int minRouteLen, string unwantedCity)
        {
            LListRoute results = new LListRoute();
            City startCity = allCities.Find(startCityName);

            if (startCity == null || startCity.Population >= maxPop || startCity.Name == unwantedCity)
                return results;

            Route currentPath = new Route();
            currentPath.AddCity(startCity);

            GenerateRoutes(startCity, currentPath, allCities, allRoads,
                           maxPop, minRouteLen, unwantedCity, results);

            return results;
        }

        private static void GenerateRoutes(City currentCity, Route currentPath, LListCity allCities, LListRoad allRoads, int maxPop, int minRouteLen, string unwantedCity, LListRoute results)
        {
            if (currentPath.TotalDistance > minRouteLen)
            {
                results.Append(currentPath.Clone());
            }

            for (allRoads.Begin(); allRoads.Exist(); allRoads.Next())
            {
                Road road = allRoads.GetRoad();
                if (road.ConnectsTo(currentCity.Name))
                {
                    string nextName = road.OtherCity(currentCity.Name);
                    City nextCity = allCities.Find(nextName);

                    if (nextCity != null &&
                        nextCity.Population < maxPop &&
                        !nextCity.Name.Equals(unwantedCity, StringComparison.OrdinalIgnoreCase) &&
                        !currentPath.Cities.ContainsName(nextCity.Name))
                    {
                        currentPath.AddCity(nextCity, road.Distance);

                        allRoads.SavePosition();
                        GenerateRoutes(nextCity, currentPath, allCities, allRoads, maxPop, minRouteLen, unwantedCity, results);
                        allRoads.RestorePosition();

                        currentPath.TotalDistance -= road.Distance;
                        currentPath.Cities.RemoveLast();
                    }
                }
            }
        }
    }
}