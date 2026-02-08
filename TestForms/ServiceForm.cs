using FormService;
using MistPrintCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForms
{
    public partial class ServiceForm : Form
    {
        private ServiceFormLogic logic { get; set; }
        public ServiceForm()
        {
            InitializeComponent();
            logic = new ServiceFormLogic(this, treeFiles);
        }
        private void btInit_Click(object sender, EventArgs e)
        {
            logic.InitializeCore();
            btInit.Enabled = false;
        }
        public void UpdateStatus()
        {
            if (logic._running && logic.core != null && Locals.CurrentStatus != null)
            {
                Action action = () =>
                {
                    lblStatus.Text = Locals.CurrentStatus.Status.ToString();
                    lblBedTemp.Text = Locals.CurrentStatus.BedTemp.ToString() + " / " + Locals.CurrentStatus.TargetBedTemp;
                    lblNozzleTemp.Text = Locals.CurrentStatus.NozzleTemp.ToString() + " / " + Locals.CurrentStatus.TargetNozzleTemp;
                    lblLayers.Text = (Locals.CurrentStatus.CurrentLayer >= 0 ? Locals.CurrentStatus.CurrentLayer.ToString() : "0") + " / " + Locals.CurrentStatus.TotalLayers;
                    lblEspTemp.Text = Math.Round(Locals.CurrentStatus.EspTemp, 1, MidpointRounding.AwayFromZero).ToString();
                    lblJobFile.Text = Locals.CurrentStatus.CurrentJobName;
                    lblLastSeen.Text = Locals.CurrentStatus.LastResponse + " s";
                    lblTime.Text = Locals.CurrentStatus.SpentTimeGc;
                    lblTimeReal.Text = Locals.CurrentStatus.SpentTimeReal;
                    lblTotalGc.Text = Locals.CurrentStatus.TotalSecondsGc + " s";

                    lblEstimate.Text = Locals.CurrentStatus.RemainingTimeString;

                    panelStat.Visible = true;
                    panelFiles.Visible = true;
                    lblFiles.Visible = true;
                    btnDelete.Visible = true;
                    btnUpload.Visible = true;
                    panelUpdate.Visible = true;
                    lblUpdate.Visible = true;
                };
                if(InvokeRequired)
                    Invoke(action);
                else
                    action();
            }
            else
            {
                Action action = () =>
                {
                    panelStat.Visible = false;
                    panelFiles.Visible = false;
                    lblFiles.Visible = false;
                    btnDelete.Visible = false;
                    btnUpload.Visible = false;
                    panelUpdate.Visible = false;
                    lblUpdate.Visible = false;
                };
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            }
        }

        private void treeFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.ToLower().EndsWith(".gcode"))
                btnPrint.Enabled = logic.SetJobFileFromNode(e.Node);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(treeFiles.SelectedNode != null && MessageBox.Show("Are you sure want to delete selected object?", "Delete warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                logic.DeleteFileFromNode(treeFiles.SelectedNode);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { Filter = ".gcode|*.gcode", Multiselect = false };
            fileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(fileDialog.FileName))
                logic.UploadFile(fileDialog.FileName, treeFiles.SelectedNode);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to start printing? Make sure that print table is clear", "Print warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Locals.Core.StartPrint();
                btnStop.Enabled = true;
                btnPrint.Enabled = false;
                panelUpdate.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to abort printing?", "Stop warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Locals.Core.StopPrint();
                btnStop.Enabled = false;
                btnPrint.Enabled = false;
                panelUpdate.Enabled = true;
            }
        }

        private void btnBrowseFirm_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { Filter = ".bin|*.bin", Multiselect = false };
            fileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(fileDialog.FileName))
                txtFirm.Text = fileDialog.FileName;
        }

        private void btnUpdateFirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirm.Text) && MessageBox.Show("Are you sure want to start update process? Make sure that correct file is selected", "Print warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Locals.CurrentStatus.Status = MistPrintCore.Enums.Enums.DeviceJobStatus.UPDATE;
                Locals.FirmawarePath = txtFirm.Text;
            }
        }

        private void ServiceForm_Shown(object sender, EventArgs e)
        {
            logic.InitializeCore();
            btInit.Enabled = false;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            logic.RefreshFiles();
        }
    }
}
