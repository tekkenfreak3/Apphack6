using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AppHack6;

namespace JumpGame
{

    public delegate void KeyboardStateEventHandler(KeyboardStateEventArgs e);
    
    public class Jump : Game
    {
		private const int SCREENWIDTH = 1024;
		private const int SCREENHEIGHT = 768;
		private const bool FULLSCREEN = false;
        GraphicsDeviceManager graphics;
		private Block block;
        private Player player;
        public SpriteBatch batch;

        public KeyboardStateEventHandler KeyboardEvent;
        
        public Jump()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = SCREENWIDTH;
            graphics.PreferredBackBufferHeight = SCREENHEIGHT;
            
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
			block = new Block(0, 0, 100, 200, Color.Blue, 20);
            player = new Player(this, new Rectangle(512, 384, 32, 32));
            this.Components.Add(player);
            this.Components.Add(block);
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
			block.Update(gt);

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
