using System.ComponentModel.DataAnnotations.Schema;

namespace MultipleDatabases.DAL.Models
{
    [Table(nameof(TestTwo)+"s")]
    public class TestTwo : TestBase
    {
        public string Test { get; set; }
    }
}
