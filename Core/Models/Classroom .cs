using Core.Enums;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Classroom
    {
        private static int _id;
        public int Id;
        public string Name { get; set; }
        public int StudentLimit { get; set; }

        private InformationField _classroomType;
        public InformationField ClassroomType
        {
            get { return _classroomType; }
            set
            {
                if (value == InformationField.Backend)
                {
                    _classroomType = value;
                    StudentLimit = 20;
                }
                else if (value == InformationField.Frontend)
                {
                    _classroomType = value;
                    StudentLimit = 15;
                }


            }
        }
        public Classroom(string name, InformationField classType)
        {
            _id++;
            Id = _id;
            Name = name;
            ClassroomType = classType;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Class Type: {ClassroomType}; Limit: {StudentLimit}";
        }

        public Student[] Students = new Student[] { };

        public async Task AddStudent(Student student)
        {
            await Task.Run(() =>
            {
                if (Students.Length < StudentLimit)
                {
                    Students.Add(student);

                }
                else
                {
                    throw new OutOfLimitException("Limitden kenara cixildi!");
                }
            });
        }

        public async Task GetAllStudents()
        {
            await Task.Run(() =>
            {
                Students.ForEach(item => Console.WriteLine(item));
            });
        }

        public async Task GetStudentFindId(int id)
        {
            await Task.Run(() =>
            {
                Students.Find(item => item.Id == id);
            });
        }


        public async Task RemoveStudent(int id)
        {

            await Task.Run(() =>
            {
                Students.Remove(Students.Find(item => item.Id == id));
            });
        }


    }
}
