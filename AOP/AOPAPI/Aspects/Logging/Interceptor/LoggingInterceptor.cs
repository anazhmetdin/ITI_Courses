using AOPAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPAPI.Aspects.Logging.Interceptor
{
    public class LoggingInterceptor : IInterceptionBehavior
    {
        private readonly ILogger _logger;

        public LoggingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            _logger.LogRequestTime("Interceptor", input.MethodBase.Name);
            _logger.LogRequestParameters("Interceptor", input.MethodBase.Name, input.Arguments);
            var result = getNext()(input, getNext);
            // after invocation
            if (result.Exception != null)
            {
                _logger.LogError(result.Exception);
                var defaultValue = GetDefaultValue(input.MethodBase);
                return input.CreateMethodReturn(defaultValue);
            }
            _logger.LogResponse("Interceptor", input.MethodBase.Name, result.ReturnValue);
            return result;
        }

        private object GetDefaultValue(MethodBase methodBase)
        {
            var info = methodBase as MethodInfo;
            var returnType = info.ReturnType;
            if (!returnType.IsValueType)
                return null;
            if (returnType == typeof(int))
                return default(int);
            return default;
        }
    }
}