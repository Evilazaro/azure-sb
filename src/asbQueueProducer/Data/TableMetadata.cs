public class TableMetadata
{
    public Table Table { get; set; }
}

public class Table
{
    public string SchemaName { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string PrimaryIdAttribute { get; set; }
    public string PrimaryNameAttribute { get; set; }
    public string OwnershipType { get; set; }
    public bool IsActivity { get; set; }
    public bool IsCustomEntity { get; set; }
    public List<Attribute> Attributes { get; set; }
    public List<Relationship> Relationships { get; set; }
    public List<Index> Indexes { get; set; }
    public DateTime DateTime { get {  return DateTime.Now; } }
}

public class Attribute
{
    public string SchemaName { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string DataType { get; set; }
    public int? MaxLength { get; set; }
    public bool IsPrimaryKey { get; set; }
    public bool IsRequired { get; set; }
    public string Format { get; set; }
    public int? Precision { get; set; }
}

public class Relationship
{
    public string RelationshipType { get; set; }
    public string ReferencedTable { get; set; }
    public string ReferencedAttribute { get; set; }
    public string ReferencingAttribute { get; set; }
    public string RelationshipSchemaName { get; set; }
    public DateTime DateTime { get { return DateTime.Now; } }
}

public class Index
{
    public string IndexName { get; set; }
    public bool IsUnique { get; set; }
    public List<string> Columns { get; set; }
    public DateTime DateTime { get { return DateTime.Now; } }
}
