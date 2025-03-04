using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardHelpDemo
{
    public class OnBoardHelpsBehavior : Behavior<ContentPage>
    {
        /// <summary>
        /// Holds the instance of the DataGrid.
        /// </summary>
        private SfDataGrid? datagrid;

        /// <summary>
        /// Holds the instance of PopupLayout.
        /// </summary>
        private Syncfusion.Maui.Popup.SfPopup? popup;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindable">SampleView type parameter named as bindAble</param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.popup = bindable.FindByName<Syncfusion.Maui.Popup.SfPopup>("popup");
            this.datagrid = bindable.FindByName<SfDataGrid>("dataGrid");
            this.datagrid.Loaded += OnDatagridLoaded;
            this.datagrid.SizeChanged += OnDatagridSizeChanged;
            this.popup.Closed += OnPopupClosed;
        }

        private void OnPopupClosed(object? sender, EventArgs e)
        {
            this.popup!.HeightRequest = 0;
            this.popup.WidthRequest = 0;
        }

        private void OnDatagridSizeChanged(object? sender, EventArgs e)
        {
            this.popup!.HeightRequest = this.datagrid!.Height;
            this.popup.WidthRequest = this.datagrid!.Width;
        }

        /// <summary>
        /// Fired when DataGrid comes in to the View
        /// </summary>
        /// <param name="sender">DataGrid_Loaded event sender</param>
        /// <param name="e">DataGrid_Loaded events args e</param>
        private void OnDatagridLoaded(object? sender, EventArgs e)
        {
            this.popup!.HeightRequest = this.datagrid!.Height;
            this.popup.WidthRequest = this.datagrid!.Width;

            this.popup.Show(0, 0);
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindable">SampleView type parameter named as bindAble</param>
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            this.datagrid!.Loaded -= OnDatagridLoaded;
            this.datagrid.SizeChanged -= OnDatagridSizeChanged;
            this.popup.Closed -= OnPopupClosed;
            this.popup = null;
            this.datagrid = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
