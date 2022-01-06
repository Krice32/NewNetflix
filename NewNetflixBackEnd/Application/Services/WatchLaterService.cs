using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WatchLaterService
    {
        WatchLaterRepository watchLaterRepository;
        public WatchLaterService()
        {
            watchLaterRepository = new WatchLaterRepository();
        }

        public WatchLater AdicionarAlteraAssistirMaisTarde(WatchLater watchLater)
        {
            try
            {
                #region regra de negócio

                bool addFlag = watchLater.WatchLaterId == 0 ? true : false;

                #endregion

                #region Adicionar ou Alterar Genero

                return addFlag ? watchLaterRepository.Add(watchLater) : watchLaterRepository.Update(watchLater);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }

        public WatchLater ObterAssistirMaisTardePorId(int id)
        {
            try
            {
                return watchLaterRepository.GetById(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }

        public bool ExcluirAssistirMaisTarde(int id)
        {
            try
            {
                return watchLaterRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<WatchLater> ListarTodosAssistirMaisTarde() => watchLaterRepository.GetAll();

    }
}
