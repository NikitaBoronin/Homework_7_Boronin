

namespace Homework_7
{
    internal class SysAdmin : Employee
    {
        #region Конструктор
        public SysAdmin(string name, Employee manager) : base(name, manager) { }
        #endregion

        #region Метод
        public override bool ReceiveTask(Task task)
        {
            Console.WriteLine($"{Name} (системщик) получает задачу: '{task.Title}'");
            return true;
        }
        #endregion

    }


}
