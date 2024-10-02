﻿
using HavenGames.Business.Models;

namespace HavenGames.Business.Services
{
    public interface IJogoService : IDisposable
    {
        Task Adicionar(Jogo jogo);
        Task Alterar(Jogo jog);
        Task Remover(Jogo jog);
        Task AdicionarPersonagem(Jogo jogo, Personagem personagem);
        Task AlterarPersonagem(Personagem existingPersonagem);
        Task RemoverPersonagem(Jogo jogo, Personagem personagem);
    }
}