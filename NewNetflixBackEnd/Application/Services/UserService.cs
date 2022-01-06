using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService

    {
        UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public User AdicionarAlteraUsuario(User user)
        {
            try
            {
                #region regra de negócio

                bool addFlag = user.UsrId == 0 ? true : false;

                #endregion

                #region Adicionar ou Alterar Genero

                return addFlag ? userRepository.Add(user) : userRepository.Update(user);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }

        public User ObterUsuarioPorId(int id)
        {
            try
            {
                return userRepository.GetById(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }

        public bool ExcluirUsuario(int id)
        {
            try
            {
                return userRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<User> ListarTodosUsuarios() => userRepository.GetAll();

    }
}

