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
		private int fallSpeed;
		private int leftOverTime = 0;

		public Block(Jump game, Rectangle blockRect, Color color, int fallSpeed) : base(game)
		{
			this.game = game;
			this.rect = blockRect;
			this.color = color;
			this.fallSpeed = (1000/fallSpeed);
			Console.WriteLine("fallspeed: " + this.fallSpeed);
		}

		public bool DestroyMe
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
			int totalTime = (gt.ElapsedGameTime.Milliseconds + leftOverTime);
			int dropAmount = totalTime / fallSpeed;

			leftOverTime = totalTime % fallSpeed;
			rect = new Rectangle(rect.X, rect.Y + dropAmount, rect.Width, rect.Height);

			if (rect.Y > game.graphics.PreferredBackBufferHeight || rect.X > game.graphics.PreferredBackBufferHeight)
			{
				game.Components.Remove(this);
			}
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
