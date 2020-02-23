using Microsoft.Xna.Framework;

namespace GeonBit.UI.Entities {

    public abstract class Screen : Panel {

        #region Constructors and Destructor

        public Screen() :
            base(Vector2.Zero, PanelSkin.None, Anchor.Center, Vector2.Zero) {
            this.Padding = Vector2.Zero;
            this.ShadowColor = Color.Transparent;
            this.OutlineWidth = 0;
            this.ClickThrough = true;
        }

        #endregion

        #region Methods

        public abstract void InitializeScreen();

        public abstract void UpdateScreen(GameTime gameTime);

        public abstract void DrawScreen(GameTime gameTime);

        internal void Initialize() {
            this.InitializeScreen();
        }

        internal void Update(GameTime gameTime) {
            this.UpdateScreen(gameTime);
        }

        internal void Draw(GameTime gameTime) {
            this.DrawScreen(gameTime);
        }

        #endregion

    }

}
