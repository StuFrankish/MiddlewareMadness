using ApiMiddleware.ApiEndpoints.Info.Dto;

namespace ApiMiddleware.ApiEndpoints.Info;

public interface IInfoEndpointResponseGenerator
{
    Task<List<InfoDataItem>> ProcessAsync();
}