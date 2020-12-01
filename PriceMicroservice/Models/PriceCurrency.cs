using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PriceMicroservice.Models
{
    [DataContract]
    public abstract class PriceCurrency
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public float Sale { get; set; }
        [DataMember]
        public float Purchase { get; set; }
        [DataMember]
        public string UpdateDate { get; set; }
    }
}
