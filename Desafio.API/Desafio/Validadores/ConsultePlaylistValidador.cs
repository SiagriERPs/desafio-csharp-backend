using FluentValidation;

namespace Desafio.Retorno
{
    internal class ConsultePlaylistValidador : AbstractValidator<ConsultePlaylistRequisicao>
    {
        public ConsultePlaylistValidador()
        {
            RuleFor(m => m)
                .Must(ValideEntrada);
        }

        bool ValideEntrada(ConsultePlaylistRequisicao requisicao) =>
            !string.IsNullOrEmpty(requisicao.Cidade) ||
            (requisicao.latitude != null && requisicao.longitude != null);
    }

}
