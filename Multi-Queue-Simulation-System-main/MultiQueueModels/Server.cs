﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.TimeDistribution = new List<TimeDistribution>();
            this.events = new List<SimulationCase>();
           this.FinishTime = 0;
            this.TotalWorkingTime = 0;

        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;
        public List<SimulationCase> events;


        //optional if needed use them
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
    }
}

