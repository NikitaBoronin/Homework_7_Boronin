
namespace Homework_7
{

    class Resident
    {
        #region Свойства
        public string Name { get; }
        public string PassportNumber { get; }
        public Problem Problem { get; }
        public Temperament Temperament { get; }
        #endregion

        #region Конструктор
        public Resident(string name, string passportNumber, Problem problem, Temperament temperament)
        {
            Name = name;
            PassportNumber = passportNumber;
            Problem = problem;
            Temperament = temperament;
        }
        #endregion
    }
}
