﻿namespace CSDL.UC
{
    partial class fIn
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
            this.rpInHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpInHoaDon
            // 
            this.rpInHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpInHoaDon.LocalReport.ReportEmbeddedResource = "CSDL.Report.rpHoaDon.rdlc";
            this.rpInHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rpInHoaDon.Name = "rpInHoaDon";
            this.rpInHoaDon.Size = new System.Drawing.Size(902, 513);
            this.rpInHoaDon.TabIndex = 0;
            // 
            // fIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 513);
            this.Controls.Add(this.rpInHoaDon);
            this.Name = "fIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fIn";
            this.Load += new System.EventHandler(this.fIn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpInHoaDon;
    }
}