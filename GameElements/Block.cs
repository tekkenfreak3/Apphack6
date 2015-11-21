using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace JumpGame
{
	public class Block : JumpSprite
	{
		private Color color;

		//Speed is pixels per second.
		private int xSpeed = 0;
	    private int ySpeed = 0;
		private int leftOverTimeX = 0;
		private int leftOverTimeY = 0;
        
		public Block(Jump game, ILevel level, Rectangle blockRect, Color color, int ySpeed) : base(game)
		{
			this.game = game;
			this.rect = blockRect;
			this.color = color;
			this.ySpeed = ySpeed == 0 ? 0 : (1000 / ySpeed);
            this.level = level;
		}

		public Block(Jump game, ILevel level, Rectangle blockRect, Color color, int xSpeed, int ySpeed) : base(game)
		{
			this.game = game;
			this.rect = blockRect;
			this.color = color;
			this.xSpeed = xSpeed == 0 ? 0 : (1000 / xSpeed);
			this.ySpeed = ySpeed == 0 ? 0 : (1000 / ySpeed);
            this.level = level;
		}

		public bool Hit
		{
			get;
			set;
		}

		protected override void LoadContent()
		{
			CreateTexture(rect.Width, rect.Height, game.graphics);
		}

		public override void Update(GameTime gt)
		{
			CalculateAndMoveX(gt);
			CalculateAndMoveY(gt);

			if (rect.Y > game.graphics.PreferredBackBufferHeight || rect.X > game.graphics.PreferredBackBufferHeight)
			{
				game.Components.Remove(this);
                level.GetBlocks().Remove(this);
			}
		}

		public int GetXSpeed(GameTime gt)
		{
			int totalTime = (gt.ElapsedGameTime.Milliseconds + leftOverTimeX);
			return totalTime / xSpeed;
		}

		public int GetYSpeed(GameTime gt)
		{
			int totalTime = (gt.ElapsedGameTime.Milliseconds + leftOverTimeY);
			return totalTime / ySpeed;
		}

		private void CalculateAndMoveX(GameTime gt)
		{
			if (xSpeed == 0)
				return;
			
			int totalTime = (gt.ElapsedGameTime.Milliseconds + leftOverTimeX);
			int dropAmount = totalTime / xSpeed;

			leftOverTimeX = totalTime % xSpeed;
			rect = new Rectangle(rect.X + dropAmount, rect.Y, rect.Width, rect.Height);
		}

		private void CalculateAndMoveY(GameTime gt)
		{
			if (ySpeed == 0)
				return;
			
			int totalTime = (gt.ElapsedGameTime.Milliseconds + leftOverTimeY);
			int dropAmount = totalTime / ySpeed;

			leftOverTimeY = totalTime % ySpeed;
			rect = new Rectangle(rect.X, rect.Y + dropAmount, rect.Width, rect.Height);
		}

		private void CreateTexture(int width, int height, GraphicsDeviceManager g)
		{
			tex = new Texture2D(g.GraphicsDevice, width, height);
			Color[] data = new Color[width*height];

			for (int i = 0; i < data.Length; ++i)
			{
				data [i] = color;
			}

			tex.SetData(data);
		}
	}
}
