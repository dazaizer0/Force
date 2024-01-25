using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Source.Force2D.Physics;
using Force.Source.Force2D.FMath;
using Force.Source.Force2D.ModuleDerivatives;
using Force.Source.Force2D.Modules;
using Force.Source.Force2D.Map;

namespace Force.Game.Examples
{
    public class TopDown2 : Microsoft.Xna.Framework.Game
    {
        #region VARIABLES
        // BASIC VARIABLES
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // VARIABLES
        private Grid grid = new Grid();

        // TEXTURES
        private static Texture2D pixelTexture2D;

        // STRUCTURES
        private Structure circle;

        // PLAYER
        private Player player;
        private Camera camera;
        #endregion

        #region GAME_SCENE
        public TopDown2()
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
            circle = new Structure(new Vector2(100, 100), 0f, pixelTexture2D, Color.White, true);

            // PLAYER
            player = new Player(new Vector2(0, 0), 0.0f, pixelTexture2D, 1048f, Color.Yellow, true);

            // SETUP
            grid.GridSize = 32;

            circle.SetupStructure(grid.GridSize);

            base.Initialize();
        }
        #endregion

        #region LOAD_CONTENT
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // LOAD TEXTURES
            player.Texture = Content.Load<Texture2D>("textures/white_circle32");
            circle.Texture = Content.Load<Texture2D>("textures/white_circle32");

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

            // PLAYER
            player.AccelerateGridTopDownMovement(gameTime);
            player.Position = FMath.ConvertVectorToGridVector(player.Position, grid.GridSize);

            // CAMERA MOVEMENT
            camera.Fallow(new Vector2(player.Position.X + camera.CenterProperties.X, player.Position.Y + camera.CenterProperties.Y), gameTime);

            // CAMERA SHAKE AND POSITION (GET)
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                camera.Shake(0.04f, 6f);
            }

            // STRUCTURE COLLISION
            if (player.DetectCollisionWith(circle))
            {
                circle.GetStructureMoveDirection(player);
                player.SimpleCollideWith(circle, gameTime);
            }

            base.Update(gameTime);
        }
        #endregion

        #region DRAW
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // SPRITE BATCH DRAW
            #region SPRITE_BATCH_DRAW
            spriteBatch.Begin(transformMatrix: camera.Transform);

            // DRAW STRUCTURES
            player.DrawThis(spriteBatch);
            circle.DrawThis(spriteBatch);

            spriteBatch.End();
            #endregion

            base.Draw(gameTime);
        }
        #endregion
    }
}
