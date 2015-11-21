using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumpGame
{
	public class Block : JumpSprite
	{
		private Jump game;
		private Texture2D texture = null;
		private Vector2 size;
		private Vector2 location;
		private Color color;

		//Speed is pixels per second.
		private int fallSpeed;
		private int leftOverTime = 0;

		public Block(Jump game, int x, int y, int width, int height, Color color, int fallSpeed) : base(game)
		{
			this.game = game;
			size = new Vector2(width, height);
			location = new Vector2(x, y);
			this.color = color;
			this.fallSpeed = (1000/fallSpeed);
			Console.WriteLine("fallspeed: " + this.fallSpeed);
		}

		public Vector2 Location
		{
			get { return location; }
			set { location = value; }
		}

		public bool DestroyMe
		{
			get;
			set;
		}

		public override void Draw(GameTime ft)
		{
			if (texture == null)
			{
				CreateTexture((int)size.X, (int)size.Y, game.graphics);
			}
			game.batch.Begin();
			game.batch.Draw(texture, location, color);
			game.batch.End();
		}

		public override void Update(GameTime gt)
		{
			int dropAmount = (gt.ElapsedGameTime.Milliseconds + leftOverTime)/fallSpeed;
			leftOverTime = gt.ElapsedGameTime.Milliseconds % fallSpeed;

//			Console.WriteLine("Update called: " + dropAmount + " leftover: " + leftOverTime);

			location = new Vector2(location.X, location.Y + dropAmount);
		}
			

		private void CreateTexture(int width, int height, GraphicsDeviceManager g)
		{
			texture = new Texture2D(g.GraphicsDevice, width, height);
			Color[] data = new Color[width*height];

			for (int i = 0; i < data.Length; ++i)
			{
				data [i] = Color.White;
			}

			texture.SetData(data);
		}
	}
}
