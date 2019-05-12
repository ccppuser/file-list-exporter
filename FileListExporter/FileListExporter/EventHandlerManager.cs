using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FileListExporter
{
	/// <summary>
	/// Event handlers information
	/// </summary>
	public class EventHandlerInfo
	{
		public object _publisher;
		public EventInfo _eventInfo;
		public Delegate _del;

		public EventHandlerInfo(object publisher, EventInfo eventInfo, Delegate del)
		{
			_publisher = publisher;
			_eventInfo = eventInfo;
			_del = del;
		}
	}

	/// <summary>
	/// Pause or resume all event handlers for Forms
	/// </summary>
	public static class EventHandlerManager
	{
		private static Dictionary<object, SortedDictionary<string, EventInfo>> _eventInfos = new Dictionary<object, SortedDictionary<string, EventInfo>>();
		private static Dictionary<object, SortedDictionary<string, Delegate>> _delegates = new Dictionary<object, SortedDictionary<string, Delegate>>();

		private static List<EventHandlerInfo> _eventHandlerInfos = new List<EventHandlerInfo>();
		private static bool _isAllEventHandlerPaused = false;

		/// <summary>
		/// Add an event handler
		/// </summary>
		/// <param name="publisher">Publisher of the event</param>
		/// <param name="eventName"></param>
		/// <param name="subscriber">Owner of the method</param>
		/// <param name="methodName"></param>
		public static void AddEventHandler(object publisher, string eventName, object subscriber, string methodName)
		{
			EventInfo eventInfo;
			Delegate del;
			GetEventInfoAndDelegate(publisher, eventName, subscriber, methodName, out eventInfo, out del);

			_eventHandlerInfos.Add(new EventHandlerInfo(publisher, eventInfo, del));
		}

		/// <summary>
		/// Extract EventInfo and Delegate
		/// </summary>
		/// <param name="publisher"></param>
		/// <param name="eventName"></param>
		/// <param name="subscriber"></param>
		/// <param name="methodName"></param>
		/// <param name="outEventInfo"></param>
		/// <param name="outDelegate"></param>
		private static void GetEventInfoAndDelegate(object publisher, string eventName, object subscriber, string methodName, out EventInfo outEventInfo, out Delegate outDelegate)
		{
			Type publisherType = publisher.GetType();
			outEventInfo = publisherType.GetEvent(eventName);

			Type subscriberType = subscriber.GetType();
			MethodInfo method = subscriberType.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			outDelegate = Delegate.CreateDelegate(outEventInfo.EventHandlerType, subscriber, method);
		}

		/// <summary>
		/// Pause all event handlers
		/// </summary>
		public static void PauseAllEventHandlers()
		{
			if (!_isAllEventHandlerPaused)
			{
				foreach (var eventHandlerInfo in _eventHandlerInfos)
				{
					eventHandlerInfo._eventInfo.RemoveEventHandler(eventHandlerInfo._publisher, eventHandlerInfo._del);
				}

				_isAllEventHandlerPaused = true;
			}
		}

		/// <summary>
		/// Resume all event handlers
		/// </summary>
		public static void ResumeAllEventHandlers()
		{
			if (_isAllEventHandlerPaused)
			{
				foreach (var eventHandlerInfo in _eventHandlerInfos)
				{
					eventHandlerInfo._eventInfo.AddEventHandler(eventHandlerInfo._publisher, eventHandlerInfo._del);
				}

				_isAllEventHandlerPaused = false;
			}
		}
	}
}
