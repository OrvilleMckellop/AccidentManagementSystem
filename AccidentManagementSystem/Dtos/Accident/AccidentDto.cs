using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentManagementSystem.Dtos.Accident
{
    public class AccidentDto
    {
        public int AccidentID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public int VehicleID { get; set; }
    }
}