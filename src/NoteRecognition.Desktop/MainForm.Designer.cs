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
            this.audioPlotUc1 = new NoteRecognition.Desktop.Controls.AudioPlotUc();
            this.fftPlotUc1 = new NoteRecognition.Desktop.Controls.FftPlotUc();
            this.SuspendLayout();
            // 
            // audioPlotUc1
            // 
            this.audioPlotUc1.Analyzer = null;
            this.audioPlotUc1.Location = new System.Drawing.Point(12, 12);
            this.audioPlotUc1.Name = "audioPlotUc1";
            this.audioPlotUc1.Size = new System.Drawing.Size(705, 327);
            this.audioPlotUc1.TabIndex = 0;
            // 
            // fftPlotUc1
            // 
            this.fftPlotUc1.Analyzer = null;
            this.fftPlotUc1.Location = new System.Drawing.Point(12, 345);
            this.fftPlotUc1.Name = "fftPlotUc1";
            this.fftPlotUc1.Size = new System.Drawing.Size(705, 327);
            this.fftPlotUc1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 692);
            this.Controls.Add(this.fftPlotUc1);
            this.Controls.Add(this.audioPlotUc1);
            this.Name = "MainForm";
            this.Text = "Note Recognition";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AudioPlotUc audioPlotUc1;
        private Controls.FftPlotUc fftPlotUc1;
    }
}

