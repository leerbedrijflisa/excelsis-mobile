using System;
using System.Collections.Generic;
using System.Linq;

namespace Lisa.Excelsis.Mobile
{
    partial class Database
    {
        public Assessment FetchAssessment(int id)
        {
            var assessment_metadata = _db.Table<Assessmentdb>().Where(x => x.Id == id).FirstOrDefault();
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

        public int SaveAssessment(Assessment assessment)
        {
            var adb = new Assessmentdb()
            {
                Assessed = assessment.Assessed,
                Name = assessment.Exam.Name,
                Subject = assessment.Exam.Subject,
                Crebo = assessment.Exam.Crebo,
                Cohort = assessment.Exam.Cohort,               
                StudentName = assessment.Student.Name,
                StudentNumber = assessment.Student.Number
            };
             _db.Insert(adb);
            assessment.Id = adb.Id;
            
            foreach (var category in assessment.Categories)
            {
                var cdb = new Categorydb()
                {
                    Name = category.Name,
                    Order = category.Order,
                    AssessmentId = assessment.Id
                };
                _db.Insert(cdb);
                category.Id = cdb.Id;
                
                foreach (var observation in category.Observations)
                {
                    var odb = new Observationdb()
                    {
                        Result = observation.Result,
                        Order = observation.Criterion.Order,
                        Title = observation.Criterion.Title,
                        Description = observation.Criterion.Description,
                        Weight = observation.Criterion.Weight,
                        CategoryId = category.Id,
                        AssessmentId = assessment.Id
                    };
                    _db.Insert(odb);
                    observation.Id = odb.Id;
                    
                    foreach (var mark in observation.Marks)
                    {
                        var mdb = new Markdb()
                        {
                            Name = mark,
                            ObservationId = observation.Id,
                            AssessmentId = assessment.Id
                        };
                        _db.Insert(mdb);
                    }
                }
            }
            return adb.Id;
        }

        public int InsertAssessment(Exam exam)
        {
            var adb = new Assessmentdb()
            {
                Assessed = DateTime.Now,
                Name = exam.Name,
                Subject = exam.Subject,
                Crebo = exam.Crebo,
                Cohort = exam.Cohort,
                StudentName = "",
                StudentNumber = ""
            };
            _db.Insert(adb);

            foreach (var category in exam.Categories)
            {
                var cdb = new Categorydb()
                {
                    Name = category.Name,
                    Order = category.Order,
                    AssessmentId = adb.Id
                };
                _db.Insert(cdb);

                foreach (var criterion in category.Criteria)
                {
                    var odb = new Observationdb()
                    {
                        Result = "notrated",
                        Order = criterion.Order,
                        Title = criterion.Title,
                        Description = criterion.Description,
                        Weight = criterion.Weight,
                        CategoryId = cdb.Id,
                        AssessmentId = adb.Id
                    };
                    _db.Insert(odb);
                }
            }
            return adb.Id;
        }

        public void UpdateAssessed(object id, DateTime assessed)
        {
            _db.Execute("UPDATE Assessments SET Assessed = ? WHERE Assessments.Id == ?", assessed, id);
        }

        public void UpdateStudent(object id, string field, string text)
        {
            _db.Execute("UPDATE Assessments SET " + field + " = ? WHERE Assessments.Id == ?", text, id);
        }

        public void UpdateResult(object id, string result)
        {
            _db.Execute("UPDATE Observations SET Result = ? WHERE Observations.Id == ?", result, id);
        }

        public void AddMark(object id, string mark)
        {
            _db.Query<Markdb>("INSERT INTO Marks (Name, ObservationId) VALUES (?,?) ", mark, id);
        }

        public void RemoveMark(object id, string mark)
        {
            _db.Execute("DELETE FROM Marks WHERE Name = ? AND ObservationId = ? ", mark, id);
        }

        public void RemoveAssessment(object id)
        {
            _db.Execute("DELETE FROM Assessments WHERE Id = ?", id);
            _db.Execute("DELETE FROM Categories WHERE AssessmentId = ?", id);
            _db.Execute("DELETE FROM Observations WHERE AssessmentId = ?", id);
            _db.Execute("DELETE FROM Marks WHERE AssessmentId = ?", id);
        }
    }
}

