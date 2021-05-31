using System;
using System.Collections.Generic;
using System.Linq;
using Lecture10.DAL.Domain;

namespace Lecture10.Models
{
    public class StudentEditModel
    {
        public IReadOnlyCollection<Group> AllGroups { get; set; }
        public Student Student { get; set; }
        public Group SelectedGroup { get; set; }
    }
}
