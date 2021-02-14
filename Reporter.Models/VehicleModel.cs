using System;

namespace Reporter.Models
{
    public class VehicleModel
    {
        /// <summary>
        /// The vehicle Id
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// The manufacturer
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// The model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The registration number
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// The registration date
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// The engine size
        /// </summary>
        public int EngineSize { get; set; }

        /// <summary>
        /// The interior color
        /// </summary>
        public string InteriorColor { get; set; }
    }
}
