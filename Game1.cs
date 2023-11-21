using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Lesson_3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTex, orangeTex, creamTex, brownTex, introScreenThing;
        Rectangle greyRect, orangeRect, creamRect, brownRect;
        Vector2 greySpeed, orangeSpeed, creamSpeed, brownSpeed;
        SoundEffect coo;
        Screen screen;
        MouseState mouseState;
        enum Screen
        {
            Intro,
            TribbleYard
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            screen = Screen.Intro;
            greyRect = new Rectangle(300, 10, 100, 100);
            greySpeed = new Vector2(5, 0);
            orangeRect = new Rectangle(30, 100, 100, 100);
            orangeSpeed = new Vector2(2, 5);
            creamRect = new Rectangle(16, 300, 100, 100);
            creamSpeed = new Vector2(6, 1);
            brownRect = new Rectangle(400, 350, 100, 100);
            brownSpeed = new Vector2(0, 9);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTex = Content.Load<Texture2D>("tribbleGrey");
            orangeTex = Content.Load<Texture2D>("tribbleOrange");
            brownTex = Content.Load<Texture2D>("tribbleBrown");
            creamTex = Content.Load<Texture2D>("tribbleCream");
            introScreenThing = Content.Load<Texture2D>("tribble_intro");
            coo = Content.Load<SoundEffect>("tribble_coo");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;

            }

            else if (screen == Screen.TribbleYard)
            {
                greyRect.X += (int)greySpeed.X;
                greyRect.Y += (int)greySpeed.Y;
                if (greyRect.Right >= _graphics.PreferredBackBufferWidth || greyRect.Left <= 0)
                {
                    greySpeed.X *= -1;
                    coo.Play();
                }
                else if (greyRect.Bottom >= _graphics.PreferredBackBufferHeight || greyRect.Top <= 0)
                {
                    greySpeed.Y *= -1;
                    coo.Play();
                }

                orangeRect.X += (int)orangeSpeed.X;
                orangeRect.Y += (int)orangeSpeed.Y;
                if (orangeRect.Right >= _graphics.PreferredBackBufferWidth || orangeRect.Left <= 0)
                {
                    orangeSpeed.X *= -1;
                    coo.Play();
                }
                else if (orangeRect.Bottom >= _graphics.PreferredBackBufferHeight || orangeRect.Top <= 0)
                {
                    orangeSpeed.Y *= -1;
                    coo.Play();
                }

                brownRect.X += (int)brownSpeed.X;
                brownRect.Y += (int)brownSpeed.Y;
                if (brownRect.Right >= _graphics.PreferredBackBufferWidth || brownRect.Left <= 0)
                {
                    brownSpeed.X *= -1;
                    coo.Play();
                }
                else if (brownRect.Bottom >= _graphics.PreferredBackBufferHeight || brownRect.Top <= 0)
                {
                    brownSpeed.Y *= -1;
                    coo.Play();
                }

                creamRect.X += (int)creamSpeed.X;
                creamRect.Y += (int)creamSpeed.Y;
                if (creamRect.Right >= _graphics.PreferredBackBufferWidth || creamRect.Left <= 0)
                {
                    creamSpeed.X *= -1;
                    coo.Play();
                }
                else if (creamRect.Bottom >= _graphics.PreferredBackBufferHeight || creamRect.Top <= 0)
                {
                    creamSpeed.Y *= -1;
                    coo.Play();
                }
            }
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introScreenThing, new Rectangle(0, 0, 800, 500), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(greyTex, greyRect, Color.White);
                _spriteBatch.Draw(brownTex, brownRect, Color.White);
                _spriteBatch.Draw(orangeTex, orangeRect, Color.White);
                _spriteBatch.Draw(creamTex, creamRect, Color.White);
            }
           
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}