using System.Collections.Generic;

namespace MultipleDatabases.DAL.Models
{
    public class TestOne : TestBase
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public bool Condition { get; set; }
        public List<TestTwo> Elems { get; set; }
    }
}
