using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Validation;

namespace HavenGames.Business.Services
{
    public class JogoService : BaseService,  IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository,
                                 INotificador notificador) : base(notificador)
        {
           _jogoRepository = jogoRepository;
        }

        public async Task Adicionar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _jogoRepository.Adicionar(jogo);
        }

        public async Task AdicionarPersonagem(Jogo jogo, Personagem personagem)
        {
            jogo.Personagens.Add(personagem);

            await _jogoRepository.AdicionarPersonagem(personagem);
            await  _jogoRepository.Alterar(jogo);
        }

        public async Task Alterar(Jogo jogo)
        {
            if (!ExecutarValidacao(new JogoValidation(), jogo)) return;

            await _jogoRepository.Alterar(jogo);
        }

        public async Task AlterarPersonagem(Personagem personagem)
        {
            await _jogoRepository.AlterarPersonagem(personagem);
        }

        public void Dispose()
        {
            _jogoRepository.Dispose();
        }

        public async Task Remover(Jogo jogo)
        {
            //if (jogo.Personagens.Any())
            //{
            //    foreach (var item in jogo.Personagens)
            //    {
            //       _jogoRepository.Remover(item);
            //    }
            //}

           await _jogoRepository.Remover(jogo);
        }

        public async Task RemoverPersonagem(Jogo jogo, Personagem personagem)
        {
            jogo.Personagens.Remove(personagem);

            await _jogoRepository.Alterar(jogo);
        }
    }
}
