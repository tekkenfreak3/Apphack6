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
        
        public override void Draw(GameTime gt)
        {
            SpriteBatch sprite = this.game.SpriteBatch;
            sprite.Begin();
            Sprite.Draw(texture, position, color: Color.White, rotation: direction, origin: rotOrigin, effect: SpriteEffects.None, depth: 0);
            Sprite.End()
        }
    }
}