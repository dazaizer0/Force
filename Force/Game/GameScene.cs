using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Engine.Force2D.Physics;
using Force.Engine.Force2D.FMath;
using Force.Engine.Force2D.ModuleDerivatives;
using Force.Engine.Force2D.Modules;

namespace Force.Game
{
    public class GameScene : Microsoft.Xna.Framework.Game
    {
        #region VARIABLES
        // BASIC VARIABLES
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // VARIABLES
        private Vector2 mouseClickPosition;
        private const int gridSize = 32;

        // TEXTURES
        private static Texture2D pixelTexture2D;

        // STRUCTURES
        private Structure circle;
        private Structure gridCursor;

        // PLAYER
        private Player player;
        private Camera camera;
        #endregion

        #region GAME_SCENE
        public GameScene()
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
            circle = new Structure(new Vector2(100, 100), 0f, pixelTexture2D, Color.Black, true);
            gridCursor = new Structure(new Vector2(0, 0), 0f, pixelTexture2D, Color.Red, true);

            // PLAYER
            player = new Player(new Vector2(0, 0), 0.0f, pixelTexture2D, 200f, Color.White, true);
            player.SprintSpeed = 300f;

            // SETUP
            circle.SetupStructure(gridSize);

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
            gridCursor.Texture = Content.Load<Texture2D>("textures/white_box32");

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
            player.AccelerateTopDownMovement(gameTime);

            // CAMERA MOVEMENT
            camera.Fallow(new Vector2(player.Position.X + camera.CenterProperties.X, player.Position.Y + camera.CenterProperties.Y), gameTime);

            // CAMERA SHAKE AND POSITION (GET)
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                mouseClickPosition = new Vector2(mouseState.X, mouseState.Y);
                camera.Shake(0.04f, 6f);
            }

            // GRID CURSOR POSITION
            Matrix inverseCameraTransform = Matrix.Invert(camera.Transform);

            // GRID CURSOR POSITION
            gridCursor.Position = FMath.ConvertMovingVectorToGridVector(
                new Vector2(mouseState.X, mouseState.Y),
                gridSize,
                inverseCameraTransform
            );

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // SPRITE BATCH DRAW
            #region SPRITE_BATCH_DRAW
            spriteBatch.Begin(transformMatrix: camera.Transform);

            // DRAW GRID CURSOR
            gridCursor.DrawThis(spriteBatch);

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
