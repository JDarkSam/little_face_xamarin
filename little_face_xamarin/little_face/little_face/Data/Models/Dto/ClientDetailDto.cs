using System;
using System.Collections.Generic;
using System.Text;

namespace little_face.Data.Models.Dto
{
    public class ClientDetailDto : Client
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public double LifeExpectancy { get; set; }
    }

}
