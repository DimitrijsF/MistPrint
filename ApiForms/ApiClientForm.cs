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

namespace ApiForms
{
    public partial class ApiClientForm : Form
    {
        public ApiClientForm()
        {
            InitializeComponent();
        }

        private ApiClientFormLogic logic;

        private void ApiClientForm_Shown(object sender, EventArgs e)
        {
            logic = new ApiClientFormLogic(this);
            logic.FileTree = treeFiles;
            logic.Initialize();
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var treeRoot = await logic.GetInitialFilesList();
            Action action = () =>
            {
                treeFiles.Nodes.Clear();
                treeFiles.Nodes.Add(treeRoot);
                treeFiles.ExpandAll();
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();

        }
        public void UpdateStatus()
        {
            if (logic._running && logic.Status != null)
            {
                Action action = () =>
                {
                    lblStatus.Text = logic.Status.Status;
                    lblBedTemp.Text = logic.Status.BedTemp.ToString() + " / " + logic.Status.TargetBedTemp;
                    lblNozzleTemp.Text = logic.Status.NozzleTemp.ToString() + " / " + logic.Status.TargetNozzleTemp;
                    lblLayers.Text = (logic.Status.CurrentLayer >= 0 ? logic.Status.CurrentLayer.ToString() : "0") + " / " + logic.Status.TotalLayers;
                    lblEspTemp.Text = Math.Round(logic.Status.EspTemp, 1, MidpointRounding.AwayFromZero).ToString();
                    lblJobFile.Text = logic.Status.CurrentJobName;
                    lblLastSeen.Text = logic.Status.LastResponse + " s";
                    lblEstimate.Text = logic.Status.RemainingTimeString;
                    lblElapsed.Text = logic.Status.SpentTimeReal;
                    if(logic.Status.Status.ToLower() == "ready" && !string.IsNullOrEmpty(logic.Status.CurrentJobName))
                        btnPrint.Enabled = true;
                    else
                        btnPrint.Enabled = false;
                    if (logic.Status.Status.ToLower() == "printing" || logic.Status.Status.ToLower() == "finishing")
                        btnStop.Enabled = true;
                    else
                        btnStop.Enabled = false;
                };
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            }
        }
        private async void treeFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            await logic.SelectFile("/" + e.Node.Tag.ToString());
        }

        private async void btRefresh_Click(object sender, EventArgs e)
        {
            var treeRoot = await logic.RefreshFiles();
            Action action = () =>
            {
                treeFiles.Nodes.Clear();
                treeFiles.Nodes.Add(treeRoot);
                treeFiles.ExpandAll();
            };
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to start printing? Make sure that print table is clear", "Print warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await logic.StartPrint();
            }
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to stop printing?", "Print warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await logic.StopPrint();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }

        private void btCreateDir_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
