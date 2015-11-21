using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Keyboard;


namespace JumpGame
{
    public class Player : JumpSprite
    {
        private int xSpeed, ySpeed;
        private bool ground;
        public Player(Jump game, Rectangle rect) : base(game)
        {
            this.game = game;
            this.rect = rect;

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
                this.ySpeed = -5;
            }
            else if (st.IsKeyDown(Keys.Down))
            {
                this.ySpeed = 5;
            }
            else
            {
                this.ySpeed = 0;
            }
        }

        public override void Update(GameTime gt)
        {
            // collision detection here

            foreach (Block b in this.game.blocks)
            {
                System.Console.WriteLine("There's a block");
            }
            this.rect.X += this.xSpeed;
            this.rect.Y += this.ySpeed;
        }
    }
}