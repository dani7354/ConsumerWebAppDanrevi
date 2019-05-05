using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Course
{
    public abstract class CourseBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set;}
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public string Host { get; set; }
        [JsonProperty("target_audience")]
        [Required]
        public string TargetAudience { get; set; }
    }
}
