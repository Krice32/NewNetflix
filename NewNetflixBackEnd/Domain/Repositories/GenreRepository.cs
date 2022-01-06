using Domain.Models;
using Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
        public class GenreRepository : IGenreRepository
        {
            NewNetflixContext context;

            public GenreRepository()
            {
                context = new NewNetflixContext();
            }

            public Genre Add(Genre genre)
            {
                context.Genre.Add(genre);
                context.SaveChanges();
                return genre;
            }

            public bool Delete(int id)
            {
                var genre = GetById(id);

                if (genre.GrId > 0)
                {
                    context.Genre.Remove(genre);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public Genre GetById(int id) => context.Genre.Find(id);

            public Genre Update(Genre genre)
            {
                var genreUp = GetById(genre.GrId);
                context.Entry(genreUp).CurrentValues.SetValues(genre);
                context.SaveChanges();
                return genreUp;
            }

            public IEnumerable<Genre> GetAll() => context.Genre.ToList();
            //select * from movies



        }
    }
