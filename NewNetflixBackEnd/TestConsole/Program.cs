using Application.Services;
using Domain.Models;

MovieService service = new MovieService();

Movie movie = new Movie() 
{ MvId = 0, MvTitle = "Meu Malvado Favorito 2", MvDate = "2012-12-16", MvImg = @"https://someimg.png" };

//movie.MvTitle = "Homem Aranha";
//movie.MvDate = "2021-12-16";
//movie.MvId = 0;


service.AdicionarAlteraMovie(movie);

Console.WriteLine(movie.MvId);
Console.WriteLine(movie.MvTitle);

//Console.WriteLine(service.ExcluirMovie(movie.MvId) ? $"Filme excluido {movie.MvTitle}" : "Erro ao excluir");

Console.ReadKey();






