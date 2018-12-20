using IMDB.Models;
using IMDB.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace IMDB.Mappers
{
    public class MovieDtoMapper
    {
        public static void MapModelToDto(Movie source, MovieDTO destination)
        {
            destination.Id = source.Id;
            destination.OriginalTitle = source.OriginalTitle;
            destination.ReleaseDate = source.ReleaseDate;
            destination.Country = source.Country;
                        
            destination.Characters = source.MovieRoles.Select(r => RoleDtoMapper.MapModelToDto(r, new RoleDTO())).ToList();

            //destination.Characters = source.MovieRoles.Select(r => new RoleDTO
            //{
            //    MovieId = r.Movie.Id,
            //    MovieId = r.Movie.Id,
            //    OriginalTitleDto = r.OriginalTitle
            //}).ToList();
        }

        public static void MapDtoToModel(MovieDTO source, Movie destination, ISession session)
        {
            destination.Id = source.Id;
            destination.OriginalTitle = source.OriginalTitle;
            destination.ReleaseDate = source.ReleaseDate;
            destination.Country = source.Country;

            session.Save(destination);

            if (source.Characters != null)
            {
                destination.MovieRoles.Clear();

                // add or update associated roles
                foreach (var sourceRole in source.Characters)
                {
                    sourceRole.MovieId = destination.Id;
                    var destinationRole = (sourceRole.Id == 0 ? null : session.Get<Role>(sourceRole.Id)) ?? new Role();
                    destination.MovieRoles.Add(RoleDtoMapper.MapDtoToModel(sourceRole, destinationRole, session));
                }
            }








            //foreach (var role in source.Characters)
            //{
            //    role.MovieId = destination.Id;

            //    if(role.Id==0  || session.Get<Role>(role.Id)==null)
            //    {
            //        role.Id = 0;
            //        destination.MovieRoles.Add(RoleDtoMapper.MapFromDTOModel(role, new Role(), session));
            //    }
            //    else
            //    {
            //        RoleDtoMapper.MapFromDTOModel(role, session.Get<Role>(role.Id), session);
            //    }
            //}

        }

        /*

        public static void MapFromViewModel(MovieDisplayDTO source, Movie destination, ISession session)
        {
            destination.Id = source.Id;
            destination.FullOriginalTitle = source.FullOriginalTitle;
            destination.Birthdate = source.Birthdate;
            destination.Country = source.Country;

            destination.Characters.ReplaceAll(source.Characters.Select(r => new Rol
            {
                name = r.name,
                Movie = destination,
                Movie = session.Get<Movie>(r.MovieId)
            }));
        }
        */
    }
}