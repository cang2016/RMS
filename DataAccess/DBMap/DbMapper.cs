using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using RMS.DataAccess;
using RMS.Utility;

namespace RMS.DataAccess
{
    /// <summary>
    /// 实现对象自动数据库相关操作类.
    /// </summary>
    /// <typeparam name="C">实现IDbConnectionString接口的连接串类.</typeparam>
    /// <typeparam name="P">实现IDbProviderName接口的数据库引擎名称.</typeparam>
    /// <typeparam name="T">实例对象类型.</typeparam>
    public class DbMapper<C, P, T> : DbOperationExx<C, P>, IDbMapper<T>
        where C : IDbConnectionString, new()
        where P : IDbProviderName, new()
    {
        #region Fileds

        private Type m_type;
        private string m_tableName;
        private Dictionary<string, PropertyInfo> m_propertyInfoDictonary;
        private List<string> m_propertyNameList;
        private string[] m_dbParams;
        private string[] m_fullDbParamsForUpdateOrDelete;

        private bool containsIdentification = false;
        private OperationType operationType;

        #endregion Fileds

        #region Constructor

        /// <summary>
        /// Construct a class provides UPDATE/SELECT/INSERT/DELETE methods
        /// to database.
        /// Typical Usage likes this:
        /// DBMapper dbMapper 
        ///     = new DBMapper(
        ///         typeof(EMENTITY)
        ///       );
        /// dbMapper.Insert(...);
        /// dbMapper.Get(...);
        /// dbMapper.GetAll(...);
        /// dbMapper.Delete(...);
        /// dbMapper.Update(...);
        /// </summary>
        /// <param name="t">
        /// TypeInfo of the specific entity.
        /// </param>
        /// <param name="tablename">
        /// Name of the target table.
        /// </param>
        public DbMapper()
        {
            this.m_type = typeof(T);

            string tablename = string.Empty;
            if(!this.m_type.IsClass)
            {
                throw new Exception("Only class is supported!");
            }

            object[] attributes = this.m_type.GetCustomAttributes(false);
            if(attributes.Length > 0)
            {
                foreach(object attr in attributes)
                {
                    if(attr is DataTableNameAttribute)
                    {
                        tablename = (attr as DataTableNameAttribute).TableName;
                        containsIdentification = (attr as DataTableNameAttribute).ContainsIdentification;
                    }
                }
            }
            else
            {
                tablename = m_type.Name;
            }

            this.m_tableName = tablename.ToUpper();

            List<string> paramnames = new List<string>();
            Dictionary<string, PropertyInfo> dicPropertyInfo = new Dictionary<string, PropertyInfo>();

            foreach(PropertyInfo propertyInfo in m_type.GetProperties())
            {
                paramnames.Add(propertyInfo.Name);
                dicPropertyInfo[propertyInfo.Name] = propertyInfo;
            }

            this.m_propertyInfoDictonary = dicPropertyInfo;
            this.m_propertyNameList = paramnames;

            int colCount = this.m_propertyNameList.Count;

            this.m_dbParams = new string[colCount + 1];
            this.m_fullDbParamsForUpdateOrDelete = new string[colCount * 2 + 1];
            this.m_dbParams[0] = "TransactionStatement";
            this.m_fullDbParamsForUpdateOrDelete[0] = "TransactionStatement";
            for(int index = 1; index <= colCount; index++)
            {
                string colname = this.m_propertyNameList[index - 1].ToUpper();
                this.m_dbParams[index] = colname;
                this.m_fullDbParamsForUpdateOrDelete[index] = colname;
                this.m_fullDbParamsForUpdateOrDelete[index + colCount] = String.Concat("where_", colname);
            }
        }

        #endregion Constructor

        #region SELECT

        /// <summary>
        /// Retrieve single object record whose column values matches values specified in $selection$.
        /// </summary>
        /// <param name="selection">
        /// selection condition
        /// </param>
        /// <returns>
        /// Records stored in entity format.
        /// If value in database is DBNull.Value, it will be converted to:
        ///     String.Empty for String type,
        ///     DateTime.MinValue for DateTime type,
        ///     Int32.MinValue for Int32 type,
        ///     Double.NaN for Double type,
        ///     Decimal.MinValue for Decimal type,
        ///     null for other types.
        /// </returns>
        public T GetObjectInstance(T selection)
        {
            operationType = OperationType.Select;
            return GetObjectInstanceList(selection).FirstOrDefault<T>();
        }

        /// <summary>
        /// Retrieve records whose column values matches values specified in $selection$.
        /// </summary>
        /// <param name="selection">
        /// selection condition
        /// </param>
        /// <returns>
        /// Records stored in entity format.
        /// If value in database is DBNull.Value, it will be converted to:
        ///     String.Empty for String type,
        ///     DateTime.MinValue for DateTime type,
        ///     Int32.MinValue for Int32 type,
        ///     Double.NaN for Double type,
        ///     Decimal.MinValue for Decimal type,
        ///     null for other types.
        /// </returns>
        public IList<T> GetObjectInstanceList(T selection)
        {
            operationType = OperationType.Select;
            object[] dbValues = new object[this.m_dbParams.Length];

            dbValues[0] = Convert.ToString(OperationType.Select);

            GenerateDbValues(selection, dbValues, containsIdentification);

            return Get(dbValues);
        }

        /// <summary>
        /// Get all records of target table.
        /// </summary>
        /// <returns>
        /// A list of entity.
        /// If value in database is DBNull.Value, it will be converted to:
        ///     String.Empty for String type,
        ///     DateTime.MinValue for DateTime type,
        ///     Int32.MinValue for Int32 type,
        ///     Double.NaN for Double type,
        ///     Decimal.MinValue for Decimal type,
        ///     null for other types.
        /// </returns>
        public IList<T> GetAllObjectInstanceList()
        {
            operationType = OperationType.Select;
            //object obj;
            //if (TryGetFromCache(out obj))
            //    return obj as IList<T>;

            object[] dbValues = new object[this.m_dbParams.Length];

            dbValues[0] = Convert.ToString(OperationType.Select);
            FillWithDbNull(dbValues);

            IList<T> all = Get(dbValues);
            //SetCache(typeof(T).FullName, all);

            return all;
        }

        /// <summary>
        /// Retrieve records whose values matches values specified in the array.
        /// </summary>
        /// <param name="dbValues">
        /// Array contains N+1 items:
        ///     - 1st one: Actionstatement, indicate which statment to execute,
        ///                including SELECT, INSERT, UPDATE, DELETE.
        ///     - N items: N equals amount of target table's columns. Each one
        ///                means the value of one column.
        /// </param>
        /// <returns>
        ///     Records stored in entity format. Type converted before using.
        /// </returns>
        private IList<T> Get(object[] dbValues)
        {
            operationType = OperationType.Select;
            //using (IDataReader _dtReader = MapperHelper.ExecuteDataReader(
            //                                    Helper.GetInitializedConnStr() ,
            //                                    this.dbParams ,
            //                                    dbValues ,
            //                                    this.SPName))
            //{
            //    return BuildEntityList(_dtReader);
            //}
            DataTable dt = FillDataTable(this.m_tableName, this.m_dbParams, dbValues);
            IList<T> result = BuildEntityList(dt);
            dt.Dispose();
            return result;
        }

        #endregion SELECT

        #region INSERT
        /// <summary>
        /// Add one new record.
        /// </summary>
        /// <param name="record">
        /// Entity object, whose each property could be mapped to one table column.
        /// </param>
        public virtual void Insert(T record, bool containsIdentityColumn = false)
        {
            operationType = OperationType.Insert;
            object[] dbValues = InitializeInsertParam(record, containsIdentityColumn);

            ExecuteNonQuery(
                this.m_dbParams,
                dbValues,
                this.m_tableName, containsIdentityColumn);
        }


        public virtual void Insert(T record)
        {
            Insert(record, containsIdentification);
        }

        /// <summary>
        /// Add multiple records to target database table, transaction enabled.
        /// </summary>
        /// <param name="records">
        /// Entity objects contains content of records.
        /// </param>
        //public virtual void InsertAll(IList<T> records)
        //{
        //    List<object[]> dbValuesList = new List<object[]>();
        //    foreach (T record in records)
        //        dbValuesList.Add(InitializeInsertParam(record));

        //    MapperHelper.ExecuteWithTrans(Helper.GetInitializedConnStr(), this.dbParams, dbValuesList, this.SPName);
        //}


        /// <summary>
        /// Attach the insert activity to a transaction.
        /// </summary>
        /// <param name="record">
        /// Entity object, whose each property could be mapped to one table column.
        /// </param>
        /// <param name="trans"></param>
        //public virtual void AttachInsertToTransaction(T record, OracleTransaction trans)
        //{
        //    object[] dbValues = InitializeInsertParam(record);
        //    MapperHelper.AttachToTransaction(
        //        this.dbParams,
        //        dbValues,
        //        this.SPName,
        //        trans);
        //}


        /// <summary>
        /// Attach these insert activities to a transaction.
        /// </summary>
        /// <param name="records">
        /// Entity objects contains content of records.
        /// </param>
        /// <param name="trans"></param>
        //public virtual void AttachInsertToTransaction(
        //    IList<T> records,
        //    OracleTransaction trans)
        //{
        //    List<object[]> dbValuesList = new List<object[]>();
        //    foreach (T record in records)
        //        dbValuesList.Add(InitializeInsertParam(record));
        //    MapperHelper.AttachToTransaction(
        //        this.dbParams,
        //        dbValuesList,
        //        this.SPName,
        //        trans);
        //}

        #endregion INSERT

        #region DELETE
        /// <summary>
        /// Delete all records match single selection condition, trasaction enabled.
        /// </summary>
        /// <param name="selection">
        /// Values of any number of columns. Used as selection condition.
        /// </param>
        public void Delete(T selection)
        {
            operationType = OperationType.Delete;
            ExecuteNonQuery(
                this.m_dbParams,
                InitializeDeleteParam(selection),
                this.m_tableName);
        }

        #endregion DELETE

        #region UPDATE
        /// <summary>
        /// Update records matches selection condition,
        /// trasaction enabled.
        /// </summary>
        /// <param name="selection">
        /// Values of any number of columns. Used as selection condition.
        /// </param>
        /// <param name="newRecord">
        /// Values of any columns, 
        /// properties with null value mean corresponding columns not changed.
        /// </param>
        public virtual void Update(T selection, T newRecord)
        {
            Update(selection, newRecord, false);
        }

        /// <summary>
        /// Update records matche selection condition,
        /// trasaction enabled.
        /// </summary>
        /// <param name="selection">
        /// Values of any number of columns. Used as selection condition.
        /// </param>
        /// <param name="newRecord">
        /// Values of all columns, 
        /// properties with null value mean corresponding columns 
        /// will be updated with null value.
        /// </param>
        public virtual void UpdateWithNullValue(T selection, T newRecord)
        {
            Update(selection, newRecord, true);
        }

        /// <summary>
        /// Update records matche selection condition,
        /// transaction enabled.
        /// </summary>
        /// <param name="selection"></param>
        /// <param name="newRecord"></param>
        /// <param name="isWithNullValue">
        /// Indicate whether values of db columns will be set to null,
        /// if the corresponding property of the entity newRecord is null value
        /// </param>
        private void Update(T selection, T newRecord, bool isWithNullValue)
        {
            operationType = OperationType.Update;
            ExecuteNonQuery(
                this.m_fullDbParamsForUpdateOrDelete,
                InitializeUpdateParam(selection, newRecord, isWithNullValue),
                this.m_tableName, containsIdentification);
        }


        #endregion UPDATE

        #region Format Input and Output

        /// <summary>
        /// Convert retrive result, which in Database Table format, to list.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public IList<T> BuildEntityList(DataTable dt)
        {
            IList<T> entityList = new List<T>();
            if(dt == null || dt.Rows.Count < 1)
            {
                return entityList;
            }
            foreach(DataRow r in dt.Rows)
            {
                T entity = BuildEntity(r);
                entityList.Add(entity);
            }

            return entityList;
        }

        /// <summary>
        ///    Convert database reocrd to entity.
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="t"></param>
        /// <returns>
        /// A list contains value of database record.
        /// If the value in database is DBNull.Value, it will be converted to:
        ///     String.Empty for String type,
        ///     DateTime.MinValue for DateTime type,
        ///     Int32.MinValue for Int32 type,
        ///     Double.NaN for Double type,
        ///     null for other types.
        /// </returns>
        private T BuildEntity(DataRow dataRow)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            T entity = Activator.CreateInstance<T>();
            for(int index = 0; index < m_propertyNameList.Count; index++)
            {
                object value = dataRow[(m_propertyNameList[index])];
                if(value == null || value == DBNull.Value)
                {
                    string propertyType = m_propertyInfoDictonary[m_propertyNameList[index]].PropertyType.Name;

                    if(Regex.IsMatch(propertyType, "Nullable*"))
                    {
                        value = null;
                    }
                    else
                    {
                        value = MapperConstants.NullValue[propertyType];
                    }
                }

                //Test
                //object newValue = null;
                //try
                //{
                //    newValue = Convert.ChangeType(value, type.GetProperty(PropNames[index]).PropertyType);
                //}
                //catch (InvalidCastException ex)
                //{
                //    newValue = value;
                //}
                //type.GetProperty(PropNames[index]).SetValue(entity, newValue, null);
                //Test End

                m_type.GetProperty(m_propertyNameList[index]).SetValue(entity, value, null);
            }

            return entity;
        }

