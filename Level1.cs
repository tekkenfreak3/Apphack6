using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JumpGame
{
    public class Level1 : ILevel
    {
        List<Block> blocks;
        Player player;
        Jump game;
        public Level1(Jump game)
        {
            this.game = game;
        }

        public Init()
        {
            this.player = new Player(game, new Rectangle(512, 16, 32, 32));
            game.Component.Add(player);

            Block floor = new Block(game, new Rectangle(0, 64, Color.RoyalPurple, ));
        }
   } 
}