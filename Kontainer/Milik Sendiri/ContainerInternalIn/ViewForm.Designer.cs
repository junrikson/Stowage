#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace ContainerInternalIn
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
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtContainerCode = new System.Windows.Forms.TextBox();
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
            this.pnlCommand.Size = new System.Drawing.Size(783, 73);
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
            this.grpInput.Controls.Add(this.label4);
            this.grpInput.Controls.Add(this.dtpDate);
            this.grpInput.Controls.Add(this.label3);
            this.grpInput.Controls.Add(this.txtNote);
            this.grpInput.Controls.Add(this.lblName);
            this.grpInput.Controls.Add(this.lblCode);
            this.grpInput.Controls.Add(this.txtContainerCode);
            this.grpInput.Controls.Add(this.txtCode);
            this.grpInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInput.Location = new System.Drawing.Point(-2, 81);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(786, 164);
            this.grpInput.TabIndex = 29;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "* Tanggal :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(483, 31);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(241, 20);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.Value = new System.DateTime(2018, 5, 10, 21, 23, 51, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 95);
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
            this.txtNote.Location = new System.Drawing.Point(127, 92);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNote.MaxLength = 250;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(597, 48);
            this.txtNote.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(54, 65);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 13);
            this.lblName.TabIndex = 33;
            this.lblName.Text = "* Kontainer :";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(40, 35);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(79, 13);
            this.lblCode.TabIndex = 32;
            this.lblCode.Text = "No. Transaksi :";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContainerCode
            // 
            this.txtContainerCode.AccessibleName = "txtContainer1";
            this.txtContainerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContainerCode.Location = new System.Drawing.Point(127, 62);
            this.txtContainerCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContainerCode.MaxLength = 5;
            this.txtContainerCode.Name = "txtContainerCode";
            this.txtContainerCode.ReadOnly = true;
            this.txtContainerCode.Size = new System.Drawing.Size(240, 20);
            this.txtContainerCode.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(127, 32);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MaxLength = 250;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(240, 20);
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
            this.ClientSize = new System.Drawing.Size(783, 271);
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
            this.Text = "Pembelian Kembali - View";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtContainerCode;
        private System.Windows.Forms.TextBox txtCode;
    }
}