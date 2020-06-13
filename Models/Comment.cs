using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebCommentsSection.Models {
    public class Comment {
        public int ID { get; set; }

        [Required, RegularExpression(@"^[A-Z]+[a-zA-Z0-9]*$")]
        public string Name { get; set; }

        [Required, StringLength(1000, MinimumLength = 1)]
        public string Message { get; set; }
        
        [Display(Name = "Date"), DataType(DataType.Date)]
        public DateTime Timestamp { get; set; }

        [Range(0,5)]
        public int Rating { get; set; }
    }
}
