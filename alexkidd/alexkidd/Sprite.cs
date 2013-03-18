using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace alexkidd
{
    public enum Direction
    {
        Left,Right,Up,None
    };
    class Sprite
    {
        public float T1 = 200f;
        public float lastAppel = 0f;
        public Vector2 Position = new Vector2(0, 0);
        private Texture2D mSpriteTexture;
        public Rectangle Size;
        public float Scale = 1.0f;
        private bool _active;
        public int FrameColone, FrameLigne;
        private Direction direction;
        public SpriteEffects effetMirroir;
        public Rectangle hitBox;
        public Sprite()
        {
            this.FrameColone = 1;
            this.FrameLigne = 1;
            this.effetMirroir = SpriteEffects.None;
            this.hitBox = new Rectangle(300, 396, 30, 30);
        }
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }

        public void Update(MouseState mouse, KeyboardState keyboard, GameTime gameTime)
        {
            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.direction = Direction.Right;
            }
            if (keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Left))
            {
                this.direction = Direction.None;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                this.direction = Direction.Left;
            }
            if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyDown(Keys.Left))
            {
                this.direction = Direction.None;
            }
            switch (this.direction)
            {
                case Direction.Right:
                    this.effetMirroir = SpriteEffects.None;
                    if (this.FrameColone == 1)
                    {
                        this.FrameColone = 2;
                    }

                    T1 -= gameTime.ElapsedGameTime.Milliseconds;
                    if (T1 < 0f)
                    {
                        
                        if (this.FrameColone == 3)
                        {
                            this.FrameColone = 2;
                        }
                        else if (this.FrameColone == 2)
                        {
                            this.FrameColone = 3;
                        }
                        this.T1 = 200f;
                    }

                    this.FrameLigne = 1;
                    break;
                case Direction.Left:
                    this.effetMirroir = SpriteEffects.FlipHorizontally;
                     if (this.FrameColone == 1)
                    {
                        this.FrameColone = 2;
                    }

                    T1 -= gameTime.ElapsedGameTime.Milliseconds;
                    if (T1 < 0f)
                    {
                        
                        if (this.FrameColone == 3)
                        {
                            this.FrameColone = 2;
                        }
                        else if (this.FrameColone == 2)
                        {
                            this.FrameColone = 3;
                        }
                        this.T1 = 200f;
                    }

                    this.FrameLigne = 1;
                    break;
                case Direction.None: 
                    
                    this.FrameColone = 1; this.FrameLigne = 1;
                    break;
                default: this.FrameColone = 1; this.FrameLigne = 1;
                    break;
            }
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position,
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height), Color.White,
                0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public void DrawPerso(SpriteBatch theSpriteBatch)
        {
            //theSpriteBatch.Draw(mSpriteTexture, Position, new Rectangle((this.FrameColone - 1) * 30, (this.FrameLigne - 1) * 30, 30, 30), Color.White);
            theSpriteBatch.Draw(mSpriteTexture, this.hitBox, new Rectangle((this.FrameColone - 1) * 30, (this.FrameLigne - 1) * 30, 30, 30), Color.White, 0f, Vector2.Zero, this.effetMirroir, 0f);
            
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
    }
}
