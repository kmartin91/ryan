using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ryan
{
    public enum Direction
    {
        Left, Right, Up, None, Shoot, Jump
    };
    class Ryan: Sprite
    {
        public const float FREQUENCY_MOVEMENT = 100f;
        public const float FREQUENCY_SHOOT = 50f;
        public const int IMPULSION_MIN = 50;
        public const int IMPULSION_MAX = 55;

        private bool enableShoot, enableJump, jumpUp;
        private Direction direction;
        public float freqMove, freqShoot, scale;
        public int frameColone, frameLigne, gravity, impulsion, ground, hightRyanBox;
        public Rectangle Size, ryanBox;
        public SpriteEffects effetMirroir;
        private Texture2D mSpriteTexture;

        public Ryan(float Scale)
        {
            this.freqMove = FREQUENCY_MOVEMENT;
            this.freqShoot = FREQUENCY_SHOOT;
            this.impulsion = IMPULSION_MIN;
            this.frameColone = 1;
            this.frameLigne = 1;
            this.effetMirroir = SpriteEffects.None;
            this.scale = Scale;
            this.ground = 380;
            this.hightRyanBox = this.ground;
            this.ryanBox = new Rectangle(300, this.hightRyanBox, 60 * (int)this.scale, 60 * (int)this.scale);
            this.enableShoot = false;
            this.enableJump = false;
            this.gravity = 1;
        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * scale), (int)(mSpriteTexture.Height * scale));
        }

        public void Update(MouseState mouse, KeyboardState keyboard,GamePadState gamePad, GameTime gameTime)
        {
            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.direction = Direction.Right;
                SetDirection(true);
            }
            if (keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Left))
            {
                this.direction = Direction.None;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                this.direction = Direction.Left;
                SetDirection(false);
            }
            if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyDown(Keys.Left))
            {
                this.direction = Direction.None;
            }
            if (keyboard.IsKeyDown(Keys.E))
            {
                this.enableShoot = true;
            }
            if (keyboard.IsKeyDown(Keys.Space) && this.enableJump == false)
            {
                this.jumpUp = true;
                this.enableJump = true;
            }

            if (keyboard.IsKeyDown(Keys.Space) && this.jumpUp == true)
            {
                this.impulsion = this.impulsion + 1;
            }
            else
            {
                this.jumpUp = false;
            }

            if (this.enableShoot == true)
            {
                this.direction = Direction.Shoot;
            }
            if (this.enableJump == true)
            {
                this.direction = Direction.Jump;
            }

            switch (this.direction)
            {
                case Direction.Right:
                    if (this.frameColone == 1)
                    {
                        this.frameColone = 2;
                    }

                    freqMove -= gameTime.ElapsedGameTime.Milliseconds;
                    if (freqMove < 0f)
                    {

                        if (this.frameColone == 3)
                        {
                            this.frameColone = 2;
                        }
                        else if (this.frameColone == 2)
                        {
                            this.frameColone = 3;
                        }
                        this.freqMove = FREQUENCY_MOVEMENT;
                    }

                    this.frameLigne = 1;
                    break;
                case Direction.Left:
                    if (this.frameColone == 1)
                    {
                        this.frameColone = 2;
                    }

                    freqMove -= gameTime.ElapsedGameTime.Milliseconds;
                    if (freqMove < 0f)
                    {

                        if (this.frameColone == 3)
                        {
                            this.frameColone = 2;
                        }
                        else if (this.frameColone == 2)
                        {
                            this.frameColone = 3;
                        }
                        this.freqMove = FREQUENCY_MOVEMENT;
                    }

                    this.frameLigne = 1;
                    break;
                case Direction.None:

                    this.frameColone = 1; this.frameLigne = 1;
                    break;
                default:
                    break;
            }

            if (this.enableJump == true)
            {
                if (this.enableShoot == false)
                {
                    this.frameColone = 2;
                    this.frameLigne = 3;
                }

                if (this.jumpUp == false)
                {
                    this.impulsion = this.impulsion - (this.gravity * 4);
                }

                this.hightRyanBox = this.hightRyanBox - (this.impulsion / 4);

                if (this.impulsion < IMPULSION_MIN)
                {
                    this.jumpUp = false;
                }
                if (this.impulsion > IMPULSION_MAX)
                {
                    this.jumpUp = false;
                }

                if (this.hightRyanBox > this.ground)
                {
                    this.enableJump = false;
                    this.hightRyanBox = this.ground;
                    this.impulsion = IMPULSION_MIN;
                }
                this.ryanBox = new Rectangle(300, this.hightRyanBox, 60 * (int)this.scale, 60 * (int)this.scale);
            }

            if (this.enableShoot == true)
            {
                freqShoot -= gameTime.ElapsedGameTime.Milliseconds;

                if (freqShoot < 0f)
                {
                    if (this.frameColone == 1 && this.frameLigne == 1)
                    {
                        this.frameColone = 1;
                        this.frameLigne = 2;
                    }
                    else if (this.frameColone == 1 && this.frameLigne == 2)
                    {
                        this.frameColone = 2;
                        this.frameLigne = 2;
                    }
                    else if (this.frameColone == 2 && this.frameLigne == 2)
                    {
                        this.frameColone = 3;
                        this.frameLigne = 2;
                    }
                    else if (this.frameColone == 3 && this.frameLigne == 2)
                    {
                        this.frameColone = 1;
                        this.frameLigne = 3;
                    }
                    else if (this.frameColone == 1 && this.frameLigne == 3)
                    {
                        this.frameColone = 1;
                        this.frameLigne = 1;
                        this.enableShoot = false;
                    }
                    else
                    {
                        this.frameColone = 1;
                        this.frameLigne = 1;
                    }
                    this.freqShoot = FREQUENCY_SHOOT;
                }
            }
        }

        public void SetDirection(bool directionRight)
        {
            if (directionRight == true)
            {
                this.effetMirroir = SpriteEffects.None;
            }
            else
            {
                this.effetMirroir = SpriteEffects.FlipHorizontally;
            }
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mSpriteTexture, this.ryanBox, new Rectangle((this.frameColone - 1) * 60, (this.frameLigne - 1) * 60, 60, 60), Color.White, 0f, Vector2.Zero, this.effetMirroir, 0f);

        }

    }
}
