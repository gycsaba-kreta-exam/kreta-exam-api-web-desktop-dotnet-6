﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories;
using Kreta.Models;

namespace Kreta.Services
{
    public class Statistics
    {
        private SchoolClassesRepo  schoolClassesRepo;
        private StudentsRepo studentsRepo;
        private SubjectRepo subjectRepo;
        private TeachersRepo teachersRepo;

        public Statistics()
        {
            schoolClassesRepo = new SchoolClassesRepo();
            studentsRepo = new StudentsRepo();
            subjectRepo = new SubjectRepo();
            teachersRepo = new TeachersRepo();
        }

        // Repók példányosíátsa

        public int GetNumerOfStudenst()
        {
            return studentsRepo.Students.Count;
        }

        public int GetNumberOfClasses()
        {
            return schoolClassesRepo.SchoolClasses.Count;
        }

        public int GetNumberOfSubjects()
        {
            return subjectRepo.Subject.Count;
        }

        public Dictionary<string, int> GetStudentPerClasses()
        {
            Dictionary<string, int> studentPerClasses = new Dictionary<string, int>();
            foreach (SchoolClass schoolClass in schoolClassesRepo.SchoolClasses)
            {
                // Az osztály id meghatározása
                int classId = schoolClass.Id;

                //az adott osztály diákjainak a száma
                int numberOfStudentsInSchoolClass = studentsRepo.Students.FindAll(student => student.SchoolClassId == classId).Count;

                // Egy bejegyzés a Dictionary-be
                studentPerClasses.Add(schoolClass.GradeGradeType, numberOfStudentsInSchoolClass);
            }

            return studentPerClasses;
        }

        public Dictionary<string, string> GetTeacherPerClasses()
        {
            Dictionary<string, string> teacherPerClasses = new Dictionary<string, string>();

            foreach (SchoolClass schoolClass in schoolClassesRepo.SchoolClasses)
            {
                int classId = schoolClass.TeacherId;
                string teacherOfClass = teachersRepo.Teachers.Where(teacher => teacher.Id == classId).Select(teacher => teacher.TeacherName).SingleOrDefault();
                teacherPerClasses.Add(schoolClass.GradeGradeType, teacherOfClass);

            }
            return teacherPerClasses;
        }
    }
}
