namespace IMDB.NHibernate.ClassMappings
{
    using global::NHibernate.Mapping.ByCode;
    using global::NHibernate.Mapping.ByCode.Conformist;
    using IMDB.Models;
    public class ActorMapping : ClassMapping<Actor>
    {
        public ActorMapping()
        {
            this.Schema("dbo");
            this.Table("Actor");

            //this.Cache(c => c.Usage(CacheUsage.ReadWrite));

            this.Id(
                e => e.Id,
                m =>
                {
                    m.Column("Id_Actor");
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

            this.Property(
                e => e.DateOfBirth,
                m =>
                {
                    m.Column("DateOfBirth");
                    m.NotNullable(true);
                    m.Unique(false);
                });
            this.Property(
                e => e.Nationality,
                m =>
                {
                    m.Column("Nationality");
                    m.NotNullable(true);
                    m.Unique(false);
                });

            // one-to-many
            this.Set(
                e => e.ActorRoles,
                cm =>
                {
                    // NOTE: inverse true should only be used to map a bidirectional relationship (the other overload should be used for that).
                    // See answer by Stefan Steinegger on https://stackoverflow.com/questions/1061179/when-to-use-inverse-false-on-nhibernate-hibernate-onetomany-relationships
                    cm.Inverse(true);
                    cm.Lazy(CollectionLazy.Lazy);
                    cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                    cm.Key(k => k.Column(col => col.Name("Id_Actor"))); // the column on the other table that points back at this entity
                },
                m => m.OneToMany());
            
            /*esto solo lo dejo por si las dudas
            this.Set(
                e => e.ActorRoles,
                m =>
                {
                    m.Schema("dbo");
                    m.Table("Role");
                    m.Lazy(CollectionLazy.Lazy);
                    m.Cascade(Cascade.None);
                    m.Key(k => k.Column("Id-Actor"));
                },
                r => r.ManyToMany(p => p.Column("Id-Movie")));
            */
        }

    }

}