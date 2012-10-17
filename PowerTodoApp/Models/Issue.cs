using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerTodoApp.Models
{
    public class Issue
    {
        [Key] public int Key { get; set; }
        [Required] public string Title { get; set; }
        public string Owner { get; set; }
        public string Content { get; set; }
        public int Priority { get; set; }
    }


}