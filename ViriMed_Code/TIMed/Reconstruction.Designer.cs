namespace TIMed
{
    partial class Reconstruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reconstruction));
            this.label1 = new System.Windows.Forms.Label();
            this.nombre_itéra = new System.Windows.Forms.NumericUpDown();
            this.b_reconst = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.nombre_itéra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre d\'itérations:";
            // 
            // nombre_itéra
            // 
            this.nombre_itéra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_itéra.Location = new System.Drawing.Point(145, 8);
            this.nombre_itéra.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nombre_itéra.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nombre_itéra.Name = "nombre_itéra";
            this.nombre_itéra.Size = new System.Drawing.Size(68, 20);
            this.nombre_itéra.TabIndex = 1;
            this.nombre_itéra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // b_reconst
            // 
            this.b_reconst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_reconst.Location = new System.Drawing.Point(65, 36);
            this.b_reconst.Name = "b_reconst";
            this.b_reconst.Size = new System.Drawing.Size(109, 29);
            this.b_reconst.TabIndex = 2;
            this.b_reconst.Text = "Reconstruire";
            this.b_reconst.UseVisualStyleBackColor = true;
            this.b_reconst.Click += new System.EventHandler(this.b_reconst_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Veuillez patienter...";
            this.label2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 101);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(171, 15);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // Reconstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 123);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.b_reconst);
            this.Controls.Add(this.nombre_itéra);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reconstruction";
            this.Text = "Reconstruction";
            this.Load += new System.EventHandler(this.Reconstruction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nombre_itéra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nombre_itéra;
        private System.Windows.Forms.Button b_reconst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}