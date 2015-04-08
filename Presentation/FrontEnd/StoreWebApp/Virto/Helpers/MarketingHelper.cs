using System;
using System.Collections;
using CommerceFoundation.Catalogs.Model;
using StoreWebApp.Models;

namespace StoreWebApp.Virto.Helpers
{
    public class MarketingHelper
    {
        public PriceModel GetItemPriceModel(Item item, Price lowestPrice, Hashtable tags)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (lowestPrice == null)
            {
                return new PriceModel();
            }
            return new PriceModel();
        }
    }
}