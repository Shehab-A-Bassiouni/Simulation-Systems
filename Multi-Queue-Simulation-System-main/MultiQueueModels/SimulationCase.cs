using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationCase
    {
        public SimulationCase()
        {
            this.AssignedServer = new Server();
        }

        public int CustomerNumber { get; set; } //done
        public int RandomInterArrival { get; set; } //done
        public int InterArrival { get; set; } //done
        public int ArrivalTime { get; set; } //done
        public int RandomService { get; set; }  //done
        public int ServiceTime { get; set; } 
        public Server AssignedServer { get; set; } 
        public int StartTime { get; set; } 
        public int EndTime { get; set; } 
        public int TimeInQueue { get; set; }
    }
}
