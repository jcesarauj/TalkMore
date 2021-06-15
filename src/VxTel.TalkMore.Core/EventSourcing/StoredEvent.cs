using System;

namespace VxTel.TalkMore.Core.EventSourcing
{
	public class StoredEvent
	{
		public StoredEvent(Guid id, string type, DateTime registerDate, string data)
		{
			Id = id;
			Type = type;
			RegisterDate = registerDate;
			Data = data;
		}

		public Guid Id { get; private set; }

		public string Type { get; private set; }

		public DateTime RegisterDate { get; private set; }

		public string Data { get; private set; }
	}
}