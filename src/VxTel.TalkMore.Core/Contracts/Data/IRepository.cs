using System;

namespace VxTel.TalkMore.Core.Contracts.Data
{
	public interface IRepository<T> : IDisposable where T : IAggregateRoot
	{
		public IUnitOfWork UnitOfWork { get; }
	}
}