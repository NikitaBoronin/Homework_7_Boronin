

namespace Homework_7
{
    internal class Manager : Employee
    {
        #region Конструктор
        public Manager(string name, Employee manager) : base(name, manager) { }
        #endregion

        #region Метод
        public override bool ReceiveTask(Task task)
        {
            Console.WriteLine($"{Name} (менеджер) получает задачу: '{task.Title}'");
            return true;
        }
        #endregion

    }


}
