using _2D_Game.Controls;
using _2D_Game.CoreClasses;
using _2D_Game.LevelDesign;
using _2D_Game.MovingSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public static int screenWidth;
        public static int screenHeight;

        private Texture2D myBackground, menuImage, diedImage, wonImage;
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
            GameWon,
            GameOver
        }
        GameState gameState = GameState.Menu;

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

            level1 = new Level1(Content, hero);
            level1.CreateLevel(Content);

            level2 = new Level2(Content, hero);
            level2.CreateLevel(Content);

            levelBeginner = new BeginnerLevel1(Content, hero);
            levelBeginner.CreateLevel(Content);

            camera = new Camera();
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyState;
            Vector2 center = new Vector2(mainFrame.Left + mainFrame.Width / 2, mainFrame.Top + mainFrame.Height / 2);
            //Updating state
            switch (gameState)
            {
                case GameState.Menu:
                    //Get keyboard state
                    keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.Enter))
                    {
                        hero.TimesDied = 0;
                        hero.Relocate();
                        gameState = GameState.level1;
                        //Hier dingen zetten die nu moeten laden (slechts 1x)
                    }
                    if (keyState.IsKeyDown(Keys.T))
                    {

                        hero.TimesDied = 0;
                        hero.Relocate();
                        gameState = GameState.Beginner;
                    }
                    break;
                case GameState.Beginner:
                    hero.Update(gameTime);
                    levelBeginner.CheckForCollision(gameTime, hero, Content);
                    camera.Follow(hero.Position);
                    if (levelBeginner.LevelEnd)
                    {
                        hero.TimesDied = 0;
                        hero.Relocate();
                        gameState = GameState.GameWon;
                    }
                    if (hero.TooManyDeaths)
                    {
                        gameState = GameState.GameOver;
                        hero.TimesDied = 0;
                        hero.TooManyDeaths = false;
                    }
                    break;
                case GameState.level1:
                    hero.Update(gameTime);

                    level1.CheckForCollision(gameTime, hero, Content);
                    camera.Follow(hero.Position);
                    if (level1.LevelEnd)
                    {
                        hero.TimesDied = 0;
                        hero.Relocate();
                        level2.ReturnEnemiesToPlaces();
                        gameState = GameState.level2;
                        
                    }
                    if (hero.TooManyDeaths)
                    {
                        gameState = GameState.GameOver;
                        hero.TimesDied = 0;
                        hero.TooManyDeaths = false;
                    }
                    break;
                case GameState.level2:
                    hero.Update(gameTime);
                    level2.CheckForCollision(gameTime, hero, Content);
                    camera.Follow(hero.Position);
                    if (level2.LevelEnd)
                    {
                        gameState = GameState.GameWon;

                    }
                    if (hero.TooManyDeaths)
                    {
                        gameState = GameState.GameOver;
                        hero.TimesDied = 0;
                        hero.TooManyDeaths = false;
                    }
                    break;
                case GameState.GameOver:
                    camera.Follow(center);
                    keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.R))
                    {
                        level1.ReturnEnemiesToPlaces();
                        gameState = GameState.level1;
                    }
                    if (keyState.IsKeyDown(Keys.M))
                    {
                        gameState = GameState.Menu;
                    }
                    break;
                case GameState.GameWon:
                    camera.Follow(center);
                    keyState = Keyboard.GetState();
                    if (keyState.IsKeyDown(Keys.R))
                    {
                        level1.ReturnEnemiesToPlaces();
                        gameState = GameState.level1;
                    }
                    if (keyState.IsKeyDown(Keys.M))
                    {
                        gameState = GameState.Menu;
                        //Hier dingen zetten die nu moeten laden (slechts 1x)
                    }
                    break;
                default:
                    break;
            }
            base.Update(gameTime);
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
                    spriteBatch.Begin();
                    spriteBatch.Draw(menuImage, mainFrame, Color.Beige);
                    spriteBatch.End();
                    break;
                case GameState.Beginner:
                    spriteBatch.Begin(transformMatrix: camera.Transform);
                    levelBeginner.DrawWorld(spriteBatch);
                    hero.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case GameState.level1:
                    spriteBatch.Begin(transformMatrix: camera.Transform);
                    level1.DrawWorld(spriteBatch);
                    hero.Draw(spriteBatch);

                    spriteBatch.End();
                    break;
                case GameState.level2:
                    spriteBatch.Begin(transformMatrix: camera.Transform);
                    level2.DrawWorld(spriteBatch);
                    hero.Draw(spriteBatch);

                    spriteBatch.End();
                    break;
                case GameState.GameWon:
                    spriteBatch.Begin(transformMatrix: camera.Transform);

                    spriteBatch.Draw(wonImage, mainFrame, Color.AliceBlue);
                    spriteBatch.End();
                    break;
                case GameState.GameOver:
                    spriteBatch.Begin(transformMatrix: camera.Transform);

                    spriteBatch.Draw(diedImage, mainFrame, Color.AliceBlue);
                    spriteBatch.End();
                    break;
                default:
                    break;
            }

            
            //currentState.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
