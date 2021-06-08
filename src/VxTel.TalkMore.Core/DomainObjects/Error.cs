namespace VxTel.TalkMore.Core.DomainObjects
{
	public class Error
	{
		public Error(string code, string description)
		{
			Code = code;
			Description = description;
		}

		public string Code { get; private set; }
		public string Description { get; private set; }
	}
}