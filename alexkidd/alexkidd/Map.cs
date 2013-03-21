using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace ryan
{
    class Map
    {
        private Texture2D mSpriteObjet,mSpriteFond,mSpriteSol;
        public Rectangle Size;
        public float Scale = 1.0f;
        public Vector2 Position = new Vector2(0, 0);
        public string fondMap;

        public Map(string fondMap)
        {
            this.fondMap = fondMap;
        }
        public void LoadContent(ContentManager theContentManager)
        {
            mSpriteFond = theContentManager.Load<Texture2D>(fondMap);
            mSpriteObjet = theContentManager.Load<Texture2D>("sprite-objet");
            Size = new Rectangle(0, 0, (int)(mSpriteObjet.Width * Scale), (int)(mSpriteObjet.Height * Scale));
        }
        public void Update(MouseState mouse, KeyboardState keyboard, GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            /*theSpriteBatch.Draw(mSpriteTexture, Position,
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height), Color.White,
                0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);*/
        }
    }
}
