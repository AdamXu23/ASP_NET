using Microsoft.AspNetCore.Mvc;
using SampleDI.Interface;
using SampleDI.Services;

namespace SampleDI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    public readonly SampleService _sampleService;
    public readonly ITransient _transient;
    public readonly IScoped _scoped;
    public readonly ISingleton _singleton;
    public SampleController(SampleService sampleService, ITransient transient, IScoped scoped, ISingleton singleton)
    {
        _sampleService = sampleService;
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }

    [HttpGet]
    public ActionResult<IDictionary<string,string>> Get()
    {
        var serviceHashCode = _sampleService.GetSampleHashcode();
        var controllerHashCode = $"Transient: {_transient.GetHashCode()},"
            + $"Scoped: {_scoped.GetHashCode()},"
            + $"Singleton: {_singleton.GetHashCode()}";
        return new Dictionary<string, string>
        {
            {"Service",serviceHashCode },
            {"Controller",controllerHashCode }
        };
    }
}
