using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace dnp.nulcommon.dao
{
    /// <summary>
    /// エンティティ基本クラス
    /// </summary>
    public abstract class DbEntity
    {
        public DbEntity()
        {
        }

        public DbEntity(DataRow row)
        {
            foreach (DataColumn col in row.Table.Columns)
            {
                PropertyInfo pi = this.GetType().GetProperties().Where(prop => col.ColumnName.Replace("#", "NO").Equals(prop.Name)).FirstOrDefault();

                if (pi != null)
                {
                    if (Convert.IsDBNull(row[col.ColumnName]))
                    {
                        pi.SetValue(this, null, null);
                    }
                    else if (pi.PropertyType.IsAssignableFrom(row[col.ColumnName].GetType()))
                    {
                        pi.SetValue(this, row[col.ColumnName], null);
                    }
                    else
                    {
                        throw new Exception(col.ColumnName + " : " + pi.PropertyType.Name + " anable set " + row[col.ColumnName].GetType().Name);
                    }
                }
            }
        }
    }
}
