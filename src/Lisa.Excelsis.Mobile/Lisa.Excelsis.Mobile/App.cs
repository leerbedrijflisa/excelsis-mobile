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

            db.CreateTable<Exam>();
            db.CreateTable<Assessor>();
            db.CreateTable<AssessmentAssessor>();
            db.CreateTable<Assessment>();
            db.CreateTable<Student>();

            base.OnStart();

            MainPage = new NavigationPage(new HomePage());
        }
    }
}