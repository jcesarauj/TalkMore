﻿using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

namespace VxTel.TalkMore.Core.EventSourcing
{
	public class EventStoreService : IEventStoreService
	{
		private readonly IEventStoreConnection _connection;

		public EventStoreService(IConfiguration configuration)
		{
			_connection = EventStoreConnection.Create(configuration.GetConnectionString("EventStoreConnection"));
			_connection.ConnectAsync();
		}

		public IEventStoreConnection GetConnection() => _connection;
	}
}