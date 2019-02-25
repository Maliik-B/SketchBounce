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
    /// <summary>
    /// Annie Ge
    /// Maliik Is here
    /// Owen is here
    /// </summary>
    public class Game1 : Game
    {

        //Enums for difficulty and game states
        enum GameStates
        {
            Menu,
            Options,
            Game,
            Pause,
            GameOver,
        }
        public enum DifficultyStates
        {
            Easy,
            Medium,
            Hard
        }
        GameStates gameCurrentState;
        public static DifficultyStates currentDifficulty { get; set; }


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        //fields for Textures
        #region

        private Texture2D BonusPoints;
        
        private Texture2D powerup;

        private Rectangle starterMenuButton;

        private Rectangle backgroundBox;

        private Texture2D character;

        private Texture2D platformTexture;

        private Texture2D background;

        private Texture2D testPowerUp;
        //Button Fields
        private Texture2D buttonBack;

        private Texture2D buttonBackH;

        private Texture2D buttonEasy;

        private Texture2D buttonEasyH;

        private Texture2D buttonMedium;

        private Texture2D buttonMediumH;

        private Texture2D buttonHard;

        private Texture2D buttonHardH;

        private Texture2D buttonOptions;

        private Texture2D buttonOptionsH;

        private Texture2D buttonPlay;

        private Texture2D buttonPlayH;

        private Texture2D buttonQuit;

        private Texture2D buttonQuitH;

        private Texture2D menuScreen;

        private Texture2D optionsScreen;

        private Texture2D GameOver;
        #endregion

        //Rectangles
        #region
        private Rectangle playRect;
        private Rectangle optionsRect;
        private Rectangle quitRect;
        private Rectangle backRect;
        private Rectangle easyRect;
        private Rectangle mediumRect;
        private Rectangle hardRect;
        #endregion

        //Button field ending
        SpriteFont ArialFont;

        //States
        #region
        //Keyboard States
        KeyboardState previousKeyboardState;

        KeyboardState currentKeyboardState;

        //Mouse States
        MouseState currentMouse;
        //Randoms
        Random randGenerator = new Random();

        Random rgen;
        string CurrentDisplayedDifficulty;
        #endregion

        //Primatives
        int smallValue;

        public static int Score { get; set; }

        public static int highScore { get; set; }

        int windowWidth = 640;
        int windowHeight = 900;

        float backgroundY = -1800;

        
        private bool isFalling = true;

        private bool beginningPlat;

        private bool testbool = true;

        private MouseState pvsState;

        //objects
        Platform MalTest;

        private Platform beginningPlatform;

        private Platform testPlatform;

        PlatformSet PlatSet;

        Player Player1;

        BonusPoints BonusPointsPowerUp;

        ExternalEditor Editor = new ExternalEditor();


        //File reading
        string fileName = "editor.txt";

        bool developerMode = false;

        //StreamWriter output;

        StreamWriter output;
        //positions
        Vector2 scorePos = new Vector2(10, 10);

        Vector2 backgroundPos;


        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = windowWidth;  // window width
            graphics.PreferredBackBufferHeight = windowHeight;   // window height
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.ApplyChanges();
            Score = 0;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //initialzing objects and fields
            MalTest = new Platform(platformTexture, 10, 10, 100, 100);
            if(output == null)
            {
                output = new StreamWriter(fileName);
                output.Close();
            }
            starterMenuButton = new Rectangle(GraphicsDevice.Viewport.Width/2,GraphicsDevice.Viewport.Height/2,300,100);
            CurrentDisplayedDifficulty = "Easy";
            rgen = new Random();
            beginningPlat = true;
            
            Player1 = new Player(character, 20, 10, 100, 100);
           
            backgroundPos = new Vector2(0, backgroundY);

            BonusPointsPowerUp = new BonusPoints(testPowerUp, 200, -500, 25, 25);

            playRect = new Rectangle(windowWidth / 2 - 73, windowHeight / 2, 146, 65);
            optionsRect = new Rectangle(windowWidth / 2 - 73, windowHeight / 2 + 100, 146, 65);
            quitRect = new Rectangle(windowWidth / 2 - 73, windowHeight / 2 + 200, 146, 65);

            easyRect = new Rectangle(windowWidth / 2 - 273, 400, 146, 65);
            mediumRect = new Rectangle(windowWidth / 2 - 73, 400, 146, 65);
            hardRect = new Rectangle(windowWidth / 2 + 127, 400, 146, 65);

            currentDifficulty = DifficultyStates.Easy;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            character = Content.Load<Texture2D>("robot2");

            platformTexture = Content.Load<Texture2D>("testplatform");

            //powerup = Content.Load<Texture2D>("star.png");

            BonusPoints = Content.Load<Texture2D>("star");

            ArialFont = Content.Load<SpriteFont>("UI");

            background = Content.Load<Texture2D>("background");

            testPowerUp = Content.Load<Texture2D>("testplatform");

            GameOver = Content.Load<Texture2D>("gameOver");

            //button region
            #region
            //Button initialization
            buttonBack = Content.Load<Texture2D>("button_back");
            buttonBackH = Content.Load<Texture2D>("button_backH");
            buttonEasy = Content.Load<Texture2D>("button_easy");
            buttonEasyH = Content.Load<Texture2D>("button_easyH");
            buttonMedium = Content.Load<Texture2D>("button_medium");
            buttonMediumH = Content.Load<Texture2D>("button_mediumH");
            buttonHard = Content.Load<Texture2D>("button_hard");
            buttonHardH = Content.Load<Texture2D>("button_hardH");
            buttonOptions = Content.Load<Texture2D>("button_options");
            buttonOptionsH = Content.Load<Texture2D>("button_optionsH");
            buttonPlay = Content.Load<Texture2D>("button_play");
            buttonPlayH = Content.Load<Texture2D>("button_playH");
            buttonQuit = Content.Load<Texture2D>("button_quit");
            buttonQuitH = Content.Load<Texture2D>("button_quitH");
            //End of button initialization
            #endregion


            menuScreen = Content.Load<Texture2D>("MenuStart");
            optionsScreen = Content.Load<Texture2D>("optionsArt");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        bool spawn = true;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            currentKeyboardState = Keyboard.GetState();
            
            // TODO: Add your update logic here
            GameStateChecker();
            
            previousKeyboardState = currentKeyboardState;

            testbool = false;

            base.Update(gameTime);
            //Code for mouse State-Maliik 
            currentMouse = Mouse.GetState();
        }
         
       
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            if (gameCurrentState == GameStates.Menu)
            {

                spriteBatch.Draw(menuScreen, new Rectangle(0, 0, windowWidth, windowHeight), Color.White);
                //spriteBatch.Draw(menuButton, starterMenuButton, Color.White);

                //spriteBatch.DrawString(ArialFont, "Start", new Vector2(starterMenuButton.X + 20, starterMenuButton.Y + 20), Color.White);

                //spriteBatch.Draw(startMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(buttonPlay, playRect, Color.White);
                spriteBatch.Draw(buttonOptions, optionsRect, Color.White);
                spriteBatch.Draw(buttonQuit, quitRect, Color.White);

                MouseState mouseState = Mouse.GetState();

                Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (mouseRect.Intersects(playRect))
                    {
                        spriteBatch.Draw(buttonPlayH, playRect, Color.White);
                    }
                    else if (mouseRect.Intersects(optionsRect))
                    {
                        spriteBatch.Draw(buttonOptionsH, optionsRect, Color.White);
                    }
                    else if (mouseRect.Intersects(quitRect))
                    {
                        spriteBatch.Draw(buttonQuitH, quitRect, Color.White);
                    }
                }

            }
            //Code related to gameplay such as plateform movement should be placed here
            if (gameCurrentState == GameStates.Game)
            {
                spriteBatch.Draw(background, backgroundPos, Color.White);

                spriteBatch.Draw(character, Player1.MyRectangle, Color.White);

                beginningPlatform.Draw(spriteBatch);

                testPlatform.Draw(spriteBatch);
                if(PlatSet != null)
                {
                    PlatSet.DrawSet(spriteBatch);
                }
                else
                {
                    Console.WriteLine("The platform set is null");
                }
                

                spriteBatch.DrawString(ArialFont, "Score: " + Score, scorePos, Color.White);


                spriteBatch.Draw(BonusPoints, BonusPointsPowerUp.MyRectangle, Color.White);

            }

                
                
            

            if(gameCurrentState == GameStates.Options)
            {
                spriteBatch.Draw(optionsScreen, new Vector2(0, 0), Color.White);
               
                spriteBatch.DrawString(ArialFont, "Current Difficulty: " + CurrentDisplayedDifficulty, new Vector2(25, windowHeight - 40), Color.White);
                
                spriteBatch.Draw(buttonEasy, easyRect, Color.White); //Easy Button

                spriteBatch.Draw(buttonMedium, mediumRect, Color.White);  //Normal

                spriteBatch.Draw(buttonHard, hardRect, Color.White); //Hard

                spriteBatch.Draw(buttonBack, backRect, Color.White);

                MouseState mouseState = Mouse.GetState();

                Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (mouseRect.Intersects(backRect))
                    {
                        spriteBatch.Draw(buttonBackH, backRect, Color.White);
                    }
                    else if (mouseRect.Intersects(easyRect))
                    {

                        spriteBatch.Draw(buttonEasyH, easyRect, Color.White); //Easy Button
                        currentDifficulty = DifficultyStates.Easy;
                        
                    }
                    else if (mouseRect.Intersects(mediumRect))
                    {
                        spriteBatch.Draw(buttonMediumH, mediumRect, Color.White);  //Normal
                        currentDifficulty = DifficultyStates.Medium;
                    }
                    else if (mouseRect.Intersects(hardRect))
                    {
                        spriteBatch.Draw(buttonHardH, hardRect, Color.White); //Hard
                        currentDifficulty = DifficultyStates.Hard;
                    }
                }
            }
            if (gameCurrentState == GameStates.Pause)
            {

            }
            if(gameCurrentState == GameStates.GameOver)
            {
                spriteBatch.Draw(GameOver, new Vector2(0, 0), Color.White);

                spriteBatch.DrawString(ArialFont, "High Score: " + highScore, new Vector2(windowWidth / 2 - 40,windowHeight/2), Color.White);

            }
            
            base.Draw(gameTime);



            spriteBatch.End();
        }
       
        //Methods
        
        bool SingleKeyPress(Keys testkey)
        {
            if(previousKeyboardState.IsKeyUp(testkey) && currentKeyboardState.IsKeyDown(testkey))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsRightButtonClicked()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool needStartPlat = true;

        bool runSaveData = true;

        bool setDefaultDifficulty = true;

        public void GameStateChecker()
        {
            MouseState mouseState = Mouse.GetState();

            if (gameCurrentState == GameStates.Menu)
            {
                LoadData();
                runSaveData = true;
                
                if (SingleKeyPress(Keys.Enter))
                {
                    gameCurrentState = GameStates.Game;

                    beginningPlat = true;
                }

                if (SingleKeyPress(Keys.O))
                {
                    gameCurrentState = GameStates.Options;
                }

                this.IsMouseVisible = true;

                Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

                if (mouseState.LeftButton == ButtonState.Released && pvsState.LeftButton == ButtonState.Pressed)
                {
                    if (mouseRect.Intersects(playRect))
                    {
                        gameCurrentState = GameStates.Game;
                    }
                    else if (mouseRect.Intersects(optionsRect))
                    {
                        gameCurrentState = GameStates.Options;
                    }
                    else if (mouseRect.Intersects(quitRect))
                    {
                        Exit();
                    }
                }

                

                Player1.MyRectangle = new Rectangle(GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2, 100, 100);

                backgroundY = -1800f;

                backgroundPos = new Vector2(0, backgroundY);

                Score = 0;

            }
            if (gameCurrentState == GameStates.Options)
            {
                if (SingleKeyPress(Keys.Q))
                {
                    gameCurrentState = GameStates.Menu;
                }
                if (SingleKeyPress(Keys.Z))
                {
                    Editor.Show();
                }

                backRect = new Rectangle(windowWidth / 2 - 73, windowHeight - 200, 146, 65);

                this.IsMouseVisible = true;

                mouseState = Mouse.GetState();

                Rectangle mouseRect = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

                if (mouseState.LeftButton == ButtonState.Released && pvsState.LeftButton == ButtonState.Pressed)
                {
                    if (mouseRect.Intersects(backRect))
                    {
                        gameCurrentState = GameStates.Menu;
                    }
                    else if (mouseRect.Intersects(easyRect))
                    {
                        
                        currentDifficulty = DifficultyStates.Easy;
                        CurrentDisplayedDifficulty = "Easy";
                        spawn = true;
                        //SaveData();
                    }
                    else if (mouseRect.Intersects(mediumRect))
                    {
                        currentDifficulty = DifficultyStates.Medium;
                        CurrentDisplayedDifficulty = "Medium";
                        spawn = true;
                        //SaveData();
                    }
                    else if (mouseRect.Intersects(hardRect))
                    {
                        currentDifficulty = DifficultyStates.Hard;
                        CurrentDisplayedDifficulty = "Hard";
                        
                        spawn = true;
                        //SaveData();
                    }
                }

            }
            if (gameCurrentState == GameStates.Game)
            {
                beginningPlatform = new Platform(platformTexture, 0, GraphicsDevice.Viewport.Height, GraphicsDevice.Viewport.Width, 10);

                testPlatform = new Platform(platformTexture, 0, GraphicsDevice.Viewport.Height, GraphicsDevice.Viewport.Width, 10);

                BonusPointsPowerUp.isCollided(Player1);

                BonusPointsPowerUp.Falling();

                bool isMouseClicked = IsRightButtonClicked();
                
                if (spawn == true)
                {
                    
                    PlatSet = new PlatformSet(windowWidth, windowHeight, currentDifficulty, platformTexture, randGenerator);

                    SaveData();
                   
                    spawn = false;

                }


                


                Player1.OwenJumping(PlatSet);
                

                Player1.CharacterMove();

                BackgroundMover();

                Bounds();

                PlatSet.Falling();
                

                if (SingleKeyPress(Keys.W))
                {
                    gameCurrentState = GameStates.GameOver;
                }

                if (currentKeyboardState.IsKeyDown(Keys.Q))
                {
                   
                }
                
            }
            if (gameCurrentState == GameStates.GameOver)
            {
                needStartPlat = true;
                

                Player1.startingJump = true;
                if (Score > highScore)
                {
                    highScore = Score;
                }
                if (runSaveData)
                {
                    runSaveData = false;
                    SaveData();
                    
                }
                
                if (SingleKeyPress(Keys.Enter))
                {
                    PlatSet.Reset();
                    gameCurrentState = GameStates.Menu;
                }
            }
            pvsState = mouseState;
        }

        public void BackgroundMover()
        {
            backgroundPos = new Vector2(0, backgroundY);

            if (Player1.Jumping == true && backgroundY <= 0)
            {
                backgroundY = backgroundY + 1;
            }

        }

        public void Bounds()
        {
            int xLoc = Player1.MyRectangle.X;

            int yLoc = Player1.MyRectangle.Y;

            if (yLoc >= 950)
            {
                gameCurrentState = GameStates.GameOver;
            }

            if(xLoc <= -100)
            {
                Player1.MyRectangle = new Rectangle(650, yLoc, 100, 100);
            }

            if (xLoc >= 650)
            {
                Player1.MyRectangle = new Rectangle(-100, yLoc, 100, 100);
            }
        }

        public void SaveData()
        {

            
                output = new StreamWriter(fileName);
                output.WriteLine(highScore);
                output.WriteLine(Player1.JumpForceVal);
                output.Close();

            output = new StreamWriter(fileName);
            output.WriteLine(highScore);
            output.WriteLine(Player1.JumpForceVal);
            output.WriteLine(Player1.gravity);
            output.WriteLine(PlatSet.platspeedEasy);
            output.WriteLine(PlatSet.platspeedMedium);
            output.WriteLine(PlatSet.platspeedHard);
            output.Close();

        }

        public void LoadData()
        {
            StreamReader input = null;
            input = new StreamReader(fileName);
            try
            {

                highScore = int.Parse(input.ReadLine());

                Player1.JumpForceVal = int.Parse(input.ReadLine());

                Player1.gravity = int.Parse(input.ReadLine());

                PlatSet.platspeedEasy = int.Parse(input.ReadLine());

                PlatSet.platspeedMedium = int.Parse(input.ReadLine());
                
                PlatSet.platspeedHard = int.Parse(input.ReadLine());

                input.Close();
            }
            catch (Exception e)
            {
                input.Close();
            }
        }
    }
}
