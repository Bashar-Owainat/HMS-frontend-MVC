    namespace mvc_app.Models
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public List<HotelRoom> hotelRooms { get; set; }

        //    "id": 1,
        //"name": "regency dalas",
        //"streetAddress": "#####",
        //"city": "Amman",
        //"state": "Jordan",
        //"country": "Jordan",
        //"phone": 5469788,
        //"hotelRooms": null
    }
}
