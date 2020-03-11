using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCities.Data.Models
{
    public class City
    {
        #region Constructor
        public City()
        {
            
        }

        #endregion

        #region Properties

        /// <summary>
        /// The Unique id and primary key for this city
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// City name (In UTF8 format)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// City name (In ASCII format)
        /// </summary>
        public string Name_ASCII { get; set; }

        /// <summary>
        /// City Latitude
        /// </summary>
        public decimal Lat { get; set; }

        /// <summary>
        /// City Longitude
        /// </summary>
        public decimal Lon { get; set; }

        /// <summary>
        /// County Id (foreign key)
        /// </summary>
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The Country related to this city
        /// </summary>
        public virtual Country Country { get; set; }

        #endregion
    }
}
