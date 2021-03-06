﻿namespace IMDB.NHibernate.ClassMappings
{
    using global::NHibernate.Mapping.ByCode;
    using global::NHibernate.Mapping.ByCode.Conformist;
    using IMDB.Models;
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
                    m.Column("Id_Movie");
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

            // one-to-many
            this.Set(
                e => e.MovieRoles,
                cm =>
                {
                    // NOTE: inverse true should only be used to map a bidirectional relationship (the other overload should be used for that).
                    // See answer by Stefan Steinegger on https://stackoverflow.com/questions/1061179/when-to-use-inverse-false-on-nhibernate-hibernate-onetomany-relationships
                    cm.Inverse(true);
                    cm.Lazy(CollectionLazy.Lazy);
                    cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                    cm.Key(k => k.Column(col => col.Name("Id_Movie"))); // the column on the other table that points back at this entity
                },
                m => m.OneToMany());
        }

    }
}