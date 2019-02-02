using System;
using System.Collections.Generic;

namespace CoreCRM.DataLayer.DataCommon.Model
{
    public class Entity
    {
        public Guid Id { get; set; }

        public string EntityName { get; set; }

        public Dictionary<string, string> StringProperties { get; set; }

        public Dictionary<string, int> IntProperties { get; set; }
    }
}
