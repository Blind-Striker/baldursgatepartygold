namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms
{
    partial class SelectSaveGameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSaveGameView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstSaveGames = new System.Windows.Forms.ListBox();
            this.dataContext = new System.Windows.Forms.BindingSource(this.components);
            this.saveListItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnChangeSaveFolder = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveListItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstSaveGames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnChangeSaveFolder);
            this.splitContainer1.Panel2.Controls.Add(this.btnSelect);
            this.splitContainer1.Size = new System.Drawing.Size(384, 221);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstSaveGames
            // 
            this.lstSaveGames.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.dataContext, "CurrentSaveListItemSelectedIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstSaveGames.DataSource = this.saveListItemsBindingSource;
            this.lstSaveGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSaveGames.FormattingEnabled = true;
            this.lstSaveGames.Location = new System.Drawing.Point(0, 0);
            this.lstSaveGames.Name = "lstSaveGames";
            this.lstSaveGames.Size = new System.Drawing.Size(249, 221);
            this.lstSaveGames.TabIndex = 0;
            // 
            // dataContext
            // 
            this.dataContext.DataSource = typeof(MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels.SelectSaveGameViewModel);
            // 
            // saveListItemsBindingSource
            // 
            this.saveListItemsBindingSource.DataMember = "SaveListItems";
            this.saveListItemsBindingSource.DataSource = this.dataContext;
            // 
            // btnChangeSaveFolder
            // 
            this.btnChangeSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeSaveFolder.Location = new System.Drawing.Point(3, 41);
            this.btnChangeSaveFolder.Name = "btnChangeSaveFolder";
            this.btnChangeSaveFolder.Size = new System.Drawing.Size(122, 23);
            this.btnChangeSaveFolder.TabIndex = 1;
            this.btnChangeSaveFolder.Text = "Change Save Folder";
            this.btnChangeSaveFolder.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(3, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(122, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // SelectSaveGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectSaveGameView";
            this.Text = "Select Save Game";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveListItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnChangeSaveFolder;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.BindingSource dataContext;
        private System.Windows.Forms.ListBox lstSaveGames;
        private System.Windows.Forms.BindingSource saveListItemsBindingSource;
    }
}