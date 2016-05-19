using Xamarin.Forms;
using System.Collections.Generic;
using System;

namespace Lisa.Excelsis.Mobile
{
    public partial class AssessmentPage : ContentPage
    {
        public AssessmentPage(Assessmentdb item = null, Exam exam = null)
        {
            if (item != null)
            {
                assessment = _db.FetchAssessment(item.Id);
                if (assessment == null)
                {
                    Navigation.PopAsync();
                }
            }
            else
            {
                var id = _db.InsertAssessment(exam);
                assessment = _db.FetchAssessment(id);
            }

            InitializeComponent();
            Title = assessment.Exam.Subject + " - " + assessment.Exam.Name + " " + assessment.Exam.Cohort;

            assessmentView = new AssessmentViewModel(this.Navigation, this)
            {
                Id = assessment.Id,
                Note = assessment.Note,
                Assessed = assessment.Assessed,
                Assessors = assessment.Assessors,
                Student = assessment.Student,
                Exam = assessment.Exam
            };
            assessmentView.OnTogglePopup += TogglePopup;

            assessmentView.Categories = new List<CategoryViewModel>();
            foreach (var categories in assessment.Categories)
            {
                var _category = new CategoryViewModel()
                {
                    Order = categories.Order.ToString(),
                    Name = categories.Name
                };

                _category.Observations = new List<ObservationViewModel>();
                foreach (var observations in categories.Observations)
                {
                    var _observation = new ObservationViewModel()
                    {
                        Id = observations.Id.ToString(),
                        Result = observations.Result,
                        Criterion = observations.Criterion,
                        Maybe_Not = observations.Marks.Contains("maybenot"),
                        Skip = observations.Marks.Contains("skip"),
                        Unclear = observations.Marks.Contains("unclear"),
                        Change = observations.Marks.Contains("change")
                    };
                    UpdateFooter(_observation, "notrated");
                    _observation.OnTogglePopup += TogglePopup;
                    _observation.OnResultChanged += UpdateFooter;
                    _observation.OnToggleChanged += ToggleItem;
                    _observation.ChangeObserveColor();
                    _category.Observations.Add(_observation);
                }
                assessmentView.Categories.Add(_category);
            }

            BindingContext = assessmentView;
            ExamDate.Date = assessmentView.Assessed.Date;
            ExamTime.Time = TimeZoneInfo.ConvertTime(assessmentView.Assessed, TimeZoneInfo.Local).TimeOfDay;
            ExamTime.PropertyChanged += DateTimeChanged;

            _popupHolder = PopupHolder;
            Container.Children.Remove(PopupHolder);
            _containerOverlay = ContainerOverlay;
            Container.Children.Remove(ContainerOverlay);

            EditorText.TextChanged += OnEditorTextChanged;
        }

        public void UpdateFooter(ObservationViewModel item, string result)
        {
            switch (item.Criterion.Weight)
            {
                case "fail":
                    if (result != "notrated" && item.Result == "seen")
                    {
                        assessmentView.TotalFail--;
                    }
                    else if (result == "seen" || (item.Result == "seen" && result == "notrated"))
                    {
                        assessmentView.TotalFail++;
                    }
                    break;
                case "pass":
                    if (result != "notrated" && item.Result == "seen")
                    {
                        assessmentView.TotalPass--;
                    }
                    else if (result == "seen" || (item.Result == "seen" && result == "notrated"))
                    {
                        assessmentView.TotalPass++;
                    }
                    break;
                case "excellent":
                    if (result != "notrated" && item.Result == "seen")
                    {
                        assessmentView.TotalExcellent--;
                    }
                    else if (result == "seen" || (item.Result == "seen" && result == "notrated"))
                    {
                        assessmentView.TotalExcellent++;
                    }
                    break;
            }
        }

        public void EntryChanged(object sender, EventArgs e)
        {
            var entry = (Entry)sender;

            if (entry.Text != null && entry.Text.Length != 0)
            {
                int iDontCare;
                if (entry.Keyboard == Keyboard.Numeric && Int32.TryParse(entry.Text, out iDontCare))
                {
                    entry.BackgroundColor = Color.Default;
                    _db.UpdateStudent(assessment.Id, "Studentnumber", entry.Text);
                }
                else
                {
                    if (entry.Keyboard == Keyboard.Default)
                    {
                        _db.UpdateStudent(assessment.Id, "Studentname", entry.Text);
                    }
                    return;
                }

                entry.BackgroundColor = Color.Default;
            }
        }

