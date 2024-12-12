
namespace Homework_7
{
    internal class Task
    {
        #region Свойства
        public string Title { get; }
        public string AssignedTo { get; }
        #endregion

        #region Конструктор
        public Task(string title, string assignedTo)
        {
            Title = title;
            AssignedTo = assignedTo;
        }
        #endregion

    }


}
