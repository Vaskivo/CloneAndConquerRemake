using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INIConfiguration.Source
{
    public partial class INICreatorForm : Form
    {
        private string INIFilePath = ".\\";
        private string INIFileExtension = ".ini";

        public INICreatorForm()
        {
            InitializeComponent();
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            //check values on fields and..
            if (!String.IsNullOrEmpty(INIFilename_textbox.Text))
            {
                //..create ini file
                INIFileHandler iniFile = new INIFileHandler(this.INIFilePath + INIFilename_textbox.Text + this.INIFileExtension);
                if(!String.IsNullOrEmpty(achiev1_textbox.Text))
                    iniFile.IniWriteValue(levelNr_combobox.SelectedItem.ToString(), achiev1_label.Text, achiev1_textbox.Text);
                if (!String.IsNullOrEmpty(achiev2_textbox.Text))                
                    iniFile.IniWriteValue(levelNr_combobox.SelectedItem.ToString(), achiev2_label.Text, achiev2_textbox.Text);
                if (!String.IsNullOrEmpty(achiev3_textbox.Text))
                    iniFile.IniWriteValue(levelNr_combobox.SelectedItem.ToString(), achiev3_label.Text, achiev3_textbox.Text);
            }
            else
            {
                throw new Exception("Filename is null!");
            }

            //Application.Exit();
        }

        private void LevelNr_label_Click(object sender, EventArgs e)
        {

        }
    }
}