using Microsoft.Maui.Controls;
using Syncfusion.Maui.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardHelpDemo
{
    public class EditingBehavior : Behavior<StackLayout>
    {
        private StackLayout? stackLayout;

        protected async override void OnAttachedTo(StackLayout stack)
        {
            base.OnAttachedTo(stack);
            this.stackLayout = stack;
            this.stackLayout.Loaded += OnStackLayoutLoaded;
        }

        private async void OnStackLayoutLoaded(object? sender, EventArgs e)
        {
            this.stackLayout!.TranslationX = Application.Current.MainPage.Width;
            await this.stackLayout.TranslateTo(0, 0, 350);
            this.AnimateEditContentView();
        }

        private async void AnimateEditContentView()
        {
            this.stackLayout!.Opacity = 0;
            await this.stackLayout.FadeTo(1, 250);
            this.stackLayout.Opacity = 0;
            await this.stackLayout.FadeTo(1, 250);
            await Task.Delay(1000);
            this.AnimateEditContentView();
        }
        protected override void OnDetachingFrom(StackLayout stack)
        {
            base.OnDetachingFrom(stack);
            this.stackLayout.Loaded -= OnStackLayoutLoaded;
            this.stackLayout = null;
        }
    }
}
