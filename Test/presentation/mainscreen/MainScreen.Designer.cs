namespace Test
{
    partial class MainScreen
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
            this.components = new System.ComponentModel.Container();
            this.productObjectsTree = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atributesLabel = new System.Windows.Forms.Label();
            this.atributesContentLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // productObjectsTree
            // 
            this.productObjectsTree.ContextMenuStrip = this.contextMenuStrip1;
            this.productObjectsTree.Location = new System.Drawing.Point(-1, 1);
            this.productObjectsTree.Name = "productObjectsTree";
            this.productObjectsTree.Size = new System.Drawing.Size(485, 443);
            this.productObjectsTree.TabIndex = 0;
            this.productObjectsTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.productObjectsTree_BeforeExpand);
            this.productObjectsTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.productObjectsTree_NodeMouseClick_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.deleteMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(126, 22);
            this.addMenuItem.Text = "Добавить";
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(126, 22);
            this.deleteMenuItem.Text = "Удалить";
            // 
            // atributesLabel
            // 
            this.atributesLabel.AutoSize = true;
            this.atributesLabel.Location = new System.Drawing.Point(500, 4);
            this.atributesLabel.Name = "atributesLabel";
            this.atributesLabel.Size = new System.Drawing.Size(67, 15);
            this.atributesLabel.TabIndex = 1;
            this.atributesLabel.Text = "Атрибуты: ";
            // 
            // atributesContentLabel
            // 
            this.atributesContentLabel.AutoSize = true;
            this.atributesContentLabel.Location = new System.Drawing.Point(500, 29);
            this.atributesContentLabel.Name = "atributesContentLabel";
            this.atributesContentLabel.Size = new System.Drawing.Size(0, 15);
            this.atributesContentLabel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Экспортировать в XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.atributesContentLabel);
            this.Controls.Add(this.atributesLabel);
            this.Controls.Add(this.productObjectsTree);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private TreeView productObjectsTree;
        private Label atributesLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem addMenuItem;
        private ToolStripMenuItem deleteMenuItem;
        private Label atributesContentLabel;
        private Button button1;
    }
}