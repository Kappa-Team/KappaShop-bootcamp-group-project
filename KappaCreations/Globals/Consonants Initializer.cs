﻿using KappaCreations.Models;

namespace KappaCreations
{
    public static partial class Consonants
    {
        /// <summary>
        /// Initializes the consonant fields.
        /// </summary>
        static Consonants()
        {
            #region Initialize PRODUCT_CATEGORIES
            var clothing = new ProductCategory("Clothing", 20);
            var tShirts = new ProductCategory("T-Shirts", 25, clothing);
            var footers = new ProductCategory("Footers", 30, clothing);
            var house = new ProductCategory("House", 20, clothing);
            var cup = new ProductCategory("Cups", 20, house);

            PRODUCT_CATEGORIES = new ProductCategory[]
            {
                clothing, tShirts, footers, house, cup
            };
            #endregion
        }
    }
}