using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Behaviours;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using System.Reflection;

namespace Ordering.API
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GetOrdersListQuery).GetTypeInfo().Assembly);
            services.AddValidatorsFromAssembly(typeof(GetOrdersListQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetOrdersListQuery).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
