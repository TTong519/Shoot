using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Transactions;

namespace Shoot
{
    public class Game1 : Game
    {
        public Rectangle[] zombieFrames = [
            new Rectangle(17, 36, 166, 277),
            new Rectangle(201, 32, 166, 235),
            new Rectangle(387, 22, 166, 256),
            new Rectangle(570, 32, 166, 235),
            new Rectangle(754, 24, 166, 252),
        ];
        private int counter;
        Player player;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        List<ScuffedGombie> GombieList = new List<ScuffedGombie>();
        private Texture2D playerTexture;
        private Texture2D gombieTexture;
        Random random = new Random();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {


            spriteBatch = new SpriteBatch(GraphicsDevice);
            Rectangle[] playerFrames = [
                new Rectangle(17, 36, 166, 277),
                new Rectangle(201, 32, 166, 235),
                new Rectangle(387, 22, 166, 256),
                new Rectangle(570, 32, 166, 235),
                new Rectangle(754, 24, 166, 252),
                ];
            
            playerTexture = Content.Load<Texture2D>("sprite-sheet_0");
            gombieTexture = Content.Load<Texture2D>("sprite-sheet_1");
            Rectangle playerIdle = new Rectangle(948, 46, 168, 212);
            player = new Player(new(100, 100), new(0.25f, 0.25f), playerTexture, playerFrames, playerIdle, 200, Content.Load<Texture2D>("816-8162960_lazer-beam-png"));
            //GombieList.Add( new ScuffedGombie(new(300, 300), new(0.25f, 0.25f), gombieTexture, zombieFrames, 200));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            counter++;
            if (counter % 30 == 0)
            {
                GombieList.Add(new ScuffedGombie(new Point(random.Next(100, GraphicsDevice.Viewport.Bounds.Width-100), random.Next(100, GraphicsDevice.Viewport.Bounds.Height - 100)), new Vector2(0.25f, 0.25f), gombieTexture, zombieFrames, 200));
            }
            player.Update(gameTime, Keyboard.GetState(), Mouse.GetState(), GraphicsDevice, GombieList);
            // TODO: Add your update logic here
            for (int i = 0; i < GombieList.Count; i++)
            {
                if (GombieList[i] != null)
                {
                    GombieList[i].Update(gameTime, player);
                    for (int j = 0; j < player.Bullets.Count; j++)
                    {
                        if (GombieList[i].isHit(player.Bullets[j]) && GombieList.Count != 0)
                        {
                            GombieList.RemoveAt(i);
                            player.Bullets.RemoveAt(j);
                        }
                    }
                }
            }
            if(player.health <= 0)
            {
                throw new Exception("you died, game over");
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            player.Draw(spriteBatch);
            for (int i = 0; i < GombieList.Count; i++)
            {
                if (GombieList[i] != null)
                {
                    GombieList[i].Draw(spriteBatch);
                }
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
