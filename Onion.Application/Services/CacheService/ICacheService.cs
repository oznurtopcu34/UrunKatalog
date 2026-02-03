namespace Onion.Application.Services.CacheService
{
    public interface ICacheService
    {
        /// <summary>
        /// Cache'ten key ile değer okur. Yoksa null döner.
        /// </summary>
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cache'e key-value yazar. Süre verilmezse varsayılan süre kullanılır.
        /// </summary>
        Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpiration = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Belirtilen key'i cache'ten siler.
        /// </summary>
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    }
}
