using System;

namespace VxTel.TalkMore.Core.Messages.CommonMessages.DomainEvents
{
	public class DomainEvent : Event
	{
		public DomainEvent(Guid agregatedId)
		{
			AgregatedId = agregatedId;
		}
	}
}