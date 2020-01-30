namespace NoteRecognition.Desktop.Controls
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
            this.noteOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Your note is";
            // 
            // noteOutput
            // 
            this.noteOutput.Enabled = false;
            this.noteOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteOutput.Location = new System.Drawing.Point(3, 42);
            this.noteOutput.Name = "noteOutput";
            this.noteOutput.Size = new System.Drawing.Size(254, 32);
            this.noteOutput.TabIndex = 6;
            // 
            // NoteIndication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noteOutput);
            this.Controls.Add(this.label2);
            this.Name = "NoteIndication";
            this.Size = new System.Drawing.Size(262, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox noteOutput;
    }
}
