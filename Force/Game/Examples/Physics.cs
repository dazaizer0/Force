using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

using Force.Engine.Force2D.ModuleDerivatives;
using Force.Engine.Force2D.FMath;
using Force.Engine.Force2D.Physics;
using Force.Engine.Force2D.ModuleDerivatives;
using Force.Engine.Force2D.Modules;

namespace Force.Game.Examples
{
    public class Physics : Microsoft.Xna.Framework.Game
    {
        #region VARIABLES
        // BASIC VARIABLES
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // TEXTURES
        private static Texture2D pixelTexture2D;

        // STRUCTURES
        PhysicsStructure object1 = new PhysicsStructure(new Vector2(100, 300), 0f, pixelTexture2D, Color.Black, true)
        { Mass = 6, Radius = 16 };

        PhysicsStructure object2 = new PhysicsStructure(new Vector2(200, 350), 0f, pixelTexture2D, Color.Black, true)
        { Mass = 1, Radius = 16 };

        float gravitationalConstant = 6.7f;
        #endregion

        #region EARTH
        public Physics()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        #endregion

        #region INITIALIZE
        protected override void Initialize()
        {
            base.Initialize();
        }
        #endregion

        #region LOAD_CONTENT
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // LOAD TEXTURES
            object1.Texture = Content.Load<Texture2D>("Textures/white_circle32");
            object2.Texture = Content.Load<Texture2D>("Textures/white_circle32");

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

            // PROTOTYPE GRAVITY OBJECTS
            object1.ApplyGravity(object2, 500f);
            object2.ApplyGravity(object1, 500f);

            object1.Update(gameTime);
            object2.Update(gameTime);

            if (object2.CheckCollision(object1))
            {
                object1.Velocity = Vector2.Zero;
                object2.Velocity = Vector2.Zero;
            }

            Gravity.ApplyGravity(object1, object2, gravitationalConstant);

            base.Update(gameTime);
        }
        #endregion

        #region DRAW
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // SPRITE BATCH DRAW
            #region SPRITE_BATCH_DRAW
            spriteBatch.Begin();

            // DRAW STRUCTURES
            object1.DrawThis(spriteBatch);
            object2.DrawThis(spriteBatch);

            spriteBatch.End();
            #endregion

            base.Draw(gameTime);
        }
        #endregion
    }
}
