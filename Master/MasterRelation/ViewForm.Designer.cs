#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace MasterRelation
{
    partial class ViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.btnNext = new Syncfusion.WinForms.Controls.SfButton();
            this.btnPrev = new Syncfusion.WinForms.Controls.SfButton();
            this.btnEdit = new Syncfusion.WinForms.Controls.SfButton();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.pnlCommand.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCommand
            // 
            this.pnlCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.pnlCommand.Controls.Add(this.btnNext);
            this.pnlCommand.Controls.Add(this.btnPrev);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommand.Location = new System.Drawing.Point(0, 0);
            this.pnlCommand.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(490, 73);
            this.pnlCommand.TabIndex = 27;
            // 
            // btnNext
            // 
            this.btnNext.AccessibleName = "btnNext";
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageMargin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnNext.ImageSize = new System.Drawing.Size(28, 28);
            this.btnNext.Location = new System.Drawing.Point(75, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 58);
            this.btnNext.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnNext.Style.DisabledImage = ((System.Drawing.Image)(resources.GetObject("btnNext.Style.DisabledImage")));
            this.btnNext.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnNext.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnNext.Style.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Style.Image")));
            this.btnNext.Style.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(199)))), ((int)(((byte)(213)))));
            this.btnNext.TabIndex = 28;
            this.btnNext.Text = "&Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNext.TextMargin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.AccessibleName = "btnPrev";
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageMargin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.btnPrev.ImageSize = new System.Drawing.Size(28, 28);
            this.btnPrev.Location = new System.Drawing.Point(11, 5);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(56, 58);
            this.btnPrev.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.btnPrev.Style.DisabledImage = ((System.Drawing.Image)(resources.GetObject("btnPrev.Style.DisabledImage")));
            this.btnPrev.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnPrev.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(229)))), ((int)(((byte)(243)))));
            this.btnPrev.Style.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Style.Image")));
            this.btnPrev.Style.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(199)))), ((int)(((byte)(213)))));
            this.btnPrev.TabIndex = 27;
            this.btnPrev.Text = "&Prev";
            this.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrev.TextMargin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
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
            // grpInput
            // 
            this.grpInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.grpInput.Controls.Add(this.txtAddress);
            this.grpInput.Controls.Add(this.label2);
            this.grpInput.Controls.Add(this.label1);
            this.grpInput.Controls.Add(this.txtExtension);
            this.grpInput.Controls.Add(this.label3);
            this.grpInput.Controls.Add(this.txtNote);
            this.grpInput.Controls.Add(this.lblName);
            this.grpInput.Controls.Add(this.lblCode);
            this.grpInput.Controls.Add(this.chkStatus);
            this.grpInput.Controls.Add(this.txtName);
            this.grpInput.Controls.Add(this.txtCode);
            this.grpInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInput.Location = new System.Drawing.Point(0, 76);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(475, 224);
            this.grpInput.TabIndex = 29;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input Data";
            // 
            // txtAddress
            // 
            this.txtAddress.AccessibleName = "txtNote";
            this.txtAddress.Location = new System.Drawing.Point(127, 112);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.MaxLength = 250;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(269, 48);
            this.txtAddress.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Alamat :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Ekstensi :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExtension
            // 
            this.txtExtension.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExtension.Location = new System.Drawing.Point(127, 85);
            this.txtExtension.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExtension.MaxLength = 4;
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.ReadOnly = true;
            this.txtExtension.Size = new System.Drawing.Size(58, 20);
            this.txtExtension.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Keterangan :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNote
            // 
            this.txtNote.AccessibleName = "txtNote";
            this.txtNote.Location = new System.Drawing.Point(127, 167);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNote.MaxLength = 250;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(269, 48);
            this.txtNote.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(40, 62);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 13);
            this.lblName.TabIndex = 33;
            this.lblName.Text = "* Nama Relasi :";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(43, 35);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(77, 13);
            this.lblCode.TabIndex = 32;
            this.lblCode.Text = "* Kode Relasi :";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkStatus
            // 
            this.chkStatus.AccessibleName = "chkStatus";
            this.chkStatus.AutoSize = true;
            this.chkStatus.Enabled = false;
            this.chkStatus.Location = new System.Drawing.Point(403, 34);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(56, 17);
            this.chkStatus.TabIndex = 20;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(127, 59);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MaxLength = 250;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(269, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(127, 32);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MaxLength = 250;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.Size = new System.Drawing.Size(269, 20);
            this.txtCode.TabIndex = 1;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.CaptionBarHeight = 35;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ClientSize = new System.Drawing.Size(490, 318);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.pnlCommand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.MinimizeBox = false;
            this.Name = "ViewForm";
            this.ShowInTaskbar = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.Text = "Master Relasi - View";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.pnlCommand.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlCommand;
        private Syncfusion.WinForms.Controls.SfButton btnEdit;
        private Syncfusion.WinForms.Controls.SfButton btnPrev;
        private Syncfusion.WinForms.Controls.SfButton btnNext;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
    }
}