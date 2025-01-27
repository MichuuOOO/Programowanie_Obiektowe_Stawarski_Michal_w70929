namespace Zad2_3.Klasy
{
    public class StudentWSIiZ : Student
    {
        public override string ZwrocPelnaNazwe()
        {
            return $"{base.ZwrocPelnaNazwe()} (Student WSIiZ)";
        }

        public new string WypiszPelnaNazweIUczelnie()
        {
            return $"{base.WypiszPelnaNazweIUczelnie()} ";
        }
    }
}
