using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class UserAmounts
    {   
        /// <summary>
        /// Converts total users to the number
        /// </summary>
        /// <param name="list"> list with the users</param>
        /// <returns>Returns total users count</returns>
        public int GetTotalUsersCount(List<User> list)
        {   
            int totalUsers = list.Count;
            return totalUsers;
        }

        /// <summary>
        /// Filters the total users based on the country and converts to the number
        /// </summary>
        /// <param name="country">country code</param>
        /// <param name="list">the list of users</param>
        /// <returns>Returns total users by country count</returns>
        public int GetUsersByCountryCount(string country, List<User> list)
        {   
            int userByCountry = list.Where(s => s.Country.Contains(country)).Count();
            return userByCountry;
        }
    }
}
