using System;

namespace AOPAPI.Utilities
{
    public interface ILogger
    {
        void LogError(Exception exception);
        void LogDebug(string message);
        void LogRequestTime(string AOP, string methodName);
        void LogRequestParameters(string AOP, string methodName, params object[] paramsArr);
        void LogResponse(string AOP, string methodName, object response);
    }
}