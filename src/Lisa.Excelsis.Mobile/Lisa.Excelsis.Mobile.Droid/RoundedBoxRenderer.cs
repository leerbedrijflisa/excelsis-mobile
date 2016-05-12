using System;
using Xamarin.Forms;
using Lisa.Excelsis.Mobile;
using Lisa.Excelsis.Mobile.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: ExportRendererAttribute(typeof(RoundedBoxView), typeof(RoundedBoxRenderer))]
namespace Lisa.Excelsis.Mobile.Droid
{
    public class RoundedBoxRenderer : BoxRenderer
    {
        public RoundedBoxRenderer()
        {
            this.SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            RoundedBoxView rbv = (RoundedBoxView)this.Element;

            Rect rc = new Rect();
            GetDrawingRect(rc);

            Rect interior = rc;
            interior.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

            Paint p = new Paint() {
                Color = rbv.Color.ToAndroid(),
                AntiAlias = true,
            };

            canvas.DrawRoundRect(new RectF(interior), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);

            p.Color = rbv.Stroke.ToAndroid();
            p.StrokeWidth = (float)rbv.StrokeThickness;
            p.SetStyle(Paint.Style.Stroke);

            canvas.DrawRoundRect(new RectF(rc), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName
                || e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName
                || e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
                this.Invalidate();
            
        }
    }
}

