using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JumpGame
{

    public delegate void KeyboardStateEventHandler(KeyboardStateEventArgs e);
    
    public class Jump : Game
    {
		private const int SCREENWIDTH = 1024;
		private const int SCREENHEIGHT = 768;
		private const bool FULLSCREEN = false;

        public List<Block> blocks;
        
        public GraphicsDeviceManager graphics;
        private Player player;
        public SpriteBatch batch;

        public KeyboardStateEventHandler KeyboardEvent;
        
        public Jump()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = SCREENWIDTH;
            graphics.PreferredBackBufferHeight = SCREENHEIGHT;
            this.blocks = new List<Block>();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
			Block block = new Block(this, new Rectangle(100, 0, 100, 200), Color.Blue, 20);
            player = new Player(this, new Rectangle(512, 384, 32, 32));
            this.Components.Add(player);
            this.Components.Add(block);
            this.blocks.Add(block);
            base.Initialize();

        }

        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }


        protected virtual void OnKeyboard(KeyboardStateEventArgs args)
		{
			if (KeyboardEvent != null)
				KeyboardEvent (args);
		}
        
        protected override void Update(GameTime gt)
        {
            KeyboardState keystate = Keyboard.GetState ();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            
            OnKeyboard (new KeyboardStateEventArgs(keystate));

            base.Update(gt);
        }

        protected override void Draw(GameTime gt)
        {
            GraphicsDevice.Clear(Color.HotPink);


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
