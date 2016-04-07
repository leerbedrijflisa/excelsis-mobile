using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace Lisa.Excelsis.Mobile
{
    public class ObservationViewModel : BindableObject
    {
        public ObservationViewModel()
        {
            SetSeenResult = new Command<ObservationViewModel>((item) =>
            { 
                OnChangeResult(item, "seen"); 
                ChangeObserveColor(); 
            });
            SetNotSeenResult = new Command<ObservationViewModel>((item) =>
            { 
                OnChangeResult(item, "unseen"); 
                ChangeObserveColor();
            });
            SetMaybeNotActive = new Command<ObservationViewModel>(ToggleMark(() => Maybe_Not = !Maybe_Not, "maybenot"));
            SetSkipActive = new Command<ObservationViewModel>(ToggleMark(() => Skip = !Skip, "skip"));
            SetUnclearActive = new Command<ObservationViewModel>(ToggleMark(() => Unclear = !Unclear, "unclear"));
            SetChangeActive = new Command<ObservationViewModel>(ToggleMark(() => Change = !Change, "change"));
            OpenItem = new Command<StackLayout>(ToggleObservation);
        }
            
        public ICommand SetSeenResult { get; set; }
        public ICommand SetNotSeenResult { get; set; }
        public ICommand SetMaybeNotActive { get; set; }
        public ICommand SetSkipActive { get; set; }
        public ICommand SetUnclearActive { get; set; }
        public ICommand SetChangeActive { get; set; }
        public ICommand OpenItem { get; set; }

        public string Id { get; set; }
        public string Result
        { 
            get { return _Result; }
            set
            {
                if (_Result != value)
                {
                    _Result = value;
                    OnPropertyChanged("Result");
                }
            }
        }
        public Criterion Criterion { get; set; }
        public bool Maybe_Not
        {
            get { return _Maybe_Not; }
            set
            {
                if (_Maybe_Not != value)
                {
                    _Maybe_Not = value;
                    OnPropertyChanged("Maybe_Not");
                }
            }
        }
        public bool Skip
        {
            get { return _Skip; }
            set
            {
                if (_Skip != value)
                {
                    _Skip = value;
                    OnPropertyChanged("Skip");
                }
            }
        }
        public bool Unclear
        {
            get { return _Unclear; }
            set
            {
                if (_Unclear != value)
                {
                    _Unclear = value;
                    OnPropertyChanged("Unclear");
                }
            }
        }
        public bool Change
        {
            get { return _Change; }
            set
            {
                if (_Change != value)
                {
                    _Change = value;
                    OnPropertyChanged("Change");
                }
            }
        }

        public bool IsSelected
        { 
            get { return _IsSelected; } 
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        public Color ResultFillColor
        {
            get { return _ResultFillColor; }
            set
            {
                if (_ResultFillColor != value)
                {
                    _ResultFillColor = value;
                    OnPropertyChanged("ResultFillColor");
                }
            }
        }

        public Color ResultStrokeColor
        {
            get { return _ResultStrokeColor; }
            set
            {
                if (_ResultStrokeColor != value)
                {
                    _ResultStrokeColor = value;
                    OnPropertyChanged("ResultStrokeColor");
                }
            }
        }

        public Color OrderColor
        {
            get { return _OrderColor; }
            set
            {
                if (_OrderColor != value)
                {
                    _OrderColor = value;
                    OnPropertyChanged("OrderColor");
                }
            }
        }

        private bool _IsSelected;
        private Color _ResultFillColor;
        private Color _ResultStrokeColor;
        private Color _OrderColor;
        private string _Result;
        private bool _Maybe_Not;
        private bool _Skip;
        private bool _Unclear;
        private bool _Change;

        private void OnChangeResult(ObservationViewModel item, string result)
        {
            if (item.Result != "notrated" && item.Result != result)
            {
                item.Result = (item.Result == "seen") ? "unseen" : "seen";
            }
            else if (item.Result == "notrated")
            {
                item.Result = result;
            }
            else
            {
                item.Result = "notrated";
            }
            _db.UpdateResult(item.Id, item.Result);
        }

        public void ChangeObserveColor()
        {
            if ((Skip || Change || Unclear || Maybe_Not) && Result == "notrated")
            {
                ResultStrokeColor = Color.FromRgb(255, 165, 0);
                ResultFillColor = Color.White;
            }
            else if ((Skip || Change || Unclear || Maybe_Not) && Result != "notrated")
            {
                ResultStrokeColor = Color.FromRgb(255, 165, 0);
                ResultFillColor = Color.FromRgb(255, 165, 0);
            }
            else if (Result != "notrated")
            {
                ResultStrokeColor = Color.FromRgb(23, 96, 127);
                ResultFillColor = Color.FromRgb(23, 96, 127);
            }
            else
            {
                ResultStrokeColor = Color.FromRgb(23, 96, 127);
                ResultFillColor = Color.White;
            }

            OrderColor = (ResultFillColor == Color.White) ? ResultStrokeColor : Color.White;
        }

        public void ToggleObservation(object sender)
        {
            var view = new AssessmentPage();
            view.OpenItem(sender);
        }

        private Action<ObservationViewModel> ToggleMark(Func<bool> toggle, string mark)
        {
            return (item) =>
            {
                if (toggle())
                {
                    _db.AddMark(item.Id, mark);
                }
                else
                {
                    _db.RemoveMark(item.Id, mark);
                }

                ChangeObserveColor();
            };
        }

        private readonly Database _db = new Database();
    }
}

