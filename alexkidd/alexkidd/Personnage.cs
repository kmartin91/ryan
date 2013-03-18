using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace alexkidd
{
    //public enum Direction
    //{
    //    Up,Left,Right
    //};
    class Personnage
    {
        Rectangle Hitbox;
        Direction direction;
        int FrameLine, FrameColone;
        public Personnage()
        {
            this.Hitbox = new Rectangle(0, 0, 30, 0);
        }
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if(keyboard.IsKeyDown(Keys.Left))
            {
                this.direction = Direction.Left;
            }
            switch (direction)
            {
                case Direction.Left: this.FrameLine = 1; this.FrameColone = 2; break;
                default: break;
            }
        }
        /*public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, new Rectangle(0,392,30,30),
                new Rectangle((this.FrameLine-1)*30,(this.FrameColone-1)*30,0, 0), Color.White,
                0.0f, Vector2.Zero, 0.0f, SpriteEffects.None, 0);
        }*/
    }
}
