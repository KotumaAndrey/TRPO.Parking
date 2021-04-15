namespace TRPO.Parking.Entities.Primitives
{
    /// <summary>
    /// Статус запроса клиента на изменение типа
    /// </summary>
    public enum ClientTypeUpdateRequestStatus
    {
        /// <summary>
        /// Запрос активен
        /// </summary>
        Active = 1,

        /// <summary>
        /// Запрос принят
        /// </summary>
        Accepted = 2,

        /// <summary>
        /// Запрос отклонен
        /// </summary>
        Rejected = 3,
    }
}
