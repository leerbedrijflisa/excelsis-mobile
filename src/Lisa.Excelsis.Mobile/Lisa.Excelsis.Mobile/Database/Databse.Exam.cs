using System;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    partial class Database
    {        
        public Exam FetchExam(int id)
        {
            var exam_data = _db.Table<Examdb>().Where(x => x.Id == id).FirstOrDefault();
            var categories = _db.Table<Exam_Categorydb>().Where(x => x.ExamId == exam_data.Id);

            var exam = new Exam()
            {
                Id = exam_data.Id,
                Name = exam_data.Name,
                NameId = exam_data.NameId,
                Subject = exam_data.Subject,
                SubjectId = exam_data.SubjectId,
                Cohort = exam_data.Cohort.ToString(),
                Crebo = exam_data.Crebo.ToString(),
                Categories = new List<Exam_Category>()
            };

            foreach(var category_data in categories)
            {
                var criteria = _db.Table<Criteriondb>().Where(x => x.CategoryId == category_data.Id);

                var category = new Exam_Category()
                {
                    Id = category_data.Id,
                    Order = category_data.Order,
                    Name = category_data.Name,
                    Criteria = new List<Criterion>()
                };

                foreach (var criterion_data in criteria)
                {
                    var criterion = new Criterion()
                    {
                        Id = criterion_data.Id,
                        Order = criterion_data.Order,
                        Title = criterion_data.Title,
                        Description = criterion_data.Description,
                        Weight = criterion_data.Weight
                    };
                    category.Criteria.Add(criterion);
                }
                exam.Categories.Add(category);
            }
            return exam;
        }

        public void SaveExams(List<Exam> exams)
        {            
            foreach (var exam in exams)
            {
                var examsfromdb = _db.Query<Examdb>("SELECT * FROM Exams WHERE name = ? AND subject = ? AND cohort = ? ", exam.Name, exam.Subject, exam.Cohort);
                if (examsfromdb.Count == 0)
                {
                    var eId = new Examdb()
                    {
                        Name = exam.Name,
                        NameId = exam.NameId,
                        Subject = exam.Subject,
                        SubjectId = exam.SubjectId,
                        Cohort = Convert.ToInt32(exam.Cohort),
                        Crebo = Convert.ToInt32(exam.Crebo)
                    };
                    _db.Insert(eId);

                    foreach (var category in exam.Categories)
                    {
                        var cId = new Exam_Categorydb()
                        {
                            Name = category.Name,
                            Order = category.Order,
                            ExamId = eId.Id
                        };
                        _db.Insert(cId);

                        foreach (var criterion in category.Criteria)
                        {
                            var crId = new Criteriondb()
                            {
                                Order = criterion.Order,
                                Title = criterion.Title,
                                Description = criterion.Description,
                                Weight = criterion.Weight,
                                ExamId = eId.Id,
                                CategoryId = cId.Id
                            };
                            _db.Insert(crId);
                        }
                    }
                }
            }
        }
    }
}

