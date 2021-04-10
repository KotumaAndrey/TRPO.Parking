namespace TRPO.Parking.Entities.Primitives
{
    /// <summary>
    /// Тип клиента
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// Обычный пользователь
        /// </summary>
        Standart = 1,

        /// <summary>
        /// Постоянный пользователь
        /// </summary>
        Regular = 2,

        /// <summary>
        /// Белый пользователь
        /// </summary>
        White = 3,

        /// <summary>
        /// Серый пользователь
        /// </summary>
        Gray = 4,

        /// <summary>
        /// Черный пользователь
        /// </summary>
        Black = 5
    }
}
