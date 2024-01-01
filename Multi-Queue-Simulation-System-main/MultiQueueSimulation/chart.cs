using MultiQueueModels;
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

namespace MultiQueueSimulation
{
    public partial class chart : UserControl
    {
        SimulationSystem system;
        int srvr_id;
        public chart(ref SimulationSystem system , int srvr)
        {
            InitializeComponent();
            this.system = system;
            this.srvr_id = srvr;
        }

       
        private void chart_Load(object sender, EventArgs e)
        {
            int finish_time = int.MinValue;
            foreach (Server serv in system.Servers)
            {
                if (serv.FinishTime > finish_time)
                    finish_time = serv.FinishTime;
            }
            int interval = finish_time /10;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = finish_time;
            chart1.ChartAreas[0].AxisX.Interval = interval;


            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Interval = 0.1;


            chart1.Series.Clear();
            var working = new Series
            {
                Name = "working",
                Color = Color.Blue,
                ChartType = SeriesChartType.Column
                
            };

            var idle = new Series
            {
                Name = "idle",
                Color = Color.Red,
                ChartType = SeriesChartType.Column
            };

            int time = 0;
            while (time <= finish_time)
            {
                bool flag = false;
                foreach (SimulationCase sc in system.Servers.ElementAt(srvr_id).events)
                {
                    if (Enumerable.Range(sc.StartTime, sc.EndTime).Contains(time))
                    {
                        flag = true;
                        working.Points.AddXY(time, 1);
                        break;
                    }
                }
                if (flag == false)
                {
                    idle.Points.AddXY(time, 1);

                }
                time++;
            }



            chart1.Series.Add(working);
            chart1.Series.Add(idle);
            chart1.Series["working"]["PointWidth"] = "2";
            chart1.Series["idle"]["PointWidth"] = "2";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
