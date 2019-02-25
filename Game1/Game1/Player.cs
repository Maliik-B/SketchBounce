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
    class Player : GameObject
    {
       
        public bool startingJump = true;
        public int JumpForce = 0;
        bool jumping = false;
        public int gravity;

        public int JumpForceVal;
        public bool Jumping { get { return jumping; } }
        

        

        Rectangle jumpZone;
        

        public Player(Texture2D texture, int xLoc, int yLoc, int width, int height) : base(texture, xLoc, yLoc, width, height)
        {
            
                gravity = 30;
            
                JumpForceVal = -25;
            

            this.height = height;
            this.width = width;
            myRectangle = new Rectangle(xLoc, yLoc, height, width);
            MyTexture = texture;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            
            jumpZone = new Rectangle(XLoc, YLoc + 90, 100, 10);
        }

       

        public void OwenJumping(PlatformSet set)
        {
            if (startingJump == true)
            {
                jumping = true;
                JumpForce = -30;
                startingJump = false;
            }

            if (jumping == false)
            {
                foreach(Rectangle p in set.platZone)
                {
                    if (jumpZone.Intersects(p))
                    {
                        jumping = true;
                        JumpForce = JumpForceVal;
                        Game1.Score += 100;
                        
                        
                    }
                }
            }

            if(jumping == true)
            {
                myRectangle = new Rectangle(myRectangle.X, myRectangle.Y + JumpForce, 100, 100);

                jumpZone = new Rectangle(myRectangle.X, myRectangle.Y + JumpForce+60, 100, 40);

                JumpForce += 1;

                if(JumpForce > 0)
                {
                    jumping = false;
                }
                
            }
            else
            {
                myRectangle = new Rectangle(myRectangle.X, myRectangle.Y + JumpForce, 100, 100);

                jumpZone = new Rectangle(myRectangle.X, myRectangle.Y + JumpForce+60, 100, 40);

                if (JumpForce < gravity)
                {
                    JumpForce += 1;
                }
                else
                {
                    JumpForce = gravity;
                }
                
            }
        }
        

        public void CharacterMove()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {

                myRectangle.X -= 10;
                jumpZone = new Rectangle(myRectangle.X, myRectangle.Y + 90, 100, 10);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                myRectangle.X += 10;
                jumpZone = new Rectangle(myRectangle.X, myRectangle.Y + 90, 100, 10);
            }
        }

    }
}
