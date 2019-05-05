using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Course
{
    public abstract class CourseBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set;}
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Host { get; set; }
        [JsonProperty("target_audience")]
        public string TargetAudience { get; set; }
    }
}
