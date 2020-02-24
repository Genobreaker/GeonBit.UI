using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace GeonBit.UI.DataTypes {

    [System.Xml.Serialization.XmlInclude(typeof(Color))]
    [System.Xml.Serialization.XmlInclude(typeof(Vector2))]
    public struct StyleProperty {

        #region Fields and Properties

        private Color? _color;

        private Vector2? _vector;
        
        private float? _float;

        public StyleProperty(float value) {
            this._float = value;
            this._color = null;
            this._vector = null;
        }

        public StyleProperty(int value) {
            this._float = value;
            this._color = null;
            this._vector = null;
        }

        public StyleProperty(Vector2 value) {
            this._vector = value;
            this._color = null;
            this._float = null;
        }

        public StyleProperty(Color value) {
            this._color = value;
            this._vector = null;
            this._float = null;
        }

        public StyleProperty(bool value) {
            this._vector = null;
            this._color = null;
            this._float = value ? 1f : 0f;
        }
        
        [ContentSerializerAttribute(Optional = true)]
        [System.Xml.Serialization.XmlIgnore]
        public Color asColor {
            get {
                return this._color != null ? (Color)this._color : Color.White;
            }
            set {
                this._color = value;
            }
        }
        
        [ContentSerializerAttribute(Optional = true)]
        [System.Xml.Serialization.XmlIgnore]
        public Vector2 asVector {
            get {
                return this._vector != null ? (Vector2)this._vector : Vector2.One;
            }
            set {
                this._vector = value;
            }
        }
        
        [ContentSerializerAttribute(Optional = true)]
        [System.Xml.Serialization.XmlIgnore]
        public float asFloat {
            get {
                return this._float.Value;
            }
            set {
                this._float = value;
            }
        }
        
        [ContentSerializerAttribute(Optional = true)]
        [System.Xml.Serialization.XmlIgnore]
        public int asInt {
            get {
                return (int)this._float.Value;
            }
            set {
                this._float = value;
            }
        }
        
        [ContentSerializerAttribute(Optional = true)]
        [System.Xml.Serialization.XmlIgnore]
        public bool asBool {
            get {
                return this._float.Value > 0f;
            }
            set {
                this._float = value ? 1f : 0f;
            }
        }
        
        [ContentSerializerAttribute(Optional = true)]
        public object _Value {
            get {
                if (this._color != null) {
                    return this._color.Value;
                } else if (this._vector != null) {
                    return this._vector.Value;
                } else {
                    return this._float.Value;
                }
            }
            set {
                if (value is Color) {
                    this._color = (Color)value;
                } else if (value is Vector2) {
                    this._vector = (Vector2)value;
                } else {
                    this._float = (float)value;
                }
            }
        }

        #endregion

    }

}
