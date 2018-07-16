
using Android.Content;
using KKSuperMart.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(ZeroPaddingRenderer))]
namespace KKSuperMart.Droid.Renderers
{
    public class ZeroPaddingRenderer : ButtonRenderer
    {
        public ZeroPaddingRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            Control?.SetPadding(0, 3, 0,3);
        }
    }
}