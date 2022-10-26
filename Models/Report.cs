using esluzba.DataAccess.Entities;

namespace esluzba.Models;

public class Report
{
    public Report(User user)
    {
        User = user;
    }

    public User User { get; set; }
    public int Points { get; set; }
    public List<Event> Compulsory { get; set; }          //Obowiązkowe
    public List<Event> Absences { get; set; }            //Nieobecności
    public List<Event> Devotions { get; set; }           //Nabożeństwa
    public List<Event> AboveServices { get; set; }       //Nadobowiązkowe
}