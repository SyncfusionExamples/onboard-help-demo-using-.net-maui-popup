using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardHelpDemo
{
    public class DragAndDropBehavior : Behavior<StackLayout>
    {
        private StackLayout _stackLayout;
        
        protected override void OnAttachedTo(StackLayout stackLayout)
        {
            base.OnAttachedTo(stackLayout);
            this._stackLayout = stackLayout;
            this._stackLayout.Loaded += OnStackLayout_Loaded;
        }

        private async void OnStackLayout_Loaded(object? sender, EventArgs e)
        {
            this._stackLayout!.TranslationX = Application.Current.MainPage.Width;
            await this._stackLayout.TranslateTo(0, 0, 350);

            this.AnimateDragDropContentView();
        }

        private async void AnimateDragDropContentView()
        {
            await this._stackLayout.TranslateTo(0, 90, 1800);
            await this._stackLayout.TranslateTo(0, 0, 0);

            this.AnimateDragDropContentView();
        }
        protected override void OnDetachingFrom(StackLayout image)
        {
            base.OnDetachingFrom(image);
            this._stackLayout.Loaded -= OnStackLayout_Loaded;
            this._stackLayout = null;
        }
    }
}
