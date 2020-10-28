using System;
using System.Collections.Generic;

namespace serie3 {
    ///<summary>
    ///Class used to define a Ski station from the read file
    ///</summary>
    class SkiStation {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Canton { get; set; }
        public string Altitude { get; set; }
        public string MaxAltitude { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AdultPrice { get; set; }
        public string ChildPrice { get; set; }
        public string NbSkiLift { get; set; }
        public string NbSlopes { get; set; }
        public string SlopeLength { get; set; }
        
        public SkiStation(string[] Attributes){
            Name = Attributes[0];
            Domain = Attributes[1];
            Canton = Attributes[2];
            Altitude = Attributes[3];
            MaxAltitude = Attributes[4];
            Latitude = Attributes[5];
            Longitude = Attributes[6];
            AdultPrice = Attributes[7];
            ChildPrice = Attributes[8];
            NbSkiLift = Attributes[9];
            NbSlopes = Attributes[10];
            SlopeLength = Attributes[11];
        }
        override public string ToString(){
            return $"Name : {Name}  Domain : {Domain}  Canton : {Canton}\nAltitude : {Altitude}  Altitude Maximum : {MaxAltitude}" +
                $" \nLatitude : {Latitude}  Longitude : {Longitude} \nAdult Price : {AdultPrice}  Child Price : {ChildPrice}" +
                $"\nNumber of Ski Lift: {NbSkiLift}  Number of Ski Slopes: {NbSlopes}\nTotal Ski Slopes length : {SlopeLength}";
        }
    }
}
