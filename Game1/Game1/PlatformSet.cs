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
    class PlatformSet
    {

        

        public Platform[] setPlatforms { get; set; }
        int easySet = 6;
        int mediumSet = 5;
        int hardSet = 3;
        int initialPlatWidth = 100;
        int initialPlatHeight = 53;

        int platspeed;

        public int platspeedEasy { get; set; }
        public int platspeedMedium { get; set; }
        public int platspeedHard { get; set; }

        bool platMoving1 = false;

        bool platMoving2 = false;

        Texture2D pText;
        
        int x;
        int y;
        Random platRand;
        int[] yCoorinates;
        Game1.DifficultyStates currentState;
        public Platform[] SetPlatforms { get { return setPlatforms; } set { value = setPlatforms; } }
        public Rectangle[] platZone { get; set; }

        public PlatformSet(int screenwidth, int screenheight, Game1.DifficultyStates setDifficulty,Texture2D platText, Random r)
        {
            
                platspeedEasy = 4;
            
                platspeedMedium = 4;
           
                platspeedHard = 4;

                //platspeedMedium = 2;
           
                //platspeedHard = 2;
            
            platRand = r;
            x = screenwidth;
            y = 0;
            pText = platText;
            if (setDifficulty == Game1.DifficultyStates.Easy)
            {
                platspeed = platspeedEasy;
                yCoorinates = new int[easySet];
                setPlatforms = new Platform[easySet];
                platZone = new Rectangle[easySet];

                int spread = 0;

                for (int i = 0; i <= easySet - 1; i++)
                {
                    y = platRand.Next(-700, 100);
                    setPlatforms[i] = new Platform(platText, screenwidth / easySet * i, y+spread, initialPlatWidth, initialPlatHeight);
                    yCoorinates[i] = y+spread;
                    platZone[i] = new Rectangle(screenwidth / easySet * i, y+spread, initialPlatWidth, 10);
                    spread = spread + 50;
                }
            }
            else if (setDifficulty == Game1.DifficultyStates.Medium)
            {
                platspeed = platspeedMedium;
                yCoorinates = new int[mediumSet];
                setPlatforms = new Platform[mediumSet];
                platZone = new Rectangle[mediumSet];
                initialPlatWidth = 80;
                initialPlatHeight = 43;
                for (int i = 0; i <= mediumSet - 1; i++)
                {
                    y = platRand.Next(-700, 100);
                    setPlatforms[i] = new Platform(platText, screenwidth / mediumSet * i, y, initialPlatWidth, initialPlatHeight);
                    yCoorinates[i] = y;
                    platZone[i] = new Rectangle(screenwidth / mediumSet * i, y, initialPlatWidth, 10);
                }
            }
            else if (setDifficulty == Game1.DifficultyStates.Hard)
            {
                platspeed = platspeedHard;
                yCoorinates = new int[hardSet];
                setPlatforms = new Platform[hardSet];
                platZone = new Rectangle[hardSet];
                initialPlatWidth = 50;
                initialPlatHeight = 33;
                for (int i = 0; i <= hardSet - 1; i++)
                {
                    y = platRand.Next(0, 600);
                    setPlatforms[i] = new Platform(platText, screenwidth / hardSet * i, y, initialPlatWidth, initialPlatHeight);
                    yCoorinates[i] = y;
                    platZone[i] = new Rectangle(screenwidth / hardSet * i, y, initialPlatWidth, 10);
                }
            }
            
            currentState = setDifficulty;
        }
        public void Falling()
        {
            if (currentState == Game1.DifficultyStates.Easy)
            {
                for (int i = 0; i <= easySet - 1; i++)
                {
                    yCoorinates[i] += platspeed;
                    FairPlats();
                    setPlatforms[i] = new Platform(pText, (x / easySet * i), yCoorinates[i], initialPlatWidth, initialPlatHeight);
                    platZone[i] = new Rectangle(x / easySet * i, yCoorinates[i], initialPlatWidth, 10);
                    if (setPlatforms[i].YLoc >= 900)
                    {
                        Replacement(i);
                    }

                }
            }
            else if (currentState == Game1.DifficultyStates.Medium)
            {
                for (int i = 0; i <= mediumSet - 1; i++)
                {
                    yCoorinates[i] += platspeed;
                    FairPlats();
                    setPlatforms[i] = new Platform(pText, (x / mediumSet * i), yCoorinates[i], initialPlatWidth, initialPlatHeight);
                    platZone[i] = new Rectangle(x / mediumSet * i, yCoorinates[i], initialPlatWidth, 10);
                    if (setPlatforms[i].YLoc >= 900)
                    {
                        Replacement(i);
                    }

                }
            }
            else if (currentState == Game1.DifficultyStates.Hard)
            {
                for (int i = 0; i <= hardSet - 1; i++)
                {
                    yCoorinates[i] += platspeed;
                    FairPlats();
                    setPlatforms[i] = new Platform(pText, (x / hardSet * i), yCoorinates[i], initialPlatWidth, initialPlatHeight);
                    platZone[i] = new Rectangle(x / hardSet * i, yCoorinates[i], initialPlatWidth, 10);
                    if (setPlatforms[i].YLoc >= 900)
                    {
                        Replacement(i);
                    }

                }
            }
        }
        public void DrawSet(SpriteBatch sb)
        {
            foreach(Platform b in setPlatforms)
           {
               b.Draw(sb);
            }
            
        }
        
        public void Replacement(int a)
        {
            if(currentState == Game1.DifficultyStates.Easy)
            {
                int xloc = platRand.Next(0, 540);
                int yLoc = platRand.Next(-154, -54);
                setPlatforms[a].XLoc = xloc;
                yCoorinates[a] = yLoc;
                platZone[a] = new Rectangle(xloc, yCoorinates[a], initialPlatWidth, 10);

                //FairPlats();
            }
            else if(currentState == Game1.DifficultyStates.Medium)
            {
                int xloc = platRand.Next(0, 540);
                int yLoc = platRand.Next(-100, -54);
                setPlatforms[a].XLoc = xloc;
                yCoorinates[a] = yLoc;
                platZone[a] = new Rectangle(xloc, yCoorinates[a], initialPlatWidth, 10);

                //FairPlats();
            }
            else if (currentState == Game1.DifficultyStates.Hard)
            {
                int xloc = platRand.Next(0, 540);
                int yLoc = platRand.Next(-80, -34);
                setPlatforms[a].XLoc = xloc;
                yCoorinates[a] = yLoc;
                platZone[a] = new Rectangle(xloc, yCoorinates[a], initialPlatWidth, 10);

                //FairPlats();
            }

        }

        public void Reset()
        {
            if(currentState == Game1.DifficultyStates.Easy)
            {
                for (int i = 0; i <= easySet - 1; i++)
                {
                    int xloc = platRand.Next(0, 540);
                    int yLoc = platRand.Next(-700, 800);
                    setPlatforms[i].XLoc = xloc;
                    yCoorinates[i] = yLoc;
                    platZone[i] = new Rectangle(x / easySet * i, y, initialPlatWidth, 10);
                }
            }
            else if(currentState == Game1.DifficultyStates.Medium)
            {
                for (int i = 0; i <= mediumSet - 1; i++)
                {
                    int xloc = platRand.Next(0, 540);
                    int yLoc = platRand.Next(-700, 800);
                    setPlatforms[i].XLoc = xloc;
                    yCoorinates[i] = yLoc;
                    platZone[i] = new Rectangle(x / mediumSet * i, y, initialPlatWidth, 10);
                }
            }
            else if(currentState == Game1.DifficultyStates.Hard)
            {
                for (int i = 0; i <= hardSet - 1; i++)
                {
                    int xloc = platRand.Next(0, 540);
                    int yLoc = platRand.Next(-700, 800);
                    setPlatforms[i].XLoc = xloc;
                    yCoorinates[i] = yLoc;
                    platZone[i] = new Rectangle(x / hardSet * i, y, initialPlatWidth, 10);
                }
            }
            
            
        }


        

        public void FairPlats()
        {
            //int plat1 = platRand.Next(0, yCoorinates.Length - 1);
            //int plat2 = platRand.Next(0, yCoorinates.Length - 1);

            //if (plat2 == plat1)
            //{
            //    plat2 = plat2 + 1;
            //    if (plat2 > yCoorinates.Length)
            //    {
            //        plat2 = plat2 - 2;
            //    }
            //}


            //if (yCoorinates[plat1] - yCoorinates[plat2] > 300)
            //{
            //    platMoving1 = true;


            //}
            //else
            //{
            //    plat1 = platRand.Next(0, yCoorinates.Length - 1);
            //    plat2 = platRand.Next(0, yCoorinates.Length - 1);
            //    platMoving1 = false;
            //}

            //if (platMoving1 == true)
            //{
            //    yCoorinates[plat1] = yCoorinates[plat1] - 1;
            //    setPlatforms[plat1].myColor = Color.Violet;
            //}
            //else
            //{
            //    setPlatforms[plat1].myColor = Color.White;
            //}



            //if (yCoorinates[plat2] - yCoorinates[plat1] > platRand.Next(100, 300))
            //{
            //    platMoving2 = true;


            //}
            //else
            //{
            //    plat1 = platRand.Next(0, yCoorinates.Length - 1);
            //    plat2 = platRand.Next(0, yCoorinates.Length - 1);
            //    platMoving2 = false;
            //}

            //if (platMoving2 == true)
            //{
            //    yCoorinates[plat2] = yCoorinates[plat1] - 1;
            //    setPlatforms[plat2].myColor = Color.Violet;
            //}
            //else
            //{
            //    setPlatforms[plat2].myColor = Color.White;
            //}


            Platform lowest = setPlatforms[0];
            Platform secondlowest = setPlatforms[1];

            foreach(Platform p in setPlatforms)
            {
                if(p.YLoc > lowest.YLoc)
                {
                    lowest = p;
                }
            }
            foreach(Platform p in setPlatforms)
            {
                if(secondlowest.YLoc < p.YLoc && p.YLoc < lowest.YLoc)
                {
                    secondlowest = p;
                }
            }

            int scndIndex = Array.FindIndex(setPlatforms, p => p == secondlowest);
            int lowIndex = Array.FindIndex(setPlatforms, p => p == lowest);

            if (lowest.YLoc - secondlowest.YLoc > 330)
            {
               
                yCoorinates[lowIndex] = yCoorinates[lowIndex] - 1; 
                setPlatforms[scndIndex].myColor = Color.PaleVioletRed;
                setPlatforms[lowIndex].myColor = Color.PaleVioletRed;
            }
            else
            {
                setPlatforms[scndIndex].myColor = Color.White;
                setPlatforms[lowIndex].myColor = Color.White;
            }

        }

    }
}
