using IMDB.Models;
using IMDB.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace IMDB.Mappers
{
    public class ActorDtoMapper
    {
        public static void MapToDTOModel(Actor source, ActorDTO destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.DateOfBirth = source.DateOfBirth;
            destination.Nationality = source.Nationality;

            destination.Roles = source.ActorRoles.Select(r => new RoleDTO
            {
                MovieId = r.Movie.Id,
                ActorId = r.Actor.Id,
                NameDto = r.Name
            }).ToList();
        }

        public static void MapFromDTOModel(ActorDTO source, Actor destination, ISession session)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.DateOfBirth = source.DateOfBirth;
            destination.Nationality = source.Nationality;

            session.Save(destination);
            

            foreach(var role in source.Roles)
            {
                destination.ActorRoles.Add(RoleDtoMapper.MapFromDTOModel(role, new Role(), session));
            }

            
        }

        /*

        public static void MapFromViewModel(ActorDisplayDTO source, Actor destination, ISession session)
        {
            destination.Id = source.Id;
            destination.FullName = source.FullName;
            destination.Birthdate = source.Birthdate;
            destination.Nationality = source.Nationality;

            destination.Roles.ReplaceAll(source.Roles.Select(r => new Rol
            {
                name = r.name,
                Actor = destination,
                Movie = session.Get<Movie>(r.MovieId)
            }));
        }
        */
    }
}