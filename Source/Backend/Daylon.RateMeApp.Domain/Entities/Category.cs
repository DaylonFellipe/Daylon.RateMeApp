namespace Daylon.RateMeApp.Domain.Entity
{
    public class Category
    {
        // Category Properties
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<SubCategory> SubCategories { get; set; } = [];
    }
}