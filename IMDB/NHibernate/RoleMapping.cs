namespace IMDB.NHibernate.ClassMappings
{
    using global::NHibernate.Mapping.ByCode;
    using global::NHibernate.Mapping.ByCode.Conformist;
    using IMDB.Models;

    public class RoleMapping : ClassMapping<Role>
    {
        public RoleMapping()
        {
            this.Schema("dbo");
            this.Table("Role");

            //this.Cache(c => c.Usage(CacheUsage.ReadWrite));

            this.Id(
                e => e.Id,
                m =>
                {
                    m.Column("Id_Role");
                    m.Generator(Generators.Native);
                });

            this.Property(
                e => e.Name,
                m =>
                {
                    m.Column("Name");
                    m.NotNullable(true);
                    m.Unique(false);
                    m.Length(50);
                });
            

            // many-to-one
            this.ManyToOne(
                e => e.Movie,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(true);
                    m.Column("Id_Movie");
                    m.Unique(false);
                    m.Cascade(Cascade.None);
                });

            this.ManyToOne(
                e => e.Actor,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(true);
                    m.Column("Id_Actor");
                    m.Unique(false);
                    m.Cascade(Cascade.None);
                });

        }
    }
}
