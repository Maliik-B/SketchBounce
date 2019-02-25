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
    class Platform : GameObject
    {
        private int activeNumber;
        public bool isActive { get; set; }

        public bool isMoving { get; set; }

        public Color myColor { get; set; }
        public int ActiveNumber
        {
            get { return activeNumber; }
            set { if (value >= 0) { activeNumber = value; } else { activeNumber = -1; } }
        }
        public Platform(Texture2D texture, int xLoc, int yLoc, int width, int height) : base(texture, xLoc, yLoc, width, height)
        {
            MyTexture = texture;
            isActive = true;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            this.width = width;
            this.height = height;
            myRectangle = new Rectangle(xLoc, yLoc, width, height);
            myColor = Color.White;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(MyTexture, myRectangle, myColor);
        }
    }
}
