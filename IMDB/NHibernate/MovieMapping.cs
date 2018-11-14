using global::NHibernate.Mapping.ByCode.Conformist;
using IMDB.Models;
using NHibernate.Mapping.ByCode;

namespace IMDB.NHibernate
{
    public class MovieMapping : ClassMapping<Movie>
    {
        public MovieMapping()
        {
            this.Schema("dbo");
            this.Table("Movie");

            //this.Cache(c => c.Usage(CacheUsage.ReadWrite));

            this.Id(
                e => e.Id,
                m =>{
                    m.Column("Id-Movie");
                    m.Generator(Generators.Native);
                });

            this.Property(
                e => e.OriginalTitle,
                m =>
                {
                    m.Column("OriginalTitle");
                    m.NotNullable(true);
                    m.Unique(false);
                    m.Length(50);
                });

            this.Property(
                e => e.ReleaseDate,
                m =>
                {
                    m.Column("ReleaseDate");
                    m.NotNullable(true);
                    m.Unique(false);
                });

            this.Property(
                e => e.Country,
                m =>
                {
                    m.Column("Country");
                    m.NotNullable(true);
                    m.Unique(false);
                    m.Length(50);
                });

            this.Set(
                e => e.MovieRoles,
                m =>
                {
                    m.Schema("dbo");
                    m.Table("Role");
                    m.Lazy(CollectionLazy.Lazy);
                    m.Cascade(Cascade.None);
                    m.Key(k => k.Column("Id-Movie"));
                },
                r => r.ManyToMany(p => p.Column("Id-Actor")));
        }

    }
}