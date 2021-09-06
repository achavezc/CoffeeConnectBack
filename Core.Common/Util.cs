using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Core.Common
{
    public static class Util
    {
        /// <summary>
        /// Convert a list to a datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="SkipGenericTypes">Parameter to bypass generic types</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection, bool SkipGenericTypes = false)
        {
            DataTable dt = new DataTable("DataTable");
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();

            //Inspect the properties and create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                Type ColumnType = pi.PropertyType;
                if ((ColumnType.IsGenericType))
                {
                    if (!SkipGenericTypes)
                    {
                        ColumnType = ColumnType.GetGenericArguments()[0];
                    }
                    else
                    {
                        continue;
                    }
                }
                dt.Columns.Add(pi.Name, ColumnType);
            }

            //Populate the data table
            foreach (T item in collection)
            {
                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    if (pi.GetValue(item, null) != null)
                    {
                        if (dr.Table.Columns.Contains(pi.Name))
                        {
                            dr[pi.Name] = pi.GetValue(item, null);
                        }
                    }
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
