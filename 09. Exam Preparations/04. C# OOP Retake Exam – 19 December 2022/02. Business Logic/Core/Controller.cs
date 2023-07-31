using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core;

public class Controller : IController
{
    //Fields
    private SubjectRepository subjects;
    private StudentRepository students;
    private UniversityRepository universities;

    public Controller()
    {
        subjects = new SubjectRepository();
        students = new StudentRepository();
        universities = new UniversityRepository();
    }

    //Methods
    public string AddStudent(string firstName, string lastName)
    {
        //Already Added Student
        if (students.FindByName($"{firstName} {lastName}") != null)
        {
            return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
        }

        //Adding Student
        students.AddModel(new Student(students.Models.Count+1, firstName, lastName));
        return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
    }

    public string AddSubject(string subjectName, string subjectType)
    {
        //Subject Type Not Supported
        if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(EconomicalSubject) &&
                subjectType != nameof(HumanitySubject))
        {
            return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
        }

        //Already Added Subject
        if ((subjects.FindByName(subjectName) != null))
        {
            return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
        }

        //Adding The Subject
        ISubject subject;

        if (subjectType == nameof(TechnicalSubject))
        {
            subject = new TechnicalSubject(subjects.Models.Count+1, subjectName);
        }
        else if (subjectType == nameof(EconomicalSubject))
        {
            subject = new EconomicalSubject(subjects.Models.Count+1, subjectName);
        }
        else
        {
            subject = new HumanitySubject(subjects.Models.Count+1, subjectName);
        }

        subjects.AddModel(subject);
        return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
    }

    public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
    {
        //Already Added University
        if (universities.FindByName(universityName) != null)
        {
            return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
        }

        //Converting And Adding
        ICollection<int> subjectsIds = new List<int>();

        foreach (var subject in requiredSubjects)
        {
            subjectsIds.Add(subjects.FindByName(subject).Id);
        }

        universities.AddModel(new University(universities.Models.Count+1, universityName, category, capacity, subjectsIds));

        return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
    }

    public string ApplyToUniversity(string studentName, string universityName)
    {
        //Student Doesnt't Exist
        string[] studentFullName = studentName.Split(" ");
        string studentFirstName = studentFullName[0];
        string studentLastName = studentFullName[1];

        if (students.FindByName(studentName) == null)
        {
            return String.Format(OutputMessages.StudentNotRegitered, studentFirstName, studentLastName);
        }

        //University Doesnt't Exist
        if (universities.FindByName(universityName) == null)
        {
            return String.Format(OutputMessages.UniversityNotRegitered, universityName);
        }

        //Student Hasn't Covered All The Required Exams For The Current University
        IStudent currentStudent = students.FindByName(studentName);
        IUniversity currentUniversity = universities.FindByName(universityName);

        foreach (var currentSubject in currentUniversity.RequiredSubjects)
        {
            if (!currentStudent.CoveredExams.Contains(currentSubject))
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
        }

        //Student Has Already Joined The Current University
        if (currentStudent.University == currentUniversity)
        {
            return String.Format(OutputMessages.StudentAlreadyJoined, studentFirstName, studentLastName, universityName);
        }

        //Joining The University
        currentStudent.JoinUniversity(currentUniversity);
        return String.Format(OutputMessages.StudentSuccessfullyJoined, studentFirstName, studentLastName, universityName);
    }

    public string TakeExam(int studentId, int subjectId)
    {
        //Student Doesn't Exist
        if (students.FindById(studentId) == null)
        {
            return String.Format(OutputMessages.InvalidStudentId);
        }

        //Subject Doesn't Exist
        if (subjects.FindById(subjectId) == null)
        {
            return String.Format(OutputMessages.InvalidSubjectId);
        }

        //Student Already Covered The Current Exam
        IStudent currentStudent = students.FindById(studentId);
        ISubject currentSubject = subjects.FindById(subjectId);

        if (currentStudent.CoveredExams.Contains(subjectId))
        {
            return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, currentStudent.FirstName, currentStudent.LastName, currentSubject.Name);
        }

        //Successfully Covered The Exam
        currentStudent.CoverExam(currentSubject);
        return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, currentStudent.FirstName, currentStudent.LastName, currentSubject.Name);
    }

    public string UniversityReport(int universityId)
    {
        IUniversity university = this.universities.FindById(universityId);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"*** {university.Name} ***");
        sb.AppendLine($"Profile: {university.Category}");
        sb.AppendLine($"Students admitted: {this.students.Models.Where(s => s.University == university).Count()}");
        sb.AppendLine($"University vacancy: {university.Capacity - this.students.Models.Where(s => s.University == university).Count()}");

        return sb.ToString().TrimEnd();
    }
}