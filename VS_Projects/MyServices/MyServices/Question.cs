using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyServices
{
    // to use a type as return type or param type for an operation
    // it must have [DataContract] attribute
    [DataContract]
    public class Question
    {
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public string Questions { get; set; }

        // without [DateMember] attribute, this prop is not serialized/deserialized 
        // across servce connection
        public DateTime DateModified { get; set; }
    }
}