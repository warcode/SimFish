using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using XnaInput;
using Sprites;

namespace SimFish
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public InputManager input;
        
        Fish f;
        List<Fish> school;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            school = new List<Fish>(10);
            input = new InputManager(this);
            input.AssignControl(PlayerIndex.One, "X", Buttons.DPadLeft, Buttons.DPadRight);
            input.AssignControl(PlayerIndex.One, "Y", Buttons.DPadDown, Buttons.DPadUp);
            input.AssignControl(PlayerIndex.One, "Size", Buttons.A, Buttons.B);

            input.AssignControl(PlayerIndex.Two, "X", Keys.Left, Keys.Right);
            input.AssignControl(PlayerIndex.Two, "Y", Keys.Down, Keys.Up);
            input.AssignControl(PlayerIndex.Two, "Size", Keys.RightControl, Keys.RightShift);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            f = new Fish();
            f.Texture = Content.Load<Texture2D>(@"fishimg");
            f.Position = new Vector2(250.0f, 250.0f);
            f.Size = new Vector2(20.0f, 20.0f);
            f.Color = Color.White;

            school.Add(f);

            f = new Fish();
            f.Texture = Content.Load<Texture2D>(@"fishimg");
            f.Position = new Vector2(270.0f, 270.0f);
            f.Size = new Vector2(20.0f, 20.0f);
            f.Color = Color.White;

            school.Add(f);

            f = new Fish();
            f.Texture = Content.Load<Texture2D>(@"fishimg");
            f.Position = new Vector2(270.0f, 230.0f);
            f.Size = new Vector2(20.0f, 20.0f);
            f.Color = Color.White;

            school.Add(f);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            foreach (Fish x in school)
            { x.Update(gameTime, graphics); }

            controls();

            // TODO: Add your update logic here
            f.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SteelBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            foreach (Fish f in school)
            {
                f.Draw(spriteBatch);
            }

            spriteBatch.End();

            

            base.Draw(gameTime);
        }

        void controls()
        {
            //player one
            float x = input.ControlState(PlayerIndex.One, "X");
            float y = input.ControlState(PlayerIndex.One, "Y");

            if (x == -1.0f) { school[0].Position += new Vector2(2.0f, 0.0f); school[0].Flip = true; }
            else if (x == 1.0f) { school[0].Position += new Vector2(-2.0f, 0.0f); school[0].Flip = false; }

            if (y == -1.0f) { school[0].Position += new Vector2(0.0f, -2.0f); }
            else if (y == 1.0f) { school[0].Position += new Vector2(0.0f, 2.0f); }

            float size = input.ControlState(PlayerIndex.One, "Size");

            if (size == -1.0f) { school[0].Size += new Vector2(1.0f, 1.0f); }
            else if (size == 1.0f) { school[0].Size += new Vector2(-1.0f, -1.0f); }

            //player two
            float x2 = input.ControlState(PlayerIndex.Two, "X");
            float y2 = input.ControlState(PlayerIndex.Two, "Y");

            if (x2 == -1.0f) { school[1].Position += new Vector2(1.0f, 0.0f); school[1].Flip = true; }
            else if (x2 == 1.0f) { school[1].Position += new Vector2(-1.0f, 0.0f); school[1].Flip = false; }

            if (y2 == -1.0f) { school[1].Position += new Vector2(0.0f, -1.0f); }
            else if (y2 == 1.0f) { school[1].Position += new Vector2(0.0f, 1.0f); }

            float size2 = input.ControlState(PlayerIndex.Two, "Size");

            if (size2 == -1.0f) { school[1].Size += new Vector2(1.0f, 1.0f); }
            else if (size2 == 1.0f) { school[1].Size += new Vector2(-1.0f, -1.0f); }
        }
    }
}
