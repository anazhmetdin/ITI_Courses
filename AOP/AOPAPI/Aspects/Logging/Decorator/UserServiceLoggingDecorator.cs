using AOPAPI.BLL;
using AOPAPI.DAL;
using AOPAPI.Models;
using AOPAPI.Utilities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace AOPAPI.Aspects.Logging
{
    public class UserServiceLoggingDecorator : IUserService
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserServiceLoggingDecorator(
            [Dependency("Validator")] IUserService userService,
            ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public bool AssignCourse(AssignCourseInput input)
        {
            _logger.LogRequestTime("Decorator", nameof(AssignCourse));
            _logger.LogRequestParameters("Decorator", nameof(AssignCourse), input);
            bool result = false;
            
            try
            {
                result = _userService.AssignCourse(input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            finally
            {
                _logger.LogResponse("Decorator", nameof(AssignCourse), result);
            }
                
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            _logger.LogRequestTime("Decorator", nameof(GetAll));
            _logger.LogRequestParameters("Decorator", nameof(GetAll));
            IEnumerable<User> result = default;

            var http = HttpContext.Current;

            try
            {
                result = _userService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            finally
            {
                _logger.LogResponse("Decorator", nameof(GetAll), result);
            }

            return result;
        }

        public User GetById(int id)
        {
            _logger.LogRequestTime("Decorator", nameof(GetById));
            _logger.LogRequestParameters("Decorator", nameof(GetById));
            User result = default;

            try
            {
                result = _userService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
            finally
            {
                _logger.LogResponse("Decorator", nameof(GetById), result);
            }

            return result;
        }
    }
}