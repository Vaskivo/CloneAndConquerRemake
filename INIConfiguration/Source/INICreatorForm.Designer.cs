namespace INIConfiguration.Source
{
    partial class INICreatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INICreatorForm));
            this.SpashIcon = new System.Windows.Forms.PictureBox();
            this.INIFilename = new System.Windows.Forms.Label();
            this.INIFilename_textbox = new System.Windows.Forms.TextBox();
            this.achiev1_label = new System.Windows.Forms.Label();
            this.achiev1_textbox = new System.Windows.Forms.TextBox();
            this.achiev2_label = new System.Windows.Forms.Label();
            this.achiev2_textbox = new System.Windows.Forms.TextBox();
            this.Update_button = new System.Windows.Forms.Button();
            this.Finish_button = new System.Windows.Forms.Button();
            this.levelNr_combobox = new System.Windows.Forms.ComboBox();
            this.LevelNr_label = new System.Windows.Forms.Label();
            this.achiev3_label = new System.Windows.Forms.Label();
            this.achiev3_textbox = new System.Windows.Forms.TextBox();
            this.Description_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpashIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // SpashIcon
            // 
            this.SpashIcon.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SpashIcon.Image = ((System.Drawing.Image)(resources.GetObject("SpashIcon.Image")));
            this.SpashIcon.InitialImage = null;
            this.SpashIcon.Location = new System.Drawing.Point(276, 19);
            this.SpashIcon.Name = "SpashIcon";
            this.SpashIcon.Size = new System.Drawing.Size(117, 107);
            this.SpashIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SpashIcon.TabIndex = 9;
            this.SpashIcon.TabStop = false;
            // 
            // INIFilename
            // 
            this.INIFilename.AutoSize = true;
            this.INIFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INIFilename.Location = new System.Drawing.Point(18, 19);
            this.INIFilename.Name = "INIFilename";
            this.INIFilename.Size = new System.Drawing.Size(93, 15);
            this.INIFilename.TabIndex = 7;
            this.INIFilename.Text = "INI Filename:";
            // 
            // INIFilename_textbox
            // 
            this.INIFilename_textbox.Location = new System.Drawing.Point(117, 18);
            this.INIFilename_textbox.Name = "INIFilename_textbox";
            this.INIFilename_textbox.Size = new System.Drawing.Size(147, 20);
            this.INIFilename_textbox.TabIndex = 0;
            // 
            // achiev1_label
            // 
            this.achiev1_label.AutoSize = true;
            this.achiev1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achiev1_label.Location = new System.Drawing.Point(18, 137);
            this.achiev1_label.Name = "achiev1_label";
            this.achiev1_label.Size = new System.Drawing.Size(87, 15);
            this.achiev1_label.TabIndex = 4;
            this.achiev1_label.Text = "Achievement 1";
            // 
            // achiev1_textbox
            // 
            this.achiev1_textbox.Location = new System.Drawing.Point(21, 156);
            this.achiev1_textbox.Multiline = true;
            this.achiev1_textbox.Name = "achiev1_textbox";
            this.achiev1_textbox.Size = new System.Drawing.Size(372, 43);
            this.achiev1_textbox.TabIndex = 2;
            // 
            // achiev2_label
            // 
            this.achiev2_label.AutoSize = true;
            this.achiev2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achiev2_label.Location = new System.Drawing.Point(18, 227);
            this.achiev2_label.Name = "achiev2_label";
            this.achiev2_label.Size = new System.Drawing.Size(87, 15);
            this.achiev2_label.TabIndex = 5;
            this.achiev2_label.Text = "Achievement 2";
            // 
            // achiev2_textbox
            // 
            this.achiev2_textbox.Location = new System.Drawing.Point(21, 246);
            this.achiev2_textbox.Multiline = true;
            this.achiev2_textbox.Name = "achiev2_textbox";
            this.achiev2_textbox.Size = new System.Drawing.Size(372, 43);
            this.achiev2_textbox.TabIndex = 3;
            // 
            // Update_button
            // 
            this.Update_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_button.Location = new System.Drawing.Point(72, 419);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(100, 40);
            this.Update_button.TabIndex = 5;
            this.Update_button.Text = "Update INI";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // Finish_button
            // 
            this.Finish_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Finish_button.Location = new System.Drawing.Point(250, 419);
            this.Finish_button.Name = "Finish_button";
            this.Finish_button.Size = new System.Drawing.Size(100, 40);
            this.Finish_button.TabIndex = 6;
            this.Finish_button.Text = "Finish";
            this.Finish_button.UseVisualStyleBackColor = true;
            this.Finish_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // levelNr_combobox
            // 
            this.levelNr_combobox.FormattingEnabled = true;
            this.levelNr_combobox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.levelNr_combobox.Items.AddRange(new object[] {
            "TinyLevel1",
            "TinyLevel2",
            "TinyLevel3"});
            this.levelNr_combobox.Location = new System.Drawing.Point(117, 91);
            this.levelNr_combobox.Name = "levelNr_combobox";
            this.levelNr_combobox.Size = new System.Drawing.Size(140, 21);
            this.levelNr_combobox.TabIndex = 1;
            // 
            // LevelNr_label
            // 
            this.LevelNr_label.AutoSize = true;
            this.LevelNr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelNr_label.Location = new System.Drawing.Point(18, 91);
            this.LevelNr_label.Name = "LevelNr_label";
            this.LevelNr_label.Size = new System.Drawing.Size(63, 15);
            this.LevelNr_label.TabIndex = 14;
            this.LevelNr_label.Text = "Level ID:";
            this.LevelNr_label.Click += new System.EventHandler(this.LevelNr_label_Click);
            // 
            // achiev3_label
            // 
            this.achiev3_label.AutoSize = true;
            this.achiev3_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achiev3_label.Location = new System.Drawing.Point(18, 317);
            this.achiev3_label.Name = "achiev3_label";
            this.achiev3_label.Size = new System.Drawing.Size(87, 15);
            this.achiev3_label.TabIndex = 16;
            this.achiev3_label.Text = "Achievement 3";
            // 
            // achiev3_textbox
            // 
            this.achiev3_textbox.Location = new System.Drawing.Point(21, 336);
            this.achiev3_textbox.Multiline = true;
            this.achiev3_textbox.Name = "achiev3_textbox";
            this.achiev3_textbox.Size = new System.Drawing.Size(372, 43);
            this.achiev3_textbox.TabIndex = 4;
            // 
            // Description_label
            // 
            this.Description_label.AutoSize = true;
            this.Description_label.Location = new System.Drawing.Point(18, 474);
            this.Description_label.Name = "Description_label";
            this.Description_label.Size = new System.Drawing.Size(207, 13);
            this.Description_label.TabIndex = 17;
            this.Description_label.Text = "(Press \'Update INI\' for each level modified)";
            // 
            // INICreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 496);
            this.Controls.Add(this.Description_label);
            this.Controls.Add(this.achiev3_label);
            this.Controls.Add(this.achiev3_textbox);
            this.Controls.Add(this.LevelNr_label);
            this.Controls.Add(this.levelNr_combobox);
            this.Controls.Add(this.INIFilename);
            this.Controls.Add(this.INIFilename_textbox);
            this.Controls.Add(this.SpashIcon);
            this.Controls.Add(this.achiev1_label);
            this.Controls.Add(this.achiev1_textbox);
            this.Controls.Add(this.achiev2_label);
            this.Controls.Add(this.achiev2_textbox);
            this.Controls.Add(this.Update_button);
            this.Controls.Add(this.Finish_button);
            this.Name = "INICreatorForm";
            this.Text = "INICreatorForm";
            ((System.ComponentModel.ISupportInitialize)(this.SpashIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SpashIcon;
        private System.Windows.Forms.Label INIFilename;
        private System.Windows.Forms.TextBox INIFilename_textbox;
        private System.Windows.Forms.Label achiev1_label;
        private System.Windows.Forms.TextBox achiev1_textbox;
        private System.Windows.Forms.Label achiev2_label;
        private System.Windows.Forms.TextBox achiev2_textbox;

        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.Button Finish_button;
        private System.Windows.Forms.ComboBox levelNr_combobox;
        private System.Windows.Forms.Label LevelNr_label;
        private System.Windows.Forms.Label achiev3_label;
        private System.Windows.Forms.TextBox achiev3_textbox;
        private System.Windows.Forms.Label Description_label;
    }
}