using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using MultiQueueTesting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MultiQueueSimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem system;
        public Form1(ref SimulationSystem system)
        {
            InitializeComponent();
            this.system = system;
            fill_basic();
            fill_time();
            fill_server();
            fill_event();
        }

        private void fill_basic() {
            srvr_no.Text = system.NumberOfServers.ToString();
            selection.Text = system.SelectionMethod.ToString();
            stp_crit.Text = system.StoppingCriteria.ToString();
            stp_no.Text = system.StoppingNumber.ToString();
        }

        private void fill_time()
        {
            foreach (TimeDistribution td in system.InterarrivalDistribution) {
                string[] info = { td.Time.ToString(), td.Probability.ToString(), td.CummProbability.ToString(), td.MinRange.ToString(), td.MaxRange.ToString() };
                ListViewItem item = new ListViewItem(info);
                listView2.Items.Add(item);
            }
        }

        private void fill_server() {
            foreach (Server srvr in system.Servers) { 
            string srvr_indx = srvr.ID.ToString();
                foreach (TimeDistribution td in srvr.TimeDistribution) {
                    string time=td.Time.ToString();
                    string probability=td.Probability.ToString();
                    string cumm=td.CummProbability.ToString();
                    string rangemin=td.MinRange.ToString();
                    string rangemax = td.MaxRange.ToString();
                    string[] info = {srvr_indx,time,probability,cumm,rangemin,rangemax };
                    ListViewItem item = new ListViewItem(info);
                    listView3.Items.Add(item);
                }
                string[] splitline = { "...................", "...................", "...................", "...................", "...................", "..................." };
                ListViewItem item2 = new ListViewItem(splitline);
                listView3.Items.Add(item2);
            }
          
        }

        private void fill_event() {
            foreach (SimulationCase sc in system.SimulationTable)
            {
                string CustomerNumber=sc.CustomerNumber.ToString();
                string RandomInterArrival =sc.RandomInterArrival.ToString();
                string InterArrival =sc.InterArrival.ToString();
                string ArrivalTime =sc.ArrivalTime.ToString();
                string RandomService =sc.RandomService.ToString();
                string ServiceTime =sc.ServiceTime.ToString();
                string AssignedServer =sc.AssignedServer.ID.ToString();
                string StartTime =sc.StartTime.ToString();
                string EndTime =sc.EndTime.ToString();
                string TimeInQueue =sc.TimeInQueue.ToString();
                string[] info = { CustomerNumber, RandomInterArrival, InterArrival, ArrivalTime, RandomService, StartTime,  ServiceTime , EndTime , AssignedServer, TimeInQueue };
                ListViewItem item = new ListViewItem(info);
                listView1.Items.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            results res = new results(ref system);
            res.Dock = DockStyle.Fill;
            this.Controls.Add(res);
            res.BringToFront();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
