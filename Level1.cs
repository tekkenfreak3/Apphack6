using System;
using System.Collections.Generic;
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
        private int points;
        private long int ticks;
        private int speed;
        private Random rng;
        
        public Level1(Jump game)
        {
            this.game = game;
            this.blocks = new List<Block>();
            this.speed = 4;
            this.rng = new Random();
        }

        public void Init()
        {
            this.player = new Player(game, this, new Rectangle(512, 16, 32, 32));
            game.Components.Add(player);

            Block floor = new Block(game, this, new Rectangle(0, 64, 1024, 32), Color.RoyalBlue, 50);
            blocks.Add(floor);
            game.Components.Add(floor);
        }

        public List<Block> GetBlocks()
        {
            return blocks;
        }
        
        public void Tick()
        {
            this.ticks++;

            if (this.ticks % 150)
            {
                
                Block b1 = new Block(game, this, new Rectangle(0, -30, rng.Next(1024 - 32), 24), )
            }
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }
   } 
}