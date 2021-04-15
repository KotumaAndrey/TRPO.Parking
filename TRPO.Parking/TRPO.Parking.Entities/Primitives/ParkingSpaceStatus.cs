namespace TRPO.Parking.Entities.Primitives
{
    /// <summary>
    /// Статус парковочного места
    /// </summary>
    public enum ParkingSpaceStatus
    {
        /// <summary>
        /// Место свободно
        /// </summary>
        Free = 1,

        /// <summary>
        /// Место занять
        /// </summary>
        Rented = 2,

        /// <summary>
        /// Место просрочено
        /// </summary>
        Late = 3,
    }
}