        /// <summary>
        /// 通过DataReader来获取对象列表.
        /// </summary>
        /// <param name="dtReader">IDataReader</param>
        /// <returns></returns>
        public IList<T> BuildEntityList(IDataReader dtReader)
        {
            IList<T> list = new List<T>();
            if(dtReader.IsClosed)
                return list;

            while(dtReader.Read())
            {
                list.Add(BuildEntity(dtReader));
            }

            return list;
        }

        private T BuildEntity(IDataReader dtReader)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            T entity = Activator.CreateInstance<T>();
            for(int index = 0; index < m_propertyNameList.Count; index++)
            {
                object value = dtReader.GetValue(dtReader.GetOrdinal(m_propertyNameList[index].ToUpper()));
                if(value == null || value == DBNull.Value)
                {
                    string propertyType = m_propertyInfoDictonary[m_propertyNameList[index]].PropertyType.Name;
                    value = MapperConstants.NullValue[propertyType];
                }

                m_type.GetProperty(m_propertyNameList[index]).SetValue(entity, value, null);
            }

            return entity;
        }

        /// <summary>
        /// Initialize values of parameters of insert activity.
        /// </summary>
        /// <param name="record">
        /// Entity object, whose each property could be mapped to one table column.
        /// </param>
        /// <returns></returns>
        private object[] InitializeInsertParam(T record)
        {
            return InitializeInsertParam(record, containsIdentification);
        }

        private object[] InitializeInsertParam(T record, bool containsIdentityColumn)
        {
            object[] dbValues = new object[this.m_dbParams.Length];

            dbValues[0] = Convert.ToString(OperationType.Insert);
            containsIdentityColumn = containsIdentification;
            GenerateDbValues(record, dbValues, containsIdentityColumn);
            return dbValues;
        }


        /// <summary>
        /// Initialize values of parameters of insert activity.
        /// </summary>
        /// <param name="record">
        /// Entity object, whose each property could be mapped to one table column.
        /// </param>
        /// <returns></returns>
        private object[] InitializeDeleteParam(T selection)
        {
            object[] dbValues = new object[this.m_dbParams.Length];
            dbValues[0] = Convert.ToString(OperationType.Delete);
            GenerateDbValues(selection, dbValues, containsIdentification);
            return dbValues;
        }


        /// <summary>
        /// Intialize values of parameters of insert activity with null values.
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        private object[] InitializeDeleteParamWithNull()
        {
            object[] dbValues = new object[this.m_dbParams.Length];
            dbValues[0] = Convert.ToString(OperationType.Delete);
            FillWithDbNull(dbValues);
            return dbValues;
        }


        /// <summary>
        /// Initialize values of parameters of the update activities.
        /// </summary>
        /// <param name="selection"></param>
        /// <param name="newRecord"></param>
        /// <param name="isWithNullValue"></param>
        /// <returns></returns>
        private object[] InitializeUpdateParam(T selection, T newRecord, bool isWithNullValue)
        {
            object[] fullDBValues = new object[this.m_fullDbParamsForUpdateOrDelete.Length];

            if(isWithNullValue)
            {
                fullDBValues[0] = MapperConstants.UPDATE_WITH_NULL_VALUE_STATEMENT;
            }
            else
            {
                fullDBValues[0] = Convert.ToString(OperationType.Update);
            }

            GenerateDbValues(selection, newRecord, fullDBValues);

            return fullDBValues;
        }


        /// <summary>
        /// Fill the last N-1 items of the array with 
        /// values of object properties. 
        /// The first element is already set.
        /// </summary>
        /// <param name="row">
        /// Entity object.
        /// </param>
        /// <param name="dbValues">
        /// Array to fill.
        /// </param>
        protected void GenerateDbValues(T row, object[] dbValues, bool containsIdentityColumn)
        {
            int index = 1;
            foreach(string paramname in m_propertyNameList)
            {
                if(containsIdentityColumn)
                {
                    PropertyInfo propertyInfo = m_propertyInfoDictonary[paramname];
                    TableColumnAttribute colAttr = propertyInfo.GetCustomAttribute<TableColumnAttribute>(false) as TableColumnAttribute;

                    if(colAttr != null && colAttr.IsPrimaryKey&& operationType != OperationType.Delete)
                    {
                        continue;    // 跳过主键列.
                    }
                }

                dbValues[index] = ConvertNoneToDbNull(m_propertyInfoDictonary[paramname].GetValue(row, null));
                if((m_propertyInfoDictonary[paramname].PropertyType.Name.Contains("Int") && Convert.ToInt32(dbValues[index]) < 1)
                    || (m_propertyInfoDictonary[paramname].PropertyType.Name.Contains("Decimal") && Convert.ToDecimal(dbValues[index]) < 1))   // 实型、整形会默认为0
                {
                    dbValues[index] = DBNull.Value;
                }
                if(!MapperConstants.DoNotFilterTimeEntities.Contains(this.m_type))
                {
                    if(m_propertyInfoDictonary[paramname].PropertyType.Name.Equals("DateTime"))
                    {
                        object datetime = dbValues[index];
                        dbValues[index] = datetime.Equals(DBNull.Value) ? datetime : Convert.ToDateTime(datetime);
                    }

                }
                index++;
            }
        }

        /// <summary>
        ///  Fill the last N-1 items of the array with 
        ///  values of object properties. 
        ///  The first element is already set.
        /// </summary>
        /// <param name="entity">
        ///     Entity object.
        /// </param>
        /// <param name="dbRowValue">
        ///     Entity object.
        /// </param>
        /// <param name="dbValues">
        ///     Array to fill.
        /// </param>
        private void GenerateDbValues(T entity, T dbRowValue, object[] dbValues)
        {
            int index = 1;
            int colCount = m_propertyNameList.Count;
            // This order align with order of stored procedure's parameters
            foreach(string paramname in m_propertyNameList)
            {
                dbValues[index] = ConvertNoneToDbNull(m_propertyInfoDictonary[paramname].GetValue(dbRowValue, null));
                dbValues[index + colCount] = ConvertNoneToDbNull(m_propertyInfoDictonary[paramname].GetValue(entity, null));

                if(!MapperConstants.DoNotFilterTimeEntities.Contains(this.m_type))
                {
                    if(m_propertyInfoDictonary[paramname].PropertyType.Name.Equals("DateTime"))
                    {
                        object datetime = dbValues[index];
                        dbValues[index] = datetime.Equals(DBNull.Value) ? datetime : Convert.ToDateTime(datetime).Date;
                        object datetime2 = dbValues[index + colCount];
                        dbValues[index + colCount] = datetime2.Equals(DBNull.Value) ? datetime2 : Convert.ToDateTime(datetime2).Date;
                    }
                }
                index++;
            }
        }

        /// <summary>
        ///     Fill the last N-1 items of the array with 
        ///     DBNull.Value. 
        ///     The first element is already set.
        /// </summary>
        /// <param name="dbValues">
        ///     Array to fill.
        /// </param>
        private void FillWithDbNull(object[] dbValues)
        {
            for(int index = 1; index <= this.m_propertyNameList.Count; index++)
            {
                dbValues[index] = DBNull.Value;
            }
        }

        #endregion UTILITY

        #region Private Method

        /// <summary>
        /// Convert None, Empty, Null value to DbNull.Value.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static object ConvertNoneToDbNull(object item)
        {
            if(item == null)
            {
                return DBNull.Value;
            }
            else if(item.Equals(MapperConstants.NullValue[item.GetType().Name]))
            {
                return DBNull.Value;
            }

            return item;
        }

        #endregion
    }
}
