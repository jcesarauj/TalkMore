using System;

namespace VxTel.TalkMore.Core.Messages
{
	public abstract class Message
	{
		protected Message()
		{
			MessageType = GetType().Name;
		}

		public string MessageType { get; protected set; }
		public Guid AgregatedId { get; protected set; }
	}
}