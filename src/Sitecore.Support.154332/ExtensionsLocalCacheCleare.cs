using Sitecore.Analytics.Data.Items;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Sitecore.Support
{
    public class ExtensionsLocalCacheCleare
    {
        /// <summary>Clears the cache.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The arguments.</param>
        public void ClearItemExtensionLocalCache(object sender, EventArgs args)
        {
            Assert.ArgumentNotNull(sender, "sender");
            Assert.ArgumentNotNull((object)args, "args");
            //Extensions.RemoveCacheEntry(item.Database.Name);
            //var fldInfo = typeof(Sitecore.Analytics.Data.Items.Extensions).GetMethod("RemoveCacheEntry", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase);
            // fldInfo.Invoke(this, new object[] { "{web}" });

            var fldInfo = typeof(Sitecore.Analytics.Data.Items.Extensions).GetField("localCache", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase);
            var currentValue = fldInfo.GetValue(null) as List<AnalyticsItems>;
            currentValue.Clear();
        }
    }
}