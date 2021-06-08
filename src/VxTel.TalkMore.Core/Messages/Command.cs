using MediatR;
using System;
using VxTel.TalkMore.Core.DomainObjects.Dtos;

namespace VxTel.TalkMore.Core.Messages
{
	public abstract class Command : Message, IRequest<Dto>
	{
		protected Command()
		{
			TimeStamp = DateTime.Now;
		}

		public DateTime TimeStamp { get; private set; }
	}
}