# Dev_Sec_CSharp

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=.net)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue?style=flat-square)](LICENSE.txt)
[![GitHub](https://img.shields.io/badge/github-devwebsec-181717?style=flat-square&logo=github)](https://github.com/devwebsec/Dev_Sec_CSharp)

Комплексный шаблон для безопасной разработки и развертывания ASP.NET Core приложений с интегрированными инструментами DevSecOps, включая SAST, SCA, DAST анализ, контейнеризацию и оркестрацию в Kubernetes.

## 📋 Содержание

- [Возможности](#-возможности)
- [Технический стек](#-технический-стек)
- [Требования](#-требования)
- [Установка](#-установка)
- [Быстрый старт](#-быстрый-старт)
- [Структура проекта](#-структура-проекта)
- [Конфигурация](#-конфигурация)
- [Функции безопасности](#-функции-безопасности)
- [Тестирование](#-тестирование)
- [Развертывание](#-развертывание)
- [Внесение изменений](#-внесение-изменений)
- [Лицензия](#-лицензия)

## 🚀 Возможности

- ✅ ASP.NET Core 8.0 приложение с лучшими практиками безопасности
- ✅ JWT аутентификация и авторизация
- ✅ Конфигурация секретов через переменные окружения и User Secrets
- ✅ Структурированное логирование (Serilog)
- ✅ Swagger/OpenAPI документация
- ✅ CORS конфигурация
- ✅ DevSecOps pipeline с автоматическими проверками безопасности
- ✅ Docker контейнеризация
- ✅ Kubernetes готовые манифесты

## 🛠 Технический стек

| Компонент | Версия | Назначение |
|-----------|--------|-----------|
| .NET | 8.0 | Runtime и фреймворк |
| ASP.NET Core | 8.0.8 | Web фреймворк |
| Serilog | 8.0.2 | Логирование |
| Swagger/Swashbuckle | 6.7.3 | API документация |
| JWT Bearer | 8.0.8 | Аутентификация |

## 📦 Требования

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) или новее
- Git
- Docker (опционально, для контейнеризации)

## 📥 Установка

### 1. Клонирование репозитория

```bash
git clone https://github.com/devwebsec/Dev_Sec_CSharp.git
cd Dev_Sec_CSharp
```

### 2. Восстановление зависимостей

```bash
dotnet restore
```

### 3. Конфигурация окружения

```bash
cp .env.example .env
# Отредактировать .env файл с вашими параметрами
```

### 4. Сборка проекта

```bash
dotnet build
```

## 🏃 Быстрый старт

### Локальный запуск

```bash
cd src/MySecureApp
dotnet run
```

Приложение будет доступно по адресам:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`
- Swagger UI: `https://localhost:5001/swagger`

### Проверка здоровья приложения

```bash
curl -k https://localhost:5001/api/health/status
```

### Ожидаемый результат

```json
{
  "status": "healthy",
  "timestamp": "2026-09-07T10:30:00Z"
}
```

## 📂 Структура проекта

```
Dev_Sec_CSharp/
├── src/
│   └── MySecureApp/
│       ├── Program.cs                 # Точка входа приложения
│       ├── Controllers/               # API контроллеры
│       │   └── HealthController.cs    # Health check endpoint
│       ├── Properties/                # Конфигурация проекта
│       └── MySecureApp.csproj         # Файл проекта
├── .github/
│   └── workflows/                     # CI/CD pipelines
├── .env.example                       # Пример конфигурации
├── .gitignore                         # Git исключения
├── LICENSE.txt                        # MIT Лицензия
└── README.md                          # Этот файл
```

## ⚙️ Конфигурация

### Переменные окружения

Создайте файл `.env` на основе `.env.example`:

```env
# Окружение приложения
ASPNETCORE_ENVIRONMENT=Development

# URLs
ASPNETCORE_URLS=https://localhost:5001;http://localhost:5000

# Секретные ключи
JWT_SECRET_KEY=your-secret-key-here-change-in-production

# Подключение к БД
CONNECTION_STRINGS__DefaultConnection=Server=localhost;Database=MyApp;User Id=sa;Password=Your_password123;

```

### Сертификаты HTTPS

Для локальной разработки создайте доверенный сертификат:

```bash
dotnet dev-certs https --trust
```

## 🔒 Функции безопасности

- **JWT Аутентификация** - Безопасная аутентификация с JWT токенами
- **CORS** - Контроль кросс-доменных запросов
- **HTTPS** - Обязательное шифрование в пути
- **Serilog Логирование** - Аудит и отслеживание событий безопасности
- **User Secrets** - Локальное управление конфиденциальной информацией
- **DevSecOps Pipeline** - Автоматические проверки безопасности в CI/CD

## 🧪 Тестирование

Автоматические тестовые проекты пока не входят в репозиторий. Проверка сборки выполняется в CI командой `dotnet build`.

## 🚢 Развертывание

### Docker

```bash
# Сборка образа
docker build -t mysecureapp:latest .

# Запуск контейнера
docker run -p 5000:80 -p 5001:443 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  -e JWT_SECRET_KEY=your-secret \
  mysecureapp:latest
```

### Kubernetes

```bash
# Применить манифесты
kubectl apply -f k8s/

# Проверить статус
kubectl get pods
kubectl get services
```

## 🤝 Внесение изменений

1. Создайте ветку для вашей функции (`git checkout -b feature/AmazingFeature`)
2. Сделайте коммиты (`git commit -m 'Add some AmazingFeature'`)
3. Отправьте в удаленный репозиторий (`git push origin feature/AmazingFeature`)
4. Откройте Pull Request

## 📝 Лицензия

Этот проект распространяется под лицензией MIT. См. файл [LICENSE.txt](LICENSE.txt) для деталей.

## 📞 Поддержка

При возникновении проблем:
- Проверьте [Issues](https://github.com/devwebsec/Dev_Sec_CSharp/issues)
- Создайте новую Issue с детальным описанием проблемы
- Приложите логи и информацию о вашей системе

---

**Версия**: 1.0.0  
**Последнее обновление**: 2026-09-07
