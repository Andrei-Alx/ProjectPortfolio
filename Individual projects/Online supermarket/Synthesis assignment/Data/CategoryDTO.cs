using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {

        }

		public CategoryDTO(string name, int? parentId)
		{
			Name = name;
			ParentId = parentId;
		}

		public CategoryDTO(int id, string name, int? parentId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
