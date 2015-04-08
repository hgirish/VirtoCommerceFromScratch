using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using CommerceClient;
using CommerceFoundation.Catalogs.Model;
using CommerceFoundation.Catalogs.Services;
using Omu.ValueInjecter;
using StoreWebApp.Models;

namespace StoreWebApp.Virto.Helpers
{
    public class CatalogHelper
    {
        public static CatalogClient CatalogClient
        {
            get
            {
                var catalogClient = DependencyResolver.Current.GetService<CatalogClient>();
                return catalogClient;
            }
        }
        public static PriceListClient PriceListClient
        {
            get { return DependencyResolver.Current.GetService<PriceListClient>(); }
        }
        public static ICatalogOutlineBuilder OutlineBuilder
        {
            get { return DependencyResolver.Current.GetService<ICatalogOutlineBuilder>(); }
        }
        public static MarketingHelper MarketingHelper
        {
            get { return DependencyResolver.Current.GetService<MarketingHelper>(); }
        }
        public static CatalogItemWithPriceModel CreateCatalogModel(string itemId,
           string parentItemId = null,
           string associationType = null,
           bool forcedActive = false,
           ItemResponseGroups responseGroups = ItemResponseGroups.ItemLarge,
           ItemDisplayOptions display = ItemDisplayOptions.ItemLarge,
           bool byItemCode = false)
        {

            var dbItem = CatalogClient.GetItem(itemId, responseGroups,
                                              UserHelper.CustomerSession.CatalogId, bycode: byItemCode);
            if (dbItem != null)
            {

                if (dbItem.IsActive || forcedActive)
                {
                    PriceModel priceModel = null;
                    PropertySet propertySet = null;
                    //ItemRelation[] variations = null;
                    ItemAvailabilityModel itemAvaiability = null;

                    if (display.HasFlag(ItemDisplayOptions.ItemPropertySets))
                    {
                        propertySet = CatalogClient.GetPropertySet(dbItem.PropertySetId);
                        //variations = CatalogClient.GetItemRelations(itemId);
                    }

                    var itemModel = CreateItemModel(dbItem, propertySet);
                    // TODO
                    //if (display.HasFlag(ItemDisplayOptions.ItemAvailability))
                    //{
                    //    var fulfillmentCenter = UserHelper.StoreClient.GetCurrentStore().FulfillmentCenterId;
                    //    var availability = CatalogClient.GetItemAvailability(dbItem.ItemId, fulfillmentCenter);
                    //    itemAvaiability = new ItemAvailabilityModel(availability);
                    //}

                    if (display.HasFlag(ItemDisplayOptions.ItemPrice))
                    {
                        var lowestPrice = PriceListClient.GetLowestPrice(dbItem.ItemId, itemAvaiability != null ? itemAvaiability.MinQuantity : 1);
                       // CatalogOutlines outlines = OutlineBuilder.BuildCategoryOutline(CatalogClient.CustomerSession.CatalogId, dbItem.ItemId);
                        CatalogOutlines outlines = new CatalogOutlines();
                        var tags = new Hashtable
							{
								{
									"Outline",
                                    outlines.ToString()
                                }
							};
                        priceModel = MarketingHelper.GetItemPriceModel(dbItem, lowestPrice, tags);
                        itemModel.CatalogOutlines = outlines;

                        // get the category name
                        if (outlines.Count > 0)
                        {
                            var outline = outlines[0];
                            if (outline.Categories.Count > 0)
                            {
                                var category = outline.Categories.OfType<Category>().Reverse().FirstOrDefault();
                                if (category != null)
                                {
                                    itemModel.CategoryName = category.Name;
                                }
                            }
                        }
                    }

                    itemModel.ParentItemId = parentItemId;

                    return string.IsNullOrEmpty(associationType)
                               ? new CatalogItemWithPriceModel(itemModel, priceModel, itemAvaiability)
                               : new AssociatedCatalogItemWithPriceModel(itemModel, priceModel, itemAvaiability, associationType);
                }
            }

            return null;
        }

        private static ItemModel CreateItemModel(Item item, PropertySet propertySet)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var model = new ItemModel { Item = item };
            model.InjectFrom(item);
            return model;
        }
    }
}