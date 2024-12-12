

namespace Homework_7
{
    internal class Problem
    {
        #region Свойства
        public int Number { get; }
        public string Description { get; }
        #endregion

        #region Конструктор
        public Problem(int number, string description)
        {
            Number = number;
            Description = description;
        }
        #endregion
    }
}
