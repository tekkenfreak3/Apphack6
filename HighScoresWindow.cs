using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace JumpGame
{
	public class HighScoresWindow : DrawableGameComponent
	{
		private const string FILEPATH = "Highscores.txt";
		private Jump game;
		private Text gameText1, gameText2;
		private List<HighscoreEntry> highScores = new List<HighscoreEntry>();
		private Texture2D background1, background2, highscoreTile;
		private Vector2 position1, position2;
		
		public HighScoresWindow(Jump game) : base(game)
		{
			this.game = game;
			position1 = new Vector2(312, 84);
			position2 = new Vector2(327, 99);
		}

		public void AddHighscoreEntry(HighscoreEntry entry)
		{
			highScores.Add(entry);

//			highScores.Sort( delegate (MyType t1, MyType t2) 
//			{ 
//				return (t1.ID.CompareTo(t2.ID)); } 
//			);
		}
		
		protected override void LoadContent()
		{
			LoadHighScores();
			background1 = CreateTexture(400, 600, game.graphics);
			background2 = CreateTexture(370, 570, game.graphics);
			highscoreTile = CreateTexture(370, 52, game.graphics);
			gameText1 = new Text(game, "", new Vector2(), Color.White);
			gameText1.OtherLoadContent("HighJakarta_22");
			gameText2 = new Text(game, "", new Vector2 (), Color.White);
			gameText2.OtherLoadContent("HighJakarta_22");
		}

		public override void Update(GameTime gt)
		{
			//Handles animation
		}

		public override void Draw(GameTime gt)
		{
			game.batch.Begin();
			game.batch.Draw(background1, position1, Color.Black);
			game.batch.Draw(background2, position2, Color.Blue);

			int stepY = 52;
			int stepX = 327;

			for (int index = 0; index < 9; index++)//index < highScores.Count && 
			{
				int curY = 149 + (stepY * (index + 1));
				game.batch.Draw(highscoreTile, new Vector2(stepX, curY), index % 2 == 0 ? Color.LightGreen : Color.Red);
				gameText1.Location = new Vector2(stepX + 25, curY + 10);
				gameText1.Content = (index + 1) + " " + "9999" + " " + "Nathan Michalski";//highScores[index].Name;
				if (gameText1.Content.Length > 28)
					gameText1.Content = gameText1.Content.Substring(0, 20);
				gameText1.InnerDraw(gt);
			}


			game.batch.End();
		}

		private void LoadHighScores()
		{
			if (!File.Exists(FILEPATH))
			{
				return;
			}

			string[] data = File.ReadAllLines(FILEPATH);
			char[] delimiter = new char[] { ':' };

			for (int dataIndex = 0; dataIndex < data.Length; dataIndex++)
			{
				string[] tData = data[dataIndex].Split(delimiter);

				if (tData.Length > 1)
					highScores.Add(new HighscoreEntry(tData[0], int.Parse(tData[1])));
			}

//			highScores.Sort(delegate(object a, object b)
//			{
//				HighscoreEntry tempA = (HighscoreEntry)a;
//				HighscoreEntry tempB = (HighscoreEntry)b;
//
//				if (tempA.Score > tempB.Score)
//				{
//					return 1;
//				}
//				else if (tempA.Score < tempB.Score)
//				{
//					return -1;
//				}
//				return 0;
//			});

//			parts.Sort(delegate(Part x, Part y)
//			{
//				if (x.PartName == null && y.PartName == null) return 0;
//				else if (x.PartName == null) return -1;
//				else if (y.PartName == null) return 1;
//				else return x.PartName.CompareTo(y.PartName);
//			});
		}

		private void SerializeHighScores()
		{
			List<String> data = new List<String>();

			foreach(HighscoreEntry entry in highScores)
			{
				data.Add(entry.Name + ":" + entry.Score);
			}

			File.WriteAllLines(FILEPATH, data);
		}

		private Texture2D CreateTexture(int width, int height, GraphicsDeviceManager g)
		{
			Texture2D tex = new Texture2D(g.GraphicsDevice, width, height);
			Color[] data = new Color[width*height];

			for (int i = 0; i < data.Length; ++i)
			{
				data [i] = Color.White;
			}

			tex.SetData(data);
			return tex;
		}
	}
}

