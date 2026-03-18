namespace Laboratorinis_2
{
    public class Road
    {
        public string Start { get; private set; }
        public string Destination { get; private set; }
        public int Distance { get; set; }

        public Road()
        {

        }

        public Road(string start, string destination, int distance)
        {
            Start = start;
            Destination = destination;
            Distance = distance;
        }

        public bool ConnectsTo(string cityName)
        {
            return Start == cityName || Destination == cityName;
        }

        public string OtherCity(string cityName)
        {
            if (Start == cityName) return Destination;
            if (Destination == cityName) return Start;

            return null;
        }

        public override string ToString()
        {
            return string.Format("{0, -20} | {1, -20} | {2, 20} km", Start, Destination, Distance);
        }
    }
}