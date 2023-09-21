using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Category
    {
        public Category()
        {

        }
        public Category(CategoryDTO categoryDTO)
        {
            Id = categoryDTO.Id ;
            Name = categoryDTO.Name;
            ParentId = categoryDTO.ParentId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
