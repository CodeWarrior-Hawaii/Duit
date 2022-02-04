using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duit.DAL.Entities
{
    public class ToDosTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Description { get; set; }
        [DisplayName("Complete")]
        public bool Completed { get; set; }
        public DateTime? CompletedDateTime { get; set; }
        public DateTime? DueDateTime { get; set; }

    }
}
