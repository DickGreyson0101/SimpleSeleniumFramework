using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APITesting.Model
{
    public class GetUserModel
    {
        public int page;
        public int per_page;
        public int total;
        public int total_pages;
        public List<Datum> data;
        public Support support;
        public class Support
        {
            public string url;
            public string text;
        }

        public class Datum
        {
            public int id;
            public string email;
            public string first_name;
            public string last_name;
            public string avatar;
        }

    }
}
