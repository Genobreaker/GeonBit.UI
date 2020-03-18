using GameInterface.Screens;
using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameInterface {

    public class MainGame : Game {

        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;
            
        public MainGame() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.IsBorderless = true;
        }
        
        protected override void Initialize() {
            UserInterface.Initialize();
            UserInterface.Instance.UseRenderTarget = true;
            UserInterface.Instance.IncludeCursorInRenderTarget = false;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            int _ScreenWidth = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            int _ScreenHeight = graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = (int)_ScreenWidth;
            graphics.PreferredBackBufferHeight = (int)_ScreenHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            InitExamplesAndUI();
            base.Initialize();
        }
       
        protected void InitExamplesAndUI() {
            UserInterface.Instance.AddScreen(new MainMenuScreen());
            UserInterface.Instance.SetCurrentScreen(typeof(MainMenuScreen));
        }

        protected override void Update(GameTime gameTime) {
            if (!IsActive) {
                return;
            }
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }

            UserInterface.Instance.Update(gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            UserInterface.Instance.Draw(this.spriteBatch);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            UserInterface.Instance.DrawMainRenderTarget(this.spriteBatch);
            base.Draw(gameTime);
        }

    }

}
