using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Game1
{
    class GameManager
    {
        string fileName = "editor.txt";
        StreamWriter output = null;

        public void LoadData()
        {
            try
            {
                StreamReader input = null;
                input = new StreamReader(fileName);

                input.Close();
            }
            catch (Exception e)
            {

            }
        }

        //public void SaveData()
        //{
        //    output = new StreamWriter(fileName);
        //    output.WriteLine(""); //Difficulty
        //    output.WriteLine(""); //High Score
        //    output.WriteLine(""); //Gravity
        //    output.WriteLine(""); //Platform spawn rate
        //    output.WriteLine(""); //Platform drop rate
        //    output.Close();
        //}
    }
}
