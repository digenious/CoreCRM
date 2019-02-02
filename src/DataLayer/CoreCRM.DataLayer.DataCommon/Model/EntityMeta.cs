using System;

namespace CoreCRM.DataLayer.DataCommon.Model
{
    public class EntityMeta
    {
        public Guid EntityMetaId { get; set; }

        public string EntityName { get; set; }

        public EntityColumnMeta[] Columns { get; set; }
    }
}
