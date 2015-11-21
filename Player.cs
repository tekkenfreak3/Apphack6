using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace JumpGame
{
    public class Player : JumpSprite
    {
        private int xSpeed, ySpeed;
        private bool ground;
        public Player(Jump game, ILevel level, Rectangle rect) : base(game)
        {
            this.game = game;
            this.rect = rect;
            this.level = level;
            this.game.KeyboardEvent += KeyboardUpdate;
        }

        protected override void LoadContent()
        {
            this.tex = this.game.Content.Load<Texture2D>("Player");

            this.origin = new Vector2(this.tex.Width / 2, this.tex.Height / 2);
        }

        public void KeyboardUpdate(KeyboardStateEventArgs args)
        {
            KeyboardState st = args.keyState;

            if (st.IsKeyDown(Keys.Left))
            {
                this.xSpeed = -5;
            }
            else if (st.IsKeyDown(Keys.Right))
            {
                this.xSpeed = 5;
            }
            else
            {
                this.xSpeed = 0;
            }

            if (st.IsKeyDown(Keys.Up))
            {
                if (this.ground)
                {
                    this.ySpeed = -24;
                    this.ground = false;
                }
            }
            else if (st.IsKeyDown(Keys.Down))
            {
                this.ySpeed = 5;
            }
        }

        public override void Update(GameTime gt)
        {

            foreach (Block b in this.level.GetBlocks())
            {
                Rectangle other = b.rect;
                
                Rectangle leftRect = new Rectangle(this.rect.X + this.xSpeed, this.rect.Y + 8, 16, this.rect.Height - 16);
                Rectangle rightRect = new Rectangle((this.rect.X + this.rect.Width) + this.xSpeed - 16, this.rect.Y + 8, 16, this.rect.Height - 16);
                Rectangle topRect = new Rectangle(this.rect.X, this.rect.Y + this.ySpeed, this.rect.Width, 16);
                Rectangle bottomRect = new Rectangle(this.rect.X, this.rect.Y  + this.rect.Height + this.ySpeed, this.rect.Width, 16);
                
                if (JumpSprite.RectCollides(rightRect, other))
                {
                    this.rect.X = b.rect.X - this.rect.Width - 1;
                    this.xSpeed = 0;
                }
                else if (JumpSprite.RectCollides(leftRect, other))
                {
                    this.rect.X = b.rect.X + b.rect.Width + 1;
                    this.xSpeed = 0;
                }

                if (JumpSprite.RectCollides(topRect, other))
                {
                    this.rect.Y = b.rect.Y + b.rect.Height + 1;
                    this.ySpeed = 0;
                }
                else if (JumpSprite.RectCollides(bottomRect, other))
                {
                    this.rect.Y = b.rect.Y - this.rect.Height;
                    this.ySpeed = 0;
                    b.Hit();
                    if (!Keyboard.GetState().IsKeyDown(Keys.Up))
                        this.ground = true;
                    
                    this.xSpeed += b.GetXSpeed(gt);
                }
            }

            if (this.rect.Y < 0)
            {
                this.rect.Y = 0;
                this.ySpeed = 0;
            }
            if (this.ySpeed < 24)
                this.ySpeed += 1;
            this.rect.X += this.xSpeed;
            this.rect.Y += this.ySpeed;

            if (this.rect.X > 1024)
            {
                this.rect.X = 0 - this.rect.Width;
            }
            else if (this.rect.X + this.rect.Width < 0)
            {
                this.rect.X = 1024;
            }
        }
    }
}