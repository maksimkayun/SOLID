using DependencyInversion.Models;

namespace DependencyInversion;

public interface IRepository
{
    public Auto CreateAuto(Auto auto);
    public Auto GetAuto(string serialNumber);
    public Auto UpdateAuto(string serialNumber, Auto auto);
    public Auto DeleteAuto(string serialNumber);
}