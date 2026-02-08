using MistPrintCore;
using MistPrintCore.Helpers;
using MistPrintCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TestForms;

namespace FormService
{
    public class ServiceFormLogic
    {
        public ServiceForm form { get; set; }
        public TreeView fileTree { get; set; }
        Thread statusTread { get; set; }
        public bool _running = false;
        public Core core { get; set; }
        public ServiceFormLogic(ServiceForm form, TreeView fileTree)
        {
            this.form = form;
            this.fileTree = fileTree;
        }
        public void LoadStatusListen()
        {
            statusTread = new Thread(ReadStatusLoop);
            statusTread.IsBackground = true;
            statusTread.Start();
        }
        private void ReadStatusLoop()
        {
            while (_running)
            {
                try
                {
                    form.UpdateStatus();
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void InitializeCore()
        {
            core = new Core();
            core.Initialize();
            _running = true;
            LoadStatusListen();
            ProcessFilesToTree();
        }
        private void ProcessFilesToTree()
        {
            fileTree.Nodes.Clear();
            TreeNode rootNode = CreateDirectoryNode(Locals.FileRoot);
            fileTree.Nodes.Add(rootNode);
            fileTree.Nodes[0].Expand();
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
        public bool SetJobFileFromNode(TreeNode node)
        {
            if (core != null && node != null)
            {
                string path = node.Tag.ToString();
                FileSystem.Directory dir = Locals.FileRoot;

                foreach (string part in path.Split('/').Where(x => !x.ToLower().EndsWith(".gcode")))
                    if (!string.IsNullOrEmpty(part))
                        dir = dir.Directories.Find(x => x.Name == part);

                if (dir == null)
                    throw new Exception("Directory not found.");
                var file = dir.Files.Find(x => x.Path == path);
                if (file == null)
                    throw new Exception("File not found.");
                FileSystemHelper.SetJobFile((FileSystem.File)file);
                return true;
            }
            return false;
        }
        public void DeleteFileFromNode(TreeNode node)
        {
            string key = node.Text;
            FileSystemHelper.ProcessDeleteFile(new FileRequest() { Path = node.Tag.ToString() });
            ProcessFilesToTree();
            //var a = fileTree.Nodes.Cast<TreeNode>().Where(x => x.Tag.ToString() == node.Tag.ToString().Remove(node.Tag.ToString().LastIndexOf("/"))).FirstOrDefault();
        }
        public void UploadFile(string file, TreeNode activeNode)
        {
            string path = "/";
            if (activeNode != null)
                path = activeNode.Tag.ToString();
            FileSystem.Directory dir = Locals.FileRoot;

            foreach (string part in path.Split('/').Where(x => !x.ToLower().EndsWith(".gcode")))
                if (!string.IsNullOrEmpty(part))
                    dir = dir.Directories.Find(x => x.Name == part);

            if (dir == null)
                throw new Exception("Directory not found.");

            FileSystemHelper.ProcessUploadFile(dir.Path, file);
            ProcessFilesToTree();
            //fileTree.Nodes.Find(activeNode.Name, true).FirstOrDefault()?.Expand();
        }

        public void RefreshFiles()
        {
            FileSystemHelper.RefreshFileList();
            ProcessFilesToTree();
        }
    }
}
