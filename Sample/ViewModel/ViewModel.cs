using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardHelpDemo
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Team> data;
        private bool popupIsOpen;
        private string lblText = "Next";
        private ContentView _mainContent;
        private ContentView _resizingView;
        private ContentView _editView;
        private ContentView _swipeView;
        private ContentView _dragView;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the GettingStartedViewModel class. 
        /// </summary>
        public TeamViewModel()
        {
            this.data = new ObservableCollection<Team>();
            this.AddRows();
            this.SetBindingImageSource();
            this.ChangeContentView = new Command(this.GoToNextContent);

            MainContent = this.ResizingContentView;
        }

        #endregion
        /// <summary>
        /// Represents the method that will handle the <see cref="E:System.ComponentModel.INotifyPropertyChanged.PropertyChanged"></see> event raised when a property is changed on a component
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        public ContentView MainContent
        {
            get
            {
                return _mainContent;
            }
            set
            {
                _mainContent = value;
                RaisePropertyChanged("MainContent");
            }
        }
        public ContentView ResizingContentView
        {
            get
            {
                if(this._resizingView == null)
                {
                    this._resizingView = new ResizingView();
                }
                return _resizingView;
            }
        }

        public ContentView EditContentView
        {
            get
            {
                if (this._editView == null)
                {
                    this._editView = new EditingView();
                }
                return _editView;
            }
        }

        public ContentView SwipingContentView
        {
            get
            {
                if (this._swipeView == null)
                {
                    this._swipeView = new SwipingView();
                }
                return _swipeView;
            }
        }

        public ContentView DragDropContentView
        {
            get
            {
                if (this._dragView == null)
                {
                    this._dragView = new DraggingView();
                }
                return _dragView;
            }
        }

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>The Data.</value>
        public ObservableCollection<Team> TeamsData
        {
            get { return this.data; }
        }

        /// <summary>
        /// Gets or sets the source for the layout image for drag and drop illustration.
        /// </summary>
        public string? DragAndDropLayoutImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the Editing illustration Image.
        /// </summary>
        public string? EditingIllustrationImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the Resizing illustration Image.
        /// </summary>
        public string? ResizingIllustrationImage { get; set; }

        /// <summary>
        /// Gets or sets the source for the Swiping illustration Image.
        /// </summary>
        public string? SwipingIllustrationImage { get; set; }

        /// <summary>
        /// Gets or sets the command for changing the rotator item.
        /// </summary>
        public Command ChangeContentView { get; set; }

        /// <summary>
        /// Gets or sets the background color for the Overlay.
        /// </summary>
        public Color OverlayColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether popup is open or not.
        /// </summary>
        public bool PopupIsOpen
        {
            get
            {
                return this.popupIsOpen;
            }

            set
            {
                this.popupIsOpen = value;
                this.RaisePropertyChanged("PopupIsOpen");
            }
        }

        public string HelpText
        {
            get { return lblText; }
            set
            {
                lblText = value;
                RaisePropertyChanged(nameof(HelpText));
            }
        }

        #region updating code

        /// <summary>
        /// Adds the rows.
        /// </summary>
        private void AddRows()
        {
            this.data.Add(new Team("Cavaliers", .616, 0, 93, 58, "cavaliers.png", "East"));
            this.data.Add(new Team("Clippers", .550, 10, 82, 67, "clippers.png", "West"));
            this.data.Add(new Team("Denver", .514, 15, 76, 72, "denvernuggets.png", "Central"));
            this.data.Add(new Team("Detroit", .513, 15, 77, 73, "detroitpistons.png", "East"));
            this.data.Add(new Team("Golden State", .347, 40, 52, 98, "goldenstate.png", "West"));
            this.data.Add(new Team("Los Angeles", .560, 0, 84, 66, "losangeles.png", "Central"));
            this.data.Add(new Team("Mavericks", .547, 2, 82, 68, "mavericks.png", "East"));
            this.data.Add(new Team("Memphis", .540, 3, 81, 69, "memphis.png", "West"));
            this.data.Add(new Team("Miami", .464, 14, 70, 81, "miami.png", "Central"));
            this.data.Add(new Team("Milwakke", .433, 19, 65, 85, "milwakke.png", "East"));
            this.data.Add(new Team("New York", .642, 0, 97, 54, "newyork.png", "West"));
            this.data.Add(new Team("Orlando", .510, 20, 77, 74, "orlando.png", "Central"));
            this.data.Add(new Team("Thunder", .480, 24, 72, 78, "thunder_logo.png", "East"));
        }

        private void SetBindingImageSource()
        {
            this.EditingIllustrationImage = "doubletap.png";
            this.ResizingIllustrationImage = "resize.png";
            this.SwipingIllustrationImage = "slide.png";
            this.DragAndDropLayoutImage = "draganddrop.png";
        }

        /// <summary>
        /// Selects the next item in the rotator.
        /// </summary>
        private void GoToNextContent()
        {
            if(!(MainContent is DraggingView))
            {
                switch (MainContent)
                {
                    case ResizingView:
                        MainContent = EditContentView;
                        break;
                    case EditingView:
                        MainContent = SwipingContentView;
                        break;
                    case SwipingView:
                        MainContent = DragDropContentView;
                        HelpText = "Ok, got it !!!";
                        break;
                    default:
                        MainContent = ResizingContentView;
                        break;
                }
            }
            else
            {
                // close the popup after displayed all content views.
                this.PopupIsOpen = false;
            }
        }
        #endregion

        #region INotifyPropertyChanged implementation

        /// <summary>
        /// Triggers when Items Collections Changed.
        /// </summary>
        /// <param name="name">string type of name</param>
        private void RaisePropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
