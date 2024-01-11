using System;
using EntitySpaces.MetadataEngine;

namespace EntitySpaces.AddIn
{
    internal class esMetaCreator
    {
        internal static Root Create(esSettings settings)
        {
            var esMeta = new Root(settings);
            if (!esMeta.Connect(settings.Driver, settings.ConnectionString))
            {
                throw new Exception("Unable to Connect to Database");
            }
            esMeta.Language = "C#";

            return esMeta;
        }
    }
}
