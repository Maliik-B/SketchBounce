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
    abstract class PowerUp : GameObject
    {

       
        public PowerUp(Texture2D texture, int xLoc, int yLoc, int width, int height) : base(texture, xLoc, yLoc, width, height)
        {
            myRectangle = new Rectangle(xLoc, yLoc, width, height);
            MyTexture = texture;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            this.height = height;
            this.width = width;
            
        }

        public abstract void isCollided(Player Player);

       
    }
}
