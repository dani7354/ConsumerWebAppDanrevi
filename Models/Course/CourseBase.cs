using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Course
{
    public abstract class CourseBase
    {
       
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        [Required]
        [JsonProperty("location")]
        public string Location { get; set;}
        [Required]
        [JsonProperty("start")]
        public DateTime Start { get; set; }
        [Required]
        [JsonProperty("end")]
        public DateTime End { get; set; }
        [Required]
        [JsonProperty("host")]
        public string Host { get; set; }
        [JsonProperty("target_audience")]
        public string TargetAudience { get; set; }
    }
}
