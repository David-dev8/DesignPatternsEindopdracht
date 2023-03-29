using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpVectors.Converters;
using SharpVectors.Runtime;
using System.Reflection;

namespace Chess.Views.CustomControls
{ 
    /// <summary>
    /// Represents a SVG image with a dynamic color
    /// </summary>
    public class SVGImage : SvgViewbox
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(SVGImage), new PropertyMetadata(null));

        static SVGImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SVGImage), new FrameworkPropertyMetadata(typeof(SVGImage)));
        }

        private IList<Brush> _seenBrushes = new List<Brush>();

        public string Color
        {
            get
            {
                return (string)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public SVGImage()
        {
            Loaded += SVGImage_Loaded;
            LayoutUpdated += SVGImage_Loaded;
        }

        private void SVGImage_Loaded(object sender, EventArgs e)
        {
            SetRightColor();
        }

        /// <summary>
        /// Sets the right color for this object
        /// </summary>
        private void SetRightColor()
        {
            if(Color != null)
            {
                SvgDrawingCanvas canvas = (SvgDrawingCanvas)Child;
                List<Drawing> drawings = (List<Drawing>)typeof(SvgDrawingCanvas)
                    .GetField("_drawObjects", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(canvas);

                foreach(Drawing drawing in drawings)
                {
                    if(drawing is GeometryDrawing geometryDrawing)
                    {
                        SetRightColor(geometryDrawing);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the right color for the given drawing
        /// </summary>
        /// <param name="drawing">The drawing whose color should be changed</param>
        private void SetRightColor(GeometryDrawing drawing)
        {
            if(!_seenBrushes.Contains(drawing.Brush))
            {
                var color = (Color)ColorConverter.ConvertFromString(Color);
                if (color.ToString() == "#FF000000" && (drawing.Brush.ToString() == "#FF000000" || drawing.Brush.ToString() == "#FFFFFFFF"))
                {
                    var brush = new SolidColorBrush()
                    {
                        Color = Invert((Color)ColorConverter.ConvertFromString(drawing.Brush.ToString()))
                    };

                    drawing.Brush = brush;
                    _seenBrushes.Add(brush);
                }
                else if (drawing.Brush.ToString() == "#FFFFFFFF")
                {
                    var brush = new SolidColorBrush()
                    {
                        Color = color
                    };

                    drawing.Brush = brush;
                    _seenBrushes.Add(brush);
                }
            }
        }

        /// <summary>
        /// Inverts a given color
        /// </summary>
        /// <param name="color"The color to be inverted></param>
        /// <returns>The inverted color</returns>
        private Color Invert(Color color)
        {
            return System.Windows.Media.Color.FromRgb(
                (byte)(255 - color.R),
                (byte)(255 - color.B),
                (byte)(255 - color.G)
            );
        }
    }
}
