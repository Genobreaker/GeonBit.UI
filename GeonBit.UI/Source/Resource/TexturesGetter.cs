using System;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace GeonBit.UI {

    internal class TexturesGetter<TEnum> where TEnum : IConvertible {

        #region Fields and Properties

        private Texture2D[] loadedTextures;

        private string basepath;

        private string suffix;

        private bool usesStates;

        private int typesCount;

        public Texture2D this[TEnum i] {
            get {
                int index = this.GetIndex(i);
                if (this.loadedTextures[index] == null) {
                    var path = this.basepath + this.EnumToString(i) + this.suffix;
                    this.loadedTextures[index] = Resources.content.Load<Texture2D>(path);
                }
                return this.loadedTextures[index];
            }
            set {
                int index = this.GetIndex(i);
                this.loadedTextures[index] = value;
            }
        }

        public Texture2D this[TEnum i, EntityState state] {
            get {
                int index = this.GetIndex(i, state);
                if (this.loadedTextures[index] == null) {
                    var path = this.basepath + this.EnumToString(i) + this.suffix + this.StateEnumToString(state);
                    this.loadedTextures[index] = Resources.content.Load<Texture2D>(path);
                }
                return loadedTextures[index];
            }
            set {
                int index = this.GetIndex(i, state);
                this.loadedTextures[index] = value;
            }
        }

        #endregion

        #region Constructors and Destructor

        public TexturesGetter(string path, string suffix = null, bool usesStates = true) {
            this.basepath = path;
            this.suffix = suffix ?? string.Empty;
            this.usesStates = usesStates;
            this.typesCount = Enum.GetValues(typeof(TEnum)).Length;
            this.loadedTextures = new Texture2D[this.usesStates ? this.typesCount * 3 : this.typesCount];
        }

        #endregion

        #region Methods

        private int GetIndex(TEnum i, EntityState? state = null) {
            if (state != null) {
                return (int)(object)i + (this.typesCount * (int)state);
            }
            return (int)(object)i;
        }

        private string EnumToString(TEnum i) {
            if (typeof(TEnum) == typeof(EntityState)) {
                return this.StateEnumToString((EntityState)(object)i);
            }
            
            if (typeof(TEnum) == typeof(IconType)) {
                return i.ToString();
            }
            
            return i.ToString().ToLowerInvariant();
        }

        private string StateEnumToString(EntityState state) {
            switch (state) {
                case EntityState.MouseDown:
                    return "_down";
                case EntityState.MouseHover:
                    return "_hover";
                case EntityState.Default:
                    return string.Empty;
            }
            return null;
        }

        #endregion

    }

}
