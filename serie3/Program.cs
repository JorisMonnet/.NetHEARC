using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Console;

namespace serie3 {
    class Program {
        static void Main() {
            List<SkiStation> listStation = ParseSkiStation();
            PrintCanton(listStation);
            PrintSkiStationByCanton(listStation);
            PrintSkiStationByPrice(listStation,2,2,150);
            PrintSkiStationByDistance(listStation,46.997727,6.938725,150);
        }
        /// <summary>
        /// Parse the DB file to extract the data and create the stations
        /// if a data is unknown, the attribute of the class will be unknown
        /// </summary>
        /// <returns>A list of all the stations contained in the file</returns>
        static List<SkiStation> ParseSkiStation() {
            List<SkiStation> listStation = new List<SkiStation>();
            string[] arrayAttributes = new string[12];
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach(char element in Resource1.SwissSkiDB.ToArray()){
                if(element != '\n'){
                    if(element != ';'){
                        builder.Append(element);
                    } else {
                        if(builder.Length == 0) builder.Append("Unknown");
                        arrayAttributes[i++]= builder.ToString();
                        builder.Clear();
                    }
                } else {
                    try{
                        double.Parse(builder.ToString());//fix a bug where Total length attribute is set with blank characters
                        arrayAttributes[i] = builder.ToString();
                    } catch{
                        arrayAttributes[i] = "Unknown";
                    }
                    if(arrayAttributes[0]!="Nom")   //remove first Line
                        listStation.Add(new SkiStation(arrayAttributes));
                    builder.Clear();
                    i = 0;
                }
            }
            return listStation;
        }
        /// <summary>
        /// Print on the console the canton from where are the stations
        /// </summary>
        /// <param name="listStation">The list of all stations</param>
        private static void PrintCanton(List<SkiStation> listStation) {
            List<string> cantons = new List<string>();
            foreach(SkiStation station in listStation){
                if(station.Canton != "Unknown" && !cantons.Contains(station.Canton)){
                    cantons.Add(station.Canton);
                }
            }
            WriteLine("################################################CANTONS################################################\n");
            foreach(string canton in cantons) WriteLine(canton);
        }
        /// <summary>
        /// Print on the console all the ski station ordered alphabetically by canton
        /// </summary>
        /// <param name="listStation">The list of all stations</param>
        private static void PrintSkiStationByCanton(List<SkiStation> listStation) {
            WriteLine("################################################Station BY CANTONS################################################\n");
            PrintSkiStation(listStation.OrderBy(s => s.Canton));
        }
        /// <summary>
        /// Print on the console all the station which cost less than the maximum price for the given group of people
        /// </summary>
        /// <param name="listStation">The list of all Stations</param>
        /// <param name="nbAdults">The number of Adults</param>
        /// <param name="nbChildren">The number of Children</param>
        /// <param name="maximumPrice">The Maximum Price allowed</param>
        private static void PrintSkiStationByPrice(List<SkiStation> listStation, int nbAdults,int nbChildren, double maximumPrice) {
            WriteLine($"########################Price Under {maximumPrice} For {nbAdults} Adults and {nbChildren} Children########################\n");
            PrintSkiStation(listStation.Where(s => (s.AdultPrice != "Unknown" && s.ChildPrice != "Unknown") && 
                            nbAdults * double.Parse(s.AdultPrice) + nbChildren * double.Parse(s.ChildPrice) < maximumPrice));
        }
        /// <summary>
        /// Print on console the list of stations filtered(or not)
        /// </summary>
        /// <param name="listStation">The list of station to show</param>
        private static void PrintSkiStation(IEnumerable<SkiStation> listStation) {
            foreach(SkiStation station in listStation){
                WriteLine(station);
                WriteLine("-------------------------------------------------------------------------------------\n");
            }
        }
        /// <summary>
        /// print all the stations which are at less than the max distance allowed from the start point
        /// </summary>
        /// <param name="listStation">list of all stations</param>
        /// <param name="lat">latitude of the start</param>
        /// <param name="lon">logitude of the start</param>
        /// <param name="maxDistance">Maximum distance allowed from the start point</param>
        private static void PrintSkiStationByDistance(List<SkiStation> listStation,double lat,double lon,double maxDistance){
            WriteLine($"######################## Distance Under {maxDistance} From ({lat},{lon}) ########################");
            PrintSkiStation(listStation.Where(s => s.Longitude!= "Unknown" && s.Latitude!= "Unknown" 
                            && GetDistance(double.Parse(s.Latitude),lat,double.Parse(s.Longitude),lon) < maxDistance));
        }
        /// <summary>
        /// return distance between two points on earth
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lat2"></param>
        /// <param name="lon1"></param>
        /// <param name="lon2"></param>
        /// <returns>the distance</returns>
        private static double GetDistance(double lat1,double lat2,double lon1,double lon2) {
            //source : https://geodesie.ign.fr/contenu/fichiers/Distance_longitude_latitude.pdf
            lat1 *= Math.PI / 180;//ToRad
            lat2 *= Math.PI / 180;//ToRad
            lon1 *= Math.PI / 180;//ToRad
            lon2 *= Math.PI / 180;//ToRad
            return Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1)) * 6378.137;
        }
    }
}
