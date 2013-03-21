using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ryan
{
    class SpriteObject
    {
        private Texture2D mSpriteTexture;
        //public Rectangle Size,Position;
        public float scale;
        public int /*positionX, positionY,*/frameLigne,frameColone;
        public string theAssetName;

        public SpriteObject(string name,float scale)
        {
            /*this.positionX = positionX;
            this.positionY = positionY;*/
            this.theAssetName = name;
            this.frameColone = 1;
            this.frameLigne = 1;
            this.scale = scale;
            switch (this.theAssetName)
            {
                case "Objet1":
                    this.frameLigne = 1;
                    this.frameColone = 1;
                    break;
                case "Objet2":
                    this.frameLigne = 1;
                    this.frameColone = 2;
                    break;
                case "Objet3":
                    this.frameLigne = 1;
                    this.frameColone = 3;
                    break;
                default:
                    this.frameColone = 1;
                    this.frameLigne = 2;
                    break;
            }
        }
        public void LoadContent(ContentManager theContentManager)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>("sprite-objet");
           
        }
        public void Update(MouseState mouse, KeyboardState keyboard, GameTime gameTime)
        {
           
        }
        public void Draw(SpriteBatch theSpriteBatch,int positionX,int positionY)
        {
            theSpriteBatch.Draw(mSpriteTexture, new Rectangle(positionX, positionY, 60 * (int)this.scale, 60 * (int)this.scale), new Rectangle((this.frameColone - 1) * 60, (this.frameLigne - 1) * 60, 60, 60), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }
    }
}
