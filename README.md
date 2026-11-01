Предметная область: Авиакомпания (сущность Flight).

## API Endpoints

| Метод | URL | Назначение |
|---|---|---|
| GET | /api/flights | получить список всех рейсов |
| GET | /api/flights/{id} | получить рейс по номеру |
| POST | /api/flights | создать новый рейс |
| PUT | /api/flights/{id} | изменить рейс |
| DELETE | /api/flights/{id} | удалить рейс |


### GET /api/flights
**Ответ (200 OK):**
```json
[
  {
    "nomer_reisa": 1,
    "gorod_vilet": "Минск",
    "gorod_prilet": "Москва",
    "vremya_vileta": "2026-11-15T08:30:00",
    "cena": 250,
    "mesta": 45,
    "dostupno": true
  }
]