﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AppHack6
{
	public class Block
	{
		private Texture2D texture = null;
		private Vector2 size;
		private Vector2 location;
		private Color color;

		//Speed is pixels per second.
		private int fallSpeed;
		private int leftOverTime = 0;

		public Block(int x, int y, int width, int height, Color color, int fallSpeed)
		{
			size = new Vector2(width, height);
			location = new Vector2(x, y);
			this.color = color;
			this.fallSpeed = (1000/fallSpeed);
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

		public void Draw(GraphicsDeviceManager g, SpriteBatch spriteBatch)
		{
			if (texture == null)
			{
				CreateTexture((int)size.X, (int)size.Y, g);
			}
			
			spriteBatch.Draw(texture, location, color);
		}

		public void Update(GameTime gt)
		{
			int dropAmount = (gt.ElapsedGameTime.Milliseconds + leftOverTime)/fallSpeed;
			leftOverTime = gt.ElapsedGameTime.Milliseconds % fallSpeed;

			Console.WriteLine("Update called: " + dropAmount);

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