#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Dashboard
{
    partial class DeleteDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteDataForm));
            this.btnEdit = new Syncfusion.WinForms.Controls.SfButton();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.btnDelete = new Syncfusion.WinForms.Controls.SfButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.cbMasterRelation = new System.Windows.Forms.CheckBox();
            this.cbMasterContainer = new System.Windows.Forms.CheckBox();
            this.cbContainerInternalOut = new System.Windows.Forms.CheckBox();
            this.cbContainerInternalIn = new System.Windows.Forms.CheckBox();
            this.cbContainerExternalOut = new System.Windows.Forms.CheckBox();
            this.cbContainerExternalIn = new System.Windows.Forms.CheckBox();
            this.cbContainerTransaction = new System.Windows.Forms.CheckBox();
            this.cbLoadingPlan = new System.Windows.Forms.CheckBox();
            this.cbStowage = new System.Windows.Forms.CheckBox();
            this.pnlCommand.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleName = "btnEdit";
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnEdit.ImageMargin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnEdit.ImageSize = new System.Drawing.Size(28, 28);
            this.btnEdit.Location = new System.Drawing.Point(75, 5);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 58);
            this.btnEdit.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnEdit.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnEdit.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnEdit.Style.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(199)))), ((int)(((byte)(213)))));
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.TextMargin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // pnlCommand
            // 
            this.pnlCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.pnlCommand.Controls.Add(this.btnDelete);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommand.Location = new System.Drawing.Point(0, 0);
            this.pnlCommand.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(430, 73);
            this.pnlCommand.TabIndex = 27;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "btnDelete";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageMargin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnDelete.ImageSize = new System.Drawing.Size(28, 28);
            this.btnDelete.Location = new System.Drawing.Point(11, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 58);
            this.btnDelete.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnDelete.Style.DisabledImage = ((System.Drawing.Image)(resources.GetObject("btnSave.Style.DisabledImage")));
            this.btnDelete.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnDelete.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnDelete.Style.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Style.Image")));
            this.btnDelete.Style.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(199)))), ((int)(((byte)(213)))));
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.TextMargin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(20, 227);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(384, 129);
            this.txtStatus.TabIndex = 5;
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.cbStowage);
            this.grpInput.Controls.Add(this.cbLoadingPlan);
            this.grpInput.Controls.Add(this.txtStatus);
            this.grpInput.Controls.Add(this.cbContainerTransaction);
            this.grpInput.Controls.Add(this.cbContainerExternalIn);
            this.grpInput.Controls.Add(this.cbContainerExternalOut);
            this.grpInput.Controls.Add(this.cbContainerInternalIn);
            this.grpInput.Controls.Add(this.cbContainerInternalOut);
            this.grpInput.Controls.Add(this.cbMasterContainer);
            this.grpInput.Controls.Add(this.cbMasterRelation);
            this.grpInput.Location = new System.Drawing.Point(3, 76);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(420, 365);
            this.grpInput.TabIndex = 26;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Hapus Data";
            // 
            // cbMasterRelation
            // 
            this.cbMasterRelation.AutoSize = true;
            this.cbMasterRelation.Location = new System.Drawing.Point(20, 20);
            this.cbMasterRelation.Name = "cbMasterRelation";
            this.cbMasterRelation.Size = new System.Drawing.Size(90, 17);
            this.cbMasterRelation.TabIndex = 6;
            this.cbMasterRelation.Text = "Master Relasi";
            this.cbMasterRelation.UseVisualStyleBackColor = true;
            this.cbMasterRelation.CheckedChanged += new System.EventHandler(this.cbMasterRelation_CheckedChanged);
            // 
            // cbMasterContainer
            // 
            this.cbMasterContainer.AutoSize = true;
            this.cbMasterContainer.Location = new System.Drawing.Point(33, 43);
            this.cbMasterContainer.Name = "cbMasterContainer";
            this.cbMasterContainer.Size = new System.Drawing.Size(106, 17);
            this.cbMasterContainer.TabIndex = 7;
            this.cbMasterContainer.Text = "Master Kontainer";
            this.cbMasterContainer.UseVisualStyleBackColor = true;
            this.cbMasterContainer.CheckedChanged += new System.EventHandler(this.cbMasterContainer_CheckedChanged);
            // 
            // cbContainerInternalOut
            // 
            this.cbContainerInternalOut.AutoSize = true;
            this.cbContainerInternalOut.Location = new System.Drawing.Point(48, 66);
            this.cbContainerInternalOut.Name = "cbContainerInternalOut";
            this.cbContainerInternalOut.Size = new System.Drawing.Size(153, 17);
            this.cbContainerInternalOut.TabIndex = 8;
            this.cbContainerInternalOut.Text = "Penjualan Kontainer (OUT)";
            this.cbContainerInternalOut.UseVisualStyleBackColor = true;
            // 
            // cbContainerInternalIn
            // 
            this.cbContainerInternalIn.AutoSize = true;
            this.cbContainerInternalIn.Location = new System.Drawing.Point(48, 89);
            this.cbContainerInternalIn.Name = "cbContainerInternalIn";
            this.cbContainerInternalIn.Size = new System.Drawing.Size(135, 17);
            this.cbContainerInternalIn.TabIndex = 9;
            this.cbContainerInternalIn.Text = "Pembelian Kembali (IN)";
            this.cbContainerInternalIn.UseVisualStyleBackColor = true;
            // 
            // cbContainerExternalOut
            // 
            this.cbContainerExternalOut.AutoSize = true;
            this.cbContainerExternalOut.Location = new System.Drawing.Point(48, 112);
            this.cbContainerExternalOut.Name = "cbContainerExternalOut";
            this.cbContainerExternalOut.Size = new System.Drawing.Size(173, 17);
            this.cbContainerExternalOut.TabIndex = 10;
            this.cbContainerExternalOut.Text = "Pengembalian Kontainer (OUT)";
            this.cbContainerExternalOut.UseVisualStyleBackColor = true;
            // 
            // cbContainerExternalIn
            // 
            this.cbContainerExternalIn.AutoSize = true;
            this.cbContainerExternalIn.Location = new System.Drawing.Point(48, 135);
            this.cbContainerExternalIn.Name = "cbContainerExternalIn";
            this.cbContainerExternalIn.Size = new System.Drawing.Size(151, 17);
            this.cbContainerExternalIn.TabIndex = 11;
            this.cbContainerExternalIn.Text = "Peminjaman Kontainer (IN)";
            this.cbContainerExternalIn.UseVisualStyleBackColor = true;
            // 
            // cbContainerTransaction
            // 
            this.cbContainerTransaction.AutoSize = true;
            this.cbContainerTransaction.Location = new System.Drawing.Point(48, 158);
            this.cbContainerTransaction.Name = "cbContainerTransaction";
            this.cbContainerTransaction.Size = new System.Drawing.Size(120, 17);
            this.cbContainerTransaction.TabIndex = 12;
            this.cbContainerTransaction.Text = "Transaksi Kontainer";
            this.cbContainerTransaction.UseVisualStyleBackColor = true;
            this.cbContainerTransaction.CheckedChanged += new System.EventHandler(this.cbContainerTransaction_CheckedChanged);
            // 
            // cbLoadingPlan
            // 
            this.cbLoadingPlan.AutoSize = true;
            this.cbLoadingPlan.Location = new System.Drawing.Point(63, 181);
            this.cbLoadingPlan.Name = "cbLoadingPlan";
            this.cbLoadingPlan.Size = new System.Drawing.Size(97, 17);
            this.cbLoadingPlan.TabIndex = 13;
            this.cbLoadingPlan.Text = "Rencana Muat";
            this.cbLoadingPlan.UseVisualStyleBackColor = true;
            this.cbLoadingPlan.CheckedChanged += new System.EventHandler(this.cbLoadingPlan_CheckedChanged);
            // 
            // cbStowage
            // 
            this.cbStowage.AutoSize = true;
            this.cbStowage.Location = new System.Drawing.Point(79, 204);
            this.cbStowage.Name = "cbStowage";
            this.cbStowage.Size = new System.Drawing.Size(68, 17);
            this.cbStowage.TabIndex = 14;
            this.cbStowage.Text = "Stowage";
            this.cbStowage.UseVisualStyleBackColor = true;
            // 
            // DeleteDataForm
            // 
            this.AcceptButton = this.btnDelete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.CaptionBarHeight = 35;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ClientSize = new System.Drawing.Size(430, 444);
            this.Controls.Add(this.pnlCommand);
            this.Controls.Add(this.grpInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.MinimizeBox = false;
            this.Name = "DeleteDataForm";
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hapus Data";
            this.Load += new System.EventHandler(this.DeleteDataForm_Load);
            this.pnlCommand.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton btnEdit;
        private System.Windows.Forms.Panel pnlCommand;
        private Syncfusion.WinForms.Controls.SfButton btnDelete;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.CheckBox cbMasterRelation;
        private System.Windows.Forms.CheckBox cbMasterContainer;
        private System.Windows.Forms.CheckBox cbContainerTransaction;
        private System.Windows.Forms.CheckBox cbContainerExternalIn;
        private System.Windows.Forms.CheckBox cbContainerExternalOut;
        private System.Windows.Forms.CheckBox cbContainerInternalIn;
        private System.Windows.Forms.CheckBox cbContainerInternalOut;
        private System.Windows.Forms.CheckBox cbStowage;
        private System.Windows.Forms.CheckBox cbLoadingPlan;
    }
}