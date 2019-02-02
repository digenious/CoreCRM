using System;

namespace CoreCRM.DataLayer.DbDomain.Model.Meta
{
    public class MetaColumn
    {
        public Guid Id { get; set; }

        public Guid MetaTableId { get; set; }

        public string ColumnName { get; set; }
    }
}
