using Application.Client.Services.DocInfo;
using Application.Client.Services.DocInfo.Interfaces;
using Application.Client.Services.FindNextAndReplaceConditions;
using Application.Client.Services.FindNextAndReplaceConditions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Services.Infrastructure.Extensions.DependencyInjection
{
    public static class ServicesServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection @this)
        {
            @this.AddSingleton<IDocInfoService, DocInfoService>();
            @this.AddSingleton<IFindNextAndReplaceConditionsService, FindNextAndReplaceConditionsService>();

            return @this;
        }
    }
}
