using System;
using System.Collections.Generic;
using System.Linq;

namespace Lisa.Excelsis.Mobile
{
    public partial class CreateAssessmentPage
    {
        private void SaveAssessment()
        {
            Assessors = new List<string>();
            Assessordb assessor;

            var assessmentMetaData = new Assessmentdb
            {
                Assessed = ExamDate.Date,
                StudentName = StudentName?.Text,
                StudentNumber = StudentNumber?.Text,
                Subject = _exam.SubjectId,
                Crebo = _exam.Crebo.ToString(),
                Name = _exam.NameId,
                Cohort = _exam.Cohort.ToString()
            };
            
            _db.Insert(assessmentMetaData);

            assessor = (from s in _db.Table<Assessordb>() 
                        where s.UserName == AssessorPicker.Items[AssessorPicker.SelectedIndex] 
                        select s).FirstOrDefault();
            
            var assessmentAssessor = new AssessmentAssessordb
            {
                AssessmentId = assessmentMetaData.Id,
                AssessorId = assessor.Id
            };
            
            Assessors.Add(assessor.UserName);
            _db.Insert(assessmentAssessor);

            if (SecondAssessorPicker.SelectedIndex != -1)
            {
                assessor = (from s in _db.Table<Assessordb>() 
                            where s.UserName == SecondAssessorPicker.Items[SecondAssessorPicker.SelectedIndex]
                            select s).FirstOrDefault();
                               
                assessmentAssessor = new AssessmentAssessordb
                {
                    AssessmentId = assessmentMetaData.Id,
                    AssessorId = assessor.Id
                };
                
                Assessors.Add(assessor.UserName);
                _db.Insert(assessmentAssessor);
            }
        }
    }
}

