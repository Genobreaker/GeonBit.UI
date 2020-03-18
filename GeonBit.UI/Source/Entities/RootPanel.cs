using GeonBit.UI.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GeonBit.UI.Entities {

    internal sealed class RootPanel : Panel {

        #region Fields and Properties

        private Screen currentScreen;

        #endregion

        #region Cosntructors and Destructor

        static RootPanel() {
            Entity.MakeSerializable(typeof(RootPanel));
        }

        public RootPanel() :
            base(Vector2.Zero, PanelSkin.None, Anchor.Center, Vector2.Zero) {
            this.Padding = Vector2.Zero;
            this.ShadowColor = Color.Transparent;
            this.OutlineWidth = 0;
            this.ClickThrough = true;
        }

        #endregion

        #region Methods

        public override Rectangle CalcDestRect() {
            int width = UserInterface.Instance.ScreenWidth;
            int height = UserInterface.Instance.ScreenHeight;
            return new Rectangle(0, 0, width, height);
        }

        internal protected override void UpdateDestinationRectsIfDirty() {
            if (this.IsDirty) {
                this.UpdateDestinationRects();
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (!this.Visible) {
                return;
            }

            this.OnBeforeDraw(spriteBatch);
            this.UpdateDestinationRectsIfDirty();
            if (this.currentScreen != null) {
                this.currentScreen.Draw(spriteBatch);
            }
            this.OnAfterDraw(spriteBatch);
        }

        internal void SetCurrentScreen(Screen screen) {
            if (this.currentScreen != null) {
                this.RemoveChild(this.currentScreen);
            }
            this.currentScreen = screen;
            this.AddChild(screen);
        }

        #endregion

    }

}
