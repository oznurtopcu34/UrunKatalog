# Ürün Katalog – E-Ticaret Platformu

ASP.NET Core MVC ve Onion (Katmanlı) Mimari ile geliştirilmiş e-ticaret platformu. **MVC web uygulaması** (Razor, yönetim panelleri) ve **REST API** (JWT, Swagger) olmak üzere iki giriş noktası vardır.

**Çözüm yapısı:** Domain (entity, repository arayüzleri) → Infrastructure (EF Core, repository implementasyonları) → Application (servisler, DTO’lar) → UIWebApp / Api.

**Kullanılan Teknolojiler:** ASP.NET Core MVC, Web API, Entity Framework Core, SQL Server, Microsoft Identity, JWT Bearer, Swagger (Swashbuckle), Redis (StackExchange.Redis), AutoMapper, Bootstrap, jQuery, Razor, Sentry.

**MVC:** SQL Server, Identity (roller: User, Manager, ContentManager, CustomerService), Bootstrap, jQuery, AutoMapper, Sentry. Areas ile UserPanel, ManagerPanel, ContentManagerPanel, CustomerServicePanel.

**API:** JWT Bearer kimlik doğrulama, Swagger (`/swagger`), Redis cache (yoksa memory). Login: `POST /api/auth/login`, Logout: `POST /api/auth/logout`.

**Sayfalandırma:** Genel yapı kullanılır. Application’da `PagedResult_DTO<T>` ve `IPaginationService`; Domain’de `IBaseRepository.GetPagedAsync`. Servisler kendi liste metodlarında bu yapıyı kullanır (örn. ürün listesi Anasayfa/Katalog’da sayfalı). İleride kategori vb. listelerde aynı kalıp kullanılabilir.

**Not:** Redis için Docker’da `docker run -d -p 6379:6379 --name redis redis`. Redis connection string yoksa API memory cache kullanır.
