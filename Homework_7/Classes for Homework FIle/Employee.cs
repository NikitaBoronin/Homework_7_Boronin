
namespace Homework_7
{
    internal abstract class Employee
    {
        #region Свойства
        public string Name { get; }
        public Employee Manager { get; }
        #endregion

        #region Конструктор
        protected Employee(string name, Employee manager)
        {
            Name = name;
            Manager = manager;
        }
        #endregion

        #region Метод
        public abstract bool ReceiveTask(Task task);
        #endregion
    }


}
