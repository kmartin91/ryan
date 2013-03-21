using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ryan
{
    interface Sprite
    {
        void Draw(SpriteBatch theSpriteBatch);
        void Update(MouseState mouse, KeyboardState keyboard,GamePadState gamePad, GameTime gameTime);
        void LoadContent(ContentManager theContentManager, string theAssetName);
    }
}
