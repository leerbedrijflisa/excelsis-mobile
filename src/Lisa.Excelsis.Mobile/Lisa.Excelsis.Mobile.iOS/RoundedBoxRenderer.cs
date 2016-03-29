using System;
using Xamarin.Forms.Platform.IOS;
using MonoTouch.UiKit;
using MonoTouch.CoreGraphics;
using Xamarin.Forms;
using Lisa.Excelsis.Mobile;
using Lisa.Excelsis.Mobile.iOS;

[assembly: ExportRendererAttribute(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace Lisa.Excelsis.Mobile.iOS
{
    public class RoundedBoxRenderer : BoxRenderer
    {
        public RoundedBoxRenderer()
        {
        }

        public override void Draw(System.Drawing.RectangleF rect)
        {
            RoundedBoxView rbv = (RoundedBoxView)this.Element;

            using (var context = UIGraphics.GetCurrentContext()) {

                context.SetFillColor(rbv.Color.ToCGColor());
                context.SetStrokeColor(rbv.Stroke.ToCGColor());
                context.SetLineWidth((float)rbv.StrokeThickness);

                var rc = this.Bounds.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

                float radius = (float)rbv.CornerRadius;
                radius = Math.Max(0, Math.Min(radius, Math.Max(rc.Height / 2, rc.Width / 2)));

                var path = CGPath.FromRoundedRect(rc, radius, radius);
                context.AddPath(path);
                context.DrawPath(CGPathDrawingMode.FillStroke);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName
                || e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName
                || e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
                this.SetNeedsDisplay();

        }
    }
}