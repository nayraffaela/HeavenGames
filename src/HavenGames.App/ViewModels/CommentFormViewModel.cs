﻿using HavenGames.Business.Models;

namespace HavenGames.App.ViewModels
{
    public class HomeViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }

    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
