using Prueba.Domain;

namespace MyApp.Application;

public class UseCase
{
    private readonly IRepository _repository;
    private readonly DomainService _domainService;

    public UseCase(IRepository repository, DomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public string Execute(string input)
    {
        var entity = new Entity();
        entity.SetData(input);

        var result = _domainService.Process(entity);
        _repository.Save(result);

        return result;
    }
}
