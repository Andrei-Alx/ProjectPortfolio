using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class CategoryManager
    {
        DbCategoryHelper dbCategoryHelper = new DbCategoryHelper();

        public CategoryManager()
        {

        }

		public void CreateCategory(string name, int? parent)
        {
            dbCategoryHelper.CreateCategory(name, parent);
        }
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            foreach(CategoryDTO categoryDTO in dbCategoryHelper.GetCategories())
            {
                Category category = new Category(categoryDTO);
                categories.Add(category);
            }
            return categories;
        }
        public List<Category> GetSubCategories(int id)
        {
            List<Category> subcategories = new List<Category>();
            foreach (CategoryDTO categoryDTO in dbCategoryHelper.GetSubCategories(id))
            {
                Category category = new Category(categoryDTO);
                subcategories.Add(category);
            }
            return subcategories;
        }
    }
}
