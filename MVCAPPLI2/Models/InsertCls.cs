using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCAPPLI2.Models
{
    public class stclass
    {
        public int sId { get; set; }
        public string sName { get; set; }
    }
    public class checkBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class InsertCls
    {
        public int sId { get; set; }
        public string sName { get; set; }
        public List<checkBoxListHelper> MyfavoriteQual { get; set; }
        public string[] selectedQual { get; set; }
        public string Qual { get; set; }

        [Required(ErrorMessage ="Enter name")]
        public string Name { get; set; }
        [Range(18,60,ErrorMessage ="enter valid age")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Enter the address")]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage ="Enter valid email")]
        [Required(ErrorMessage ="Enter an email")]
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password mismatch")]
        public string CPassword { get; set; }
        public string msg { get; set; }
    }
}