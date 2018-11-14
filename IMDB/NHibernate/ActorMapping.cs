
using global::NHibernate.Mapping.ByCode.Conformist;
using IMDB.Models;
using NHibernate.Mapping.ByCode;

namespace IMDB.NHibernate
{
    public class ActorMapping: ClassMapping<Actor>
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
                    m.Column("Id-Actor");
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
        }

    }
}