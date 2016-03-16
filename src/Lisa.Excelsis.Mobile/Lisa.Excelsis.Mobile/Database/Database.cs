using System;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Lisa.Excelsis.Mobile
{
    public class Database
    {
        public Database()
        {
        }

        public Assessment FetchAssessment()
        {
            var assessment_metadata = _db.Table<Assessmentdb>().FirstOrDefault();
            var categories = _db.Table<Categorydb>().Where(x => x.AssessmentId == assessment_metadata.Id);

            if (assessment_metadata != null)
            {
                var assessment = new Assessment()
                {
                    Id = assessment_metadata.Id,
                    Assessed = assessment_metadata.Assessed,
                    Exam = new Exam()
                    {
                        Name = assessment_metadata.Name,
                        Subject = assessment_metadata.Subject,
                        Crebo = assessment_metadata.Crebo,
                        Cohort = assessment_metadata.Cohort
                    },
                    Student = new Student()
                    {
                        Name = assessment_metadata.StudentName,
                        Number = assessment_metadata.StudentNumber
                    },
                    Categories = new List<Category>()
                };

                foreach (var category_metadata in categories)
                {
                    var observations = _db.Table<Observationdb>().Where(x => x.CategoryId == category_metadata.Id);

                    var category = new Category()
                    {
                        Id = category_metadata.Id,
                        Name = category_metadata.Name,
                        Order = category_metadata.Order,
                        Observations = new List<Observation>()
                    };

                    foreach (var observation_metadata in observations)
                    {
                        var marks = _db.Table<Markdb>().Where(x => x.ObservationId == observation_metadata.Id);

                        var observation = new Observation()
                        {
                                Id = observation_metadata.Id,
                                Result = observation_metadata.Result,
                                Criterion = new Criterion()
                                {
                                    Title = observation_metadata.Title,
                                    Description = observation_metadata.Description,
                                    Order = observation_metadata.Order,
                                    Weight = observation_metadata.Weight
                                },
                                Marks = marks.Select(x => x.Name).ToList()
                        };

                        category.Observations.Add(observation);
                    }
                    assessment.Categories.Add(category);
                }
                return assessment;
            }
            return null;
        }

        public void SaveAssessment(Assessment assessment)
        {
            var adb = new Assessmentdb()
            {
                Id = assessment.Id,
                Assessed = assessment.Assessed,
                Name = assessment.Exam.Name,
                Subject = assessment.Exam.Subject,
                Crebo = assessment.Exam.Crebo,
                Cohort = assessment.Exam.Cohort,               
                StudentName = assessment.Student.Name,
                StudentNumber = assessment.Student.Number
            };
            _db.InsertOrReplace(adb);

            var categoryList = new List<Categorydb>();
            foreach (var category in assessment.Categories)
            {
                var cdb = new Categorydb()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Order = category.Order,
                    AssessmentId = assessment.Id
                };
                categoryList.Add(cdb);

                var observationList = new List<Observationdb>();
                foreach (var observation in category.Observations)
                {
                    var odb = new Observationdb()
                    {
                        Id = observation.Id,
                        Result = observation.Result,
                        Order = observation.Criterion.Order,
                        Title = observation.Criterion.Title,
                        Description = observation.Criterion.Description,
                        Weight = observation.Criterion.Weight,
                        CategoryId = category.Id
                    };
                    observationList.Add(odb);

                    var markList = new List<Markdb>();
                    foreach (var mark in observation.Marks)
                    {
                        var mdb = new Markdb()
                        {
                            Name = mark,
                            ObservationId = observation.Id
                        };
                        markList.Add(mdb);
                    }
                    _db.InsertOrReplaceAll(markList);
                }
                _db.InsertOrReplaceAll(observationList);
            }
            _db.InsertOrReplaceAll(categoryList);
        }

        public void UpdateResult(object id, string result)
        {
            _db.Query<Observationdb>("UPDATE Observations SET Result = ? WHERE Observations.Id == ?", result, id);
        }

        public void AddMark(object id, string mark)
        {
            _db.Query<Markdb>("INSERT INTO Marks (Name, ObservationId) VALUES (?,?) ", mark, id);
        }

        public void RemoveMark(object id, string mark)
        {
            _db.Query<Markdb>("DELETE FROM Marks WHERE Name = ? AND ObservationId = ? ", mark, id);
        }


        private readonly SQLiteConnection _db = DependencyService.Get<ISQLite>().GetConnection();
    }
}

