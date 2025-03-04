using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardHelpDemo
{
    public class SwipingBehavior : Behavior<StackLayout>
    {
        private StackLayout? stackLayout;

        protected override void OnAttachedTo(StackLayout view)
        {
            base.OnAttachedTo(view);
            this.stackLayout = view;
            this.stackLayout.Loaded += OnStackLayoutLoaded;
        }

        private async void OnStackLayoutLoaded(object? sender, EventArgs e)
        {
            this.stackLayout!.TranslationX = Application.Current.MainPage.Width;
            await this.stackLayout.TranslateTo(0, 0, 300);

            this.AnimateSwipingContentView();
        }

        private async void AnimateSwipingContentView()
        {
            await this.stackLayout.TranslateTo(90, 0, 1800);
            await this.stackLayout.TranslateTo(0, 0, 0);
            this.AnimateSwipingContentView();
        }

        protected override void OnDetachingFrom(StackLayout image)
        {
            base.OnDetachingFrom(image);
            this.stackLayout.Loaded -= OnStackLayoutLoaded;
            this.stackLayout = null;
        }

    }
}
