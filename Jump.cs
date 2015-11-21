using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AppHack6;

namespace JumpGame
{
    public class Jump : Game
    {
		private const int SCREENWIDTH = 1024;
		private const int SCREENHEIGHT = 768;
		private const bool FULLSCREEN = false;
        GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		private Block block;
        public SpriteBatch batch;
        
        public Jump()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = SCREENWIDTH;
            graphics.PreferredBackBufferHeight = SCREENHEIGHT;
            
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
			spriteBatch = new SpriteBatch (GraphicsDevice);
			block = new Block(0, 0, 100, 200, Color.Blue, 20);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

			block.Update(gt);

            base.Update(gt);
        }

        protected override void Draw(GameTime gt)
        {
            GraphicsDevice.Clear(Color.HotPink);


			spriteBatch.Begin();
			block.Draw(graphics, spriteBatch);
			spriteBatch.End();

            base.Draw(gt);
        }
        
        public static void Main()
        {
            System.Console.WriteLine("Test");
            try
            {
                using (Jump game = new Jump())
                    game.Run();
            }catch (EntryPointNotFoundException e)
            {
            }
        }
    }

    public class KeyboardStateEventArgs : EventArgs {
		public KeyboardStateEventArgs(KeyboardState state) : base()
		{
			keyState = state;
		}
		public KeyboardState keyState { get; set;}
	}
}