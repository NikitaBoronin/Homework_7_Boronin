

namespace Homework_7
{
    class Temperament
    {
        #region Свойства
        public int Scandalousness { get; }
        public bool IsSmart { get; }
        #endregion

        #region Конструктор
        public Temperament(int scandalousness, bool isSmart)
        {
            Scandalousness = scandalousness;
            IsSmart = isSmart;
        }
        #endregion
    }
}
