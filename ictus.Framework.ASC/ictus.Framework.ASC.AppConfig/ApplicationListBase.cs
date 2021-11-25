using System;
using System.Collections;
using System.Collections.Specialized;

namespace ictus.Framework.ASC.AppConfig
{
	public class ApplicationListBase : NameObjectCollectionBase
	{
		public ApplicationListBase() : base()
		{
		}

		public virtual void Add(string key, object value)
		{
			base.BaseAdd(key, value);
		}

		public virtual void Remove(string key)
		{
			base.BaseRemove(key);
		}

		public void Clear()
		{
			base.BaseClear();
		}

		public bool Contain(string key)
		{
			return (bool)(base.BaseGet(key) != null);
		}
	}
}
