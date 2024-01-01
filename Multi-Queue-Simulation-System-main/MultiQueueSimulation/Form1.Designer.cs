namespace MultiQueueSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tbl_cst_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tble_rnd_arrival = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_interarriv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_clock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_rnd_srvs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_srvs_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_srvr_ind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbl_q_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.time_interarrival = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_prob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_cum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_min = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time_max = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView3 = new System.Windows.Forms.ListView();
            this.srvr_index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.srvr_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.srvr_prob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.srvs_cum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.srvr_min = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.srvr_max = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.srvr_no = new System.Windows.Forms.Label();
            this.stp_crit = new System.Windows.Forms.Label();
            this.selection = new System.Windows.Forms.Label();
            this.stp_no = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(475, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 114);
            this.label1.TabIndex = 31;
            this.label1.Text = "MultiQueue";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 10);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(10, 675);
            this.flowLayoutPanel2.TabIndex = 33;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(10, 0);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(1433, 10);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(10, 675);
            this.flowLayoutPanel4.TabIndex = 34;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(10, 675);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(1423, 10);
            this.flowLayoutPanel5.TabIndex = 35;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tbl_cst_no,
            this.tble_rnd_arrival,
            this.tbl_interarriv,
            this.tbl_clock,
            this.tbl_rnd_srvs,
            this.tbl_start,
            this.tbl_srvs_time,
            this.tbl_end,
            this.tbl_srvr_ind,
            this.tbl_q_time});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 130);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(858, 537);
            this.listView1.TabIndex = 36;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tbl_cst_no
            // 
            this.tbl_cst_no.Text = "Customer No.";
            this.tbl_cst_no.Width = 80;
            // 
            // tble_rnd_arrival
            // 
            this.tble_rnd_arrival.Text = "Random Arrival";
            this.tble_rnd_arrival.Width = 90;
            // 
            // tbl_interarriv
            // 
            this.tbl_interarriv.Text = "Interarrival";
            this.tbl_interarriv.Width = 70;
            // 
            // tbl_clock
            // 
            this.tbl_clock.Text = "Arrival Clock Time";
            this.tbl_clock.Width = 108;
            // 
            // tbl_rnd_srvs
            // 
            this.tbl_rnd_srvs.Text = "Random Service";
            this.tbl_rnd_srvs.Width = 100;
            // 
            // tbl_start
            // 
            this.tbl_start.Text = "Start Time";
            // 
            // tbl_srvs_time
            // 
            this.tbl_srvs_time.Text = "Service Time";
            this.tbl_srvs_time.Width = 85;
            // 
            // tbl_end
            // 
            this.tbl_end.Text = "End Time";
            // 
            // tbl_srvr_ind
            // 
            this.tbl_srvr_ind.Text = "Server Index";
            this.tbl_srvr_ind.Width = 80;
            // 
            // tbl_q_time
            // 
            this.tbl_q_time.Text = "Time in Queue";
            this.tbl_q_time.Width = 90;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(991, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 37;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time_interarrival,
            this.time_prob,
            this.time_cum,
            this.time_min,
            this.time_max});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(896, 130);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(546, 244);
            this.listView2.TabIndex = 38;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // time_interarrival
            // 
            this.time_interarrival.Text = "Interarrival Time";
            this.time_interarrival.Width = 90;
            // 
            // time_prob
            // 
            this.time_prob.Text = "Probability";
            // 
            // time_cum
            // 
            this.time_cum.Text = "Cumulative Probability";
            this.time_cum.Width = 120;
            // 
            // time_min
            // 
            this.time_min.Text = "Range (Min)";
            this.time_min.Width = 75;
            // 
            // time_max
            // 
            this.time_max.Text = "Range (Max)";
            this.time_max.Width = 75;
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.srvr_index,
            this.srvr_time,
            this.srvr_prob,
            this.srvs_cum,
            this.srvr_min,
            this.srvr_max});
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(896, 396);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(546, 270);
            this.listView3.TabIndex = 39;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            // 
            // srvr_index
            // 
            this.srvr_index.Text = "Server Index";
            this.srvr_index.Width = 75;
            // 
            // srvr_time
            // 
            this.srvr_time.Text = "Service Time";
            this.srvr_time.Width = 75;
            // 
            // srvr_prob
            // 
            this.srvr_prob.Text = "Service Probability";
            this.srvr_prob.Width = 105;
            // 
            // srvs_cum
            // 
            this.srvs_cum.Text = "Cumulative Probability";
            this.srvs_cum.Width = 120;
            // 
            // srvr_min
            // 
            this.srvr_min.Text = "Range (Min)";
            this.srvr_min.Width = 75;
            // 
            // srvr_max
            // 
            this.srvr_max.Text = "Range (Max)";
            this.srvr_max.Width = 75;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.flowLayoutPanel6.Location = new System.Drawing.Point(880, 131);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(10, 535);
            this.flowLayoutPanel6.TabIndex = 40;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.flowLayoutPanel7.Location = new System.Drawing.Point(896, 380);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(549, 10);
            this.flowLayoutPanel7.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "Number of Servers :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Stopping Number :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Stopping Criteria :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "Selection Method :";
            // 
            // srvr_no
            // 
            this.srvr_no.AutoSize = true;
            this.srvr_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srvr_no.Location = new System.Drawing.Point(155, 16);
            this.srvr_no.Name = "srvr_no";
            this.srvr_no.Size = new System.Drawing.Size(16, 16);
            this.srvr_no.TabIndex = 46;
            this.srvr_no.Text = "...";
            // 
            // stp_crit
            // 
            this.stp_crit.AutoSize = true;
            this.stp_crit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stp_crit.Location = new System.Drawing.Point(155, 73);
            this.stp_crit.Name = "stp_crit";
            this.stp_crit.Size = new System.Drawing.Size(16, 16);
            this.stp_crit.TabIndex = 47;
            this.stp_crit.Text = "...";
            // 
            // selection
            // 
            this.selection.AutoSize = true;
            this.selection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selection.Location = new System.Drawing.Point(155, 41);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(16, 16);
            this.selection.TabIndex = 48;
            this.selection.Text = "...";
            // 
            // stp_no
            // 
            this.stp_no.AutoSize = true;
            this.stp_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stp_no.Location = new System.Drawing.Point(155, 94);
            this.stp_no.Name = "stp_no";
            this.stp_no.Size = new System.Drawing.Size(16, 16);
            this.stp_no.TabIndex = 49;
            this.stp_no.Text = "...";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1443, 10);
            this.flowLayoutPanel3.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1142, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 45);
            this.button2.TabIndex = 51;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 685);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.stp_no);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.stp_crit);
            this.Controls.Add(this.srvr_no);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel7);
            this.Controls.Add(this.flowLayoutPanel6);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader tbl_cst_no;
        private System.Windows.Forms.ColumnHeader tble_rnd_arrival;
        private System.Windows.Forms.ColumnHeader tbl_interarriv;
        private System.Windows.Forms.ColumnHeader tbl_clock;
        private System.Windows.Forms.ColumnHeader tbl_rnd_srvs;
        private System.Windows.Forms.ColumnHeader tbl_start;
        private System.Windows.Forms.ColumnHeader tbl_srvs_time;
        private System.Windows.Forms.ColumnHeader tbl_end;
        private System.Windows.Forms.ColumnHeader tbl_srvr_ind;
        private System.Windows.Forms.ColumnHeader tbl_q_time;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader time_interarrival;
        private System.Windows.Forms.ColumnHeader time_prob;
        private System.Windows.Forms.ColumnHeader time_cum;
        private System.Windows.Forms.ColumnHeader time_min;
        private System.Windows.Forms.ColumnHeader time_max;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader srvr_index;
        private System.Windows.Forms.ColumnHeader srvr_time;
        private System.Windows.Forms.ColumnHeader srvr_prob;
        private System.Windows.Forms.ColumnHeader srvs_cum;
        private System.Windows.Forms.ColumnHeader srvr_min;
        private System.Windows.Forms.ColumnHeader srvr_max;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label srvr_no;
        private System.Windows.Forms.Label stp_crit;
        private System.Windows.Forms.Label selection;
        private System.Windows.Forms.Label stp_no;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button2;
    }
}

