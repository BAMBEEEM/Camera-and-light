using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Camera_and_light
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // A collection of crates
        Crate[] crates;

        // The camera 
        CirclingCamera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here

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

            // initialize the crate 
            // Make some crates
            crates = new Crate[] {
        new Crate(this, CrateType.DarkCross, Matrix.Identity),
        new Crate(this, CrateType.Slats, Matrix.CreateTranslation(4, 0, 5)),
        new Crate(this, CrateType.Cross, Matrix.CreateTranslation(-8, 0, 3)),
        new Crate(this, CrateType.DarkCross, Matrix.CreateRotationY(MathHelper.PiOver4) * Matrix.CreateTranslation(1, 0, 7)),
        new Crate(this, CrateType.Slats, Matrix.CreateTranslation(3, 0, -3)),
        new Crate(this, CrateType.Cross, Matrix.CreateRotationY(3) * Matrix.CreateTranslation(3, 2, -3))
    };            // TODO: use this.Content to load your game content here

            // Initialize the camera 
            camera = new CirclingCamera(this, new Vector3(0, 5, 10), 0.5f);
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

            // TODO: Add your update logic here

            // Update the camera 
            camera.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // Draw some crates
            foreach (Crate crate in crates)
            {
                crate.Draw(camera);
            }
            base.Draw(gameTime);
        }
    }
}
