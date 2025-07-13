# Biogenom.WebApi — Документация по API

Тестирование API доступно по адресу:  
[http://localhost:5234/swagger/index.html]

## Эндпоинты

### Получить последний отчёт
- **GET** `/api/NutritionReport/last`
- **Описание:** Возвращает последний отчёт пользователя.

### Удалить последний отчёт
- **DELETE** `/api/NutritionReport/last`
- **Описание:** Удаляет последний отчёт пользователя.

### Сохранить новый отчёт
- **POST** `/api/NutritionReport`
- **Описание:** Сохраняет новый индивидуальный отчёт пользователя.
- **Тело запроса:** NutritionReportDto (заполнить обязательно)

### Получить преимущества БАДов
- **GET** `/api/NutritionReport/benefits`
- **Описание:** Возвращает преимущества приёма БАДов.

## Схемы данных (DTO)

**DTO (Data Transfer Object)** — нужен обмена информацией между клиентом и сервером через API.

- **NutritionReportDto** — структура индивидуального отчёта.
- **NutritionElementDto** — элемент нутриента.
- **PersonalizedElementValueDto** — персонализированный набор элементов
- **PersonalizedSetItemDto** — личный набор данных.
