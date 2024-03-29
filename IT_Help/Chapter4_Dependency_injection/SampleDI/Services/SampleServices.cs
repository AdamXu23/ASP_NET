using Microsoft.AspNetCore.Mvc;
using SampleDI.Interface;

namespace SampleDI.Services;

public class SampleService
{
    private readonly ITransient _transient;
    private readonly IScoped _scoped;
    private readonly ISingleton _singleton;
    public SampleService(ITransient transient, IScoped scoped, ISingleton singleton)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }
    public string GetSampleHashcode()
    {
        return $"Transient: {_transient.GetHashCode()},"
            + $"Scoped: {_scoped.GetHashCode()},"
            + $"Singleton: {_singleton.GetHashCode()}";
    }
}
