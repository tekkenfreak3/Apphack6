using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace JumpGame
{
    public abstract class JumpSprite : DrawableGameComponent
    {
        protected Texture2D tex;
        protected Rectangle rect;

        protected Vector2 origin;
        protected float direction;
        
        protected Jump game;

        public JumpSprite(Jump game) : base(game)
        {
        }
        
        public override void Draw(GameTime gt)
        {
            Vector2 position = new Vector2((int)rect.X, (int)rect.Y);

            System.Console.WriteLine("TEXTURE: " + this.tex);
            SpriteBatch sprite = this.game.batch;
            sprite.Begin();
            sprite.Draw (tex, position, Color.White);
            sprite.End();
        }

        protected bool Collides(JumpSprite other)
        {
            // my x, my y, etc
            int mx = this.rect.X;
            int my = this.rect.Y;
            int mx2 = this.rect.X + this.rect.Width;
            int my2 = this.rect.Y + this.rect.Height;

            int ox = other.rect.X;
            int oy = other.rect.Y;
            int ox2 = other.rect.X + this.rect.Width;
            int oy2 = other.rect.Y + this.rect.Height;
            
            if ((mx <= ox2 && mx2 >= ox) || (ox <= mx2 && ox2 >= mx))
                {
                    if ((my <= oy2 && my2 >= oy) || (oy <= my2 && oy2 >= my))
                    {
                        return true;
                    }
                }
                return false;
        }
    }
}