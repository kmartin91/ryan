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
        

        Sprite mBackgroundOne;
        Sprite mBackgroundTwo;
       
        Sprite alex;
        RenderTarget2D backgroundRender;

       // private Texture2D _alex;
       
        public GameFunc()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Allow resizing
            /*this.Window.AllowUserResizing = true;
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);*/
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
            //Window_ClientSizeChanged(null, null);

            mBackgroundOne = new Sprite();
            mBackgroundOne.Scale = 0.4f;
            mBackgroundTwo = new Sprite();
            mBackgroundTwo.Scale = 0.4f;
           

            alex = new Sprite();
           // alex.Scale = 0.03f;

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

           // _alex = Content.Load<Texture2D>("alex-kidd");
            alex.LoadContent(this.Content, "sprite");
            alex.Position = new Vector2(10, 396);

            //backgroundRender = new RenderTarget2D(graphics.GraphicsDevice, alex.Size.Width +100,alex.Size.Width + 100, 1, SurfaceFormat.Color);

            mBackgroundOne.LoadContent(this.Content, "world");
            mBackgroundOne.Position = new Vector2(0, 0);

            mBackgroundTwo.LoadContent(this.Content, "world");
            mBackgroundTwo.Position = new Vector2(mBackgroundOne.Position.X + mBackgroundOne.Size.Width, 0);
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
           if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //Code for Keyboard



            if (mBackgroundOne.Position.X < -mBackgroundOne.Size.Width)
                mBackgroundOne.Position.X = mBackgroundTwo.Position.X + mBackgroundTwo.Size.Width;
            if (mBackgroundTwo.Position.X < -mBackgroundTwo.Size.Width)
                mBackgroundTwo.Position.X = mBackgroundOne.Position.X + mBackgroundOne.Size.Width;
           

            Vector2 aDirection = new Vector2(-1, 0);
            Vector2 bDirection = new Vector2(1, 0);
            Vector2 aSpeed = new Vector2(60, 0);

            KeyboardState aCurrentKeyboardState = Keyboard.GetState();
            MouseState aCurrentMouseState = Mouse.GetState();
            alex.Update(aCurrentMouseState, aCurrentKeyboardState, gameTime);
            if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true && aCurrentKeyboardState.IsKeyDown(Keys.Left) == false)
            {

                mBackgroundOne.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                mBackgroundTwo.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            base.Update(gameTime);
        }

       /* void Window_ClientSizeChanged(object sender, EventArgs e)
        {
        }*/

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();


            mBackgroundOne.Draw(this.spriteBatch);
            mBackgroundTwo.Draw(this.spriteBatch);
            alex.DrawPerso(this.spriteBatch);
            //alex.Draw(this.spriteBatch,new Rectangle(0,0, 30,30));
            spriteBatch.End();

 
            //spriteBatch.Draw(_alex, _alexBasePos,null, Color.White, MathHelper.ToRadians(_rotation), new Vector2(_alex.Width / 2, _alex.Height / 2), 0.07f, SpriteEffects.None, 0);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
