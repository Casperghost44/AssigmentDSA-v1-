using System;
using System.Collections.Generic;
using System.Text;

namespace AssigmentDSA_v1_.Entities
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public float AverageScore { get; set; }

        public override string ToString()
        {
            return $"First name: {FirstName}; Last name: {LastName}; Student #: {StudentNumber}; AverageScore: {AverageScore}";
        }
    }
}
