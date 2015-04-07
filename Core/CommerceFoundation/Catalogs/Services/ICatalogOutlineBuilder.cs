namespace CommerceFoundation.Catalogs.Services
{
    public interface ICatalogOutlineBuilder
    {
        CatalogOutlines BuildCategoryOutline(string catalogId, string itemId);
    }
}