using System;

namespace AlignAPITest.Model
{
    public class AgentMission
    {
        public long AgentId { get; set; }
        public string Agent { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
      
        public double Lat { get; set; }
        
        public double Lon { get; set; }

    }
}