        public void DateTimeChanged(object sender, EventArgs e)
        {
            DateTime date = new DateTime(ExamDate.Date.Year, ExamDate.Date.Month, ExamDate.Date.Day,
                                         ExamTime.Time.Hours, ExamTime.Time.Minutes, ExamTime.Time.Seconds);
            _db.UpdateAssessed(assessment.Id, date);
        }

        public void TimeChanged(object sender, EventArgs e)
        {
            var picker = (TimePicker)sender;
        }

        public void ToggleItem(object sender)
        {
            var stacklayout = sender as StackLayout;
            var item = stacklayout.BindingContext as ObservationViewModel;
            var row = stacklayout.FindByName<RowDefinition>("ShowButtons");

            if (_oldItem != null && _oldItem != item)
            {
                _oldAnimation.Commit(_oldPage, "the old animation", length: 100);
                _oldItem.IsSelected = false;
            }
            if (item.IsSelected)
            {
                CollapseAnimation(row).Commit(this, "the animation", length: 100);
                item.IsSelected = false;
            }
            else
            {
                item.IsSelected = true;
                ExpandAnimation(row).Commit(this, "the animation", length: 100);
            }

            _oldRow = row;
            _oldItem = item;
            _oldPage = this;
            _oldAnimation = CollapseAnimation(row);
        }

        public void TogglePopup(string popup, object sender = null)
        {
            switch (popup)
            {
                case "info":
                    if (sender != null)
                    {
                        Container.Children.Add(_containerOverlay);
                        Container.Children.Add(_popupHolder);
                        var observation = sender as ObservationViewModel;
                        InfoPopupLabel.Text = (observation.Criterion.Description.Length > 0) ? observation.Criterion.Description : "Geen beschrijving aanwezig";
                        InfoPopupLabelTitle.Text = (observation.Criterion.Title.Length > 0) ? observation.Criterion.Title.TrimEnd('.') : "Geen titel beschikbaar";
                    }
                    else
                    {
                        Container.Children.Remove(_containerOverlay);
                        Container.Children.Remove(_popupHolder);
                        InfoPopupLabel.Text = string.Empty;
                    }
                    InfoPopup.IsVisible = !InfoPopup.IsVisible;
                    EditorPopup.IsVisible = false;
                    break;
                case "editor":
                    if (EditorPopup.IsVisible)
                    {
                        Container.Children.Remove(_containerOverlay);
                        Container.Children.Remove(_popupHolder);
                    }
                    else
                    {
                        Container.Children.Add(_containerOverlay);
                        Container.Children.Add(_popupHolder);
                    }

                    InfoPopup.IsVisible = false;
                    EditorPopup.IsVisible = !EditorPopup.IsVisible;
                    break;
            }
        }

        private void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != null)
            {
                assessment.Note = e.NewTextValue;
                _db.UpdateAssessmentNote(assessment.Id, e.NewTextValue);
            }
        }

        private Animation ExpandAnimation(RowDefinition row)
        {
            return new Animation(
                (d) => row.Height = Anim(d, 0, double.MaxValue), row.Height.Value, _rowHeight, Easing.Linear);
        }

        private Animation CollapseAnimation(RowDefinition row)
        {
            return new Animation(
                (d) => row.Height = new GridLength(Anim(d, 0, double.MaxValue)), _rowHeight, 0, Easing.Linear);
        }

        private double Anim(double value, double minValue, double maxValue)
        {
            if (value < minValue)
            {
                return minValue;
            }

            if (value > maxValue)
            {
                return maxValue;
            }

            return value;
        }

        private static BoxView _containerOverlay;
        private static StackLayout _popupHolder;
        private static double _rowHeight = 230; //90
        private static Animation _oldAnimation;
        private static RowDefinition _oldRow;
        private static Page _oldPage;
        private static ObservationViewModel _oldItem;
        private static Assessment assessment;
        private static AssessmentViewModel assessmentView;
        private readonly Database _db = new Database();
    }
}

