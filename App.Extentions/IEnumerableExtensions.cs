using App.Common.Comparers;
using App.Common.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Extentions
{
    [DebuggerStepThrough]
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> value, Func<T, T, bool> comparer, Func<T, int> hashCode)
        {
            return value.Distinct(new GenericEqualityComparer<T>(comparer, hashCode));
        }

        public static IEnumerable<T> SafeConcat<T>(this IEnumerable<T> value, IEnumerable<T> second)
        {
            if (value.IsNotNull() && second.IsNotNull())
            {
                return value.Concat(second);
            }
            else if (value.IsNotNull())
            {
                return value;
            }
            else if (second.IsNotNull())
            {
                return second;
            }

            return new T[] { };
        }

        /// <summary>
        /// Writes dictionary data to csv
        /// </summary>
        public static byte[] ToCSVData(this IEnumerable<Dictionary<string, object>> value)
        {
            var csvData = string.Empty;

            if (value.Count() > 0)
            {
                var firstRow = value.First();

                csvData += firstRow.Keys.ToCSV(k => k) + "\r\n";

                foreach (var item in value)
                {
                    csvData += item.Values.ToCSV(v => v.AsString().Replace(',', ' ')) + "\r\n";
                }
            }

            return System.Text.Encoding.ASCII.GetBytes(csvData);
        }

        /// <summary>
        ///  Determines whether a sequence contains a specified element(s) by using a predicate
        /// </summary>
        public static bool Contains<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Any(predicate);
        }

        /// <summary>
        ///  Determines whether a sequence contains a specified element(s) by using a predicate
        /// </summary>
        public static bool ContainsAndNotEmpty<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source.IsNull())
            {
                return false;
            }

            return source.Count() > 0 && source.Any(predicate);
        }

        /// <summary>
        ///  Determines whether all items in a sequence adheres to the predicate
        /// </summary>
        public static bool AllAndNotEmpty<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.Count() > 0 && source.All(predicate);
        }

        /// <summary>
        /// Returns a bool indicating whether the list contains any items
        /// </summary>
        public static bool HasItems<TSource>(this IEnumerable<TSource> source)
        {
            return source.IsNotNull() && source.Count() > 0;
        }

        /// <summary>
        /// Returns a bool indicating whether the list contains any items
        /// </summary>
        public static bool HasItems(this IEnumerable source)
        {
            return source.OfType<object>().HasItems();
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> list, Action<TSource> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static IEnumerable<TSource> Batch<TSource>(this IEnumerable<TSource> list, int batchNumber, int batchSize)
        {
            return list.Skip((batchNumber * batchSize) - batchSize).Take(batchSize);
        }

        /// <summary>
        /// Applies rounding to adhere to target value. Very useful for a list of percentages not adding up to 100.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">the list of objects the contain the values on one of the properties</param>
        /// <param name="targetAmount">The amount the method must adhere to (e.g. 100 for percentages)</param>
        /// <param name="propertyValue">A delegate to the property  containg the values in the lilst</param>
        /// <param name="modifyPropertyValue">A delegate to set the property value. Used by the method to update one of the entries</param>
        /// <param name="capToTargetAmount">Indicates whether method should force values to be deducted if the sum of values are over the target (default is false)</param>
        public static void ApplyRounding<T>(this IEnumerable<T> values, decimal targetValue, Func<T, decimal> propertyValue, Action<T, decimal> modifyPropertyValue, bool capToTargetValue = false)
        {
            if (values.Count() > 0)
            {
                var currentTotalValue = values.Sum(v => propertyValue(v));

                if (capToTargetValue)
                {
                    if (currentTotalValue > targetValue)
                    {
                        var lastItem = values.Last();
                        var lastItemValue = propertyValue(lastItem);
                        lastItemValue -= currentTotalValue - targetValue;
                        modifyPropertyValue(lastItem, lastItemValue);
                    }
                }
                else
                {
                    Invariant.IsFalse(currentTotalValue > targetValue, () => "Total sum of values may not be more than target value");
                }

                var results = new List<decimal>();

                foreach (var item in values)
                {
                    results.Add(propertyValue(item));
                }

                var total = results.Sum();
                var diff = targetValue - total;

                if (diff != 0)
                {
                    var itemIndex = results.IndexOf(results.OrderByDescending(f => f).First());
                    var value = values.ToArray()[itemIndex];
                    modifyPropertyValue(value, propertyValue(value) + diff);
                }
            }
        }

        public static IEnumerable<T> ReOrderList<T>(this IEnumerable<T> list, string[] order, Func<T, string> comparerDelegate)
        {
            var reorderedList = new List<T>();
            for (var i = 0; i < order.Length; i++)
            {
                var value = order[i];
                var item = list.FirstOrDefault(o => value == comparerDelegate.Invoke(o));
                if (item.IsNotNull())
                {
                    reorderedList.Add(item);
                }
            }
            return reorderedList;
        }

        public static string ToCSV<T>(this IEnumerable<T> value, Func<T, string> property)
        {
            return value.ToCSV(property, ",");
        }

        public static string ToCSV<T>(this IEnumerable<T> value, Func<T, string> property, string separator)
        {
            if (value.IsNotNull())
            {
                return string.Join(separator, value.Select(v => property(v)).ToArray());
            }
            return string.Empty;
        }

        public static IList<KeyValuePair<string, decimal?>> ToKeyValuePair<T>(this IEnumerable<T> source, Func<T, string> key, Func<T, decimal?> value)
        {
            var result = new List<KeyValuePair<string, decimal?>>();

            foreach (var item in source)
            {
                result.Add(new KeyValuePair<string, decimal?>(key.Invoke(item), value.Invoke(item)));
            }

            return result;
        }

        public static IEnumerable<object> EnumerateObjects(this IEnumerable value)
        {
            var result = new List<object>();

            if (value.IsNotNull())
            {
                var enumerator = value.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    result.Add(enumerator.Current);
                }
            }

            return result;
        }

        public static IEnumerable<T> FilterInt<T>(this IEnumerable<T> result, Func<T, int?> propertyValue, int? value) where T : class
        {
            if (value.HasValue)
            {
                return result.Where(r => propertyValue(r).HasValue && propertyValue(r).Value == value.Value).ToList();
            }

            return result;
        }

        public static IEnumerable<T> FilterStringLike<T>(this IEnumerable<T> result, Func<T, string> propertyValue, string value) where T : class
        {
            if (value.IsNotNullOrEmpty())
            {
                return result.Where(r => propertyValue(r).IsNotNullOrEmpty() && propertyValue(r).IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            return result;
        }

        public static IEnumerable<T> FilterStringEquals<T>(this IEnumerable<T> result, Func<T, string> propertyValue, string value) where T : class
        {
            if (value.IsNotNullOrEmpty())
            {
                value = value.ToUpperInvariant();
                return result.Where(r => propertyValue(r).IsNotNullOrEmpty() && string.Compare(propertyValue(r), value, StringComparison.OrdinalIgnoreCase) == 0).ToList();
            }

            return result;
        }

        public static IEnumerable<T> FilterStringCSV<T>(this IEnumerable<T> result, Func<T, string> propertyValue, string value) where T : class
        {
            if (value.IsNotNullOrEmpty())
            {
                var values = value.ToUpperInvariant().Split(',');
                return result.Where(r => propertyValue(r).IsNotNullOrEmpty() && values.Contains(propertyValue(r).ToUpperInvariant())).ToList();
            }

            return result;
        }

        public static int SafeCount<T>(this IEnumerable<T> source)
        {
            if (source.IsNotNull())
            {
                return source.Count();
            }

            return 0;
        }
    }
}
