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
        }

        protected override void LoadContent()
        {
            System.Console.WriteLine("\n\n\n\nCONTENT LOADED RIGHT NOW\n\n\n\n");
            this.tex = this.game.Content.Load<Texture2D>("Player");
            if (this.tex == null)
            {
                System.Console.WriteLine("The fuck? No texture loaded");
                System.Environment.Exit(1);
            }
            else
            {
                System.Console.WriteLine("Texture loaded?" + this.tex);
            }
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
        }

        public override void Update(GameTime gt)
        {

            // collision detection here
            
            this.rect.X += this.xSpeed;
            this.rect.Y += this.ySpeed;
        }
    }
}