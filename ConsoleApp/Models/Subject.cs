using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp.Models
{
    [XmlRoot()]
    public class Subject
    {
        [XmlAttribute("Id")]
        public int SubjectId { get; set; }

        [XmlElement("Name")]
        public string Title { get; set; }
    }
}
