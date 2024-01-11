using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EntitySpaces.CodeGenerator;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.AddIn
{
    internal class UcTemplateControl : TreeView
    {
        private TreeNode _rootNode;
        private readonly TemplateUICollection _coll = new TemplateUICollection();
        private readonly SortedList<int, UserControl> _currentUiControls = new SortedList<int, UserControl>();
        private esSettings _settings;

        private ImageList _imageList;
        private ContextMenuStrip _folderMenu;
        private ToolStripMenuItem _showallexecutable;
        private ToolStripMenuItem _showall;
        private ToolStripSeparator _toolStripSeparator6;
        private ToolStripMenuItem _collapseAll;
        private System.ComponentModel.IContainer components;

        public void LoadTemplates(ContextMenuStrip templateMenu, ContextMenuStrip subTemplateMenu, esSettings settings)
        {
            try
            {
                this._settings = settings;

                if (this.TreeViewNodeSorter == null)
                {
                    this.TreeViewNodeSorter = new NodeSorter();
                    InitializeComponent();

                    Template.SetTemplateCachePath(esSettings.TemplateCachePath);
                    Template.SetCompilerAssemblyPath(_settings.CompilerAssemblyPath);
                }

                this.Nodes.Clear();
                _rootNode = this.Nodes.Add("Templates");
                _rootNode.ImageIndex = 2;
                _rootNode.SelectedImageIndex = 2;
                _rootNode.ContextMenuStrip = this._folderMenu;

                this._currentUiControls.Clear();
                this._coll.Clear();

                string[] files = Directory.GetFiles(_settings.TemplatePath, "*.est", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    Template template = new Template();
                    TemplateHeader header = null;
                    string[] nspace = null;

                    try
                    {
                        // If this doesn't meet the criteria skip it and move on to the next file
                        template.Parse(file);

                        header = template.Header;
                        if (header.Namespace == string.Empty) continue;

                        nspace = header.Namespace.Split('.');
                        if (nspace == null || nspace.Length == 0) continue;
                    }
                    catch { continue; }

                    // Okay, we have a valid template with a namespace ...
                    TreeNode node = _rootNode;
                    TreeNode[] temp = null;

                    // This foreach loop adds all of the folder entries based on 
                    // the namespace
                    foreach (string entry in nspace)
                    {
                        temp = node.Nodes.Find(entry, true);

                        if (temp == null || temp.Length == 0)
                        {
                            node = node.Nodes.Add(entry);
                            node.Name = entry;
                        }
                        else
                        {
                            node = temp[0];
                        }

                        node.ImageIndex = 2;
                        node.SelectedImageIndex = 2;
                        node.ContextMenuStrip = this._folderMenu;
                    }

                    // Now we add the final node, with the template icon and stash the Template
                    // in the node's "Tag" property for later use when they execute it.
                    node = node.Nodes.Add(template.Header.Title);
                    node.Tag = template;
                    node.ToolTipText = header.Description + " : " + header.Author + " (" + header.Version + ")" + Environment.NewLine;


                    if (header.IsSubTemplate)
                    {
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;
                        node.ContextMenuStrip = subTemplateMenu;
                    }
                    else
                    {
                        node.ImageIndex = 1;
                        node.SelectedImageIndex = 1;
                        node.ContextMenuStrip = templateMenu;
                    }
                }

                // Now, let's sort it so it all makes sense ...
                this.Sort();
            }
            catch { }
        }

        public bool IsExecuteableTemplateSelected()
        {
            bool isSelected = false;

            try
            {
                TreeNode node = this.SelectedNode;

                if (node != null && node.Tag != null)
                {
                    Template template = node.Tag as Template;
                    isSelected = !template.Header.IsSubTemplate;
                }
            }
            catch { }

            return isSelected;
        }

        private void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null)
                {
                    e.Node.ImageIndex = 3;
                    e.Node.SelectedImageIndex = 3;
                }

                e.Cancel = false;
            }
            catch { }
        }

        private void tree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (e.Node.Tag == null)
                {
                    e.Node.ImageIndex = 2;
                    e.Node.SelectedImageIndex = 2;
                }

                e.Cancel = false;
            }
            catch { }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcTemplateControl));
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this._folderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._showallexecutable = new System.Windows.Forms.ToolStripMenuItem();
            this._showall = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._collapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this._folderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "template.png");
            this._imageList.Images.SetKeyName(1, "template_selected.png");
            this._imageList.Images.SetKeyName(2, "folder_closed.png");
            this._imageList.Images.SetKeyName(3, "folder_open.png");
            // 
            // folderMenu
            // 
            this._folderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showallexecutable,
            this._showall,
            this._toolStripSeparator6,
            this._collapseAll});
            this._folderMenu.Name = "_folderMenu";
            this._folderMenu.Size = new System.Drawing.Size(234, 76);
            this._folderMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.folderMenu_ItemClicked);
            // 
            // showallexecutable
            // 
            this._showallexecutable.Image = ((System.Drawing.Image)(resources.GetObject("_showallexecutable.Image")));
            this._showallexecutable.Name = "_showallexecutable";
            this._showallexecutable.Size = new System.Drawing.Size(233, 22);
            this._showallexecutable.Text = "Show All Executable Templates";
            // 
            // showall
            // 
            this._showall.Image = ((System.Drawing.Image)(resources.GetObject("_showall.Image")));
            this._showall.Name = "_showall";
            this._showall.Size = new System.Drawing.Size(233, 22);
            this._showall.Text = "Show All Templates";
            // 
            // toolStripSeparator6
            // 
            this._toolStripSeparator6.Name = "_toolStripSeparator6";
            this._toolStripSeparator6.Size = new System.Drawing.Size(230, 6);
            // 
            // collapseAll
            // 
            this._collapseAll.Image = ((System.Drawing.Image)(resources.GetObject("_collapseAll.Image")));
            this._collapseAll.Name = "_collapseAll";
            this._collapseAll.Size = new System.Drawing.Size(233, 22);
            this._collapseAll.Text = "Collapse All";
            // 
            // ucTemplateControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HideSelection = false;
            this.ImageIndex = 0;
            this.ImageList = this._imageList;
            this.ItemHeight = 18;
            this.LineColor = System.Drawing.Color.Black;
            this.PathSeparator = ".";
            this.SelectedImageIndex = 0;
            this.ShowNodeToolTips = true;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucTemplateControl_MouseClick);
            this.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            this.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeCollapse);
            this._folderMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ucTemplateControl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    TreeNode node = this.GetNodeAt(e.X, e.Y);

                    if (node != null)
                    {
                        this.SelectedNode = node;
                    }
                }
            }
            catch { }
        }

        private void folderMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name.ToLower())
                {
                    case "showallexecutable":

                        this.SelectedNode.Collapse(false);
                        this.ShowAllExecutableTemplates(this.SelectedNode);
                        this.SelectedNode.EnsureVisible();
                        break;

                    case "showall":

                        this.SelectedNode.ExpandAll();
                        this.SelectedNode.EnsureVisible();
                        break;

                    case "collapseall":

                        this.SelectedNode.Collapse();
                        break;
                }
            }
            catch { }
        }

        private void ShowAllExecutableTemplates(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Tag != null)
                {
                    Template template = childNode.Tag as Template;

                    if (!template.Header.IsSubTemplate)
                    {
                        ExpandNode(node);
                        break;
                    }
                }
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                ShowAllExecutableTemplates(childNode);
            }
        }

        private void ExpandNode(TreeNode node)
        {
            if (node == null) return;

            node.Expand();

            ExpandNode(node.Parent);
        }
    }

    // Create a node sorter that implements the IComparer interface.
    internal class NodeSorter : IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
        public int Compare(object x, object y)
        {
            try
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                if ((tx.Tag == null && ty.Tag == null) ||
                    (tx.Tag != null && ty.Tag != null))
                {
                    // We compare folder to folder or tempate to template
                    return string.Compare(tx.Text, ty.Text);
                }
                else
                {
                    if (tx.Tag == null)
                    {
                        // This is a folder, we want it before templates
                        return -1;
                    }
                    else
                    {
                        // This is a template, we want it at the bottom, after folders
                        return 1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
