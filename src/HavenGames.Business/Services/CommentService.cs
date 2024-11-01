using HavenGames.Business.Interfaces;
using HavenGames.Business.Models;
using HavenGames.Business.Validation;

namespace HavenGames.Business.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly string _timeZoneId = "E. South America Standard Time";
        public CommentService(ICommentRepository commentRepository, 
                                INotificador notificador) : base(notificador)
        {
            _commentRepository = commentRepository;
        }

        public async Task Adicionar(Comment comment)
        {
            if (!ExecutarValidacao(new CommentValidation(), comment)) return;

            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(_timeZoneId);
            comment.Inclusao = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
            
            await _commentRepository.Adicionar(comment);
        }
        public async Task<IEnumerable<Comment>> ObterTodos()
        {
            return await _commentRepository.ObterTodosOrdenadosPorData();
        }


        public void Dispose()
        {
            _commentRepository.Dispose();
        }

        public async Task DeleteComment(Comment comment)
        {
          await _commentRepository.Remover(comment.Id);
        }
    }


}
