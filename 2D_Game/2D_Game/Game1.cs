using System;
using _2D_Game.Controls;
using _2D_Game.CoreClasses;
using _2D_Game.LevelDesign;
using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2D_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Hero hero;
        Camera camera;
        Song backgroundMusic;

        public static int screenWidth;
        public static int screenHeight;

        private Texture2D myBackground, menuImage, diedImage, wonImage, controlsImage, infoImage;
        private Rectangle mainFrame;

        LevelFactoryWithEnemies level1, level2;
        LevelFactory levelBeginner;

        //GameStates
        public enum GameState
        {
            Menu,
            level1,
            level2,
            Beginner,
            Info,
            Controls,
            GameWon,
            GameOver
        }
        GameState gameState = GameState.Menu;
        GameState prevGameState = GameState.Menu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1500;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1000;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;

            screenHeight = graphics.PreferredBackBufferHeight;
            screenWidth = graphics.PreferredBackBufferWidth;

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

            hero = new Hero(Content, new Vector2(178, 100));
            hero.input = new BedieningPijltjes();


            myBackground = Content.Load<Texture2D>("png/BG");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            menuImage = Content.Load<Texture2D>("png/BGMenu");
            wonImage = Content.Load<Texture2D>("png/BGWON");
            diedImage = Content.Load<Texture2D>("png/BGDead");
            controlsImage = Content.Load<Texture2D>("png/BGControls");
            infoImage = Content.Load<Texture2D>("png/BGInfo");

            level1 = new Level1(Content, hero);
            level1.CreateLevel(Content);

            level2 = new Level2(Content, hero);
            level2.CreateLevel(Content);

            levelBeginner = new BeginnerLevel1(Content, hero);
            levelBeginner.CreateLevel(Content);

            camera = new Camera();

            backgroundMusic = Content.Load<Song>("Background");
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;
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
        /// checking for collisions, gathering input, playing audio and checking the gamestate.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyState;
            Vector2 center = new Vector2(mainFrame.Left + mainFrame.Width / 2, mainFrame.Top + mainFrame.Height / 2);
            switch (gameState)
            {
                case GameState.Menu:
                    //Get keyboard state
                    keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.Enter))
                    {
                        ResetHero();
                        prevGameState = gameState;
                        gameState = GameState.level1;
                    }
                    if (keyState.IsKeyDown(Keys.T))
                    {
                        ResetHero();
                        prevGameState = gameState;
                        gameState = GameState.Beginner;
                    }
                    if (keyState.IsKeyDown(Keys.I))
                    {
                        prevGameState = gameState;
                        gameState = GameState.Info;
                    }
                    if (keyState.IsKeyDown(Keys.C))
                    {
                        prevGameState = gameState;
                        gameState = GameState.Controls;
                    }
                    break;
                case GameState.Beginner:
                    UpdateLevel(gameTime);
                    if (levelBeginner.LevelEnd)
                    {
                        ResetHero();
                        prevGameState = gameState;
                        gameState = GameState.GameWon;
                    }
                    if (hero.TooManyDeaths)
                    {
                        prevGameState = gameState;
                        gameState = GameState.GameOver;
                        HeroDiedTooMuch();
                    }
                    break;
                case GameState.level1:
                    UpdateLevel(gameTime);
                    if (level1.LevelEnd)
                    {
                        ResetHero();
                        level2.ReturnEnemiesToPlaces();
                        prevGameState = gameState;
                        gameState = GameState.level2;
                        
                    }
                    if (hero.TooManyDeaths)
                    {
                        prevGameState = gameState;
                        gameState = GameState.GameOver;
                        HeroDiedTooMuch();
                    }
                    break;
                case GameState.level2:
                    UpdateLevel(gameTime);
                    if (level2.LevelEnd)
                    {
                        ResetHero();
                        prevGameState = gameState;
                        gameState = GameState.GameWon;

                    }
                    if (hero.TooManyDeaths)
                    {
                        prevGameState = gameState;
                        gameState = GameState.GameOver;
                        HeroDiedTooMuch();
                    }
                    break;
                case GameState.Info:
                    camera.Follow(center);
                    keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.M))
                    {
                        prevGameState = gameState;
                        gameState = GameState.Menu;
                    }
                    break;
                case GameState.Controls:
                    camera.Follow(center);
                    keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.M))
                    {
                        prevGameState = gameState;
                        gameState = GameState.Menu;
                    }
                    break;
                case GameState.GameOver:
                    camera.Follow(center);
                    keyState = Keyboard.GetState();
                    ReturnToGameOrMenuCheck(keyState);
                    break;
                case GameState.GameWon:
                    camera.Follow(center);
                    keyState = Keyboard.GetState();
                    ReturnToGameOrMenuCheck(keyState);
                    break;
                default:
                    break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Update methods for the levels during playing of the game.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateLevel(GameTime gameTime)
        {
            hero.Update(gameTime);
            switch (gameState)
            {
                case GameState.level1:
                    level1.CheckForCollision(gameTime, hero, Content);
                    break;
                case GameState.level2:
                    level2.CheckForCollision(gameTime, hero, Content);
                    break;
                case GameState.Beginner:
                    levelBeginner.CheckForCollision(gameTime, hero, Content);
                    break;
                default:
                    break;
            }
            camera.Follow(hero.Position);
        }

        /// <summary>
        /// Default method that is called when the player has died too many times and so the gameover screen is shown. 
        /// It sets the toomanydeaths to false so the player can restart.
        /// </summary>
        private void HeroDiedTooMuch()
        {
            hero.TooManyDeaths = false;
            ResetHero();
        }

        /// <summary>
        /// Method called when the player has died too many times or has finished a level. 
        /// Simply relocates the hero to the starting  position and resets timesdied.
        /// </summary>
        private void ResetHero()
        {
            hero.TimesDied = 0;
            hero.Relocate();
        }

        /// <summary>
        /// Checks which gamestate was the previous state so the player can redo a level without having to go through a previous one,
        /// or if the player wants to go to the main menu.
        /// </summary>
        /// <param name="keyState"></param>
        private void ReturnToGameOrMenuCheck(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.R))
            {
                switch (prevGameState)
                {
                    case GameState.level1:
                        level1.ReturnEnemiesToPlaces();
                        prevGameState = gameState;
                        gameState = GameState.level1;
                        break;
                    case GameState.level2:
                        level2.ReturnEnemiesToPlaces();
                        prevGameState = gameState;
                        gameState = GameState.level2;
                        break;
                    case GameState.Beginner:
                        prevGameState = gameState;
                        gameState = GameState.Beginner;
                        break;
                    default:
                        break;
                }
            }
            if (keyState.IsKeyDown(Keys.M))
            {
                prevGameState = gameState;
                gameState = GameState.Menu;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(myBackground, mainFrame, Color.AliceBlue);
            spriteBatch.End();
            switch (gameState)
            {
                case GameState.Menu:
                    DrawMenus(menuImage);
                    break;
                case GameState.Beginner:
                    DrawLevel(spriteBatch);
                    break;
                case GameState.level1:
                    DrawLevel(spriteBatch);
                    break;
                case GameState.level2:
                    DrawLevel(spriteBatch);
                    break;
                case GameState.Info:
                    DrawMenus(infoImage);
                    break;
                case GameState.Controls:
                    DrawMenus(controlsImage);
                    break;
                case GameState.GameWon:
                    DrawMenus(wonImage);
                    break;
                case GameState.GameOver:
                    DrawMenus(diedImage);
                    break;
                default:
                    break;
            }
            base.Draw(gameTime);
        }

        /// <summary>
        /// Switch method that lets the respective level draw for each gamestate.
        /// </summary>
        /// <param name="spriteBatch"></param>
        private void DrawLevel(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.Transform);
            switch (gameState)
            {
                case GameState.level1:
                    level1.DrawWorld(spriteBatch);
                    break;
                case GameState.level2:
                    level2.DrawWorld(spriteBatch);
                    break;
                case GameState.Beginner:
                    levelBeginner.DrawWorld(spriteBatch);
                    break;
                default:
                    break;
            }
            hero.Draw(spriteBatch);
            spriteBatch.End();
        }

        /// <summary>
        /// Method for the menu images to be drawn. The image is received as a parameter so no switch statement is needed.
        /// </summary>
        /// <param name="image"></param>
        private void DrawMenus(Texture2D image)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(image, mainFrame, Color.Beige);
            spriteBatch.End();
        }
    }
}
