namespace LibrarySystem324.View
{
    partial class FrmHome
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
            this.label7 = new System.Windows.Forms.Label();
            this.btnSpecimenEditor = new System.Windows.Forms.Button();
            this.btnDefinitionEditor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(406, 52);
            this.label7.TabIndex = 9;
            this.label7.Text = "Specimen Catalog";
            // 
            // btnSpecimenEditor
            // 
            this.btnSpecimenEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpecimenEditor.Location = new System.Drawing.Point(467, 82);
            this.btnSpecimenEditor.Name = "btnSpecimenEditor";
            this.btnSpecimenEditor.Size = new System.Drawing.Size(184, 80);
            this.btnSpecimenEditor.TabIndex = 10;
            this.btnSpecimenEditor.Text = "Specimen Editor";
            this.btnSpecimenEditor.UseVisualStyleBackColor = true;
            this.btnSpecimenEditor.Click += new System.EventHandler(this.BtnBookEditor_Click);
            // 
            // btnDefinitionEditor
            // 
            this.btnDefinitionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefinitionEditor.Location = new System.Drawing.Point(467, 179);
            this.btnDefinitionEditor.Name = "btnDefinitionEditor";
            this.btnDefinitionEditor.Size = new System.Drawing.Size(184, 80);
            this.btnDefinitionEditor.TabIndex = 14;
            this.btnDefinitionEditor.Text = "Definition Editor";
            this.btnDefinitionEditor.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibrarySystem324.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(21, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(423, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "https://slate.com/technology/2021/06/spotify-e-books-amazon-publishers-libraries-" +
    "licensing.html";
            // 
            // FrmHome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(663, 408);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDefinitionEditor);
            this.Controls.Add(this.btnSpecimenEditor);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmHome";
            this.Text = "Specimen Catalog";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSpecimenEditor;
        private System.Windows.Forms.Button btnDefinitionEditor;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}