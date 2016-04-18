namespace Lisa.Excelsis.Mobile
{
    public delegate void ResultEventHandler(ObservationViewModel item, string result);

    public delegate void NewAssessmentEventHandler();

    public delegate void OpenAssessmentEventHandler(Assessmentdb item);

    public delegate void ToggleObservationEventHandler(object item);
}
