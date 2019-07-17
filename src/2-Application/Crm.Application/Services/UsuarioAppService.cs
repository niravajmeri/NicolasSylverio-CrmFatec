using AutoMapper;
using Crm.Application.Interface;
using Crm.Application.ViewModels;
using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Interfaces.Services;
using Crm.Domain.Models.Usuarios;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioAppService
        (
            IUsuarioRepository usuarioRepository,
            IMapper mapper
        )
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void Cadastrar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);

            _usuarioRepository.Add(usuario);
        }

        public IEnumerable<UsuarioViewModel> GetAllUsuarioViewModel()
        {
            var usuarios = _usuarioRepository.GetAll().ToList();

            var usuariosViewModel = new List<UsuarioViewModel>();

            foreach (var usuario in usuarios)
            {
                usuariosViewModel.Add(_mapper.Map<UsuarioViewModel>(usuario));
            }

            return usuariosViewModel;
        }
        public void Add(Usuario obj)
        {
            _usuarioRepository.Add(obj);
        }

        public Usuario GetById(int id)
        {
            return _usuarioRepository.GetById(id);
        }

        public void Remove(Usuario obj)
        {
            _usuarioRepository.Remove(obj);
        }

        public void Update(Usuario obj)
        {
            _usuarioRepository.Update(obj);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }
    }
}