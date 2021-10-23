using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SupermanDelivery.Droid.Renderer;
using SupermanDelivery.Renderer;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessBorderlessEntryRenderer))]
namespace SupermanDelivery.Droid.Renderer
{
    public class BorderlessBorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessBorderlessEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}