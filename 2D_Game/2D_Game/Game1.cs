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
        Enemies enemy;
        Camera camera;

        public static int screenWidth;
        public static int screenHeight;

        private Texture2D myBackground;
        private Rectangle mainFrame;

        Level1 level;

        enum GameState
        {
            StartMenu,
            Controls,
            Loading,
            Playing,
            Paused
        }
        GameState gameState;

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

            enemy = new Enemies(Content.Load<Texture2D>("HeroSprites/Jumping"), new Vector2(200, 100), 150);

            myBackground = Content.Load<Texture2D>("png/BG");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            level = new Level1(Content, hero, enemy);
            level.CreateLevel(Content);

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

            //if (nextState != null)
            //{
            //    currentState = nextState;
            //    nextState = null;

            //}
            //currentState.Update(gameTime, spriteBatch);
            //currentState.PostUpdate(gameTime);
            hero.Update(gameTime);
            enemy.Update(gameTime);
            level.CheckForCollision(gameTime, hero, enemy);
            camera.Follow(hero.Position);
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

            spriteBatch.Begin(transformMatrix: camera.Transform);

            level.DrawWorld(spriteBatch);
            enemy.Draw(spriteBatch);
            hero.Draw(spriteBatch);

            spriteBatch.End();
            //currentState.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
