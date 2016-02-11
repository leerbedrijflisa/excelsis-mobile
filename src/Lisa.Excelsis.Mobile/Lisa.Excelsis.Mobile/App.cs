﻿using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class App : Application
    {
        public App()
        {
            
        }

        protected override void OnStart()
        {
            // make sure the tables are created before doing any database logic
            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.CreateTable<Examdb>();
            db.CreateTable<Assessordb>();
            db.CreateTable<AssessmentAssessordb>();
            db.CreateTable<Assessmentdb>();
            db.CreateTable<Categorydb>();
            db.CreateTable<Observationdb>();
            db.CreateTable<Criteriondb>();

            base.OnStart();

            MainPage = new RootPage();
        }
    }
}