using Lecture10.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture10.DAL.MemoryStorage
{
    public class GroupMemoryStorage : IGroupStorage
    {
        public  List<Group> groups;
        private int lastId;
        public GroupMemoryStorage()
        {
            groups = new List<Group>
            {
                new Group
                {
                    Id = 1,
                    Name = "Радиофизика",
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Id = 1,
                            FullName = "Иванов Иван Иванович"
                        },
                        new Student
                        {
                            Id = 2,
                            FullName = "Петров Петр Петрович"
                        }
                    }
                },
                new Group
                {
                    Id = 2,
                    Name = "Микроэлектроника",
                    Students = new List<Student>
                    {
                        new Student
                        {
                            Id = 3,
                            FullName = "Сидоров Сидор Сидорович"
                        }                        
                    }
                },
                new Group
                {
                    Id = 3,
                    Name = "Общая физика",
                    Students = new List<Student>
                    {

                    }
                }
            };
            lastId = 3;
        }
        public void AddStudent(Group group, string fullName)
        {
            Student stdnt = new Student()
            {
                Id = lastId + 1,
                FullName = fullName
            };
            group.Students.Add(stdnt);
        }

        public void ChangeStudent(Group group, string fullName, int id)
        {
            var changeStudent = GetStudentGetStudentById(id);
            changeStudent.FullName = fullName;
            DeleteStudent(id);
            group.Students.Add(changeStudent);

        }

        public void DeleteStudent(int id)
        {

            var gr = GetGroupByIdStunet(id);
            var stdnt = GetStudentGetStudentById(id);
            foreach (var g in groups)
            {
                if (g == gr)
                {
                    g.Students.Remove(stdnt);
                }
            }

        }

        public Student GetStudentGetStudentById(int id)
        {
            var gr = GetGroupByIdStunet(id);
            var stdnt = (from Student in gr.Students
                         where Student.Id == id
                         select Student).FirstOrDefault();
            return stdnt;
        }
        public Group GetGroupByIdGroup(int id)
        {
            var gr = (from Group in groups                      
                      where Group.Id == id
                      select Group).FirstOrDefault();
            return gr;
        }
        public Group GetGroupByIdStunet(int id)
        {
            var gr = (from Group in groups
                      from Student in Group.Students
                      where Student.Id == id
                      select Group).FirstOrDefault();
            return gr;
        }
        public IReadOnlyCollection<Group> GetAll()
        {
            return groups;
        }
    }
}
