using System;
using System.Collections.Generic;
using System.Text;

namespace TestDifference
{
    public class Dog
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
