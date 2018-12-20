using IMDB.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Mappers
{
    public class RoleDtoMapper
    {
        public static RoleDTO MapModelToDto(Role source, RoleDTO destination)
        {
            destination.Id = source.Id;
            destination.NameDto = source.Name;
            destination.MovieId = source.Movie.Id;
            destination.ActorId = source.Actor.Id;

            return destination;

        }

        public static Role MapDtoToModel(RoleDTO source, Role destination, ISession session)
        {
            destination.Id = source.Id;
            destination.Name = source.NameDto;
            destination.Movie = session.Get<Movie>(source.MovieId);
            destination.Actor = session.Get<Actor>(source.ActorId);
            

            return destination;
        }


    }
}