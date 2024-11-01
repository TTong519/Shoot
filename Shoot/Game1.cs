﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Transactions;

namespace Shoot
{
    public class Game1 : Game
    {
        Player player;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        ScuffedGombie Gombie;
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
            Rectangle[] zombieFrames = [
                new Rectangle(17, 36, 166, 277),
                new Rectangle(201, 32, 166, 235),
                new Rectangle(387, 22, 166, 256),
                new Rectangle(570, 32, 166, 235),
                new Rectangle(754, 24, 166, 252),
                ];

            Rectangle playerIdle = new Rectangle(948, 46, 168, 212);
            player = new Player(new(100, 100), new(0.25f, 0.25f), Content.Load<Texture2D>("sprite-sheet_0"), playerFrames, playerIdle, 200, Content.Load<Texture2D>("816-8162960_lazer-beam-png"));
            Gombie = new ScuffedGombie(new(300, 300), new(0.25f, 0.25f), Content.Load<Texture2D>("sprite-sheet_1"), zombieFrames, 200);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Update(gameTime, Keyboard.GetState(), Mouse.GetState());
            // TODO: Add your update logic here
            Gombie.Update(gameTime, player);
            this.Window.Title = $"zX:{Gombie.Speed.X},zY:{Gombie.Speed.Y},pX:{player.Speed.X},pY:{player.Speed.Y}";
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            player.Draw(spriteBatch);
            Gombie.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
