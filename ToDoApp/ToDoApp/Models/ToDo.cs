using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Column("nvarchar(250)")]
        [Required]
        public string Name { get; set; }
        [Column("varchar(250)")]
        public string Description { get; set; }
        [Column("datetime")]
        [DisplayName("Date & Time")]
        public DateTime DateTime { get; set; }
    }
}
