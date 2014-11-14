using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.Category.Entities
{
    public class Classification
    {
        //大分類
        public string BigClassification { get; set; }
        //中分類
        public string MiddleClassification { get; set; }
        //小分類
        public string SmallClassification { get; set; }
    }
}
