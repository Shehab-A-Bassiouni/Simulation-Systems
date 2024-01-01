using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using System.IO;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form

    {
        SimulationSystem system;
        
        public Form1(ref SimulationSystem system)
        {
            this.system = system;
           
            InitializeComponent();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            system.PerformanceMeasures.TotalSalesProfit = 0;
            system.PerformanceMeasures.TotalCost = 0;
            system.PerformanceMeasures.TotalLostProfit = 0;
            system.PerformanceMeasures.TotalScrapProfit = 0;
            system.PerformanceMeasures.TotalNetProfit = 0;
            system.PerformanceMeasures.DaysWithMoreDemand = 0;
            system.PerformanceMeasures.DaysWithUnsoldPapers = 0;



        }
        private void intializeView1()
        {
            foreach (SimulationCase sc in system.SimulationTable) {
                string day = sc.DayNo.ToString();
                string randomType = sc.RandomNewsDayType.ToString();
                string newType = sc.NewsDayType.ToString();
                string rndmDemand = sc.RandomDemand.ToString();
                string dem = sc.Demand.ToString();
                decimal cost = (decimal)((system.NumOfNewspapers * 33) / 100);
                string purchase = cost.ToString();
                string salesProfit = sc.SalesProfit.ToString();
                string lost = sc.LostProfit.ToString();
                string scrap = sc.ScrapProfit.ToString();
                string netProfit = sc.DailyNetProfit.ToString();
                string[] list = { day, randomType, newType, rndmDemand, dem, purchase, salesProfit , lost, scrap , netProfit };
                ListViewItem item = new ListViewItem(list);
                listView1.Items.Add(item);
            }
        
        }
        private void initiallizeView2() 
        {
            string numOfPapers = system.NumOfNewspapers.ToString();
            string numOfRecords = system.NumOfRecords.ToString();
            string purchase = system.PurchasePrice.ToString();
            string scrap = system.ScrapPrice.ToString();
            string selling = system.SellingPrice.ToString();
            string[] list = { numOfPapers, numOfRecords, purchase, scrap, selling };
            ListViewItem item = new ListViewItem(list);
            listView2.Items.Add(item);
        }

        private void intializeVieww3() {

            foreach (DayTypeDistribution dt in system.DayTypeDistributions) {
                string day;
                if (dt.DayType == Enums.DayType.Good) day = "Good";
                else if (dt.DayType == Enums.DayType.Fair) day = "Fair";
                else day = "Poor";
                string prob = dt.Probability.ToString();
                string cumm = dt.CummProbability.ToString();
                string min = dt.MinRange.ToString();
                string max = dt.MaxRange.ToString();
                string[] list = { day, prob, cumm, min, max };
                ListViewItem item = new ListViewItem(list);
                listView3.Items.Add(item);
            }
        }

        private void initializaeView4() {
            foreach (DemandDistribution dd in system.DemandDistributions) {
                string demand = dd.Demand.ToString();
                string good = dd.DayTypeDistributions.ElementAt(0).Probability.ToString();
                string fair = dd.DayTypeDistributions.ElementAt(1).Probability.ToString();
                string poor = dd.DayTypeDistributions.ElementAt(2).Probability.ToString();
                string G_min= dd.DayTypeDistributions.ElementAt(0).MinRange.ToString();
                string G_max= dd.DayTypeDistributions.ElementAt(0).MaxRange.ToString();
                string F_min= dd.DayTypeDistributions.ElementAt(1).MinRange.ToString();
                string F_max= dd.DayTypeDistributions.ElementAt(1).MaxRange.ToString();
                string P_min= dd.DayTypeDistributions.ElementAt(2).MinRange.ToString();
                string P_max= dd.DayTypeDistributions.ElementAt(2).MaxRange.ToString();
                string[] list = { demand, good, fair, poor, G_min, G_max, F_min, F_max , P_min , P_max };
                ListViewItem item = new ListViewItem(list);
                listView4.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void clear() {
          

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            system.test = Convert.ToInt32(comboBox1.Text);
            fileProcessing();
            simCase();
            intializeView1();
            initiallizeView2();
            intializeVieww3();
            initializaeView4();
            intializelabels();
            string result;
            if (system.test == 1)
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase1);
                MessageBox.Show(result);
            }
            else if (system.test == 2)
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase2);
                MessageBox.Show(result);
            }
            else {
                result = TestingManager.Test(system, Constants.FileNames.TestCase3);
                MessageBox.Show(result);
            }

        }
        private void intializelabels() {
            label9.Text = system.PerformanceMeasures.TotalSalesProfit.ToString();
            label10.Text = system.PerformanceMeasures.TotalCost.ToString();
            label11.Text = system.PerformanceMeasures.TotalLostProfit.ToString();
            label12.Text = system.PerformanceMeasures.TotalScrapProfit.ToString();
            label13.Text = system.PerformanceMeasures.TotalNetProfit.ToString();
            label14.Text = system.PerformanceMeasures.DaysWithMoreDemand.ToString();
            label15.Text = system.PerformanceMeasures.DaysWithUnsoldPapers.ToString();
        }
        private void fileProcessing() {
            //reading the file into single string then split it by empty lines
            string PATH;
            if (system.test == 1) PATH = "..\\..\\TestCases\\TestCase1.txt";
            else if (system.test == 2) PATH = "..\\..\\TestCases\\TestCase2.txt";
            else PATH = "..\\..\\TestCases\\TestCase3.txt";

            string line = File.ReadAllText(PATH);
            string[] entries = line.Split(new string[] { "\r\n\r\n" }, Int32.MaxValue, StringSplitOptions.RemoveEmptyEntries);
            //-------------------------------------------------------------------------------------------------------------
            system.NumOfNewspapers = intSingleLine(entries[0]);
            system.NumOfRecords = intSingleLine(entries[1]);
            system.PurchasePrice = decimalSingleLine(entries[2]);
            system.ScrapPrice = decimalSingleLine(entries[3]);
            system.SellingPrice = decimalSingleLine(entries[4]);
            dayDist(entries[5]);
            demand(entries[6]);
            cummForDemand();
        }
        private int intSingleLine(string toSplit)
        {
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num = Convert.ToInt32(newSplit[1]);
            return num;
        }

        private decimal decimalSingleLine(string toSplit)
        {
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            decimal num = Convert.ToDecimal(newSplit[1]);
            return num;
        }
        private void dayDist(string toSplit)
        {
            decimal cumm = 0;

            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] body = newSplit[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i <= 3; i++) {
                DayTypeDistribution dt = new DayTypeDistribution();
                if (i == 1) dt.DayType = Enums.DayType.Good;
                else if (i == 2) dt.DayType = Enums.DayType.Fair;
                else dt.DayType = Enums.DayType.Poor;
                dt.Probability = Convert.ToDecimal(body[i - 1]);
                cumm += dt.Probability;
                dt.CummProbability = cumm;
                dt.MaxRange = (int)(cumm * 100);
                dt.MinRange = (int)((dt.CummProbability - dt.Probability) * 100) + 1;
                system.DayTypeDistributions.Add(dt);
            }

        }

        private void demand(string toSplit) {
            string[] newSplit = toSplit.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < newSplit.Length; i++) {
                DemandDistribution dd = new DemandDistribution();
                string[] body = newSplit[i].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                dd.Demand = Convert.ToInt32(body[0]);
                
                for (int y = 1; y <= 3; y++) { 
                    DayTypeDistribution dt = new DayTypeDistribution();
                    if (y == 1) dt.DayType = Enums.DayType.Good;
                    else if (y == 2) dt.DayType = Enums.DayType.Fair;
                    else dt.DayType = Enums.DayType.Poor;
                    dt.Probability = Convert.ToDecimal(body[y]);
                    dd.DayTypeDistributions.Add(dt);
                }
                system.DemandDistributions.Add(dd);
                
            }



        }

        private void cummForDemand() {
            decimal cummGood = 0;
            decimal cummFair = 0;
            decimal cummPoor = 0;

            foreach (DemandDistribution dd in system.DemandDistributions) {
                cummGood += dd.DayTypeDistributions.ElementAt(0).Probability;
                cummFair += dd.DayTypeDistributions.ElementAt(1).Probability;
                cummPoor += dd.DayTypeDistributions.ElementAt(2).Probability;
                //----
                dd.DayTypeDistributions.ElementAt(0).CummProbability=cummGood;
                dd.DayTypeDistributions.ElementAt(1).CummProbability = cummFair;
                dd.DayTypeDistributions.ElementAt(2).CummProbability = cummPoor;
                //----
                dd.DayTypeDistributions.ElementAt(0).MaxRange= (int)(cummGood * 100);
                dd.DayTypeDistributions.ElementAt(1).MaxRange = (int)(cummFair * 100);
                dd.DayTypeDistributions.ElementAt(2).MaxRange = (int)(cummPoor * 100);
                //------
                dd.DayTypeDistributions.ElementAt(0).MinRange = (int)((dd.DayTypeDistributions.ElementAt(0).CummProbability - dd.DayTypeDistributions.ElementAt(0).Probability) * 100) + 1;
                dd.DayTypeDistributions.ElementAt(1).MinRange = (int)((dd.DayTypeDistributions.ElementAt(1).CummProbability - dd.DayTypeDistributions.ElementAt(1).Probability) * 100) + 1;
                dd.DayTypeDistributions.ElementAt(2).MinRange = (int)((dd.DayTypeDistributions.ElementAt(2).CummProbability - dd.DayTypeDistributions.ElementAt(2).Probability) * 100) + 1;


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void simCase() {
            Random rd = new Random();
            for (int i = 0; i < system.NumOfRecords; i++) {
                SimulationCase sc = new SimulationCase();
                sc.DayNo = i;
                sc.RandomNewsDayType = rd.Next(1, 100);
                
                foreach (DayTypeDistribution dt in system.DayTypeDistributions) {
                    if (sc.RandomNewsDayType >= dt.MinRange && sc.RandomNewsDayType <= dt.MaxRange) {
                        sc.NewsDayType = dt.DayType;
                        break;
                    }
                }
                int x;
                if (sc.NewsDayType == Enums.DayType.Good) x = 0;
                else if (sc.NewsDayType == Enums.DayType.Fair) x = 1;
                else x = 2;

                sc.RandomDemand=rd.Next(1, 100);
                

                foreach (DemandDistribution dd in system.DemandDistributions)
                {
                    if (sc.RandomDemand >= dd.DayTypeDistributions.ElementAt(x).MinRange && sc.RandomDemand <= dd.DayTypeDistributions.ElementAt(x).MaxRange) {
                        sc.Demand = dd.Demand;
                        break;
                    }
                }
                //------------------- performance
                sc.DailyCost = (decimal)(system.NumOfNewspapers*system.PurchasePrice);
                if (sc.Demand >= system.NumOfNewspapers) sc.SalesProfit = (system.NumOfNewspapers*system.SellingPrice);
                else sc.SalesProfit = (sc.Demand * system.SellingPrice) ;

                if (sc.Demand < system.NumOfNewspapers)
                {
                    system.PerformanceMeasures.DaysWithUnsoldPapers++;
                    sc.ScrapProfit = (decimal)(((system.NumOfNewspapers - sc.Demand) * system.ScrapPrice));
                }
                else sc.ScrapProfit = 0;

                if (sc.Demand > system.NumOfNewspapers)
                {
                    system.PerformanceMeasures.DaysWithMoreDemand++;
                    sc.LostProfit = (decimal)(((sc.Demand - system.NumOfNewspapers) * (system.SellingPrice - system.PurchasePrice)));
                }
                else sc.LostProfit = 0;

                sc.DailyNetProfit = sc.SalesProfit - sc.DailyCost - sc.LostProfit + sc.ScrapProfit;
                system.PerformanceMeasures.TotalCost += sc.DailyCost;
                system.PerformanceMeasures.TotalSalesProfit += sc.SalesProfit;
                system.PerformanceMeasures.TotalLostProfit += sc.LostProfit;
                system.PerformanceMeasures.TotalScrapProfit += sc.ScrapProfit;
                system.PerformanceMeasures.TotalNetProfit += sc.DailyNetProfit;

                system.SimulationTable.Add(sc);

            }

        }
    }
}
