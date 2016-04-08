using System;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class DummyData
    {
        public static List<Assessor> FetchAssessors()
        {
            return new List<Assessor>()
            {
                new Assessor
                {
                    FirstName = "Joost",
                    LastName = "Ronkes Agerbeek",
                    UserName = "joostronkesagerbeek",
                },
                new Assessor
                {
                    FirstName = "Maarten",
                    LastName = "Nouwen",
                    UserName = "maartennouwen",
                }
                ,
                new Assessor
                {
                    FirstName = "Peter",
                    LastName = "Snoek",
                    UserName = "petersnoek",
                }
            };
        }
        public static Assessment FetchAssessment()
        {
            return new Assessment
            {
                Id = 10,
                Assessed = new DateTime(),
                Student = new Student
                {
                    Name = "",
                    Number = ""
                },
                Exam = new Exam
                {
                    Name = "Opleveren van een applicatie",
                    Cohort = "2011",
                    Crebo = "95311",
                    Subject = "Applicatieontwikkelaar"
                },
                Assessors = new List<Assessor>()
                {
                    new Assessor
                    {
                        UserName = "joostronkesagerbeek",
                        FirstName = "Joost",
                        LastName = "Ronkes Agerbeek"
                    },
                    new Assessor
                    {
                        UserName = "petersnoek",
                        FirstName = "Peter",
                        LastName = "Snoek"
                    }
                },
                Categories = new List<Category>()
                {
                    new Category
                    {
                        Id = 1,
                        Order = 1,
                        Name = "Implementatieplan",
                        Observations = new List<Observation>()
                        {
                            new Observation
                            {
                                Id = 136,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat vertelt de opdrachtgever wat er van hem/haar verwacht wordt tijdens de oplevering.",
                                    Description = " - De kandidaat moet de klant laten weten dat hij/zij de nieuwe features moet testen. - De kandidaat moet de klant laten weten dat hij van de nieuwe features moet aangeven of ze voldoen aan de verwachting van de klant. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 1,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 137,
                                        Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat laat de opdrachtgever weten welke features nieuw zijn in de huidige release.",
                                    Description = " - De kandidaat moet de opdrachtgever laten weten welke features er in de afgelopen iteratie toegevoegd zijn. - De kandidaat zou de nieuwe features mondeling kunnen overdragen. - De kandidaat zou de nieuwe features schriftelijk kunnen overdragen. - De kandidaat zou de klant het iteratielog kunnen laten zien en duidelijk kunnen maken welke features op het iteratielog nieuw en afgerond zijn. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                    Order = 2,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 138,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat laat de opdrachtgever weten welke bugs opgelost zijn in de huidige release.",
                                    Description = " - De kandidaat moet de opdrachtgever laten weten welke bugs uit voorgaande iteraties opgelost zijn. - De kandidaat zou de nieuwe bug fixes mondeling kunnen overdragen. - De kandidaat zou de nieuwe bug fixes schriftelijk kunnen overdragen. - De kandidaat moet de opdrachtgever expliciet vertellen dat er geen bugs opgelost zijn als dat het geval is. - De kandidaat mag bugs die tijdens de huidige iteratie ontstaan, gevonden en opgelost zijn buiten beschouwing laten. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                    Order = 3,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 139,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat laat de opdrachtgever weten welke problemen de huidige release bevat.",
                                    Description = " - De kandidaat moet de opdrachtgever op de hoogte stellen van gevonden bugs die nog niet zijn opgelost en van eventuele gevonden problemen met beveiliging en/of performance. - De kandidaat zou de problemen mondeling kunnen overdragen. - De kandidaat zou de problemenschriftelijk kunnen overdragen. - De kandidaat moet de opdrachtgever expliciet vertellen dat er geen problemen bekend zijn als dat het geval is. - De kandidaat hoeft niet melding te maken van problemen die niet te maken hebben met functionaliteit, beveiliging of performance. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan",
                                    Order = 4,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 140,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat heeft een lijst gemaakt van zaken die de opdrachtgever kan testen.",
                                    Description = " - De kandidaat moet een schriftelijke lijst aan de klant geven met daarop de features die de klant moet testen. - De kandidaat moet op de lijst alle nieuwe features opnemen. - De kandidaat moet op de lijst alle bug fixes opnemen. - De kandidaat mag meer features op de lijst zetten dan alleen de features die nieuw zijn. - De kandidaat mag het iteratielog gebruiken als testlijst op voorwaarde dat alle features op het iteratielog zo omschreven zijn dat de opdrachtgever zonder verdere toelichting snapt wat hij/zij moet testen. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 5,
                                    Weight = "excellent"
                                },
                                Marks = new List<string>()
                            }
                        }
                    },
                    new Category
                    {
                        Id = 2,
                        Order = 2,
                        Name = "Oplevering",
                        Observations = new List<Observation>()
                        {
                            new Observation
                            {
                                Id = 141,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat heeft niet gezorgd voor een omgeving waar de opdrachtgever mee kan testen.",
                                    Description = " - De kandidaat moet de applicatie klaar gezet hebben voor onmiddellijk gebruik. - De kandidaat mag niet een installer van de applicatie opleveren, tenzij de installer een geplande feature is van de iteratie. - De kandidaat mag de applicatie opleveren zonder een account voor klant te hebben aangemaakt. Als de kandidaat tijdens de oplevering de omgeving  klaarzet of afmaakt, dan mag hij/zij wel door met de proeve, maar krijgt een onvoldoende voor dit criterium. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                    Order = 6,
                                    Weight = "fail"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 142,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat heeft de database gevuld met zinvolle testgegevens.",
                                    Description = " - De kandidaat moet de gegevens in de database zetten die de klant nodig heeft om alle nieuwe features en bug fixes te kunnen testen. - De kandidaat mag niet een complete lege database opleveren. - De kandidaat mag een feature inbouwen die de database vult met testgegevens en de klant die feature laten uitvoeren voordat de tests beginnen. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 7,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 143,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat maakt notities van de resultaten van de tests.",
                                    Description = " - De kandidaat moet de resultaten van de tests schriftelijk vastleggen. - De kandidaat moet een aantekening maken van iedere nieuwe feature waar de klant om vraagt, tenzij de feature al op de backlog staat. - De kandidaat moet een aantekening maken van iedere bug die de klant vindt, tenzij de bug al geregistreerd is in het bugtrackingsysteem. - De kandidaat mag de resultaten vastleggen op een manier die alleen voor de kandidaat zelf zinvol is. - De kandidaat mag een ander aantekeningen laten maken, maar moet dan controleren of de aantekeningen inhoudelijke kloppen. Alleen controleren of de aantekening gemaakt is, is niet genoeg. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 8,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 144,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat vraagt de opdrachtgever om van iedere geplande en afgeronde feature van de huidige iteratie aan te geven of de feature aan de wensen van de opdrachtgever voldoet.",
                                    Description = " - De kandidaat moet ervoor zorgen dat de klant van iedere nieuwe feature aangeeft of de feature aan de wensen van de klant voldoet. - De kandidaat mag het vragen naar feedback van de klant achterwege laten als de klant uit zichzelf al feedback geeft. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 9,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 145,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De opdrachtgever moet testen op het systeem waar de kandidaat (of een groepsgenoot) op ontwikkelt.",
                                    Description = " - De kandidaat moet de applicatie opleveren op een systeem waar de applicatie niet op ontwikkeld is. - De kandidaat mag niet de opdrachtgever laten testen in een virtual machine op een systeem waar de applicatie op ontwikkeld is. - De kandidaat mag de applicatie hosten in een virtual machine op een systeem waar de applicatie op ontwikkeld is, op voorwaarde dat de opdrachtgever kan testen vanaf een ander systeem. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 10,
                                    Weight = "fail"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 146,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat voert tests zelf uit.",
                                    Description = " - De kandidaat moet de klant alle tests laten uitvoeren. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 11,
                                    Weight = "fail"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 147,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat past de code van de software aan vlak voor of tijdens de oplevering.",
                                    Description = " - De kandidaat moet de applicatie afronden voordat de oplevering plaatsvindt. - De kandidaat mag niet code van de software aanpassen als de oplevering al begonnen is. - De kandidaat mag niet de oplevering later laten starten om nog code van de software aan te kunnen passen. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                    Order = 12,
                                    Weight = "fail"
                                },
                                Marks = new List<string>()
                            }
                        }
                    },
                    new Category
                    {
                        Id = 3,
                        Order = 3,
                        Name = "Evaluatie",
                        Observations = new List<Observation>()
                        {
                            new Observation
                            {
                                Id = 148,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat kan aangeven hoe de oplevering in het vervolg nog beter kan.",
                                    Description = " - De kandidaat moet een concreet verbeterpunt noemen. - De kandidaat moet verbeterpunten noemen die zinvol zijn gezien het verloop van de oplevering. - De kandidaat mag niet volstaan met de constatering dat er niets te verbeteren valt aan de oplevering. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                    Order = 13,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 149,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat kan vertellen welke feedback hij/zij van de opdrachtgever heeft gekregen.",
                                    Description = " - De kandidaat moet aangeven wat de opdrachtgever van de oplevering vond. - De kandidaat moet feedback van de opdrachtgever gevraagd hebben voordat de evaluatie plaatsvindt. - De kandidaat mag de feedback van de opdrachtgever niet goed begrepen hebben. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                    Order = 14,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            },
                            new Observation
                            {
                                Id = 150,
                                Result = "notrated",
                                Criterion = new Criterion
                                {
                                    Title = "De kandidaat kan een onderbouwde mening geven over het verloop van de oplevering.",
                                    Description = " - De kandidaat moet aangeven of hij/zij vindt dat de oplevering goed verlopen is. - De kandidaat moet een reden kunnen geven voor zijn/haar mening. - De kandidaat mag een mening geven waar de examinator het niet mee eens is. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                    Order = 15,
                                    Weight = "pass"
                                },
                                Marks = new List<string>()
                            }
                        }
                    }
                }
            };
        }
    }
}

