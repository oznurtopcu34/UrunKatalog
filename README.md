# Ürün Katalog – E-Ticaret Platformu

Bu e-ticaret platformu, kullanıcı dostu, güvenli ve yönetilebilir bir alışveriş deneyimi sunmak için geliştirilmiştir. **ASP.NET Core MVC** ve **Onion (Katmanlı) Mimari** kullanılarak esnek ve ölçeklenebilir bir yapı oluşturulmuştur.

Çözümde **iki giriş noktası** vardır: **MVC web uygulaması** (tarayıcı, yönetim panelleri) ve **REST API** (JWT ile kimlik doğrulama, mobil/SPA entegrasyonu için).

---

## Çözüm Yapısı (Solution)

| Proje | Açıklama |
|-------|----------|
| **Onion.Domain** | Entity'ler, repository arayüzleri, enum'lar. Hiçbir katmana bağımlı değildir. |
| **Onion.Infrastructure** | EF Core, DbContext, repository implementasyonları, veritabanı konfigürasyonları. |
| **Onion.Application** | İş kuralları, servis arayüzleri ve implementasyonları, DTO'lar, AutoMapper profilleri. |
| **Onion.UIWebApp** | MVC web uygulaması (Razor, Areas ile paneller). Kullanıcı ve yönetici arayüzü. |
| **Onion.Api** | REST API (JWT, Swagger). Mobil uygulama veya SPA tarafından tüketilebilir. |

**Bağımlılık yönü:** UIWebApp ve Api → Application → Infrastructure → Domain. Domain en içte, dış katmanlar ona bağımlı.

---

## Onion (Katmanlı) Mimari

- **Domain:** Sadece modeller ve repository **arayüzleri**. Veritabanı veya framework referansı yok.
- **Application:** Servis **arayüzleri + implementasyonlar** (örn. `IUserService` / `UserService`), DTO'lar, mapper'lar. Repository'leri Domain üzerinden kullanır.
- **Infrastructure:** Repository **implementasyonları**, `ProductDbContext`, EF Core, migration'lar. Veri erişim detayları burada.
- **UIWebApp / Api:** Sadece sunum ve giriş noktası; iş mantığı Application servisleri üzerinden yürütülür.

SOLID prensiplerine uyumluluk hedeflenmiştir (özellikle Dependency Inversion: üst katmanlar arayüzlere bağımlı).

---

## MVC Web Uygulaması (Onion.UIWebApp)

Tarayıcıdan kullanılan, sayfa tabanlı (Razor) e-ticaret ve yönetim uygulaması.

### Kullanılan Teknolojiler

- **Backend:** ASP.NET Core MVC
- **Veritabanı:** SQL Server, Entity Framework Core
- **Kimlik doğrulama:** Microsoft Identity (cookie tabanlı), roller: `User`, `Manager`, `ContentManager`, `CustomerService`
- **Frontend:** HTML, CSS, JavaScript, **Razor**, **Bootstrap**, **jQuery**, jQuery Validation (unobtrusive)
- **Mapping:** AutoMapper (Entity ↔ DTO, UI için ayrı UIMapper profilleri)
- **Hata takibi:** Sentry (uygulama hatalarının izlenmesi ve raporlanması)

### Areas (Yönetim / Kullanıcı Panelleri)

| Area | Rol | İçerik (kısaca) |
|------|-----|------------------|
| **UserPanel** | User | Kullanıcı paneli, siparişlerim, şikayet, SSS (FAQ) |
| **ManagerPanel** | Manager | Ürün ekleme/güncelleme, kategori, teklifler (Bid), iade talepleri, haftalık siparişler |
| **ContentManagerPanel** | ContentManager | Blog yazıları, haberler, içerik kategorileri, ürün listesi/güncelleme |
| **CustomerServicePanel** | CustomerService | Şikayetler, SSS yönetimi, iade talepleri |

Tüm panel controller'ları `[Authorize(Roles = "...")]` ile korunur; giriş yapmamış veya yetkisiz kullanıcı girişe alınmaz.

