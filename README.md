# AweSomeShopOrders

O projeto nao tem como objetivo a implementacao de regras de negocio de grande complexidade, mas o uso de tecnologias de mensageria,cache,service discovery e a utilizacao de api gateway

## Features

- Adicionar uma ordem.
- Buscar Ordem por Id.

## Tech

Tecnologia e Patterns utilizados:

- [.Net Core - 6.0] - Backend!.
- [CQRS] - Pattern Command Query Responsibility Segregation.
- [Api Gateway] - Ocelot
- [DataBase] - MongoDB.
- [Service Discovery] - Consul
- [Mensageria] - RabbitMQ Subscriber e Producer
- [Cache] - Redis


## Installation

Executar docker-compose para instalar o MySQL em um container.
Entrar na pasta  `AweSomeShopOrders.API`.

Executar o seguinte comando para executar o projeto.

```sh
dotnet watch run
```
## Swagger

Link: `http://localhost:5000/swagger/index.html`.
