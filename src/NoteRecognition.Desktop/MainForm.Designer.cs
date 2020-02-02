namespace NoteRecognition.Desktop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dragNDrop = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fftPlotUc1 = new NoteRecognition.Desktop.Controls.FftPlotUc();
            this.audioPlotUc1 = new NoteRecognition.Desktop.Controls.AudioPlotUc();
            this.noteIndication = new NoteRecognition.Desktop.Controls.NoteIndication();
            ((System.ComponentModel.ISupportInitialize)(this.dragNDrop)).BeginInit();
            this.SuspendLayout();
            // 
            // dragNDrop
            // 
            this.dragNDrop.AllowDrop = true;
            this.dragNDrop.Cursor = System.Windows.Forms.Cursors.Default;
            this.dragNDrop.Image = ((System.Drawing.Image)(resources.GetObject("dragNDrop.Image")));
            this.dragNDrop.Location = new System.Drawing.Point(786, 56);
            this.dragNDrop.Name = "dragNDrop";
            this.dragNDrop.Size = new System.Drawing.Size(256, 256);
            this.dragNDrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dragNDrop.TabIndex = 2;
            this.dragNDrop.TabStop = false;
            this.dragNDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragNDrop_DragDrop);
            this.dragNDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragNDrop_DragEnter);
            this.dragNDrop.DragOver += new System.Windows.Forms.DragEventHandler(this.dragNDrop_DragOver);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(781, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Drag And Drop a wav. file here";
            // 
            // fftPlotUc1
            // 
            this.fftPlotUc1.Analyzer = null;
            this.fftPlotUc1.Location = new System.Drawing.Point(12, 345);
            this.fftPlotUc1.Name = "fftPlotUc1";
            this.fftPlotUc1.Size = new System.Drawing.Size(705, 327);
            this.fftPlotUc1.TabIndex = 1;
            // 
            // audioPlotUc1
            // 
            this.audioPlotUc1.Analyzer = null;
            this.audioPlotUc1.Location = new System.Drawing.Point(12, 12);
            this.audioPlotUc1.Name = "audioPlotUc1";
            this.audioPlotUc1.Size = new System.Drawing.Size(705, 327);
            this.audioPlotUc1.TabIndex = 0;
            // 
            // noteIndication
            // 
            this.noteIndication.Location = new System.Drawing.Point(786, 446);
            this.noteIndication.MaxMagnitudeFrequency = 0D;
            this.noteIndication.MaxMagnitudeInDb = 0D;
            this.noteIndication.Name = "noteIndication";
            this.noteIndication.Size = new System.Drawing.Size(262, 183);
            this.noteIndication.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 692);
            this.Controls.Add(this.noteIndication);
            this.Controls.Add(this.fftPlotUc1);
            this.Controls.Add(this.audioPlotUc1);
            this.Controls.Add(this.dragNDrop);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Note Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.dragNDrop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.AudioPlotUc audioPlotUc1;
        private Controls.FftPlotUc fftPlotUc1;
        private System.Windows.Forms.PictureBox dragNDrop;
        private System.Windows.Forms.Label label1;
        private Controls.NoteIndication noteIndication;
    }
}

