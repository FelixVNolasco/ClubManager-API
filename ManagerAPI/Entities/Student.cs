using System;
using ManagerAPI.Common;

namespace ManagerAPI.Entities
{
    public class Student : IEntity
    {
        public int StudentId { get; set; }
        public string boleta { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string career { get; set; }
        public string school { get; set; }
        public bool signedUp { get; set; }

    }
}
