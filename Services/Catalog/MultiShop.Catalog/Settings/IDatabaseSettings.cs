namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        string CategoryCollectionName { get; set; }
        string ProductCollectionName { get; set; }
        string ProductDetailCollectionName { get; set; }
        string ProductImageCollectionName { get; set; }
        string FeatureSliderCollectionName { get; set; }
        string SpecialOfferCollectionName { get; set; }
        string FeatureCollectionName { get; set; }
        string OfferDiscountCollectionName { get; set; }
        string BrandCollectionName { get; set; }
        string AboutCollectionName { get; set; }
        string ContactCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
