using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace alexkidd
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameFunc : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D _alex;
        private Vector2 _alexBasePos;
        private Vector2 _alexNewPos;
        private float _rotation;

        public GameFunc()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _rotation = 0f;
            // Allow resizing
            this.Window.AllowUserResizing = true;
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
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
            Window_ClientSizeChanged(null, null);
           // _alexBasePos = Vector2.One;
            _alexBasePos = new Vector2(50, 50);
            _alexNewPos = Vector2.One;
            //alex = new Alexkidd();
           
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

            // TODO: use this.Content to load your game content here

            _alex = Content.Load<Texture2D>("alex-kidd");
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            this._alex.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
           /* if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();*/

            // TODO: Add your update logic here
            //Code for Keyboard
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.Right))
                _alexBasePos.X += 1;
            if (kbState.IsKeyDown(Keys.Left))
                _alexBasePos.X -= 1;

            //Code for xbox 360 gamepad
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            GamePadCapabilities gamepadCaps = GamePad.GetCapabilities(PlayerIndex.One);
            if (gamepadState.IsConnected)
            {
                if (gamepadCaps.HasLeftXThumbStick)
                {

                }
            }
            base.Update(gameTime);
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

           /* spriteBatch.Begin();
            spriteBatch.Draw(_alex, _alexBasePos,null, Color.White, MathHelper.ToRadians(_rotation), new Vector2(_alex.Width / 2, _alex.Height / 2), 0.07f, SpriteEffects.None, 0);
            spriteBatch.End();*/
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
