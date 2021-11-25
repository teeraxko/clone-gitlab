using System;

namespace ictus.Framework.ASC.Entity
{
    public interface ICollectionBase
    {   
        int Count{get;}

        void Add(IEntityBase value);
        void Remove(IEntityBase value);
        void Remove(string EntityKey);
        void Clear();
        void Contains(IEntityBase value);
        void Contains(string EntityKey);
    }
}
