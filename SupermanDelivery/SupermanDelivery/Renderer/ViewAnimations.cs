using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SupermanDelivery.Renderer
{
    public static class ViewAnimations
    {
        public static async Task FadeAnimY(View view)
        {


            await Task.WhenAll
               (
                    view.FadeTo(1, 200),
                    view.TranslateTo(0, 0, 200)
               );
        }
    }
}
