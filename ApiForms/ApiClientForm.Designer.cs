namespace ApiForms
{
    partial class ApiClientForm
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
            this.lblEstimate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblFiles = new System.Windows.Forms.Label();
            this.panelFiles = new System.Windows.Forms.Panel();
            this.treeFiles = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelStat = new System.Windows.Forms.Panel();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLayers = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblJobFile = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEspTemp = new System.Windows.Forms.Label();
            this.lblLastSeen = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBedTemp = new System.Windows.Forms.Label();
            this.lblNozzleTemp = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btCreateDir = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.panelFiles.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelStat.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEstimate
            // 
            this.lblEstimate.AutoSize = true;
            this.lblEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEstimate.Location = new System.Drawing.Point(108, 200);
            this.lblEstimate.Name = "lblEstimate";
            this.lblEstimate.Size = new System.Drawing.Size(40, 16);
            this.lblEstimate.TabIndex = 22;
            this.lblEstimate.Text = "None";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(4, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Remaining time:";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(194, 417);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFiles.Location = new System.Drawing.Point(290, 9);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(36, 16);
            this.lblFiles.TabIndex = 20;
            this.lblFiles.Text = "Files";
            // 
            // panelFiles
            // 
            this.panelFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFiles.Controls.Add(this.treeFiles);
            this.panelFiles.Location = new System.Drawing.Point(288, 31);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.Size = new System.Drawing.Size(364, 380);
            this.panelFiles.TabIndex = 19;
            // 
            // treeFiles
            // 
            this.treeFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeFiles.Location = new System.Drawing.Point(3, 3);
            this.treeFiles.Name = "treeFiles";
            this.treeFiles.Size = new System.Drawing.Size(354, 370);
            this.treeFiles.TabIndex = 0;
            this.treeFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFiles_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panelStat);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(14, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 380);
            this.panel1.TabIndex = 17;
            // 
            // panelStat
            // 
            this.panelStat.Controls.Add(this.lblElapsed);
            this.panelStat.Controls.Add(this.label4);
            this.panelStat.Controls.Add(this.lblEstimate);
            this.panelStat.Controls.Add(this.lblLayers);
            this.panelStat.Controls.Add(this.label15);
            this.panelStat.Controls.Add(this.label10);
            this.panelStat.Controls.Add(this.lblJobFile);
            this.panelStat.Controls.Add(this.label13);
            this.panelStat.Controls.Add(this.label5);
            this.panelStat.Controls.Add(this.lblEspTemp);
            this.panelStat.Controls.Add(this.lblLastSeen);
            this.panelStat.Controls.Add(this.label11);
            this.panelStat.Controls.Add(this.label7);
            this.panelStat.Controls.Add(this.lblBedTemp);
            this.panelStat.Controls.Add(this.lblNozzleTemp);
            this.panelStat.Controls.Add(this.label9);
            this.panelStat.Location = new System.Drawing.Point(6, 41);
            this.panelStat.Name = "panelStat";
            this.panelStat.Size = new System.Drawing.Size(255, 258);
            this.panelStat.TabIndex = 6;
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblElapsed.Location = new System.Drawing.Point(108, 173);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(40, 16);
            this.lblElapsed.TabIndex = 24;
            this.lblElapsed.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(4, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Elapsed time:";
            // 
            // lblLayers
            // 
            this.lblLayers.AutoSize = true;
            this.lblLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLayers.Location = new System.Drawing.Point(109, 147);
            this.lblLayers.Name = "lblLayers";
            this.lblLayers.Size = new System.Drawing.Size(40, 16);
            this.lblLayers.TabIndex = 13;
            this.lblLayers.Text = "None";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(4, 147);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 16);
            this.label15.TabIndex = 12;
            this.label15.Text = "Done layers:";
            // 
            // lblJobFile
            // 
            this.lblJobFile.AutoSize = true;
            this.lblJobFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblJobFile.Location = new System.Drawing.Point(108, 121);
            this.lblJobFile.Name = "lblJobFile";
            this.lblJobFile.Size = new System.Drawing.Size(40, 16);
            this.lblJobFile.TabIndex = 11;
            this.lblJobFile.Text = "None";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(3, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "Job file:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Last seen:";
            // 
            // lblEspTemp
            // 
            this.lblEspTemp.AutoSize = true;
            this.lblEspTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEspTemp.Location = new System.Drawing.Point(108, 95);
            this.lblEspTemp.Name = "lblEspTemp";
            this.lblEspTemp.Size = new System.Drawing.Size(40, 16);
            this.lblEspTemp.TabIndex = 9;
            this.lblEspTemp.Text = "None";
            // 
            // lblLastSeen
            // 
            this.lblLastSeen.AutoSize = true;
            this.lblLastSeen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLastSeen.Location = new System.Drawing.Point(108, 9);
            this.lblLastSeen.Name = "lblLastSeen";
            this.lblLastSeen.Size = new System.Drawing.Size(40, 16);
            this.lblLastSeen.TabIndex = 3;
            this.lblLastSeen.Text = "None";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "Esp temp.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nozzle temp.";
            // 
            // lblBedTemp
            // 
            this.lblBedTemp.AutoSize = true;
            this.lblBedTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBedTemp.Location = new System.Drawing.Point(108, 65);
            this.lblBedTemp.Name = "lblBedTemp";
            this.lblBedTemp.Size = new System.Drawing.Size(40, 16);
            this.lblBedTemp.TabIndex = 7;
            this.lblBedTemp.Text = "None";
            // 
            // lblNozzleTemp
            // 
            this.lblNozzleTemp.AutoSize = true;
            this.lblNozzleTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNozzleTemp.Location = new System.Drawing.Point(108, 36);
            this.lblNozzleTemp.Name = "lblNozzleTemp";
            this.lblNozzleTemp.Size = new System.Drawing.Size(40, 16);
            this.lblNozzleTemp.TabIndex = 5;
            this.lblNozzleTemp.Text = "None";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Bed temp.";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(115, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Disabled";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Status:";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(577, 417);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpload.Location = new System.Drawing.Point(288, 417);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 15;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(14, 417);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btCreateDir
            // 
            this.btCreateDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCreateDir.Location = new System.Drawing.Point(369, 417);
            this.btCreateDir.Name = "btCreateDir";
            this.btCreateDir.Size = new System.Drawing.Size(105, 23);
            this.btCreateDir.TabIndex = 25;
            this.btCreateDir.Text = "Create folder";
            this.btCreateDir.UseVisualStyleBackColor = true;
            this.btCreateDir.Click += new System.EventHandler(this.btCreateDir_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(496, 417);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 26;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // ApiClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 450);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btCreateDir);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.panelFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ApiClientForm";
            this.Text = "MistPrint Client";
            this.Shown += new System.EventHandler(this.ApiClientForm_Shown);
            this.panelFiles.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelStat.ResumeLayout(false);
            this.panelStat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEstimate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Panel panelFiles;
        private System.Windows.Forms.TreeView treeFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelStat;
        private System.Windows.Forms.Label lblLayers;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblJobFile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEspTemp;
        private System.Windows.Forms.Label lblLastSeen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBedTemp;
        private System.Windows.Forms.Label lblNozzleTemp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btCreateDir;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btRefresh;
    }
}

