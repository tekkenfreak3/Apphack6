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
        private int ticks;
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

            if (this.ticks % 150 == 0)
            {
                
                Block b1 = new Block(game, this, new Rectangle(0, -30, rng.Next(1024 - 32), 24), Color.RoyalBlue, 50);
                Block b2 = new Block(game, this, new Rectangle(b1.rect.X + b1.rect.Width + 48, -30, 1024, 24), Color.RoyalBlue, 50);

                b1.SetPartner(b2);
                this.blocks.Add(b1);
                this.blocks.Add(b2);
                this.game.Components.Add(b1);
                this.game.Components.Add(b2);
            }
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }
   } 
}