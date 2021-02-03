using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;

namespace Core.Utils
{
    public static class Extensions
    {
        public static DataTable ToDataTable<T>(this List<T> data)
        {
            DataTable table = new DataTable();

            if (data != null)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

                foreach (PropertyDescriptor prop in props)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in props)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                    table.Rows.Add(row);
                }

            }
            return table;
        }

        public static DataTable ToDataTableScalar<T>(this List<T> list)
        {
            DataTable listaGenerica = new DataTable();
            listaGenerica.Columns.Add("value", typeof(string));

            list.ForEach(x => listaGenerica.Rows.Add(x));

            return listaGenerica;
        }
    }
}
