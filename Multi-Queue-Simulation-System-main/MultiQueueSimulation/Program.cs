using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MultiQueueSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SimulationSystem system = new SimulationSystem();
            //-------------------------------------------------------------------------------------------------------------
            //reading the file into single string then split it by empty lines
            string PATH = "..\\..\\TestCases\\TestCase1.txt";
            string line = File.ReadAllText(PATH);
            string[] entries = line.Split(new string[] {"\r\n\r\n"}, Int32.MaxValue, StringSplitOptions.RemoveEmptyEntries);
            //-------------------------------------------------------------------------------------------------------------
            //filling system data
            system.NumberOfServers = numOfServers(entries[0]);
            system.StoppingNumber = stoppingNumber(entries[1]);
            system.StoppingCriteria = stoppingCriteria(entries[2]);
            system.SelectionMethod = selectionMethod(entries[3]);
            interArrival(entries[4],ref system);
            add_servers(ref system, entries);
            int len = event_generator(ref system); //generate events
            int bigest_q=0; //max q length
            //selection methods
            if (system.SelectionMethod == Enums.SelectionMethod.HighestPriority)
                bigest_q=highest_priority(ref system);
            if (system.SelectionMethod == Enums.SelectionMethod.Random)
                bigest_q = random(ref system);
            if (system.SelectionMethod == Enums.SelectionMethod.LeastUtilization)
                bigest_q = least_uti(ref system);

            performance_measures_system(ref system, bigest_q);
             performance_measures_server(ref system);
            //-------------------------------------------------------------------------------------------------------------
                string result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                MessageBox.Show(result);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(ref system));
        }

        //split servers string then fill the servers and its tables
        static void add_servers(ref SimulationSystem system , string[] entries) {
            int index = 1;
            for (int i = 5; i < system.NumberOfServers+5; i++) {
                decimal cumProp = 0;
                decimal minim = 1;
                string[] newSplit = entries[i].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
               
                Server srvr = new Server();
                for (int x = 1; x < newSplit.Length; x++) {
                    string[] y = newSplit[x].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    TimeDistribution td = new TimeDistribution();
                    td.Time = Convert.ToInt32(y[0]);
                    td.Probability = Convert.ToDecimal(y[1]);


                    cumProp += td.Probability;
                    int max = Convert.ToInt32(cumProp * 100);
                    int min = Convert.ToInt32(minim);
                    minim = cumProp * 100 + 1;

                    td.CummProbability = cumProp;
                    td.MinRange = min;
                    td.MaxRange = max;

                    srvr.TimeDistribution.Add(td);
                }
                srvr.ID = index;
                system.Servers.Add(srvr);
                index++;
            }
        }

        //split numberofservers string and get the number
        static int numOfServers(string toSplit)
        {
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num = Convert.ToInt32(newSplit[1]);
            return num;
        }

        //split stoppingNumber string and get the number
        static int stoppingNumber(string toSplit)
        {
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num = Convert.ToInt32(newSplit[1]);
            return num;
        }

        //split StoppingCriteria string and get the number

        static Enums.StoppingCriteria stoppingCriteria(string toSplit)
        {
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num = Convert.ToInt32(newSplit[1]);
            if (num == 1) return Enums.StoppingCriteria.NumberOfCustomers;
            else return Enums.StoppingCriteria.SimulationEndTime;
            
        }

        //split SelectionMethod string and get the number
        static Enums.SelectionMethod selectionMethod(string toSplit)
        {
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num = Convert.ToInt32(newSplit[1]);
            if (num == 1) return Enums.SelectionMethod.HighestPriority;
            else if (num == 2) return Enums.SelectionMethod.Random;
            else return Enums.SelectionMethod.LeastUtilization;
            
        }

        //fill server and time table
        static void interArrival(string toSplit , ref SimulationSystem system) {
            decimal cumProp = 0;
            decimal minim = 1;
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries); //split header and content
            for (int i = 1; i < newSplit.Length; i++) { //processing the content
                string[] x = newSplit[i].Split(new string[] { ", " },StringSplitOptions.RemoveEmptyEntries); // split content line by line and by ", " 
                int time = Convert.ToInt32(x[0]);
                decimal probability = Convert.ToDecimal(x[1]);
                cumProp += probability;
                int max = Convert.ToInt32(cumProp*100);
                int min = Convert.ToInt32(minim);
                minim = cumProp*100 +1;
                TimeDistribution TD = new TimeDistribution();
                TD.Time = time;
                TD.Probability = probability;
                TD.CummProbability = cumProp;
                TD.MinRange=min;
                TD.MaxRange=max;
                system.InterarrivalDistribution.Add(TD);
            }
        }
        // calaculate time for random number
        static int interarrival_cal(SimulationSystem system, int random)
        {
            foreach (TimeDistribution td in system.InterarrivalDistribution)
                if (random >= td.MinRange && random <= td.MaxRange)
                    return td.Time;
            MessageBox.Show("error in interarrival_calc");
            return 0;
        }

        // calaculate service time for random number
        static int service_time_calc(SimulationSystem system, int random, Server srvr)
        {
            foreach (TimeDistribution td in srvr.TimeDistribution)
                if (random >= td.MinRange && random <= td.MaxRange)
                    return td.Time;


            MessageBox.Show("service_time_calc");
            return 0;
        }

        //generate events
        static int event_generator(ref SimulationSystem system) {
            Random rd = new Random();
            int clock = 0;
            int len;
            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
                len = system.StoppingNumber;
            else
                len = 100;


            for (int i = 1; i <= len; i++) { 
                SimulationCase case_event = new SimulationCase();
                case_event.CustomerNumber = i;
                case_event.RandomInterArrival = rd.Next(1, 100);
                if (i == 1) {
                    case_event.InterArrival = 0;
                } 
               else case_event.InterArrival = interarrival_cal(system, case_event.RandomInterArrival);
                clock += case_event.InterArrival;
                case_event.ArrivalTime = clock;
                case_event.RandomService=rd.Next(1,100);
                //service
                //assigned server
                //start time
                //end time
                //time in q
                
                system.SimulationTable.Add(case_event);
            }
            return len;


        }

        //highest perority method
        static int highest_priority(ref SimulationSystem system ) {
            List<SimulationCase> cases = new List<SimulationCase>();
            int biggest_q = 0;
            foreach(SimulationCase an_event in system.SimulationTable) {
                bool will_be_q = true;
                int least_finish_time_value = int.MaxValue;
                Server least_finish_time_indx = new Server();
                foreach (Server serv in system.Servers) {
                    if (serv.FinishTime <= an_event.ArrivalTime) {
                        an_event.StartTime = an_event.ArrivalTime;
                        an_event.AssignedServer = serv;
                        an_event.ServiceTime = service_time_calc(system, an_event.RandomService, serv);
                        an_event.EndTime = an_event.StartTime + an_event.ServiceTime;
                        an_event.TimeInQueue = 0;
                        serv.FinishTime = an_event.EndTime;
                        serv.events.Add(an_event);
                        will_be_q = false;
                        serv.TotalWorkingTime += an_event.ServiceTime;
                        break;
                     
                    }
            

                }

                if (will_be_q == true)
                {
                    foreach (Server servo in system.Servers)
                        if (servo.FinishTime < least_finish_time_value)
                        {
                            least_finish_time_value = servo.FinishTime;
                            least_finish_time_indx = servo;
                        }



                    an_event.StartTime = least_finish_time_indx.FinishTime;
                    an_event.AssignedServer = least_finish_time_indx;
                    an_event.ServiceTime = service_time_calc(system, an_event.RandomService, least_finish_time_indx);
                    an_event.EndTime = an_event.StartTime + an_event.ServiceTime;
                    an_event.TimeInQueue = least_finish_time_indx.FinishTime - an_event.ArrivalTime;
                    least_finish_time_indx.FinishTime = an_event.EndTime;
                    least_finish_time_indx.events.Add(an_event);
                    least_finish_time_indx.TotalWorkingTime += an_event.ServiceTime;
                    int temp = 0;

                    foreach (SimulationCase cs in cases){
                        if (cs.StartTime > an_event.ArrivalTime) {
                            temp++;
                        }  
                        
                    }
                    cases.Add(an_event);
                    temp++;

                    if(temp>biggest_q) biggest_q = temp;



                }
                if (system.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime && an_event.EndTime >= system.StoppingNumber)
                {
                    system.cit_2_cst_no = an_event.CustomerNumber;
                    break;
                }
            }
            return biggest_q;

        }

        //random method
        static int random(ref SimulationSystem system) {
           
            Random rd = new Random();
            List<SimulationCase> cases = new List<SimulationCase>();
            int biggest_q = 0;
            foreach (SimulationCase an_event in system.SimulationTable) {
                bool will_be_q = true;
                List<Server> available_server = new List<Server>();
                foreach (Server serv in system.Servers) 
                    if (serv.FinishTime <= an_event.ArrivalTime) {
                      available_server.Add(serv);
                      will_be_q = false;
                    }
                if (will_be_q == false)
                {
                    Server serv = available_server.ElementAt(rd.Next(0, (available_server.Count())));
                    an_event.StartTime = an_event.ArrivalTime;
                    an_event.AssignedServer = serv;
                    an_event.ServiceTime = service_time_calc(system, an_event.RandomService, serv);
                    an_event.EndTime = an_event.StartTime + an_event.ServiceTime;
                    an_event.TimeInQueue = 0;
                    serv.FinishTime = an_event.EndTime;
                    serv.events.Add(an_event);
                    serv.TotalWorkingTime += an_event.ServiceTime;
                    
                }

                else {
                    int least_finish_time_value = int.MaxValue;
                    Server least_finish_time_indx = new Server();
                    foreach (Server servo in system.Servers)
                        if (servo.FinishTime < least_finish_time_value)
                        {
                            least_finish_time_value = servo.FinishTime;
                            least_finish_time_indx = servo;
                        }
                    an_event.StartTime = least_finish_time_indx.FinishTime;
                    an_event.AssignedServer = least_finish_time_indx;
                    an_event.ServiceTime = service_time_calc(system, an_event.RandomService, least_finish_time_indx);
                    an_event.EndTime = an_event.StartTime + an_event.ServiceTime;
                    an_event.TimeInQueue = least_finish_time_indx.FinishTime - an_event.ArrivalTime;
                    least_finish_time_indx.FinishTime = an_event.EndTime;
                    least_finish_time_indx.events.Add(an_event);
                    least_finish_time_indx.TotalWorkingTime += an_event.ServiceTime;

                    int temp = 0;
                    foreach (SimulationCase cs in cases)
                    {
                        if (cs.StartTime > an_event.ArrivalTime)
                        {
                            temp++;
                        }

                    }
                    cases.Add(an_event);
                    temp++;

                    if (temp > biggest_q) biggest_q = temp;
                }
                if (system.StoppingCriteria == Enums.StoppingCriteria.SimulationEndTime && an_event.EndTime >= system.StoppingNumber)
                {
                    system.cit_2_cst_no = an_event.CustomerNumber;
                    break;
                }
            }

            return biggest_q;
        }

        // calculate  utilization for each server
        static void least_uti_calc(ref SimulationSystem system , int time) {
            foreach (Server serv in system.Servers) {
                int total_work = 0;
                foreach (SimulationCase sc in serv.events) {
                    if (sc.EndTime <= time) {
                        total_work += sc.ServiceTime;
                    }
                    else if ((sc.EndTime - sc.ServiceTime) < time) {
                        total_work += (time - sc.EndTime);
                    }
                    else {
                        break;
                    }
                }
                if(time!=0)
                serv.Utilization = (decimal)(total_work) / (decimal)(time);
                else
                    serv.Utilization = 0;
            }

        }

        //least utilization method
        static int least_uti(ref SimulationSystem system) {
            List<SimulationCase> cases = new List<SimulationCase>();
            int biggest_q = 0;
            //loop on all cases
            foreach (SimulationCase an_event in system.SimulationTable) {
                least_uti_calc(ref system, an_event.ArrivalTime);
                Server serv = new Server();
                bool will_be_q = true;
                List<Server> available_server = new List<Server>();
                //collect available servers
                foreach (Server servo in system.Servers)
                    if (servo.FinishTime <= an_event.ArrivalTime)
                    {
                        available_server.Add(servo);
                        will_be_q = false;
                    }
                //choose least utilization from available servers
                if (will_be_q == false)
                {
                    decimal least_value = int.MaxValue;
                    foreach (Server s in available_server)
                    {
                        if (s.Utilization < least_value)
                        {
                            least_value = s.Utilization;
                            serv = s;
                        }
                    }
                    an_event.StartTime = an_event.ArrivalTime;
                    an_event.AssignedServer = serv;
                    an_event.ServiceTime = service_time_calc(system, an_event.RandomService, serv);
                    an_event.EndTime = an_event.StartTime + an_event.ServiceTime;
                    an_event.TimeInQueue = 0;
                    serv.FinishTime = an_event.EndTime;
                    serv.events.Add(an_event);
                    serv.TotalWorkingTime += an_event.ServiceTime;
                }
                else
                {
                    //collect firt servers to finish(in list cuz of similar finish time)
                   List<Server> ss = new List<Server>();

                    int least_finish_time_value = int.MaxValue;
                    //get least time in all servers
                    foreach (Server servo in system.Servers)
                        if (servo.FinishTime < least_finish_time_value)
                        {
                            least_finish_time_value = servo.FinishTime;
                        }

                    //loop on all servers to pick server with that time
                    foreach (Server servo in system.Servers)
                        if (servo.FinishTime == least_finish_time_value)
                        {
                            least_finish_time_value = servo.FinishTime;
                            ss.Add(servo);
                        }

                    //get least utilization one
                    decimal least = int.MaxValue;
                    Server least_finish_time_indx = new Server();
                    foreach (Server servo in ss) {
                        if (servo.Utilization < least) {
                            least = servo.Utilization;
                            least_finish_time_indx = servo;
                        }
                    }

                    an_event.StartTime = least_finish_time_indx.FinishTime;
                    an_event.AssignedServer = least_finish_time_indx;
                    an_event.ServiceTime = service_time_calc(system, an_event.RandomService, least_finish_time_indx);
                    an_event.EndTime = an_event.StartTime + an_event.ServiceTime;
                    an_event.TimeInQueue = least_finish_time_indx.FinishTime - an_event.ArrivalTime;
                    least_finish_time_indx.FinishTime = an_event.EndTime;
                    least_finish_time_indx.events.Add(an_event);
                    least_finish_time_indx.TotalWorkingTime += an_event.ServiceTime;
                    int temp = 0;

                    foreach (SimulationCase cs in cases)
                    {
                        if (cs.StartTime > an_event.ArrivalTime)
                        {
                            temp++;
                        }

                    }
                    cases.Add(an_event);
                    temp++;

                    if (temp > biggest_q) biggest_q = temp;
                }
            }
            
            
           


            return biggest_q;
        }

        //performace measures for servers
        static void performance_measures_server(ref SimulationSystem system) {
            int sim_time=int.MinValue;
            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                foreach (Server srv in system.Servers)
                    if (srv.FinishTime > sim_time)
                        sim_time = srv.FinishTime;
            }
            else
                sim_time = system.StoppingNumber;
                
                

            foreach (Server srv in system.Servers) {
                if (srv.TotalWorkingTime != 0 && srv.events.Count() != 0)
                    srv.AverageServiceTime = (decimal)srv.TotalWorkingTime / (decimal)srv.events.Count();
                else
                    srv.AverageServiceTime = 0;
               
                srv.IdleProbability = (decimal)(sim_time - srv.TotalWorkingTime) / (decimal)sim_time;
                srv.Utilization = (decimal)srv.TotalWorkingTime /(decimal) sim_time;
            }
        }

        //performace measures for system
        static void performance_measures_system(ref SimulationSystem system , int bigest_q) {
            decimal total_time_cst_waited_in_q = 0;
            decimal avrg_wait;
            decimal num_of_cst_in_q = 0;
            decimal prob = 0;
            foreach (SimulationCase sc in system.SimulationTable)
                if (sc.TimeInQueue > 0)
                {
                    total_time_cst_waited_in_q += sc.TimeInQueue;
                    num_of_cst_in_q++;

                }
            if (system.StoppingCriteria == Enums.StoppingCriteria.NumberOfCustomers)
            {
                avrg_wait = (total_time_cst_waited_in_q / system.StoppingNumber);
                prob = (num_of_cst_in_q / system.StoppingNumber);


            }
            else
            {
                avrg_wait = (total_time_cst_waited_in_q / system.cit_2_cst_no);
                prob = (num_of_cst_in_q / system.cit_2_cst_no);


            }

            system.PerformanceMeasures.AverageWaitingTime = avrg_wait;
            system.PerformanceMeasures.WaitingProbability = prob;
            system.PerformanceMeasures.MaxQueueLength = bigest_q;

        }
    }
}
