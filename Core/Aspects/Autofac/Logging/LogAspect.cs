﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilites.Interceptors;
using Core.Utilites.Messages;

namespace Core.Aspects.Autofac.Logging;

public class ExceptionLogAspect : MethodInterception
{
	private readonly LoggerServiceBase _loggerServiceBase;

	public ExceptionLogAspect(Type loggerService)
	{
		if (loggerService.BaseType != typeof(LoggerServiceBase))
			throw new System.Exception(AspectMessages.WrongLoggerType);

		_loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
	}

	protected override void OnException(IInvocation invocation, System.Exception e)
	{
		var logDetailWithException = GetLogDetail(invocation);
		logDetailWithException.ExceptionMessage = e.Message;
		_loggerServiceBase.Error(logDetailWithException);
	}

	private LogDetailWithException GetLogDetail(IInvocation invocation)
	{
		var logParameters = new List<LogParameter>();

		for (var i = 0; i < invocation.Arguments.Length; i++)
			logParameters.Add(new LogParameter
			{
				Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
				Value = invocation.Arguments[i],
				Type = invocation.Arguments[i].GetType().Name
			});

		var logDetailWithException = new LogDetailWithException
		{
			MethodName = invocation.Method.Name,
			LogParameters = logParameters
		};

		return logDetailWithException;
	}
}