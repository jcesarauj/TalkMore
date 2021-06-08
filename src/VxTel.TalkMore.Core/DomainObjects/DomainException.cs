using System;

namespace VxTel.TalkMore.Core.DomainObjects
{
	public class DomainException : Exception
	{
		public DomainException()
		{
		}

		public DomainException(string message) : base(message)
		{
		}

		public DomainException(string message, Exception exception) : base(message, exception)
		{
		}
	}
}