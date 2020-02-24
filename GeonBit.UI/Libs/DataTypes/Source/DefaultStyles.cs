using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace GeonBit.UI.DataTypes {

    public enum FontStyle {
        Regular,
        Bold,
        Italic
    };

    public class DefaultStyles {

        [XmlElement(IsNullable = true)]
        public float? Scale = null;
        
        [XmlElement("Color", IsNullable = true)]
        public Color? FillColor = null;
        
        [XmlElement("Color", IsNullable = true)]
        public Color? OutlineColor = null;
        
        [XmlElement(IsNullable = true)]
        public int? OutlineWidth = null;
        
        [XmlElement(IsNullable = true)]
        public bool? ForceAlignCenter = null;
        
        [XmlElement(IsNullable = true)]
        public FontStyle? FontStyle = null;
        
        [XmlElement("Color", IsNullable = true)]
        public Color? SelectedHighlightColor = null;
        
        [XmlElement("Color", IsNullable = true)]
        public Color? ShadowColor = null;
        
        [XmlElement("Vector", IsNullable = true)]
        public Vector2? ShadowOffset = null;
        
        [XmlElement("Vector", IsNullable = true)]
        public Vector2? Padding = null;
        
        [XmlElement("Vector", IsNullable = true)]
        public Vector2? SpaceBefore = null;
        
        [XmlElement("Vector", IsNullable = true)]
        public Vector2? SpaceAfter = null;
        
        public float? ShadowScale = null;
        
        [XmlElement("Vector", IsNullable = true)]
        public Vector2? DefaultSize = null;

    }

}
