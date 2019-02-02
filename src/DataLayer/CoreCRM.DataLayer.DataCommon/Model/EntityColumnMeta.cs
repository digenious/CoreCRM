using System;

namespace CoreCRM.DataLayer.DataCommon.Model
{
    public class EntityColumnMeta
    {
        public Guid EntityColumnId { get; set; }

        public string Name { get; set; }

        public ColumnType ColumnType { get; set; }
    }
}
