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
    class GameObject
    {
        //Fields
        protected int xLoc;
        protected int yLoc;
        protected int height;
        protected int width;
        protected Rectangle myRectangle;

        public int XLoc { get { return xLoc; } set { xLoc = value; } }

        public int YLoc { get { return yLoc; } set { yLoc = value; } }

        public int Height { get { return height; } set { height = value; } }

        public int Width { get { return width; } set { width = value; } }

        public Texture2D MyTexture { get; set; }

        public Rectangle MyRectangle { get { return myRectangle; } set { myRectangle = value; } }

        //Gets the height, width, xLocation, yLocation and creates a rectangle with those fields
        public GameObject()
        {

        }
        public GameObject(Texture2D texture, int xLoc, int yLoc, int width, int height)
        {
            
            MyTexture = texture;
            this.height = height;
            this.width = width;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            myRectangle = new Rectangle(xLoc, yLoc, width, height);
            
        }

        public GameObject(Texture2D texture, float xLoc, float yLoc)
        {

        }
        
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(MyTexture, myRectangle, Color.White);
        }
    }
}
