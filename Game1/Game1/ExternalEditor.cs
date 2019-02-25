using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game1
{
    public partial class ExternalEditor : Form
    {
        string fileName = "editor.txt";
        string tempJumpForce;
        string tempGravity;
        string tempEasySpeed;
        string tempMediumSpeed;
        string tempHardSpeed;

        public ExternalEditor()
        {
            InitializeComponent();
        }

        public void SaveData()
        {
            StreamWriter output = new StreamWriter(fileName);
            output.WriteLine(Game1.highScore); //High Score
            output.WriteLine(tempJumpForce); //JumpForce
            output.WriteLine(tempGravity); //Gravity
            output.WriteLine(tempEasySpeed); //Easy Fall Speed
            output.WriteLine(tempMediumSpeed); //Medium Fall Speed
            output.WriteLine(tempHardSpeed); //Hard Fall Speed
            output.Close();

        }

        private void ExitPressed(object sender, EventArgs e)
        {
            Hide();
            //output.Close();
        }

        private void ExternalEditor_Load(object sender, EventArgs e)
        {
        }

        private void ChangeGravity(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            tempGravity = t.Text;
            SaveData();
        }

        private void PlatSpeedEasy(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            tempEasySpeed = t.Text;
            SaveData();
        }

        private void PlatSpeedMedium(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            tempMediumSpeed = t.Text;
            SaveData();
        }
        private void ChangeJumpForce(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            tempJumpForce = t.Text;
            SaveData();
        }

        private void Difficulty_Click(object sender, EventArgs e)
        {

        }

        private void PlatSpeedHard(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            tempHardSpeed = t.Text;
            SaveData();
        }
    }
}
