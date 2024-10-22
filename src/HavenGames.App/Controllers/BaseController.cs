using HavenGames.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HavenGames.App.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool IsOperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}

