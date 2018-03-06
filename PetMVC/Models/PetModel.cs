using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMVC.Models
{
    public class PetModel
    {
        [Key]
        public int PetID { get; set; }
        public string PetName { get; set; }
        public int Age { get; set; }
        

    }
}