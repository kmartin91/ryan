using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace alexkidd
{
    public enum Direction
    {
        Left,Right,Up
    };
    class Sprite
    {
        public Vector2 Position = new Vector2(0, 0);
        private Texture2D mSpriteTexture;
        public Rectangle Size;
        public float Scale = 1.0f;
        private bool _active;
        public int FrameLine,FrameColone;
        private Direction direction;

        public Sprite()
        {
            this.FrameLine = 1;
            this.FrameColone = 1;
        }
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
        }
        public void Update(MouseState mouse, KeyboardState keyboard,GameTime gametime)
        {
            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.direction = Direction.Right;
            }
           
            switch (this.direction)
            {
                case Direction.Right:
                    this.FrameLine = 2;
                    this.FrameColone = 1;
                    break;
                default: this.FrameLine = 1; this.FrameColone = 1;
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
            theSpriteBatch.Draw(mSpriteTexture, Position, new Rectangle((this.FrameLine - 1) * 30, (this.FrameColone - 1) * 30, 30, 30), Color.White);
            
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
    }
}
