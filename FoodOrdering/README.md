﻿# Patterns

1. [Repository](Repositories)

2. [DTO](Dto)

3. [Strategy](BusinessLogic/DeliveryStrategy)

4. [Facade](Facades)

5. [Template method](BusinessLogic/PaymentProcessor)

6. [State](BusinessLogic/OrderState)

# Docker

- docker pull postgres

- docker run --name postgres -e POSTGRES_USER=yelov -e POSTGRES_PASSWORD=password -p 5433:5432 -v /home/yelov:/var/lib/postgresql/data -d postgres