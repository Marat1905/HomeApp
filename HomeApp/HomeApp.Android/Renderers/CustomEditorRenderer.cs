using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using HomeApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace HomeApp.Droid.Renderers
{
    /// <summary>
    /// Отключаем подчеркивание по умолчанию для элемента Editor на платформе  Android
    /// </summary>
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}