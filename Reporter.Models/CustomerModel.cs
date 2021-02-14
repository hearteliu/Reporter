using System;
using System.Collections.Generic;

namespace Reporter.Models
{
    public class CustomerModel
    {
        /// <summary>
        /// The customer Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// The forename
        /// </summary>
        public string Forename { get; set; }

        /// <summary>
        /// The surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The vehicles owned
        /// </summary>
        public List<VehicleModel> VehiclesOwned { get; set; }
    }
}
