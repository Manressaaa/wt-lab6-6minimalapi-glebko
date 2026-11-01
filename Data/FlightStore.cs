using wt_lab6_6minimalapi_glebko.Models;

namespace wt_lab6_6minimalapi_glebko.Data;

public static class FlightStore
{
    public static List<Flight> Flights { get; } = new()
    {
        new Flight
        {
            nomer_reisa = 101,
            gorod_vilet = "Нюйорк",
            gorod_prilet = "Горки)",
            vremya_vileta = new DateTime(2026, 11, 15, 8, 30, 0),
            cena = 250,
            mesta = 45,
            dostupno = true
        },
        new Flight
        {
            nomer_reisa = 102,
            gorod_vilet = "Минск",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 11, 16, 12, 0, 0),
            cena = 180,
            mesta = 30,
            dostupno = true
        },
        new Flight
        {
            nomer_reisa = 103,
            gorod_vilet = "Москва",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 11, 17, 22, 15, 0),
            cena = 400,
            mesta = 0,
            dostupno = false
        },
        new Flight
        {
            nomer_reisa = 104,
            gorod_vilet = "Гомель",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 12, 20, 14, 0, 0),
            cena = 300,
            mesta = 50,
            dostupno = true
        },
        new Flight
        {
            nomer_reisa = 105,
            gorod_vilet = "Витебск",
            gorod_prilet = "Горки",
            vremya_vileta = new DateTime(2026, 12, 25, 6, 45, 0),
            cena = 150,
            mesta = 20,
            dostupno = true
        }
    };

}