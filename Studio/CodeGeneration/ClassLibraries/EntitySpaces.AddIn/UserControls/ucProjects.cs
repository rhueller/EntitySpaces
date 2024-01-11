using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EntitySpaces.CodeGenerator;
using EntitySpaces.Common;
using EntitySpaces.MetadataEngine;
using Microsoft.Win32;

namespace EntitySpaces.AddIn.UserControls
{
    internal partial class UcProjects : esUserControl
    {
        private string _projectName;
        private esProject _project;
        private MostRecentlyUsedList _mru;
        private bool _isDirty;

        public UcProjects()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                // ignored
            }
        }

        private void ucProjects_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode) return;
                
                _mru = new MostRecentlyUsedList();

                tree.LoadTemplates(null, null, Settings);

                try
                {
                    projectTree.SelectedNode = projectTree.Nodes[0];
                }
                catch
                {
                    // ignored
                }

                LoadMruList();
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void LoadMruList()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\EntitySpaces 2019", false))
            {
                if (key == null) return;

                _mru.Load(key, "Project_");
                PopulateMruMenu();
            }
        }

        private void SaveMruList()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\EntitySpaces 2019", true))
            {
                if (key == null) return;

                _mru.Save(key, "Project_");
                PopulateMruMenu();
            }
        }

        private void PopulateMruMenu()
        {
            menuMRU.Items.Clear();

            foreach (var project in _mru)
            {
                if (project == null) continue;

                try
                {
                    var info = new FileInfo(project);
                    var item = menuMRU.Items.Add(info.Name);
                    item.ToolTipText = project;
                    item.Image = Resource.check;
                }
                catch
                {
                    // ignored
                }
            }
        }

        public override void OnSettingsChanged()
        {
      
        }

        private void ButtonRecord_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindow.HideErrorOrStatusMessage();

                splitContainer.Panel1Collapsed = true;
                splitContainer.Panel2Collapsed = false;

                EnableToolbarButtons(false);
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void buttonRecordOk_Click(object sender, EventArgs e)
        {
            var origCursor = Cursor;

            try
            {
                Cursor = Cursors.WaitCursor;

                MainWindow.HideErrorOrStatusMessage();

                var templateDisplaySurface = new TemplateDisplaySurface();

                var template = tree.SelectedNode.Tag as Template;
                templateDisplaySurface.DisplayTemplateUi(false, null, Settings, template, OnExecute, OnCancel);

                splitContainer.Panel1Collapsed = false;
                splitContainer.Panel2Collapsed = true;
                _isDirty = true;
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
            finally
            {
                EnableToolbarButtons(true);

                Cursor = origCursor;
            }
        }

        private void buttonRecordCancel_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindow.HideErrorOrStatusMessage();

                splitContainer.Panel1Collapsed = false;
                splitContainer.Panel2Collapsed = true;

                EnableToolbarButtons(true);
                _isDirty = false;
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void EnableToolbarButtons(bool enable)
        {
            ButtonProjectOpen.Enabled = enable;

            if (_projectName != null)
            {
                ButtonSave.Enabled = enable;
            }
            ButtonSaveAs.Enabled = enable;
            ButtonExecute.Enabled = enable;
            ButtonClear.Enabled = enable;
            ButtonOpenFolder.Enabled = enable;
            ButtonMoveDown.Enabled = enable;
            ButtonMoveUp.Enabled = enable;

            if (enable)
            {
                var node = projectTree.SelectedNode;

                if (node == null) return;

                if (node.Tag is ProjectNodeData data)
                {
                    ButtonRecord.Enabled = true;
                }
            }
            else
            {
                ButtonRecord.Enabled = false;
            }
        }

        private void ProjectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                MainWindow.HideErrorOrStatusMessage();

                if (e.Button == MouseButtons.Right)
                {
                    var node = projectTree.GetNodeAt(e.X, e.Y);

                    if (node != null)
                    {
                        projectTree.SelectedNode = node;
                    }
                }
                else
                {
                    if (e.Node != null && e.Node.ImageIndex == 2)
                    {
                        ButtonRecord.Enabled = false;
                    }
                    else
                    {
                        ButtonRecord.Enabled = true;
                    }

                    ButtonExecute.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void ProjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var node = e.Node;

                if (node == null) return;
                ButtonRecord.Enabled = node.ImageIndex != 2;

            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void AddFolder_Click(object sender, EventArgs e)
        {
            AddFolder("Folder", true);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindow.HideErrorOrStatusMessage();

                var node = projectTree.SelectedNode;

                if (node == null || node == projectTree.Nodes[0]) return;
                node.Remove();
                _isDirty = true;
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void EditTemplatesMenuItem_Click(object sender, EventArgs e)
        {
            var origCursor = Cursor;

            try
            {
                Cursor = Cursors.WaitCursor;

                MainWindow.HideErrorOrStatusMessage();

                var templateDisplaySurface = new TemplateDisplaySurface();

                var node = projectTree.SelectedNode;

                var data = node.Tag as ProjectNodeData;

                templateDisplaySurface.DisplayTemplateUi(true, data?.Input, data.Settings as esSettings, data.Template, OnExecute, OnCancel);

                splitContainer.Panel1Collapsed = false;
                splitContainer.Panel2Collapsed = true;

                _isDirty = true;
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
            finally
            {
                EnableToolbarButtons(true);

                Cursor = origCursor;
            }
        }

        private void EditSettingsMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindow.HideErrorOrStatusMessage();

                var node = projectTree.SelectedNode;
                var data = node.Tag as ProjectNodeData;

                var popup = new PopupSettings();
                popup.Settings = (esSettings)data?.Settings;

                if (popup.ShowDialog() == DialogResult.OK)
                {
                    data.Settings = popup.Settings;
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private static void OnCancel(TemplateDisplaySurface surface)
        {

        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindow.HideErrorOrStatusMessage();

                var node = projectTree.SelectedNode;

                if (node != null)
                {
                    node.BeginEdit();
                    _isDirty = true;
                }

            }
            catch { }
        }

        private void ExecuteMenuItem_Click(object sender, EventArgs e)
        {
            var origCursor = Cursor;
            var error = false;

            try
            {
                MainWindow.HideErrorOrStatusMessage();

                Cursor = Cursors.WaitCursor;

                var node = projectTree.SelectedNode;

                if (node != null)
                {
                    MainWindow.HideErrorOrStatusMessage();
                    ExecuteRecordedTemplates(node);
                }
            }
            catch (Exception ex)
            {
                error = true;
                MainWindow.ShowError(ex);
            }
            finally
            {
                if (!error)
                {
                    MainWindow.ShowStatusMessage("Project Executed Successfully");
                }
                Cursor = origCursor;
            }

            try
            {
                if (_isDirty) PromptForSave();
            }
            catch
            {
                // ignored
            }
        }

        private void ExecuteRecordedTemplates(TreeNode node)
        {
            ExecuteRecordedTemplate(node);

            foreach (TreeNode childNode in node.Nodes)
            {
                ExecuteRecordedTemplates(childNode);
            }
        }

        private void ExecuteRecordedTemplate(TreeNode node)
        {
            if (node?.Tag == null) return;
            var tag = node.Tag as ProjectNodeData;

            var esMeta = esMetaCreator.Create(tag?.Settings as esSettings);
            esMeta.Input = tag?.Input;

            var template = new Template();
            template.Execute(esMeta, tag.Template.Header.FullFileName);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                buttonRecordOk.Enabled = tree.IsExecuteableTemplateSelected();
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private bool OnExecute(TemplateDisplaySurface surface)
        {
            try
            {
                if (surface.GatherUserInput())
                {
                    var ht = surface.CacheUserInput();

                    if (projectTree.SelectedNode != null && projectTree.SelectedNode.Tag != null)
                    {
                        var tag = projectTree.SelectedNode.Tag as ProjectNodeData;
                        if (tag != null) tag.Input = ht;
                    }
                    else
                    {
                        AddRecordedTemplate(surface, true);
                        _isDirty = true;
                    }
                }
                else return false;
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
                return false;
            }

            return true;
        }

        public void AddFolder(string name, bool beginEdit)
        {
            try
            {
                var node = projectTree.SelectedNode;

                if (node == null)
                {
                    node = projectTree.Nodes[0];
                }

                if (node != null)
                {
                    var folder = new TreeNode(name);
                    node.Nodes.Add(folder);
                    _isDirty = true;

                    node.Expand();

                    projectTree.SelectedNode = folder;

                    if (beginEdit)
                    {
                        folder.BeginEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        public void AddRecordedTemplate(TemplateDisplaySurface surface, bool beginEdit)
        {
            try
            {
                var node = projectTree.SelectedNode;

                if (node == null)
                {
                    node = projectTree.Nodes[0];
                }

                if (node != null)
                {
                    var recordedTemplate = new TreeNode(surface.Template.Header.Title);
                    recordedTemplate.ImageIndex = 2;
                    recordedTemplate.SelectedImageIndex = 2;
                    recordedTemplate.ContextMenuStrip = menuTemplate;
                    node.Nodes.Add(recordedTemplate);

                    var tag = new ProjectNodeData();
                    tag.Template = surface.Template;
                    tag.Input = surface.CacheUserInput();
                    tag.Settings = Settings.Clone();
                    recordedTemplate.Tag = tag;
        
                    node.Expand();
                    _isDirty = true;

                    projectTree.SelectedNode = recordedTemplate;

                    if (beginEdit)
                    {
                        recordedTemplate.BeginEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        #region Drag Drop

        private void ProjectTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                var root = (TreeNode)e.Item;
                if (root == projectTree.Nodes[0]) return;

                DoDragDrop(e.Item, DragDropEffects.Move);
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void ProjectTree_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = DragDropEffects.Move;
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void ProjectTree_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Effect != DragDropEffects.Move) return;

                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    var pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                    var destinationNode = ((TreeView)sender).GetNodeAt(pt);
                    var newNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                    if (destinationNode == null) return;
                    if (destinationNode.ImageIndex == 2) return;
                    if (newNode == destinationNode) return;

                    newNode.Remove();
                    _isDirty = true;

                    destinationNode.Nodes.Add(newNode);
                    destinationNode.Expand();
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        #endregion

        private void ButtonProjectOpen_Click(object sender, EventArgs e)
        {
            var oldCursor = Cursor.Current;
            _isDirty = false;

            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Open EntitySpaces Project File";
                openFileDialog.Filter = "Project Files (*.esprj)|*.esprj|All Files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenProject(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void ConvertProjectToTree(TreeNode parentNode, esProjectNode esNode)
        {
            TreeNode node = null;

            if (parentNode == null)
            {
                node = projectTree.Nodes.Add(esNode.Name);
            }
            else
            {
                node = parentNode.Nodes.Add(esNode.Name);
            }

            if(!esNode.IsFolder)
            {
                var tag = new ProjectNodeData();
                tag.Template = esNode.Template;
                tag.Settings = esNode.Settings;
                tag.Input = esNode.Input;

                node.Tag = tag;
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
                node.ContextMenuStrip = menuTemplate;

                node.ToolTipText = esNode.Template.Header.Description + " (" + node.FullPath + ")";
            }

            foreach (esProjectNode childNode in esNode.Children)
            {
                ConvertProjectToTree(node, childNode);
            }
        }

        private void ConvertTreeToProject(esProjectNode esParentNode, TreeNode node)
        {
            var esNode = new esProjectNode();
            esNode.Name = node.Text;

            if (esParentNode == null)
            {
                _project.RootNode = esNode;
            }
            else
            {
                esParentNode.Children.Add(esNode);
            }

            if (node.Tag != null)
            {
                var tag = node.Tag as ProjectNodeData;

                esNode.Template = tag.Template;
                esNode.Settings = tag.Settings;
                esNode.Input = tag.Input;

                esNode.IsFolder = false;
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                ConvertTreeToProject(esNode, childNode);
            }
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            var oldCursor = Cursor.Current;

            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save EntitySpaces Project File";
                saveFileDialog.Filter = "Project Files (*.esprj)|*.esprj|All Files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    SaveProject(saveFileDialog.FileName);

                    _projectName = saveFileDialog.FileName;
                    ButtonSave.Enabled = true;

                    _mru.Push(_projectName);
                    SaveMruList();
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var oldCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SaveProject(_projectName);
                OpenProject(_projectName);
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void SaveProject(string fileNameAndPath)
        {
            var rootNode = projectTree.Nodes[0];

            _project = new esProject();
            ConvertTreeToProject(_project.RootNode, rootNode);
            _project.Save(fileNameAndPath, MainWindow.Settings);
            _project = null;
            _isDirty = false;
        }

        private void OpenProject(string fileNameAndPath)
        {
            var oldCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var project = new esProject();
                project.Load(fileNameAndPath, MainWindow.Settings);

                projectTree.Nodes.Clear();
                ConvertProjectToTree(null, project.RootNode);

                ButtonSave.Enabled = true;

                _projectName = fileNameAndPath;

                projectTree.ExpandAll();

                projectTree.SelectedNode = projectTree.Nodes[0];
                projectTree.Select();

                EnableToolbarButtons(true);

                _mru.Push(_projectName);
                SaveMruList();
            }
            catch (Exception ex)
            {
                _mru.Remove(fileNameAndPath);
                SaveMruList();
                MainWindow.ShowError(ex);
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                projectTree.Nodes.Clear();
                projectTree.Nodes.Add(new TreeNode("Project"));
                _projectName = null;
                ButtonSave.Enabled = false;

                projectTree.SelectedNode = projectTree.Nodes[0];
                projectTree.Select();
                _isDirty = false;

                EnableToolbarButtons(true);
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "explorer";
                p.StartInfo.Arguments = "/e," + Settings.OutputPath;
                p.StartInfo.UseShellExecute = true;
                p.Start();
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void expandAllMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (projectTree.SelectedNode != null)
                {
                    projectTree.SelectedNode.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void menuMRU_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                var project = e.ClickedItem.ToolTipText;
                _mru.Remove(project);  // OpenProject will reinsert him at the top
                OpenProject(project);
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }

        private void CopyNodePath(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode != null)
            {
                Clipboard.SetText(projectTree.SelectedNode.FullPath);
            }
        }

        private void MoveUpMenuItem_Click(object sender, EventArgs e)
        {
            var node = projectTree.SelectedNode;

            if (node == null) return;

            var parent = node.Parent;
            var prevNode = node.PrevNode;

            if (prevNode == null) return;

            projectTree.BeginUpdate();

            var index = node.Index;
            var pIndex = node.PrevNode.Index;

            parent.Nodes.Remove(prevNode);

            parent.Nodes.Insert(index, prevNode);

            projectTree.SelectedNode = node;

            projectTree.EndUpdate();

            _isDirty = true;
        }

        private void FolderMoveUpMenuItem_Click(object sender, EventArgs e)
        {
            MoveUpMenuItem_Click(sender, e);
        }

        private void MoveDownMenuItem_Click(object sender, EventArgs e)
        {
            var node = projectTree.SelectedNode;

            if (node == null) return;

            var parent = node.Parent;
            var nextNode = node.NextNode;

            if (nextNode == null) return;

            projectTree.BeginUpdate();

            var index = node.Index;
            var pIndex = node.NextNode.Index;

            parent.Nodes.Remove(nextNode);

            parent.Nodes.Insert(index, nextNode);

            projectTree.SelectedNode = node;

            projectTree.EndUpdate();

            _isDirty = true;
        }

        private void FolderMoveDownMenuItem_Click(object sender, EventArgs e)
        {
            MoveDownMenuItem_Click(sender, e);
        }

        private void ButtonMoveUp_Click(object sender, EventArgs e)
        {
            MoveUpMenuItem_Click(sender, e);
        }

        private void ButtonMoveDown_Click(object sender, EventArgs e)
        {
            MoveDownMenuItem_Click(sender, e);
        }

        public void PromptForSave()
        {
            try
            {
                if (_isDirty)
                {
                    var result = MessageBox.Show("Do you want to save the project", "Your project has unsaved changes",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        if (_projectName != null)
                        {
                            ButtonSave_Click(null, EventArgs.Empty);
                        }
                        else
                        {
                            ButtonSaveAs_Click(null, EventArgs.Empty);
                        }
                    }

                    _isDirty = false;
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError(ex);
            }
        }
    }

    #region ProjectNodeData

    internal class ProjectNodeData
    {
        public Template Template;
        public Hashtable Input;
        public ISettings Settings;
    }


    #endregion
}
