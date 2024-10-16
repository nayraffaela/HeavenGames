using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Validation;

namespace HavenGames.Business.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository, 
                                INotificador notificador) : base(notificador)
        {
            _commentRepository = commentRepository;
        }

        public async Task Adicionar(Comment comment)
        {
            if (!ExecutarValidacao(new CommentValidation(), comment)) return;
            await _commentRepository.Adicionar(comment);
        }
        public async Task<IEnumerable<Comment>> ObterTodos()
        {
            return await _commentRepository.ObterTodos(); 
        }


        public void Dispose()
        {
            _commentRepository.Dispose();
        }

        public async Task DeleteComment(Comment comment)
        {
          await _commentRepository.Remover(comment);
        }
    }


}
