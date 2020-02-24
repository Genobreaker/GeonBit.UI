using System;
using System.Collections.Generic;
using System.Linq;
using GeonBit.UI.DataTypes;
using GeonBit.UI.DataTypes.Metadata;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GeonBit.UI {

    internal static class Resources {

        #region Fields and Properties

        internal static ContentManager content;

        private static Dictionary<char, string> charStringDict = new Dictionary<char, string>();

        #region Components

        internal static Texture2D whiteTexture;

        internal static TexturesGetter<CursorType> cursors = new TexturesGetter<CursorType>("textures/cursor_");

        internal static CursorTextureData[] cursorsData;

        internal static TexturesGetter<PanelSkin> panelTextures = new TexturesGetter<PanelSkin>("textures/panel_");

        internal static TextureData[] panelData;

        internal static TexturesGetter<ButtonSkin> buttonTextures = new TexturesGetter<ButtonSkin>("textures/button_");

        internal static TextureData[] buttonData;

        internal static TexturesGetter<EntityState> checkBoxTextures = new TexturesGetter<EntityState>("textures/checkbox");

        internal static TexturesGetter<EntityState> radioTextures = new TexturesGetter<EntityState>("textures/radio");

        internal static Texture2D progressBarTexture;

        internal static TextureData progressBarData;

        internal static Texture2D progressBarFillTexture;

        internal static Texture2D horizontalLineTexture;

        internal static TexturesGetter<SliderSkin> sliderTextures = new TexturesGetter<SliderSkin>("textures/slider_");

        internal static TexturesGetter<SliderSkin> sliderMarkTextures = new TexturesGetter<SliderSkin>("textures/slider_", "_mark");

        internal static TextureData[] sliderData;

        internal static TexturesGetter<IconType> iconTextures = new TexturesGetter<IconType>("textures/icons/");

        internal static Texture2D iconBackgroundTexture;

        internal static Texture2D verticalScrollbarTexture;

        internal static Texture2D verticalScrollbarMarkTexture;

        internal static TextureData verticalScrollbarData;

        internal static Texture2D arrowDown;

        internal static Texture2D arrowUp;

        internal static SpriteFont[] fonts;

        internal static Effect disabledEffect;

        internal static Effect silhouetteEffect;

        #endregion

        #endregion

        #region Methods

        public static void LoadContent(ContentManager content) {
            InitialiseCharStringDict();
            Resources.content = content;

            horizontalLineTexture = Resources.content.Load<Texture2D>("textures/horizontal_line");
            whiteTexture = Resources.content.Load<Texture2D>("textures/white_texture");
            iconBackgroundTexture = Resources.content.Load<Texture2D>("textures/icons/background");
            verticalScrollbarTexture = Resources.content.Load<Texture2D>("textures/scrollbar");
            verticalScrollbarMarkTexture = Resources.content.Load<Texture2D>("textures/scrollbar_mark");
            arrowDown = Resources.content.Load<Texture2D>("textures/arrow_down");
            arrowUp = Resources.content.Load<Texture2D>("textures/arrow_up");
            progressBarTexture = Resources.content.Load<Texture2D>("textures/progressbar");
            progressBarFillTexture = Resources.content.Load<Texture2D>("textures/progressbar_fill");

            cursorsData = new CursorTextureData[Enum.GetValues(typeof(CursorType)).Length];
            foreach (CursorType cursor in Enum.GetValues(typeof(CursorType))) {
                string cursorName = cursor.ToString().ToLowerInvariant();
                cursorsData[(int)cursor] = content.Load<CursorTextureData>("textures/cursor_" + cursorName + "_md");
            }

            panelData = new TextureData[Enum.GetValues(typeof(PanelSkin)).Length];
            foreach (PanelSkin skin in Enum.GetValues(typeof(PanelSkin))) {
                if (skin == PanelSkin.None) {
                    continue;
                }
                string skinName = skin.ToString().ToLowerInvariant();
                panelData[(int)skin] = content.Load<TextureData>("textures/panel_" + skinName + "_md");
            }

            verticalScrollbarData = content.Load<TextureData>("textures/scrollbar_md");

            sliderData = new TextureData[Enum.GetValues(typeof(SliderSkin)).Length];
            foreach (SliderSkin skin in Enum.GetValues(typeof(SliderSkin))) {
                string skinName = skin.ToString().ToLowerInvariant();
                sliderData[(int)skin] = content.Load<TextureData>("textures/slider_" + skinName + "_md");
            }

            fonts = new SpriteFont[Enum.GetValues(typeof(Entities.FontStyle)).Length];
            foreach (Entities.FontStyle style in Enum.GetValues(typeof(Entities.FontStyle))) {
                fonts[(int)style] = content.Load<SpriteFont>("fonts/" + style.ToString());
                fonts[(int)style].LineSpacing += 2;
            }

            buttonData = new TextureData[Enum.GetValues(typeof(ButtonSkin)).Length];
            foreach (ButtonSkin skin in Enum.GetValues(typeof(ButtonSkin))) {
                string skinName = skin.ToString().ToLowerInvariant();
                buttonData[(int)skin] = content.Load<TextureData>("textures/button_" + skinName + "_md");
            }

            progressBarData = content.Load<TextureData>("textures/progressbar_md");

            disabledEffect = content.Load<Effect>("effects/disabled");
            silhouetteEffect = content.Load<Effect>("effects/silhouette");

            LoadComponentStyles();
        }
        
        public static string GetStringForChar(char c) {
            if (!charStringDict.ContainsKey(c)) {
                return c.ToString();
            }
            return charStringDict[c];
        }

        private static void InitialiseCharStringDict() {
            charStringDict.Clear();
            var asciiValues = Enumerable.Range('\x1', 127).ToArray();
            for (int i = 0; i < asciiValues.Length; i++) {
                char c = (char)asciiValues[i];
                charStringDict.Add(c, c.ToString());
            }
        }

        private static void LoadComponentStyles() {
            LoadDefaultStyles(ref Entity.DefaultStyle, "Entity");
            LoadDefaultStyles(ref Paragraph.DefaultStyle, "Paragraph");
            LoadDefaultStyles(ref Button.DefaultStyle, "Button");
            LoadDefaultStyles(ref Button.DefaultParagraphStyle, "ButtonParagraph");
            LoadDefaultStyles(ref CheckBox.DefaultStyle, "CheckBox");
            LoadDefaultStyles(ref CheckBox.DefaultParagraphStyle, "CheckBoxParagraph");
            LoadDefaultStyles(ref ColoredRectangle.DefaultStyle, "ColoredRectangle");
            LoadDefaultStyles(ref DropDown.DefaultStyle, "DropDown");
            LoadDefaultStyles(ref DropDown.DefaultParagraphStyle, "DropDownParagraph");
            LoadDefaultStyles(ref DropDown.DefaultSelectedParagraphStyle, "DropDownSelectedParagraph");
            LoadDefaultStyles(ref Header.DefaultStyle, "Header");
            LoadDefaultStyles(ref HorizontalLine.DefaultStyle, "HorizontalLine");
            LoadDefaultStyles(ref Icon.DefaultStyle, "Icon");
            LoadDefaultStyles(ref Image.DefaultStyle, "Image");
            LoadDefaultStyles(ref Label.DefaultStyle, "Label");
            LoadDefaultStyles(ref Panel.DefaultStyle, "Panel");
            LoadDefaultStyles(ref ProgressBar.DefaultStyle, "ProgressBar");
            LoadDefaultStyles(ref ProgressBar.DefaultFillStyle, "ProgressBarFill");
            LoadDefaultStyles(ref RadioButton.DefaultStyle, "RadioButton");
            LoadDefaultStyles(ref RadioButton.DefaultParagraphStyle, "RadioButtonParagraph");
            LoadDefaultStyles(ref SelectList.DefaultStyle, "SelectList");
            LoadDefaultStyles(ref SelectList.DefaultParagraphStyle, "SelectListParagraph");
            LoadDefaultStyles(ref Slider.DefaultStyle, "Slider");
            LoadDefaultStyles(ref TextInput.DefaultStyle, "TextInput");
            LoadDefaultStyles(ref TextInput.DefaultParagraphStyle, "TextInputParagraph");
            LoadDefaultStyles(ref TextInput.DefaultPlaceholderStyle, "TextInputPlaceholder");
            LoadDefaultStyles(ref VerticalScrollbar.DefaultStyle, "VerticalScrollbar");
            LoadDefaultStyles(ref PanelTabs.DefaultButtonStyle, "PanelTabsButton");
            LoadDefaultStyles(ref PanelTabs.DefaultButtonParagraphStyle, "PanelTabsButtonParagraph");
        }
        
        private static void LoadDefaultStyles(ref StyleSheet sheet, string entityName) {
            string stylesheetBase = "styles/" + entityName;
            FillDefaultStyles(ref sheet, EntityState.Default, Resources.content.Load<DefaultStyles>(stylesheetBase + "-Default"));
            FillDefaultStyles(ref sheet, EntityState.MouseHover, Resources.content.Load<DefaultStyles>(stylesheetBase + "-MouseHover"));
            FillDefaultStyles(ref sheet, EntityState.MouseDown, Resources.content.Load<DefaultStyles>(stylesheetBase + "-MouseDown"));
        }

        private static void FillDefaultStyles(ref StyleSheet sheet, EntityState state, DefaultStyles styles) {
            if (styles.FillColor != null) {
                sheet[state.ToString() + "." + "FillColor"] = new StyleProperty((Color)styles.FillColor);
            }
            if (styles.FontStyle != null) {
                sheet[state.ToString() + "." + "FontStyle"] = new StyleProperty((int)styles.FontStyle);
            }
            if (styles.ForceAlignCenter != null) {
                sheet[state.ToString() + "." + "ForceAlignCenter"] = new StyleProperty((bool)styles.ForceAlignCenter);
            }
            if (styles.OutlineColor != null) {
                sheet[state.ToString() + "." + "OutlineColor"] = new StyleProperty((Color)styles.OutlineColor);
            }
            if (styles.OutlineWidth != null) {
                sheet[state.ToString() + "." + "OutlineWidth"] = new StyleProperty((int)styles.OutlineWidth);
            }
            if (styles.Scale != null) {
                sheet[state.ToString() + "." + "Scale"] = new StyleProperty((float)styles.Scale);
            }
            if (styles.SelectedHighlightColor != null) {
                sheet[state.ToString() + "." + "SelectedHighlightColor"] = new StyleProperty((Color)styles.SelectedHighlightColor);
            }
            if (styles.ShadowColor != null) {
                sheet[state.ToString() + "." + "ShadowColor"] = new StyleProperty((Color)styles.ShadowColor);
            }
            if (styles.ShadowOffset != null) {
                sheet[state.ToString() + "." + "ShadowOffset"] = new StyleProperty((Vector2)styles.ShadowOffset);
            }
            if (styles.Padding != null) {
                sheet[state.ToString() + "." + "Padding"] = new StyleProperty((Vector2)styles.Padding);
            }
            if (styles.SpaceBefore != null) {
                sheet[state.ToString() + "." + "SpaceBefore"] = new StyleProperty((Vector2)styles.SpaceBefore);
            }
            if (styles.SpaceAfter != null) {
                sheet[state.ToString() + "." + "SpaceAfter"] = new StyleProperty((Vector2)styles.SpaceAfter);
            }
            if (styles.ShadowScale != null) {
                sheet[state.ToString() + "." + "ShadowScale"] = new StyleProperty((float)styles.ShadowScale);
            }
            if (styles.DefaultSize != null) {
                sheet[state.ToString() + "." + "DefaultSize"] = new StyleProperty((Vector2)styles.DefaultSize);
            }
        }

        #endregion

    }

}
