using MistPrintCore;
using MistPrintCore.Models;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiForms
{
    public class ApiClientFormLogic
    {
        public ApiClientForm form { get; set; }
        public TreeView FileTree { get; set; }
        private Thread statusTread { get; set; }
        public ClientStatus Status { get; set; }
        public bool _running { get; set; } = false;
        private NetCore Net { get; set; }
        private FileSystem.Directory RootDirectory { get; set; }
        public ApiClientFormLogic(ApiClientForm form)
        {
            this.form = form;
        }

        public void Initialize()
        {

            Status = new ClientStatus();
            Net = new NetCore();
            _running = true;
            statusTread = new Thread(ReadStatusLoop);
            statusTread.IsBackground = true;
            statusTread.Start();
        }
        private TreeNode CreateDirectoryNode(FileSystem.Directory directory)
        {
            TreeNode dirNode = new TreeNode(directory.Name) { Tag = directory.Path };
            foreach (var subDir in directory.Directories)
            {
                TreeNode subDirNode = CreateDirectoryNode(subDir);
                dirNode.Nodes.Add(subDirNode);
            }
            foreach (var file in directory.Files)
            {
                TreeNode fileNode = new TreeNode(file.Name) { Tag = file.Path };
                dirNode.Nodes.Add(fileNode);
            }
            return dirNode;
        }
        private void ReadStatusLoop()
        {
            while (_running)
            {
                try
                {
                    Status = Net.GetStatus();
                    form.UpdateStatus();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<TreeNode> GetInitialFilesList()
        {
            try
            {
                RootDirectory = await Net.GetFileSystem();
                return CreateDirectoryNode(RootDirectory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task SelectFile(string path)
        {
            try
            {
                await Net.SelectFile(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task StartPrint()
        {
            try
            {
                await Net.StartPrint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task StopPrint()
        {
            try
            {
                await Net.StopPrint();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TreeNode> RefreshFiles()
        {
            try
            {
                RootDirectory = await Net.RefreshFiles();
                return CreateDirectoryNode(RootDirectory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
