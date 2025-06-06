﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleIdServer.Scim.Persistence.EF;

#nullable disable

namespace SimpleIdServer.Scim.MySQLMigrations.Migrations
{
    [DbContext(typeof(SCIMDbContext))]
    [Migration("20241204132454_AddIntVersion")]
    partial class AddIntVersion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SCIMRepresentationSCIMSchema", b =>
                {
                    b.Property<string>("RepresentationsId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SchemasId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("RepresentationsId", "SchemasId");

                    b.HasIndex("SchemasId");

                    b.ToTable("SCIMRepresentationSCIMSchema", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.ProvisioningConfiguration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ResourceType")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ProvisioningConfigurations", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.ProvisioningConfigurationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Exception")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExecutionDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProvisioningConfigurationId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RepresentationId")
                        .HasColumnType("longtext");

                    b.Property<int>("RepresentationVersion")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("WorkflowId")
                        .HasColumnType("longtext");

                    b.Property<string>("WorkflowInstanceId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProvisioningConfigurationId");

                    b.ToTable("ProvisioningConfigurationHistory", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.ProvisioningConfigurationRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsArray")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("ProvisioningConfigurationId")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ProvisioningConfigurationRecordId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("ValuesString")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProvisioningConfigurationId");

                    b.HasIndex("ProvisioningConfigurationRecordId");

                    b.ToTable("ProvisioningConfigurationRecord", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.Realm", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Owner")
                        .HasColumnType("longtext");

                    b.HasKey("Name");

                    b.ToTable("Realms", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMAttributeMapping", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Mode")
                        .HasColumnType("int");

                    b.Property<string>("SourceAttributeId")
                        .HasColumnType("longtext");

                    b.Property<string>("SourceAttributeSelector")
                        .HasColumnType("longtext");

                    b.Property<string>("SourceResourceType")
                        .HasColumnType("longtext");

                    b.Property<string>("TargetAttributeId")
                        .HasColumnType("longtext");

                    b.Property<string>("TargetResourceType")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SCIMAttributeMappingLst", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMRepresentation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("ExternalId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RealmName")
                        .HasColumnType("longtext");

                    b.Property<string>("ResourceType")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Version")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SCIMRepresentationLst", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMRepresentationAttribute", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AttributeId")
                        .HasColumnType("longtext");

                    b.Property<string>("ComputedValueIndex")
                        .HasColumnType("longtext");

                    b.Property<string>("FullPath")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<bool>("IsComputed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Namespace")
                        .HasColumnType("longtext");

                    b.Property<string>("ParentAttributeId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RepresentationId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ResourceType")
                        .HasColumnType("longtext");

                    b.Property<string>("SchemaAttributeId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ValueBinary")
                        .HasColumnType("longtext");

                    b.Property<bool?>("ValueBoolean")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ValueDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal?>("ValueDecimal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ValueInteger")
                        .HasColumnType("int");

                    b.Property<string>("ValueReference")
                        .HasColumnType("longtext");

                    b.Property<string>("ValueString")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FullPath");

                    b.HasIndex("ParentAttributeId");

                    b.HasIndex("RepresentationId");

                    b.HasIndex("SchemaAttributeId");

                    b.HasIndex("ValueString");

                    b.ToTable("SCIMRepresentationAttributeLst", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMSchema", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsRootSchema")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("ResourceType")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SCIMSchemaLst", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMSchemaAttribute", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CanonicalValues")
                        .HasColumnType("longtext");

                    b.Property<bool>("CaseExact")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DefaultValueInt")
                        .HasColumnType("longtext");

                    b.Property<string>("DefaultValueString")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("FullPath")
                        .HasColumnType("longtext");

                    b.Property<bool>("MultiValued")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Mutability")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("ParentId")
                        .HasColumnType("longtext");

                    b.Property<string>("ReferenceTypes")
                        .HasColumnType("longtext");

                    b.Property<bool>("Required")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Returned")
                        .HasColumnType("int");

                    b.Property<string>("SchemaId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Uniqueness")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchemaId");

                    b.ToTable("SCIMSchemaAttribute", "dbo");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMSchemaExtension", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Required")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SCIMSchemaId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Schema")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SCIMSchemaId");

                    b.ToTable("SCIMSchemaExtension", "dbo");
                });

            modelBuilder.Entity("SCIMRepresentationSCIMSchema", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domains.SCIMRepresentation", null)
                        .WithMany()
                        .HasForeignKey("RepresentationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleIdServer.Scim.Domains.SCIMSchema", null)
                        .WithMany()
                        .HasForeignKey("SchemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.ProvisioningConfigurationHistory", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domains.ProvisioningConfiguration", "ProvisioningConfiguration")
                        .WithMany("HistoryLst")
                        .HasForeignKey("ProvisioningConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ProvisioningConfiguration");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.ProvisioningConfigurationRecord", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domains.ProvisioningConfiguration", null)
                        .WithMany("Records")
                        .HasForeignKey("ProvisioningConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleIdServer.Scim.Domains.ProvisioningConfigurationRecord", null)
                        .WithMany("Values")
                        .HasForeignKey("ProvisioningConfigurationRecordId");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMRepresentationAttribute", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domains.SCIMRepresentationAttribute", null)
                        .WithMany("Children")
                        .HasForeignKey("ParentAttributeId");

                    b.HasOne("SimpleIdServer.Scim.Domains.SCIMRepresentation", "Representation")
                        .WithMany("FlatAttributes")
                        .HasForeignKey("RepresentationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SimpleIdServer.Scim.Domains.SCIMSchemaAttribute", "SchemaAttribute")
                        .WithMany()
                        .HasForeignKey("SchemaAttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Representation");

                    b.Navigation("SchemaAttribute");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMSchemaAttribute", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domains.SCIMSchema", null)
                        .WithMany("Attributes")
                        .HasForeignKey("SchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMSchemaExtension", b =>
                {
                    b.HasOne("SimpleIdServer.Scim.Domains.SCIMSchema", null)
                        .WithMany("SchemaExtensions")
                        .HasForeignKey("SCIMSchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.ProvisioningConfiguration", b =>
                {
                    b.Navigation("HistoryLst");

                    b.Navigation("Records");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.ProvisioningConfigurationRecord", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMRepresentation", b =>
                {
                    b.Navigation("FlatAttributes");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMRepresentationAttribute", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("SimpleIdServer.Scim.Domains.SCIMSchema", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("SchemaExtensions");
                });
#pragma warning restore 612, 618
        }
    }
}
