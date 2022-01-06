using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SerieService
    {
        SerieRepository serieRepository;

        public SerieService()
        {
            serieRepository = new SerieRepository();
        }

        public Series AdicionarAlteraSerie(Series serie)
        {
            try
            {
                #region Validações
                    bool addFlag = serie.SeId == 0 ? true : false;
                #endregion

                #region regra de negócio
                // data do lançamento tem que ser superior a 31/12/1999    

                #endregion

                #region Adicionar ou Alterar Movie
                
                return addFlag ? serieRepository.Add(serie) : serieRepository.Update(serie);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }

        public Series ObterSeriePorId(int id)
        {
            try
            {
                return serieRepository.GetById(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }

        public bool ExcluirSerie(int id)
        {
            try
            {
                return serieRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<Series> ListarTodasSeries() => serieRepository.GetAll();
    }
}
