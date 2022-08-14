using Microsoft.AspNetCore.Mvc;
using RLHerrera.Business.Interfaces;
using System.Threading.Tasks;

namespace RLHerrera.App.Extensions
{
    [ViewComponent(Name = "SummaryViewComponent")]
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
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));

            return View();
        }
    }
}
