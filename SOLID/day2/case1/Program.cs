using System.Numerics;

namespace case1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeFactory factory = new EmployeeFactory();

            IDevelop developer = factory.GetDeveloper("dev");
            ILead lead = factory.GetTeamLead("lead");
            IManage manager = factory.GetManager("manager");

            var task1 = lead.CreateTask("task1", "some task 1");
            manager.AssignTask(task1, developer);

            var task2 = lead.CreateTask("task2", "some task 2");
            lead.AssignTask(task2, developer);

            developer.WorkOnTask();
            developer.WorkOnTask();
        }
    }

    // 1.
    // a. Based on specifications, we need to create an interface and a TeamLead class to implement it.
    // b. Later another role like Manager, who assigns tasks to TeamLead and will not work on the tasks, is introduced into the system,
    // Apply needed refactoring to for better design and mention the current design smells
    public interface IManage
    {
        void AssignTask(DevTask task, IDevelop developer);
    }

    public interface IDevelop
    {
        Queue<DevTask> Tasks { get; set; }
        void WorkOnTask();
    }

    public interface ILead : IManage, IDevelop
    {
        DevTask CreateTask(string title, string description);
    }

    public class DevTask
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DevTask(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }

    public class DevTaskService
    {
        internal void AssignTask(DevTask task, IDevelop developer)
        {
            developer.Tasks.Enqueue(task);
        }

        public DevTask CreateTask(string title, string description)
        {
            return new(title, description);
        }
    }

    public class ServiceLocator
    {
        public T Get<T>() where T : new()
        {
            return new T();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public Employee(string name)
        {
            Name = name;
        }
    }

    public class EmployeeFactory
    {
        private readonly ServiceLocator locator;

        public EmployeeFactory()
        {
            locator = new ServiceLocator();
        }

        public Developer GetDeveloper(string name)
        {
            return new Developer(name);
        }
        public TeamLead GetTeamLead(string name)
        {
            return new TeamLead(name, locator.Get<DevTaskService>());
        }
        public Manager GetManager(string name)
        {
            return new Manager(name, locator.Get<DevTaskService>());
        }
    }

    public class Developer : Employee, IDevelop
    {
        public Queue<DevTask> Tasks { get; set; } = new();

        public Developer(string Name): base(Name)
        {
        }

        public void WorkOnTask()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine(Name + " has no tasks");
            }
            else
            {
                DevTask task = Tasks.Dequeue();
                Console.WriteLine(Name + " working on " + task.Title);
            }
        }
    }

    public class Manager : Employee, IManage
    {
        public Manager(string name, DevTaskService devTaskService): base(name)
        {
            _devTaskService = devTaskService;
        }

        private readonly DevTaskService _devTaskService;

        public void AssignTask(DevTask task, IDevelop developer)
        {
            _devTaskService.AssignTask(task, developer);
        }
    }

    public class TeamLead : Developer, ILead
    {
        public TeamLead(string name, DevTaskService devTaskService) : base(name)
        {
            _devTaskService = devTaskService;
        }

        private readonly DevTaskService _devTaskService;

        public void AssignTask(DevTask task, IDevelop developer)
        {
            _devTaskService.AssignTask(task, developer);
        }

        public DevTask CreateTask(string title, string description)
        {
            return _devTaskService.CreateTask(title, description);
        }
    }
}