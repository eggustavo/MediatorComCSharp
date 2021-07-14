using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EGG.Domain.Interfaces.UoW;
using prmToolkit.NotificationPattern;

namespace EGG.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected IActionResult CreateActionResult(Domain.Commands.Response response)
        {
            if (response.Notifications.Any())
                return BadRequest(response);

            var commitResult = _uow.Commit();

            if (commitResult.Sucesso)
                return Ok(response);

            return BadRequest(new
            {
                Success = false,
                Notifications = new Notification("Persitência", commitResult.MensagemErroDetalhada != null
                    ? $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro} - {commitResult.MensagemErroDetalhada}"
                    : $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro}")
            });
        }
    }
}