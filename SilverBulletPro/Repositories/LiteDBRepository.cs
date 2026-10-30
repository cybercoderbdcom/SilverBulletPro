using System;
using System.Collections.Generic;
using LiteDB;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Repositories;

namespace SilverBulletPro.Repositories
{
	// Token: 0x020001E0 RID: 480
	public class LiteDBRepository<T> : IRepository<T, Guid> where T : Persistable<Guid>
	{
		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x0004C458 File Offset: 0x0004A658
		// (set) Token: 0x06000F3E RID: 3902 RVA: 0x0004C460 File Offset: 0x0004A660
		public string ConnectionString { get; set; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0004C469 File Offset: 0x0004A669
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x0004C471 File Offset: 0x0004A671
		public string Collection { get; set; }

		// Token: 0x06000F41 RID: 3905 RVA: 0x0004C47A File Offset: 0x0004A67A
		public LiteDBRepository(string connectionString, string collection)
		{
			this.ConnectionString = connectionString;
			this.Collection = collection;
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x0004C490 File Offset: 0x0004A690
		private LiteDatabase Connect()
		{
			this._db = new LiteDatabase("filename=" + this.ConnectionString + "; Connection=Shared;", null);
			this._coll = this._db.GetCollection<T>(this.Collection, 10);
			return this._db;
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x0004C4DD File Offset: 0x0004A6DD
		public void Disconnect(bool dispose = false)
		{
			if (dispose)
			{
				this._db.Dispose();
			}
			this._coll = null;
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0004C4F4 File Offset: 0x0004A6F4
		public void Add(T entity)
		{
			using (this.Connect())
			{
				this._coll.Insert(entity);
				this.Disconnect(false);
			}
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x0004C538 File Offset: 0x0004A738
		public void Add(IEnumerable<T> entities)
		{
			using (this.Connect())
			{
				this._coll.InsertBulk(entities, 5000);
				this.Disconnect(false);
			}
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x0004C584 File Offset: 0x0004A784
		public IEnumerable<T> Get()
		{
			IEnumerable<T> result;
			using (this.Connect())
			{
				result = this._coll.FindAll();
			}
			return result;
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x0004C5C4 File Offset: 0x0004A7C4
		public T Get(Guid id)
		{
			T result;
			using (this.Connect())
			{
				T t = this._coll.FindById(id);
				this.Disconnect(false);
				result = t;
			}
			return result;
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x0004C610 File Offset: 0x0004A810
		public void Remove(T entity)
		{
			using (this.Connect())
			{
				this._coll.Delete(entity.Id);
				this.Disconnect(false);
			}
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x0004C664 File Offset: 0x0004A864
		public void Remove(IEnumerable<T> entities)
		{
			using (this.Connect())
			{
				foreach (T t in entities)
				{
					this._coll.Delete(t.Id);
				}
				this.Disconnect(false);
			}
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x0004C6E8 File Offset: 0x0004A8E8
		public void RemoveAll()
		{
			using (LiteDatabase liteDatabase = this.Connect())
			{
				liteDatabase.DropCollection(this.Collection);
				this.Disconnect(false);
			}
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x0004C72C File Offset: 0x0004A92C
		public void Update(T entity)
		{
			using (this.Connect())
			{
				this._coll.Update(entity);
				this.Disconnect(false);
			}
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x0004C770 File Offset: 0x0004A970
		public void Update(IEnumerable<T> entities)
		{
			using (this.Connect())
			{
				this._coll.Update(entities);
				this.Disconnect(false);
			}
		}

		// Token: 0x04000715 RID: 1813
		private LiteDatabase _db;

		// Token: 0x04000716 RID: 1814
		private ILiteCollection<T> _coll;
	}
}
