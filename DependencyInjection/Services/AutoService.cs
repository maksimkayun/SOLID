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
            ActionEnum.Add => MapUtil<Auto, AutoDto>.Map(Process(
                auto,
                e => _repository.CreateAuto(e)
            )),
            ActionEnum.Get => MapUtil<Auto, AutoDto>.Map(Process(
                auto,
                e => _repository.GetAuto(e.SerialNumber)
            )),
            ActionEnum.Update => MapUtil<Auto, AutoDto>.Map(Process(
                auto,
                e => _repository.UpdateAuto(e.SerialNumber, e)
            )),
            ActionEnum.Delete => MapUtil<Auto, AutoDto>.Map(Process(auto,
                e => _repository.DeleteAuto(e.SerialNumber)
            )),
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
    }

    private static T Process<T>(T arg ,Func<T, T> func)
    {
        return func(arg);
    }

    public enum ActionEnum
    {
        Add = 1,
        Get = Add << 1,
        Update = Get << 1,
        Delete = Update << 1
    }
}