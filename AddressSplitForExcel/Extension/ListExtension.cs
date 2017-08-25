using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.ComponentModel;

namespace AddressSplitForExcel.Extension
{
    public static class ListExtension
    {
        public static DataTable ToTable<T>(this IEnumerable<T> list)
        {
            DataTable table = CreateDatatable(typeof(T));
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
            foreach(var item in list)
            {
                DataRow row = table.NewRow();
                foreach(PropertyDescriptor prop in properties)
                {
                    if (table.Columns.Contains(prop.Name))
                    {
                        if (prop.PropertyType == typeof(string))
                        {
                            row[prop.Name] = prop.GetValue(item) ?? string.Empty;
                        }
                        else if (prop.PropertyType == typeof(DateTime)) 
                        {
                            DateTime? dt = (prop.GetValue(item) as DateTime?);
                            if(dt != System.DateTime.MinValue)
                            {
                                row[prop.Name] = dt;
                            }
                            else
                            {
                                row[prop.Name] = System.Data.SqlTypes.SqlDateTime.MinValue;
                            }
                        }
                        else
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateDatatable(Type T)
        {
            DataTable table = new DataTable();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(T);
            foreach(PropertyDescriptor prop in properties)
            {
                Type columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                table.Columns.Add(prop.Name, columnType);
            }
            return table;
        }
    }
}
