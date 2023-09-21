namespace Data
{
    public interface IDbCategoryHelper
    {
        void CreateCategory(string name, int? parent);
        void DeleteCategory(int id);
        IEnumerable<CategoryDTO> GetCategories();
        CategoryDTO GetCategoryByName(string name);
        List<CategoryDTO> GetSubCategories(int id);
        void UpdateCategory(CategoryDTO category);
        void UpdateSubCategory(CategoryDTO category);
    }
}