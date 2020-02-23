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
            UserInterface.Initialize(Content);
            UserInterface.Active.UseRenderTarget = true;
            UserInterface.Active.IncludeCursorInRenderTarget = false;
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
            UserInterface.Active.AddScreen(new MainMenuScreen());
            UserInterface.Active.SetCurrentScreen(typeof(MainMenuScreen));
        }

        protected override void Update(GameTime gameTime) {
            if (!IsActive) {
                return;
            }
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }
            
            UserInterface.Active.Update(gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime) {
            UserInterface.Active.Draw(spriteBatch);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            UserInterface.Active.DrawMainRenderTarget(spriteBatch);
            base.Draw(gameTime);
        }

    }

}
