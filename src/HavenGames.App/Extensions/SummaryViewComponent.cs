using HavenGames.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HavenGames.app.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }
        public async Task<IViewComponentResult> InvokeAsync()

        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());
            notificacoes.ForEach(v => ViewData.ModelState.AddModelError(string.Empty, v.Mensagem));
            return View();
        }
    }
}
