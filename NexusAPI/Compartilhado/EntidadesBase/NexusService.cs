using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using System.Security.Claims;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// Interface para implementar serviços de regras de negócio.
    /// </summary>
    /// <typeparam name="T">DTO de Envio</typeparam>
    /// <typeparam name="U">DTO de resposta</typeparam>
    /// <typeparam name="O">Classe base</typeparam>
    public abstract class NexusService<T, U, O> where O : NexusObjeto
    {
        protected readonly NexusRepository<O> repository;

        protected readonly TokenService tokenService;

        public NexusService(NexusRepository<O> repository, TokenService tokenService)
        {
            this.repository = repository;
            this.tokenService = tokenService;
        }

        public virtual async Task<U> ObterPorUIDAsync(string UID)
        {
            var obj = await repository.ObterPorUIDAsync(UID);
            return obj == null ? throw new ObjetoNaoEncontrado(UID) : ConverterParaDTOResposta(obj);
        }

        public virtual async Task<List<U>> ObterTudoAsync(int numeroPagina)
        {
            var objs = await repository.ObterTudoAsync(numeroPagina);
            var objsResposta = new List<U>();
                
            objs.ForEach(o => objsResposta.Add(ConverterParaDTOResposta(o)));

            return objsResposta;
        }

        public virtual async Task<U> AdicionarAsync(T obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UID = Guid.NewGuid().ToString();
            objClasse.UsuarioCriadorUID = tokenService.ObterUID(claims);

            var UID = (await repository.AdicionarAsync(objClasse)).UID;

            var objAposSerCriado = await repository.ObterPorUIDAsync(UID);

            if (objAposSerCriado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return ConverterParaDTOResposta(objAposSerCriado);
        }

        public virtual async Task<U> EditarAsync(string UID, T obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UID = UID;

            if (!await ExistePorUIDAsync(objClasse.UID))
            {
                throw new ObjetoNaoEncontrado(objClasse.UID);
            }

            objClasse.AtualizadoPorUID = tokenService.ObterUID(claims);

            await repository.EditarAsync(objClasse);

            var objAposSerAtualizado = await repository.ObterPorUIDAsync(UID);
            
            if (objAposSerAtualizado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return ConverterParaDTOResposta(objAposSerAtualizado);
        }

        public virtual async Task DeletarAsync(string UID, IEnumerable<Claim> claims)
        {
            var objClasse = await repository.ObterPorUIDAsync(UID);

            if (objClasse == null)
            {
                throw new ObjetoNaoEncontrado(UID);
            }

            objClasse.FinalizadoPorUID = tokenService.ObterUID(claims);

            await repository.DeletarAsync(objClasse);
        }


        public virtual async Task<bool> ExistePorUIDAsync(string UID)
        {
            var obj = await repository.ObterPorUIDAsync(UID);
            return obj != null;
        }

        public abstract U ConverterParaDTOResposta(O obj);

        public virtual O ConverterParaClasse(T obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, O>());
            var mapper = new Mapper(config);

            return mapper.Map<O>(obj);
        }
    }
}
