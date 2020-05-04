namespace NYC_Flights13_Backend.Models
{
    public class AirlineDTO
    {
        public string Carrier { get; private set; }

        public string Name { get; private set; }

        public AirlineDTO()
        {
        }

        public AirlineDTO(string carrier, string name)
        {
            Carrier = carrier;
            Name = name;
        }
    }
}