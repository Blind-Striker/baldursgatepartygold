using MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.CustomControls;

namespace MvpVmSample.Presentation.PartyGoldEditor.WindowsForms
{
    partial class PartyGoldEditorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartyGoldEditorView));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetSaveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectSaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.lblPartyGold = new System.Windows.Forms.Label();
            this.txtPartyGold = new System.Windows.Forms.TextBox();
            this.dataContext = new System.Windows.Forms.BindingSource(this.components);
            this.lblNewPartyGold = new System.Windows.Forms.Label();
            this.txtNewPartyGold = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrStatus = new MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.CustomControls.BindableToolStripStatusLabel();
            this.toolStrSelectedSaveGameName = new BindableToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(274, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetSaveFolder,
            this.tsmiSelectSaveGame});
            this.settingsToolStripMenuItem.Image = global::MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.Properties.Resources.Setting;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // tsmiSetSaveFolder
            // 
            this.tsmiSetSaveFolder.Image = global::MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.Properties.Resources.folder_saved_search;
            this.tsmiSetSaveFolder.Name = "tsmiSetSaveFolder";
            this.tsmiSetSaveFolder.Size = new System.Drawing.Size(168, 22);
            this.tsmiSetSaveFolder.Text = "Select Save Folder";
            // 
            // tsmiSelectSaveGame
            // 
            this.tsmiSelectSaveGame.Image = global::MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.Properties.Resources.sword;
            this.tsmiSelectSaveGame.Name = "tsmiSelectSaveGame";
            this.tsmiSelectSaveGame.Size = new System.Drawing.Size(168, 22);
            this.tsmiSelectSaveGame.Text = "Select Save Game";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.helpToolStripMenuItem.Image = global::MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.Properties.Resources.help;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.Properties.Resources.About;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(107, 22);
            this.tsmiAbout.Text = "About";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStrSelectedSaveGameName});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(66, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::MvpVmSample.Presentation.PartyGoldEditor.WindowsForms.Properties.Resources.Save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            // 
            // lblPartyGold
            // 
            this.lblPartyGold.AutoSize = true;
            this.lblPartyGold.Location = new System.Drawing.Point(13, 64);
            this.lblPartyGold.Name = "lblPartyGold";
            this.lblPartyGold.Size = new System.Drawing.Size(93, 13);
            this.lblPartyGold.TabIndex = 2;
            this.lblPartyGold.Text = "Current Party Gold";
            // 
            // txtPartyGold
            // 
            this.txtPartyGold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyGold.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataContext, "PartyGold", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N0"));
            this.txtPartyGold.Location = new System.Drawing.Point(112, 57);
            this.txtPartyGold.Name = "txtPartyGold";
            this.txtPartyGold.ReadOnly = true;
            this.txtPartyGold.Size = new System.Drawing.Size(143, 20);
            this.txtPartyGold.TabIndex = 3;
            // 
            // dataContext
            // 
            this.dataContext.DataSource = typeof(MvpVmSample.Presentation.PartyGoldEditor.Core.ViewModels.PartyGoldEditorViewModel);
            // 
            // lblNewPartyGold
            // 
            this.lblNewPartyGold.AutoSize = true;
            this.lblNewPartyGold.Location = new System.Drawing.Point(13, 86);
            this.lblNewPartyGold.Name = "lblNewPartyGold";
            this.lblNewPartyGold.Size = new System.Drawing.Size(81, 13);
            this.lblNewPartyGold.TabIndex = 4;
            this.lblNewPartyGold.Text = "New Party Gold";
            // 
            // txtNewPartyGold
            // 
            this.txtNewPartyGold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPartyGold.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataContext, "NewPartyGold", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.txtNewPartyGold.Location = new System.Drawing.Point(112, 83);
            this.txtNewPartyGold.Name = "txtNewPartyGold";
            this.txtNewPartyGold.Size = new System.Drawing.Size(143, 20);
            this.txtNewPartyGold.TabIndex = 5;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 109);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(274, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStrStatus
            // 
            this.toolStrStatus.Name = "toolStrStatus";
            this.toolStrStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrSelectedSaveGameName
            // 
            this.toolStrSelectedSaveGameName.Name = "tslSelectedSaveGameName";
            this.toolStrSelectedSaveGameName.Size = new System.Drawing.Size(0, 22);
            // 
            // PartyGoldEditorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 131);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txtNewPartyGold);
            this.Controls.Add(this.lblNewPartyGold);
            this.Controls.Add(this.txtPartyGold);
            this.Controls.Add(this.lblPartyGold);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PartyGoldEditorView";
            this.Text = "Party Gold Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetSaveFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectSaveGame;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label lblPartyGold;
        private System.Windows.Forms.TextBox txtPartyGold;
        private System.Windows.Forms.Label lblNewPartyGold;
        private System.Windows.Forms.TextBox txtNewPartyGold;
        private System.Windows.Forms.StatusStrip statusStrip;
        private BindableToolStripStatusLabel toolStrStatus;
        private System.Windows.Forms.BindingSource dataContext;
        private BindableToolStripStatusLabel toolStrSelectedSaveGameName;
    }
}

