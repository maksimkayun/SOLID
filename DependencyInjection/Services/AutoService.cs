using DependencyInjection.Implementation;
using DependencyInjection.Mapping;
using DependencyInjection.Models;
using DependencyInjection.Services.DTO;

namespace DependencyInjection.Services;

public class AutoService
{
    private readonly PgRepository _pgRepository;
    private readonly OraRepository _oraRepository;

    public AutoService(PgRepository pgRepository, OraRepository oraRepository)
    {
        _pgRepository = pgRepository;
        _oraRepository = oraRepository;
    }

    public AutoDto ProcessAuto(ActionEnum action, string serialNumber, AutoDto? autoDto = null, bool usePg = false)
    {
        var auto = MapUtil<AutoDto, Auto>.Map(autoDto);

        return action switch
        {
            ActionEnum.Add => MapUtil<Auto, AutoDto>.Map(Process(
                auto,
                usePg
                    ? e => _pgRepository.CreateAuto(e)
                    : e => _oraRepository.CreateAuto(e)
            )),
            ActionEnum.Get => MapUtil<Auto, AutoDto>.Map(Process(
                auto,
                usePg
                    ? e => _pgRepository.GetAuto(e.SerialNumber)
                    : e => _oraRepository.GetAuto(e.SerialNumber))),
            ActionEnum.Update => MapUtil<Auto, AutoDto>.Map(Process(
                auto,
                usePg
                    ? e => _pgRepository.UpdateAuto(e.SerialNumber, e)
                    : e => _oraRepository.UpdateAuto(e.SerialNumber, e))),
            ActionEnum.Delete => MapUtil<Auto, AutoDto>.Map(Process(auto,
                usePg
                    ? e => _pgRepository.DeleteAuto(e.SerialNumber)
                    : e => _oraRepository.DeleteAuto(e.SerialNumber))),
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