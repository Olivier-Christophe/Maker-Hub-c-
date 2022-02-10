using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.Entities
{
    public class SampleCategory
    {
        public int SampleCategoryId { get; set; }
        public int SampleId { get; set; }
        public int CategoryId { get; set; }

    }
}