### Kayıtlı Servisler (Program.cs)

- **Application servisleri:** User, Cart, CartItem, Category, Order, OrderItem, Product, Return, ReturnItem, BlogPost, News, ContentCategory, FAQ, Complaint, Bid
- **Repository'ler:** Her entity için ilgili repository interface (Domain) → implementasyon (Infrastructure) kayıtlı
- **AutoMapper:** Tüm assembly'lerdeki profil'ler taranarak eklenir

### Veritabanı

- `ProductDbContext` (Infrastructure), SQL Server. Connection string `appsettings.json` içinde `DefaultConnection` ile verilir.

---

## REST API (Onion.Api)

Mobil uygulama, SPA veya harici istemcilerin kullanabileceği REST API. Kimlik doğrulama **JWT Bearer** ile yapılır.

### Kullanılan Teknolojiler

- **Çerçeve:** ASP.NET Core (Web API)
- **Veritabanı:** Aynı SQL Server / `ProductDbContext` (MVC ile aynı veritabanı kullanılabilir)
- **Kimlik doğrulama:** Microsoft Identity + **JWT Bearer** (token tabanlı)
- **Dokümantasyon:** **Swagger (Swashbuckle)** – Development ortamında `/swagger` açılır; JWT Bearer tanımlı
- **Cache:** **Redis** (StackExchange.Redis). Connection string yoksa **memory distributed cache** kullanılır
- **Application katmanı:** User, Token, **Cache** servisleri kullanılır (`ICacheService`, `IUserService`, `ITokenService`)

### Önemli Endpoint’ler

| Metot | Yol | Açıklama |
|-------|-----|----------|
| POST | `/api/auth/login` | Kullanıcı adı/e-posta + şifre ile giriş; yanıtta JWT token, kullanıcı bilgisi, roller, token son kullanma süresi |
| POST | `/api/auth/logout` | Çıkış (Bearer token gerekir; istemci token’ı kendisi silmeli) |

Login yanıtında `token`, `userName`, `email`, `roles`, `expiresAt` döner. Koruma gerektiren endpoint’lerde `Authorization: Bearer {token}` header’ı gönderilir.

### Yapılandırma (appsettings)

- **ConnectionStrings:** `DefaultConnection` (SQL Server), `Redis` (örn. `localhost:6379`)
- **JwtSettings:** `SecretKey`, `Issuer`, `Audience`, `ExpirationInMinutes`

Redis bağlantısı tanımlı değilse API, dağıtık cache için otomatik olarak **memory cache** kullanır (Docker/Redis zorunlu değil).

### Çalıştırma

- API’yi ayağa kaldırın; Development’ta kök adres (`/`) `/swagger` sayfasına yönlendirilir.
- Swagger’da **Authorize** ile login’den alınan token’ı `Bearer {token}` olarak girip korumalı endpoint’leri test edebilirsiniz.

---

## Ortak Kullanılanlar (Application / Domain)

- **DTO’lar:** Login, kullanıcı, ürün, kategori, sipariş, iade, şikayet, blog, haber, SSS, teklif vb. (Application/Model/DTO's)
- **Servisler:** User, Token, Cache, Product, Category, Order, Cart, BlogPost, News, FAQ, Complaint, Bid, Return, ContentCategory… (Application/Services; her biri interface + implementasyon)
- **Mapper’lar:** Entity ↔ DTO dönüşümleri (Application/Mapper; UI için ek profil’ler UIWebApp içinde)

---

## İleride Yapılacaklar / Notlar

- **Redis (Docker):** Docker kurulduktan sonra Redis kullanmak için:
  - Container çalıştır: `docker run -d -p 6379:6379 --name redis redis`
  - API zaten `ConnectionStrings:Redis` ile `localhost:6379` bekliyor; Redis çalışınca cache otomatik Redis’e geçer.
  - Docker yokken `Redis` connection string’i boş/eksik bırakılırsa uygulama memory cache kullanır.
