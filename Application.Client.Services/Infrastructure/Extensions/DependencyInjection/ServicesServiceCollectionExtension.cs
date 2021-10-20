using Application.Client.Services.DocInfo;
using Application.Client.Services.DocInfo.Interfaces;
using Application.Client.Services.FindNext.SearchConditions;
using Application.Client.Services.FindNext.SearchConditions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Services.Infrastructure.Extensions.DependencyInjection
{
    public static class ServicesServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection @this)
        {
            @this.AddSingleton<IDocInfoService, DocInfoService>();
            @this.AddSingleton<IFindNextSearchConditionsService, FindNextSearchConditionsService>();

            return @this;
        }
    }
}
