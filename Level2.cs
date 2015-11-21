using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JumpGame
{
    public class Level2 : ILevel
    {
        List<Block> blocks;
        Player player;
        Jump game;
        private int points;
        private int ticks;
        private int spawnInterval;
        private int tilNext;
        private int speed;
        private Random rng;
        private SoundEffect music;
        private SoundEffectInstance musicInstance;
        public Level2(Jump game)
        {
            this.game = game;
            this.blocks = new List<Block>();
            this.speed = -64;
            this.rng = new Random();
            this.spawnInterval = 200;
            this.tilNext = this.spawnInterval;
        }

        public void Init()
        {
            this.player = new Player(game, this, new Rectangle(128, 768 - 64, 32, 32));
            game.Components.Add(player);

            Block floor = new Block(game, this, new Rectangle(128, 768 - 32, 48, 1024), Color.RoyalBlue, this.speed, 0);
            blocks.Add(floor);
            game.Components.Add(floor);

            music = this.game.Content.Load<SoundEffect>("bamboo");

            musicInstance = music.CreateInstance();
            musicInstance.IsLooped = true;
            musicInstance.Play();
        }

        public List<Block> GetBlocks()
        {
            return blocks;
        }
        
        public void Tick()
        {
            this.ticks++;

            if (this.tilNext == 0)
            {
                this.tilNext = this.spawnInterval;
            }

            if (this.ticks % (200 * 5) == 0)
            {
                if (this.spawnInterval > 88)
                {
                    this.spawnInterval = (int)(this.spawnInterval * 0.90);
                    Console.WriteLine("Spawn interval is: " + this.spawnInterval);
                }


            }

            this.tilNext--;
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }
   } 
}