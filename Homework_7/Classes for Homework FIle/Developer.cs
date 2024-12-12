
namespace Homework_7.Classes
{
    internal class Developer : Employee
    {
        #region Конструктор
        public Developer(string name, Employee manager) : base(name, manager) { }
        #endregion

        #region Метод
        public override bool ReceiveTask(Task task)
        {
            Console.WriteLine($"{Name} (разработчик) получает задачу: '{task.Title}'");
            return true;
        }
        #endregion
    }


}
