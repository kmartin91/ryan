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

namespace ryan
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameFunc : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Map mBackgroundTwo;
        Map mBackgroundThree;
        Map mBackgroundOne;

        SpriteObject objet1, objet2, objet3;

        Ryan ryan;



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
            // Window_ClientSizeChanged(null, null);

          /*  mBackgroundTwo = new Map();
            mBackgroundTwo.Scale = 0.4f;
            mBackgroundThree = new Map();
            mBackgroundThree.Scale = 0.4f;
            mBackgroundOne = new Map();
            mBackgroundOne.Scale = 0.4f;*/

            ryan = new Ryan(1.0f);

            objet1 = new SpriteObject("Objet1", 1.0f);
            objet2 = new SpriteObject("Objet2", 1.0f);
            objet3 = new SpriteObject("Objet3", 1.0f);
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
            ryan.LoadContent(this.Content, "sprite");
            //ryan.Position = new Vector2(10, 370);

            //backgroundRender = new RenderTarget2D(graphics.GraphicsDevice, alex.Size.Width +100,alex.Size.Width + 100, 1, SurfaceFormat.Color);

          /*  mBackgroundTwo.LoadContent(this.Content, "world");
            mBackgroundTwo.Position = new Vector2(0, 0);

            mBackgroundThree.LoadContent(this.Content, "world");
            mBackgroundThree.Position = new Vector2(mBackgroundTwo.Position.X + mBackgroundTwo.Size.Width, 0);

            mBackgroundOne.LoadContent(this.Content, "world");
            mBackgroundOne.Position = new Vector2(mBackgroundTwo.Position.X - mBackgroundTwo.Size.Width, 0);*/

            objet1.LoadContent(this.Content);
            objet2.LoadContent(this.Content);
            objet3.LoadContent(this.Content);
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
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();
            MouseState aCurrentMouseState = Mouse.GetState();
            GamePadState aCurrentGamePad = GamePad.GetState(PlayerIndex.One);
            ryan.Update(aCurrentMouseState, aCurrentKeyboardState, aCurrentGamePad,gameTime);





            /*Vector2 aDirection = new Vector2(-1, 0);

            Vector2 aSpeed = new Vector2(100, 0);


            if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true && aCurrentKeyboardState.IsKeyDown(Keys.Left) == false)
            {
                if (mBackgroundTwo.Position.X < -mBackgroundTwo.Size.Width)
                    mBackgroundTwo.Position.X = mBackgroundOne.Position.X + mBackgroundOne.Size.Width;
                if (mBackgroundThree.Position.X < -mBackgroundThree.Size.Width)
                    mBackgroundThree.Position.X = mBackgroundTwo.Position.X + mBackgroundTwo.Size.Width;
                if (mBackgroundOne.Position.X < -mBackgroundOne.Size.Width)
                    mBackgroundOne.Position.X = mBackgroundThree.Position.X + mBackgroundThree.Size.Width;
                mBackgroundTwo.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                mBackgroundThree.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                mBackgroundOne.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true && aCurrentKeyboardState.IsKeyDown(Keys.Right) == false)
            {
                if (mBackgroundTwo.Position.X > (mBackgroundTwo.Size.Width + mBackgroundTwo.Size.Width))
                    mBackgroundTwo.Position.X = mBackgroundThree.Position.X - mBackgroundTwo.Size.Width;
                if (mBackgroundThree.Position.X > (mBackgroundTwo.Size.Width + mBackgroundTwo.Size.Width))
                    mBackgroundThree.Position.X = mBackgroundOne.Position.X - mBackgroundThree.Size.Width;
                if (mBackgroundOne.Position.X > (mBackgroundTwo.Size.Width + mBackgroundTwo.Size.Width))
                    mBackgroundOne.Position.X = mBackgroundTwo.Position.X - mBackgroundOne.Size.Width;

                mBackgroundTwo.Position -= aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                mBackgroundThree.Position -= aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                mBackgroundOne.Position -= aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }*/


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


           /* mBackgroundTwo.Draw(this.spriteBatch);
            mBackgroundThree.Draw(this.spriteBatch);
            mBackgroundOne.Draw(this.spriteBatch);*/
            ryan.Draw(this.spriteBatch);




            //Generation aléatoire map

           /* objet1.Draw(this.spriteBatch, 10, 376);
            objet2.Draw(this.spriteBatch, 200, 376);
            objet1.Draw(this.spriteBatch, 120, 376);
            objet2.Draw(this.spriteBatch, 190, 376);
            objet3.Draw(this.spriteBatch, 3000, 376);
            objet3.Draw(this.spriteBatch, 240, 376);
            */
            spriteBatch.End();


            //spriteBatch.Draw(_alex, _alexBasePos,null, Color.White, MathHelper.ToRadians(_rotation), new Vector2(_alex.Width / 2, _alex.Height / 2), 0.07f, SpriteEffects.None, 0);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
