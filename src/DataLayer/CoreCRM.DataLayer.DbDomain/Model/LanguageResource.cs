using System;

namespace CoreCRM.DataLayer.DbDomain.Model
{
    public class LanguageResource
    {
        public Guid Id { get; set; }

        public string ResourceName { get; set; }

        public string ResourceData { get; set; }
    }
}
