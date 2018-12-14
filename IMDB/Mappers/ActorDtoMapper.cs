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
        public static void MapModelToDto(Actor source, ActorDTO destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.DateOfBirth = source.DateOfBirth;
            destination.Nationality = source.Nationality;
                        
            destination.Roles = source.ActorRoles.Select(r => RoleDtoMapper.MapToDTOModel(r, new RoleDTO())).ToList();

            //destination.Roles = source.ActorRoles.Select(r => new RoleDTO
            //{
            //    MovieId = r.Movie.Id,
            //    ActorId = r.Actor.Id,
            //    NameDto = r.Name
            //}).ToList();
        }

        public static void MapDtoToModel(ActorDTO source, Actor destination, ISession session)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.DateOfBirth = source.DateOfBirth;
            destination.Nationality = source.Nationality;

            session.Save(destination);

            if (source.Roles!=null)
            {
                destination.ActorRoles.Clear();

                // add or update associated roles
                foreach (var sourceRole in source.Roles)
                {
                    sourceRole.ActorId = destination.Id;
                    var destinationRole = (sourceRole.Id == 0 ? null : session.Get<Role>(sourceRole.Id)) ?? new Role();
                    destination.ActorRoles.Add(RoleDtoMapper.MapFromDTOModel(sourceRole, destinationRole, session));
                }
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