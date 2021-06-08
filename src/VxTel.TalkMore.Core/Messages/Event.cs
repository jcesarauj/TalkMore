using MediatR;
using System;

namespace VxTel.TalkMore.Core.Messages
{
	public abstract class Event : Message, INotification
	{
		protected Event()
		{
			CreateDate = DateTime.Now;
		}

		public DateTime CreateDate { get; private set; }
	}
}