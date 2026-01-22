namespace TestForms
{
    partial class ServiceForm
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
            this.btInit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelStat = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelFiles = new System.Windows.Forms.Panel();
            this.treeFiles = new System.Windows.Forms.TreeView();
            this.lblFiles = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.btnUpdateFirm = new System.Windows.Forms.Button();
            this.btnBrowseFirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirm = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelStat.SuspendLayout();
            this.panelFiles.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btInit
            // 
            this.btInit.Location = new System.Drawing.Point(12, 415);
            this.btInit.Name = "btInit";
            this.btInit.Size = new System.Drawing.Size(75, 23);
            this.btInit.TabIndex = 0;
            this.btInit.Text = "Initialize";
            this.btInit.UseVisualStyleBackColor = true;
            this.btInit.Click += new System.EventHandler(this.btInit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(104, 415);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(286, 415);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Visible = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(466, 415);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panelStat);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 380);
            this.panel1.TabIndex = 4;
            // 
            // panelStat
            // 
            this.panelStat.Controls.Add(this.lblTime);
            this.panelStat.Controls.Add(this.label17);
            this.panelStat.Controls.Add(this.lblLayers);
            this.panelStat.Controls.Add(this.label15);
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
            this.panelStat.Size = new System.Drawing.Size(242, 258);
            this.panelStat.TabIndex = 6;
            this.panelStat.Visible = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(75, 173);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "None";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 173);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Time:";
            // 
            // lblLayers
            // 
            this.lblLayers.AutoSize = true;
            this.lblLayers.Location = new System.Drawing.Point(76, 147);
            this.lblLayers.Name = "lblLayers";
            this.lblLayers.Size = new System.Drawing.Size(33, 13);
            this.lblLayers.TabIndex = 13;
            this.lblLayers.Text = "None";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 147);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Done layers:";
            // 
            // lblJobFile
            // 
            this.lblJobFile.AutoSize = true;
            this.lblJobFile.Location = new System.Drawing.Point(75, 121);
            this.lblJobFile.Name = "lblJobFile";
            this.lblJobFile.Size = new System.Drawing.Size(33, 13);
            this.lblJobFile.TabIndex = 11;
            this.lblJobFile.Text = "None";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Job file:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Last seen:";
            // 
            // lblEspTemp
            // 
            this.lblEspTemp.AutoSize = true;
            this.lblEspTemp.Location = new System.Drawing.Point(75, 95);
            this.lblEspTemp.Name = "lblEspTemp";
            this.lblEspTemp.Size = new System.Drawing.Size(33, 13);
            this.lblEspTemp.TabIndex = 9;
            this.lblEspTemp.Text = "None";
            // 
            // lblLastSeen
            // 
            this.lblLastSeen.AutoSize = true;
            this.lblLastSeen.Location = new System.Drawing.Point(75, 9);
            this.lblLastSeen.Name = "lblLastSeen";
            this.lblLastSeen.Size = new System.Drawing.Size(33, 13);
            this.lblLastSeen.TabIndex = 3;
            this.lblLastSeen.Text = "None";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Esp temp.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nozzle temp.";
            // 
            // lblBedTemp
            // 
            this.lblBedTemp.AutoSize = true;
            this.lblBedTemp.Location = new System.Drawing.Point(75, 65);
            this.lblBedTemp.Name = "lblBedTemp";
            this.lblBedTemp.Size = new System.Drawing.Size(33, 13);
            this.lblBedTemp.TabIndex = 7;
            this.lblBedTemp.Text = "None";
            // 
            // lblNozzleTemp
            // 
            this.lblNozzleTemp.AutoSize = true;
            this.lblNozzleTemp.Location = new System.Drawing.Point(75, 36);
            this.lblNozzleTemp.Name = "lblNozzleTemp";
            this.lblNozzleTemp.Size = new System.Drawing.Size(33, 13);
            this.lblNozzleTemp.TabIndex = 5;
            this.lblNozzleTemp.Text = "None";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Bed temp.";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(81, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Disabled";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Status";
            // 
            // panelFiles
            // 
            this.panelFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFiles.Controls.Add(this.treeFiles);
            this.panelFiles.Location = new System.Drawing.Point(286, 29);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.Size = new System.Drawing.Size(255, 380);
            this.panelFiles.TabIndex = 7;
            this.panelFiles.Visible = false;
            // 
            // treeFiles
            // 
            this.treeFiles.Location = new System.Drawing.Point(3, 3);
            this.treeFiles.Name = "treeFiles";
            this.treeFiles.Size = new System.Drawing.Size(245, 370);
            this.treeFiles.TabIndex = 0;
            this.treeFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFiles_AfterSelect);
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(283, 13);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(28, 13);
            this.lblFiles.TabIndex = 8;
            this.lblFiles.Text = "Files";
            this.lblFiles.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(192, 415);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panelUpdate
            // 
            this.panelUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUpdate.Controls.Add(this.btnUpdateFirm);
            this.panelUpdate.Controls.Add(this.btnBrowseFirm);
            this.panelUpdate.Controls.Add(this.label4);
            this.panelUpdate.Controls.Add(this.txtFirm);
            this.panelUpdate.Location = new System.Drawing.Point(547, 29);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(241, 380);
            this.panelUpdate.TabIndex = 10;
            this.panelUpdate.Visible = false;
            // 
            // btnUpdateFirm
            // 
            this.btnUpdateFirm.Location = new System.Drawing.Point(159, 56);
            this.btnUpdateFirm.Name = "btnUpdateFirm";
            this.btnUpdateFirm.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateFirm.TabIndex = 14;
            this.btnUpdateFirm.Text = "Update";
            this.btnUpdateFirm.UseVisualStyleBackColor = true;
            this.btnUpdateFirm.Click += new System.EventHandler(this.btnUpdateFirm_Click);
            // 
            // btnBrowseFirm
            // 
            this.btnBrowseFirm.Location = new System.Drawing.Point(7, 56);
            this.btnBrowseFirm.Name = "btnBrowseFirm";
            this.btnBrowseFirm.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFirm.TabIndex = 13;
            this.btnBrowseFirm.Text = "Browse";
            this.btnBrowseFirm.UseVisualStyleBackColor = true;
            this.btnBrowseFirm.Click += new System.EventHandler(this.btnBrowseFirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Selected file";
            // 
            // txtFirm
            // 
            this.txtFirm.Enabled = false;
            this.txtFirm.Location = new System.Drawing.Point(6, 30);
            this.txtFirm.Name = "txtFirm";
            this.txtFirm.Size = new System.Drawing.Size(228, 20);
            this.txtFirm.TabIndex = 0;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(544, 9);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(87, 13);
            this.lblUpdate.TabIndex = 11;
            this.lblUpdate.Text = "Firmware Update";
            this.lblUpdate.Visible = false;
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.panelUpdate);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.panelFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btInit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ServiceForm";
            this.Text = "MistPrint Service Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelStat.ResumeLayout(false);
            this.panelStat.PerformLayout();
            this.panelFiles.ResumeLayout(false);
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btInit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLastSeen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEspTemp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblBedTemp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNozzleTemp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelStat;
        private System.Windows.Forms.Label lblJobFile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblLayers;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelFiles;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.TreeView treeFiles;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.Button btnUpdateFirm;
        private System.Windows.Forms.Button btnBrowseFirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirm;
        private System.Windows.Forms.Label lblUpdate;
    }
}

