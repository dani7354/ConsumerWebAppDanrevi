using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Models.Course
{
    public class CourseDetailsViewModel : CourseBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public List<Participant> Participants { get; set; }

    }
}
