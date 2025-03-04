using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardHelpDemo
{
    public class ResizingBehavior : Behavior<StackLayout>
    {
        private StackLayout? stackLayout;
        protected override void OnAttachedTo(StackLayout bindable)
        {
            base.OnAttachedTo(bindable);
            this.stackLayout = bindable as StackLayout;
            this.AnimateResizingContentView();
        }

        protected override void OnDetachingFrom(StackLayout bindable)
        {
            base.OnDetachingFrom(bindable);
            this.stackLayout = null;
        }

        private async void AnimateResizingContentView()
        {
            await this.stackLayout!.TranslateTo(100, 0, 1000);
            await this.stackLayout!.TranslateTo(0, 0, 0);
            this.AnimateResizingContentView();
        }
    }
}
