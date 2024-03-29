﻿
using ApplicationPropertiesSettings;

namespace KretaRazorPages.Extensions.View
{
    public class FlagExtension
    {
        public string GetFlagSpanClass()
        {
            string flagSpanClass = "<span class=\"fi fi-";
            string currentCulture=AppConfigControl.GettAppSettings("CurrentCulture");
            if (currentCulture == null)
            {
                CultureProperties apiUriProperties = new CultureProperties();
                currentCulture = apiUriProperties.GetDefaultCulture();
            }

            flagSpanClass += currentCulture.Substring(0, 2) + "\" id=\"flag\"></span>";
            return flagSpanClass;
        }
    }
}
