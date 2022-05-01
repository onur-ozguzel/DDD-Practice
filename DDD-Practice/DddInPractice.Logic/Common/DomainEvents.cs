using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DddInPractice.Logic.Common
{
    public static class DomainEvents
    {
        //private static Dictionary<Type, List<Delegate>> _dynamicHandlers;
        //private static List<Type> _staticHandlers;
        private static List<Type> _handlers;

        public static void Init()
        {
            //_dynamicHandlers = Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .Where(w => typeof(IDomainEvent).IsAssignableFrom(w) && !w.IsInterface)
            //    .ToList()
            //    .ToDictionary(x => x, x => new List<Delegate>());

            //_staticHandlers = Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .Where(w => w.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IHandler<>)))
            //    .ToList();

            _handlers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(w => w.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IHandler<>)))
                .ToList();
        }

        //public static void Register<T>(Action<T> eventHandler)
        //    where T : IDomainEvent
        //{
        //    _dynamicHandlers[typeof(T)].Add(eventHandler);
        //}

        //public static void Raise<T>(T domainEvent)
        //    where T : IDomainEvent
        //{
        //    foreach (Delegate handler in _dynamicHandlers[domainEvent.GetType()])
        //    {
        //        var action = (Action<T>)handler;
        //        action(domainEvent);
        //    }

        //    foreach (Type handler in _staticHandlers)
        //    {
        //        if (typeof(IHandler<T>).IsAssignableFrom(handler))
        //        {
        //            IHandler<T> instance = (IHandler<T>)Activator.CreateInstance(handler);
        //            instance.Handle(domainEvent);
        //        }
        //    }
        //}

        internal static void Dispatch(IDomainEvent domainEvent)
        {
            foreach (Type handlerType in _handlers)
            {
                bool canHandleEvent = handlerType.GetInterfaces()
                    .Any(x => x.IsGenericType
                        && x.GetGenericTypeDefinition() == typeof(IHandler<>)
                        && x.GenericTypeArguments[0] == domainEvent.GetType());

                if (canHandleEvent)
                {
                    dynamic handler = Activator.CreateInstance(handlerType);
                    handler.Handle((dynamic)domainEvent);
                }
            }
        }
    }
}
