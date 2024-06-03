using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITesting.Model
{
    public class CreateUserResponseModel
    {
        public string Name { get; set; }
        public string Job {  get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
