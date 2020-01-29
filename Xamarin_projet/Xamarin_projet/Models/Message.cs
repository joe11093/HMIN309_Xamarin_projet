using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Xamarin_projet
{
    public class Message
    {
        [JsonProperty("id"), PrimaryKey]
        public int Id { get; set; }
        [JsonProperty("student_id")]
        public int StudentId { get; set; }
        [JsonProperty("gps_lat")]
        public double GpsLat { get; set; }
        [JsonProperty("gps_long")]
        public double GpsLong { get; set; }
        [JsonProperty("student_message")]
        public string StudentMessage { get; set; }

        public bool Favorite { get; set; }

        public Message()
        {
        }

        public Message(int id, int studentId, double gpsLat, double gpsLong, string studentMessage)
        {
            Id = id;
            StudentId = studentId;
            GpsLat = gpsLat;
            GpsLong = gpsLong;
            StudentMessage = studentMessage ?? throw new ArgumentNullException(nameof(studentMessage));
            Favorite = false;
        }

        public Message(int id, int studentId, double gpsLat, double gpsLong, string studentMessage, bool Fav)
        {
            Id = id;
            StudentId = studentId;
            GpsLat = gpsLat;
            GpsLong = gpsLong;
            StudentMessage = studentMessage ?? throw new ArgumentNullException(nameof(studentMessage));
            Favorite = Fav;
        }

        public override string ToString()
        {
            return "id: " + this.Id + "sender: " + this.StudentId + "message: " + this.StudentMessage;
        }
    }
}
