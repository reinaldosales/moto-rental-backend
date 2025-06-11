namespace MRB.Infra.Data.Abstractions;

public interface IUnitOfWork
{
    public Task Commit();
}