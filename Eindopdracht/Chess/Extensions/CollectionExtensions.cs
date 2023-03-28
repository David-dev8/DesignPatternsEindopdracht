using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Extensions
{

    /// <summary>
    /// This class contains all the extension methods for Generic T collections
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Turns a multidimensional array into a single dimmensional array
        /// </summary>
        /// <typeparam name="T">The datatype of the collection</typeparam>
        /// <param name="value">The Collection to flatten</param>
        /// <returns>A collection with all the allement of the given value in a single dimmension</returns>
        public static IEnumerable<T> Flatten<T>(this ICollection<object> value)
        {
            ICollection<object> currentIteration = value;
            while(currentIteration.Any(element => element is Array))
            {
                IList<object> newIteration = new List<object>();
                foreach(var item in currentIteration)
                {
                    if(item is Array array)
                    {
                        foreach(var element in array)
                        {
                            newIteration.Add(element);
                        }
                    }
                    else
                    {
                        newIteration.Add((T)item);
                    }
                }
                currentIteration = newIteration;
            }
            return currentIteration.Cast<T>();
        }
    }
}
