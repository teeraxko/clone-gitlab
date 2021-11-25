using System;
using System.Text;
using System.Data;

using ictus.Framework.ASC.Entity;

namespace ictus.Framework.ASC.DataAccess.DNF20
{
    public abstract class DataAccessBase<E, C> : ictus.Framework.ASC.DataAccess.IDataAccessBase where E : IEntityBase where C : ICollectionBase
    {
        protected DataAccessBase() : base()
        {
            tableAccess = new TableAccess();
        }
        
        private TableAccess tableAccess;

        protected abstract string getTableName();
        protected abstract string getSQLSelect();
        protected abstract string getSQLInsert();
        protected abstract string getSQLUpdate();
        protected abstract string getSQLDelete();
        protected abstract string getBaseCondition(CriteriaBase criteria);
        protected abstract string getKeyCondition(E value);

        protected abstract void fill(E value, IDataReader dr);

        protected virtual bool fetch(E value, string sql)
        {
            //IDataReader dataReader = new ASCDataReader(tableAccess.ExecuteDataReader(sql));
            //bool result = dataReader.Read();
            //if (result)
            //{
            //    fill(value, dataReader);
            //}
            //return result;

            return false;
        }

        protected virtual bool fetch(C value, string sql)
        {
            return false;
        }

        //============================== Public Method ==============================
        public virtual bool Fill(E value, CriteriaBase criteria)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(" From ");
            stringBuilder.Append(getTableName());
            stringBuilder.Append(getBaseCondition(criteria));
            stringBuilder.Append(getKeyCondition(value));

            return fetch(value, stringBuilder.ToString());
        }

        public virtual bool FillCollection(C value, CriteriaBase criteria)
        {
            return false;
        }

        public virtual bool Insert(E value)
        {
            return false;
        }

        public virtual bool Insert(C value)
        {
            return false;
        }

        public virtual bool Update(E value)
        {
            return false;
        }

        public virtual bool Update(C value)
        {
            return false;
        }

        public virtual bool Delete(E value)
        {
            return false;
        }

        public virtual bool Delete(C value)
        {
            return false;
        }
    }
}