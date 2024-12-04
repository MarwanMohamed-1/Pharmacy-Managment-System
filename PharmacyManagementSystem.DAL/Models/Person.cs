using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  PharmacyManagementSystem.DAL.Models

{
    public abstract class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone_Num { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
