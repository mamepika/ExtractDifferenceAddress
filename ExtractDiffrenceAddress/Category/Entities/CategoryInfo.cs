using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.Category.Entities
{
    public class CategoryInfo
    {
        public Classification classification { get; set; }
        //大分類名称
        public string BigClassificationName { get; set; }
        //中分類名称
        public string MiddleClassificationName { get; set; }
        //小分類名称
        public string SmallClassificationName { get; set; }
    }
}
