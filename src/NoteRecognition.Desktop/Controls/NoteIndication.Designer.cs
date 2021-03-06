﻿namespace NoteRecognition.Desktop.Controls
{
    partial class NoteIndication
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.noteOutputDb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.noteOutputHz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.noteOutputName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Note Params";
            // 
            // noteOutputDb
            // 
            this.noteOutputDb.Enabled = false;
            this.noteOutputDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteOutputDb.Location = new System.Drawing.Point(0, 51);
            this.noteOutputDb.Name = "noteOutputDb";
            this.noteOutputDb.Size = new System.Drawing.Size(256, 32);
            this.noteOutputDb.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Amplitude (dB)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Frequency (Hz)";
            // 
            // noteOutputHz
            // 
            this.noteOutputHz.Enabled = false;
            this.noteOutputHz.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteOutputHz.Location = new System.Drawing.Point(0, 102);
            this.noteOutputHz.Name = "noteOutputHz";
            this.noteOutputHz.Size = new System.Drawing.Size(256, 32);
            this.noteOutputHz.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Note name";
            // 
            // noteOutputName
            // 
            this.noteOutputName.Enabled = false;
            this.noteOutputName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteOutputName.Location = new System.Drawing.Point(0, 154);
            this.noteOutputName.Name = "noteOutputName";
            this.noteOutputName.Size = new System.Drawing.Size(256, 32);
            this.noteOutputName.TabIndex = 11;
            // 
            // NoteIndication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noteOutputName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.noteOutputHz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noteOutputDb);
            this.Controls.Add(this.label2);
            this.Name = "NoteIndication";
            this.Size = new System.Drawing.Size(256, 218);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox noteOutputDb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox noteOutputHz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox noteOutputName;
    }
}
