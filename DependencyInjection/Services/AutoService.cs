using DependencyInjection.Implementation;
using DependencyInjection.Mapping;
using DependencyInjection.Models;
using DependencyInjection.Services.DTO;

namespace DependencyInjection.Services;

public class AutoService
{
    private readonly IRepository _repository;

    public AutoService(IRepository repository)
    {
        _repository = repository;
    }

    public AutoDto ProcessAuto(ActionEnum action, string serialNumber, AutoDto? autoDto = null)
    {
        var auto = MapUtil<AutoDto, Auto>.Map(autoDto);

        return action switch
        {
            ActionEnum.Add => Process<Auto, AutoDto>(
                auto,
                e => _repository.CreateAuto(e)
            ),
            ActionEnum.Get => Process<Auto, AutoDto>(
                auto,
                e => _repository.GetAuto(e.SerialNumber)
            ),
            ActionEnum.Update => Process<Auto, AutoDto>(
                auto,
                e => _repository.UpdateAuto(e.SerialNumber, e)
            ),
            ActionEnum.Delete => Process<Auto, AutoDto>(auto,
                e => _repository.DeleteAuto(e.SerialNumber)
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
    }

    private static R Process<T, R>(T arg ,Func<T, T> func) => MapUtil<T, R>.Map(func(arg));

    public enum ActionEnum
    {
        Add = 1,
        Get = Add << 1,
        Update = Get << 1,
        Delete = Update << 1
    }
}