using System.Linq.Expressions;

namespace Cadastros.Application.Contracts
{
    public interface IFiltroPersistencia<DTO, D>
        where D : class
        where DTO : class
    {
        public Expression<Func<D, bool>> CriaExpressao(DTO? dado);
    }
}