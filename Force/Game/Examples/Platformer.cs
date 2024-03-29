﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Source.Force2D.Physics;
using Force.Source.Force2D.FMath;
using Force.Source.Force2D.ModuleDerivatives;
using Force.Source.Force2D.Modules;
using Force.Source.Force.Audio;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Force.Game.Examples
{
    public class Platformer : Microsoft.Xna.Framework.Game
    {
        #region VARIABLES
        // BASIC VARIABLES
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // TEXTURES
        private static Texture2D pixelTexture2D;

        // STRUCTURES
        private Structure structure;

        // PLAYER
        private Player player;
        private Camera camera;

        // AUDIO
        private Song jojoSong;
        private bool jojoSongActivated = false;

        #endregion

        #region PLATFORMER
        public Platformer()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        #endregion

        #region INITIALIZE
        protected override void Initialize()
        {
            // CAMERA SETUP
            camera = new Camera(new Vector2(0, 0), 0.0f, GraphicsDevice.Viewport, 1.25f, true);
            camera.CenterProperties = new Vector2(410, 250);

            // STRUCTURES
            structure = new Structure(new Vector2(100, 465), 0f, pixelTexture2D, Color.Red, true);

            // PLAYER
            player = new Player(new Vector2(0, 0), 0.0f, pixelTexture2D, 200f, Color.White, true);
            player.Mass = 40;

            base.Initialize();
        }
        #endregion

        #region LOAD_CONTENT
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // LOAD CONTENT
            player.Texture = Content.Load<Texture2D>("textures/white_box32");
            structure.Texture = Content.Load<Texture2D>("textures/white_box32");

            jojoSong = Content.Load<Song>("audio/jojod");

            // CREATE PIXEL TEXTURE
            pixelTexture2D = new Texture2D(GraphicsDevice, 1, 1);
            pixelTexture2D.SetData(new Color[] { Color.White });
        }
        #endregion

        #region UPDATE
        protected override void Update(GameTime gameTime)
        {
            // EXIT CONDITION
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // AUDIO
            if (!jojoSongActivated) 
            {
                MediaPlayer.Play(jojoSong);
                jojoSongActivated = true; 
            }

            // PLAYER
            player.AcceleratePlatformMovement(gameTime);
            player.SimplePhysics(gameTime, new Vector2(0, 9.81f));
            player.Update(gameTime);

            // CAMERA MOVEMENT
            camera.Fallow(new Vector2(player.Position.X + camera.CenterProperties.X, player.Position.Y + camera.CenterProperties.Y), gameTime);

            // CAMERA SHAKE AND POSITION (GET)
            MouseState mouse_state = Mouse.GetState();

            if (mouse_state.LeftButton == ButtonState.Pressed)
            {
                camera.Shake(0.04f, 6f);
            }

            // COLLISIONS
            player.EnableScreenEdgeCollisions(graphics);

            if (player.DetectCollisionWith(structure))
            {
                structure.GetStructureMoveDirection(player);
                player.PlatformerCollideWith(structure, gameTime);
            }

            base.Update(gameTime);
        }
        #endregion

        #region DRAW
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            // SPRITE BATCH DRAW
            #region SPRITE_BATCH_DRAW
            spriteBatch.Begin(transformMatrix: camera.Transform);

            for (int x = 0; x < graphics.PreferredBackBufferWidth; x += 32)
            {
                for (int y = 0; y < graphics.PreferredBackBufferHeight + 32; y += 32)
                {
                    spriteBatch.Draw(pixelTexture2D, new Rectangle(x, y, 32, 32), Color.Black);

                }
            }

            // DRAW STRUCTURES
            player.DrawThis(spriteBatch);
            structure.DrawThis(spriteBatch);

            spriteBatch.End();
            #endregion

            base.Draw(gameTime);
        }
        #endregion
    }
}