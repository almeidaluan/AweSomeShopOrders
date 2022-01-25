using AweSomeShop.Orders.Application.Commands;
using AweSomeShop.Orders.Application.Subscribers;
using AweSomeShop.Orders.Core.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AweSomeShop.Orders.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddHandler(this IServiceCollection services){
            services.AddMediatR(typeof(AddOrderCommand));
            return services;
        }

        public static IServiceCollection AddSubscriber(this IServiceCollection services){
            services.AddHostedService<PaymentAcceptedSubscriber>();
            return services;
        }
    }
}