using System;

namespace VxTel.TalkMore.Core.DomainObjects
{
	public class StoredEvent
	{
		public Guid Id { get; set; }
		public string Type { get; set; }
		public DateTime Date { get; set; }
		public string Data { get; set; }
	}
}
