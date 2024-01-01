using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MultiQueueModels;


namespace MultiQueueSimulation
{
    public partial class results : UserControl
    {
        SimulationSystem system;
        int srvr_id;
        public results(ref SimulationSystem system )
        {
            InitializeComponent();
            this.system = system;
            this.sys_avg.Text =system.PerformanceMeasures.AverageWaitingTime.ToString();
            this.sys_prop.Text = system.PerformanceMeasures.WaitingProbability.ToString(); ;
            this.sys_max.Text=system.PerformanceMeasures.MaxQueueLength.ToString();
            server_fill();
        }

        private void server_fill() {
            foreach (Server serv in system.Servers)
                comboBox1.Items.Add(serv.ID);
        }
        private void results_Load(object sender, EventArgs e)
        {
            //graph
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             srvr_id = Convert.ToInt32(comboBox1.Text) - 1;
            decimal get_srvr_avg = Math.Round(system.Servers.ElementAt(srvr_id).AverageServiceTime,5);
            decimal get_srvr_prop = Math.Round(system.Servers.ElementAt(srvr_id).IdleProbability,5);
            decimal get_srvr_uti = Math.Round(system.Servers.ElementAt(srvr_id).Utilization, 5);
            this.srvr_avg.Text =get_srvr_avg.ToString();
            this.srvr_prop.Text = get_srvr_prop.ToString();
            this.srvr_uti.Text = get_srvr_uti.ToString();

            //------------------------------------------------
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart c = new chart(ref system, srvr_id);
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);
            c.BringToFront();
        }
    }
}
