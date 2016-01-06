using System;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;

            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;

            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            int result;

            var isValid = Int32.TryParse(args.NewTextValue, out result) && args.NewTextValue.Length <= 8;

            ((Entry)sender).BackgroundColor = isValid ? Color.Default : Color.FromRgb(255, 51, 51);
        }
    }
}