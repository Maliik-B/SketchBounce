using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class CustomRectangle
    {
        public float xPos { get; set; }
        public float yPos { get; set; }
        public float width { get; set; }
        public float height { get; set; }

        public CustomRectangle(float xPos, float yPos, float width, float height)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.width = width;
            this.height = height;
        }

        static public bool isColliding(CustomRectangle Player, PlatformSet Platforms)
        {
            
            foreach (Platform p in Platforms.setPlatforms)
            {

                if (Player.xPos >= p.XLoc || Player.xPos + Player.width <= p.XLoc + p.Width || Player.yPos >= p.YLoc || Player.yPos + Player.height <= p.YLoc + p.Height)
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }
    }
}
