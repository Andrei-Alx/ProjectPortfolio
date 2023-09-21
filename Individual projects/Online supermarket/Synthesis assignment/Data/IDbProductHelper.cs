namespace Data
{
    public interface IDbProductHelper
    {
        void AddProduct(string category, string subCategory, string status, string name, decimal price, string measureUnit, string? image);
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetAvailableProducts();
		void UpdateProduct(int id, string category, string subCategory, string status, string name, decimal price, string measureUnit, string? image);
        void ModifyProductStatus(int id, string status);
        ProductDTO? GetProductByID(int id);
        IEnumerable<ProductDTO> GetProductsBySubCategory(string subCategoryName);
	}
}