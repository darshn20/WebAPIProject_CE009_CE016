using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class User
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
         [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
         [JsonProperty(PropertyName = "Gender")]
        public string Gender { get; set; }
         [JsonProperty(PropertyName = "DOB")]
        public DateTime DOB { get; set; }
         [JsonProperty(PropertyName = "Type")]
        public UserType Type { get; set; }
        [JsonProperty(PropertyName = "Subject")]
        public string Subject {get;set;}
        [JsonProperty(PropertyName = "Std")]
        public int Std { get; set; }
    }
    public enum UserType
    {
        Student = 1,
        Teacher = 2
    }
}
