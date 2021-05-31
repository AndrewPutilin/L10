using Lecture10.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture10.DAL.MemoryStorage
{
    public interface IGroupStorage
    {
        void AddStudent(Group group, string fullName);
        void DeleteStudent(int id);
        void ChangeStudent(Group group, string fullName, int id);
        Student GetStudentGetStudentById(int id);
        Group GetGroupByIdGroup(int id);
        IReadOnlyCollection<Group> GetAll();
    }
}
