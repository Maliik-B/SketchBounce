using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class BonusPoints : PowerUp
    {
        int pointsAdded;

        Random rgen;
        
        public BonusPoints(Texture2D texture, int xLoc, int yLoc, int width, int height) : base(texture, xLoc, yLoc, width, height)
        {
            this.height = height;
            this.width = width;
            myRectangle = new Rectangle(xLoc, yLoc, height, width);
            MyTexture = texture;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            pointsAdded = 500;
            
            rgen = new Random();
        }

        public override void isCollided(Player Player)
        {
            if (Player.MyRectangle.Intersects(myRectangle))
            {
                Game1.Score += pointsAdded;

                Replacement();
                
            }
            
        }

        public void Falling()
        {
            yLoc += 5;

            myRectangle = new Rectangle(xLoc, yLoc, width, height);

            if (yLoc >= 900)
            {
                Replacement();
            }
        }

        public void Replacement()
        {
            int x = rgen.Next(50,600);
            int y = rgen.Next(-600, -100);

            yLoc = y;
            xLoc = x;

            myRectangle = new Rectangle(xLoc, yLoc, width, height);
        }
    }

}
