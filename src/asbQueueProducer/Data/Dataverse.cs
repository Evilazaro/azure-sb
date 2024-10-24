using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asbQueueProducer.Data
{
    static class Dataverse
    {
        public static TableMetadata tableMetadata
        {
            get
            {
                var tableMetadata = new TableMetadata
                {
                    Table = new Table
                    {
                        SchemaName = "account",
                        DisplayName = "Account",
                        Description = "Stores company account information.",
                        PrimaryIdAttribute = "accountid",
                        PrimaryNameAttribute = "name",
                        OwnershipType = "UserOwned",
                        IsActivity = false,
                        IsCustomEntity = true,
                        Attributes = new List<Attribute>
                {
                    new Attribute
                    {
                        SchemaName = "accountid",
                        DisplayName = "Account ID",
                        Description = "Unique identifier for the account.",
                        DataType = "UniqueIdentifier",
                        IsPrimaryKey = true,
                        IsRequired = true
                    },
                    new Attribute
                    {
                        SchemaName = "name",
                        DisplayName = "Account Name",
                        Description = "The name of the account.",
                        DataType = "String",
                        MaxLength = 200,
                        IsRequired = true
                    },
                    new Attribute
                    {
                        SchemaName = "createdon",
                        DisplayName = "Created On",
                        Description = "The date and time the account was created.",
                        DataType = "DateTime",
                        Format = "DateAndTime",
                        IsRequired = false
                    },
                    new Attribute
                    {
                        SchemaName = "emailaddress1",
                        DisplayName = "Email Address",
                        Description = "The primary email address for the account.",
                        DataType = "String",
                        MaxLength = 100,
                        IsRequired = false
                    },
                    new Attribute
                    {
                        SchemaName = "revenue",
                        DisplayName = "Annual Revenue",
                        Description = "The annual revenue of the account.",
                        DataType = "Money",
                        Precision = 2,
                        IsRequired = false
                    }
                },
                        Relationships = new List<Relationship>
                {
                    new Relationship
                    {
                        RelationshipType = "OneToMany",
                        ReferencedTable = "contact",
                        ReferencedAttribute = "accountid",
                        ReferencingAttribute = "parentcustomerid",
                        RelationshipSchemaName = "account_contact"
                    },
                    new Relationship
                    {
                        RelationshipType = "ManyToOne",
                        ReferencedTable = "owner",
                        ReferencedAttribute = "ownerid",
                        ReferencingAttribute = "ownerid",
                        RelationshipSchemaName = "account_owner"
                    }
                },
                        Indexes = new List<Index>
                {
                    new Index
                    {
                        IndexName = "account_name_index",
                        IsUnique = false,
                        Columns = new List<string> { "name" }
                    }
                }
                    }
                };
                return tableMetadata;
            }
        }
    }
}