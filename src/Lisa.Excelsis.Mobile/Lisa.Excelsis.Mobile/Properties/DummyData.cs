using System;
using System.Collections.Generic;

namespace Lisa.Excelsis.Mobile
{
    public class Initialize
    {
        public static void Exams()
        {
            var examList = new List<Exam>();

            examList.Add(new Exam
            {
                Name = "Opleveren van een applicatie",
                NameId = "opleverenvaneenapplicatie",
                Cohort = "2011",
                Crebo = "95311",
                Subject = "Applicatieontwikkelaar",
                SubjectId = "applicatieontwikkelaar",
                Categories = new List<Exam_Category>()
                {
                    new Exam_Category
                    {
                        Order = 1,
                        Name = "Implementatieplan",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat vertelt de opdrachtgever wat er van hem/haar verwacht wordt tijdens de oplevering.",
                                Description = " - De kandidaat moet de klant laten weten dat hij/zij de nieuwe features moet testen. - De kandidaat moet de klant laten weten dat hij van de nieuwe features moet aangeven of ze voldoen aan de verwachting van de klant. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 1,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat laat de opdrachtgever weten welke features nieuw zijn in de huidige release.",
                                Description = " - De kandidaat moet de opdrachtgever laten weten welke features er in de afgelopen iteratie toegevoegd zijn. - De kandidaat zou de nieuwe features mondeling kunnen overdragen. - De kandidaat zou de nieuwe features schriftelijk kunnen overdragen. - De kandidaat zou de klant het iteratielog kunnen laten zien en duidelijk kunnen maken welke features op het iteratielog nieuw en afgerond zijn. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                Order = 2,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat laat de opdrachtgever weten welke bugs opgelost zijn in de huidige release.",
                                Description = " - De kandidaat moet de opdrachtgever laten weten welke bugs uit voorgaande iteraties opgelost zijn. - De kandidaat zou de nieuwe bug fixes mondeling kunnen overdragen. - De kandidaat zou de nieuwe bug fixes schriftelijk kunnen overdragen. - De kandidaat moet de opdrachtgever expliciet vertellen dat er geen bugs opgelost zijn als dat het geval is. - De kandidaat mag bugs die tijdens de huidige iteratie ontstaan, gevonden en opgelost zijn buiten beschouwing laten. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                Order = 3,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat laat de opdrachtgever weten welke problemen de huidige release bevat.",
                                Description = " - De kandidaat moet de opdrachtgever op de hoogte stellen van gevonden bugs die nog niet zijn opgelost en van eventuele gevonden problemen met beveiliging en/of performance. - De kandidaat zou de problemen mondeling kunnen overdragen. - De kandidaat zou de problemenschriftelijk kunnen overdragen. - De kandidaat moet de opdrachtgever expliciet vertellen dat er geen problemen bekend zijn als dat het geval is. - De kandidaat hoeft niet melding te maken van problemen die niet te maken hebben met functionaliteit, beveiliging of performance. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan",
                                Order = 4,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft een lijst gemaakt van zaken die de opdrachtgever kan testen.",
                                Description = " - De kandidaat moet een schriftelijke lijst aan de klant geven met daarop de features die de klant moet testen. - De kandidaat moet op de lijst alle nieuwe features opnemen. - De kandidaat moet op de lijst alle bug fixes opnemen. - De kandidaat mag meer features op de lijst zetten dan alleen de features die nieuw zijn. - De kandidaat mag het iteratielog gebruiken als testlijst op voorwaarde dat alle features op het iteratielog zo omschreven zijn dat de opdrachtgever zonder verdere toelichting snapt wat hij/zij moet testen. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 5,
                                Weight = "excellent"
                            }
                        }
                    },
                    new Exam_Category
                    {
                        Order = 2,
                        Name = "Oplevering",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat heeft niet gezorgd voor een omgeving waar de opdrachtgever mee kan testen.",
                                Description = " - De kandidaat moet de applicatie klaar gezet hebben voor onmiddellijk gebruik. - De kandidaat mag niet een installer van de applicatie opleveren, tenzij de installer een geplande feature is van de iteratie. - De kandidaat mag de applicatie opleveren zonder een account voor klant te hebben aangemaakt. Als de kandidaat tijdens de oplevering de omgeving  klaarzet of afmaakt, dan mag hij/zij wel door met de proeve, maar krijgt een onvoldoende voor dit criterium. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                Order = 6,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft de database gevuld met zinvolle testgegevens.",
                                Description = " - De kandidaat moet de gegevens in de database zetten die de klant nodig heeft om alle nieuwe features en bug fixes te kunnen testen. - De kandidaat mag niet een complete lege database opleveren. - De kandidaat mag een feature inbouwen die de database vult met testgegevens en de klant die feature laten uitvoeren voordat de tests beginnen. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 7,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat maakt notities van de resultaten van de tests.",
                                Description = " - De kandidaat moet de resultaten van de tests schriftelijk vastleggen. - De kandidaat moet een aantekening maken van iedere nieuwe feature waar de klant om vraagt, tenzij de feature al op de backlog staat. - De kandidaat moet een aantekening maken van iedere bug die de klant vindt, tenzij de bug al geregistreerd is in het bugtrackingsysteem. - De kandidaat mag de resultaten vastleggen op een manier die alleen voor de kandidaat zelf zinvol is. - De kandidaat mag een ander aantekeningen laten maken, maar moet dan controleren of de aantekeningen inhoudelijke kloppen. Alleen controleren of de aantekening gemaakt is, is niet genoeg. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 8,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat vraagt de opdrachtgever om van iedere geplande en afgeronde feature van de huidige iteratie aan te geven of de feature aan de wensen van de opdrachtgever voldoet.",
                                Description = " - De kandidaat moet ervoor zorgen dat de klant van iedere nieuwe feature aangeeft of de feature aan de wensen van de klant voldoet. - De kandidaat mag het vragen naar feedback van de klant achterwege laten als de klant uit zichzelf al feedback geeft. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 9,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De opdrachtgever moet testen op het systeem waar de kandidaat (of een groepsgenoot) op ontwikkelt.",
                                Description = " - De kandidaat moet de applicatie opleveren op een systeem waar de applicatie niet op ontwikkeld is. - De kandidaat mag niet de opdrachtgever laten testen in een virtual machine op een systeem waar de applicatie op ontwikkeld is. - De kandidaat mag de applicatie hosten in een virtual machine op een systeem waar de applicatie op ontwikkeld is, op voorwaarde dat de opdrachtgever kan testen vanaf een ander systeem. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 10,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat voert tests zelf uit.",
                                Description = " - De kandidaat moet de klant alle tests laten uitvoeren. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 11,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat past de code van de software aan vlak voor of tijdens de oplevering.",
                                Description = " - De kandidaat moet de applicatie afronden voordat de oplevering plaatsvindt. - De kandidaat mag niet code van de software aanpassen als de oplevering al begonnen is. - De kandidaat mag niet de oplevering later laten starten om nog code van de software aan te kunnen passen. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: niet gedaan.",
                                Order = 12,
                                Weight = "fail"
                            }
                        }
                    },

                    new Exam_Category
                    {
                        Order = 3,
                        Name = "Evaluatie",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat kan aangeven hoe de oplevering in het vervolg nog beter kan.",
                                Description = " - De kandidaat moet een concreet verbeterpunt noemen. - De kandidaat moet verbeterpunten noemen die zinvol zijn gezien het verloop van de oplevering. - De kandidaat mag niet volstaan met de constatering dat er niets te verbeteren valt aan de oplevering. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                Order = 13,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan vertellen welke feedback hij/zij van de opdrachtgever heeft gekregen.",
                                Description = " - De kandidaat moet aangeven wat de opdrachtgever van de oplevering vond. - De kandidaat moet feedback van de opdrachtgever gevraagd hebben voordat de evaluatie plaatsvindt. - De kandidaat mag de feedback van de opdrachtgever niet goed begrepen hebben. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                Order = 14,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan een onderbouwde mening geven over het verloop van de oplevering.",
                                Description = " - De kandidaat moet aangeven of hij/zij vindt dat de oplevering goed verlopen is. - De kandidaat moet een reden kunnen geven voor zijn/haar mening. - De kandidaat mag een mening geven waar de examinator het niet mee eens is. Als de examinatoren het niet eens kunnen worden over de beoordeling, dan geldt voor deze waarneming: gedaan.",
                                Order = 15,
                                Weight = "pass"
                            }
                        }
                    }
                }
            });

            examList.Add(new Exam
            {
                Name = "Ontwerpen van een applicatie",
                NameId = "ontwerpenvaneenapplicatie",
                Cohort = "2011",
                Crebo = "95311",
                Subject = "Applicatieontwikkelaar",
                SubjectId = "applicatieontwikkelaar",
                Categories = new List<Exam_Category>()
                {
                    new Exam_Category
                    {
                        Order = 1,
                        Name = "Iteratievergadering",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat noteert de wensen van de klant als concrete features.",
                                Description = "",
                                Order = 1,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat plaatst features altijd eerst op de backlog.",
                                Description = "",
                                Order = 2,
                                Weight = "excellent"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat maakt geen gebruik van een backlog.",
                                Description = "",
                                Order = 3,
                                Weight = "fail"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat denkt actief mee met de klant over features door vragen te stellen en voorstellen te doen.",
                                Description = "",
                                Order = 4,
                                Weight = "excellent"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat zet zelfstandig features op de backlog in plaats van naar de klant te luisteren.",
                                Description = "",
                                Order = 5,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat controleert van bestaande features op de backlog of het ingeschatte puntenaantal nog klopt.",
                                Description = "",
                                Order = 6,
                                Weight = "excellent"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat laat de klant kiezen welke features het team de komende iteratie gaat oppakken.",
                                Description = "",
                                Order = 7,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat adviseert de klant bij het kiezen van features voor de komende iteratie.",
                                Description = "",
                                Order = 8,
                                Weight = "excellent"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat kiest zelf features voor de komende iteratie.",
                                Description = "",
                                Order = 9,
                                Weight = "fail"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat valt de klant hinderlijk in de rede.",
                                Description = "",
                                Order = 10,
                                Weight = "fail"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat spreekt met de klant een datum en tijd af voor de oplevering van de software.",
                                Description = "",
                                Order = 11,
                                Weight = "pass"

                            }
                        }
                    },
                    new Exam_Category
                    {
                        Order = 2,
                        Name = "Oplevering",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat geeft in het iteratielog duidelijk aan welke features het team de komende iteratie zal realiseren.",
                                Description = "",
                                Order = 12,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft voor de komende iteratie alleen features op het iteratielog staan die functionele eisen beschrijven.",
                                Description = "",
                                Order = 13,
                                Weight = "excellent"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft features die wel besproken, maar niet gepland zijn apart vermeld.",
                                Description = "",
                                Order = 14,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft features die de vorige iteratie niet afgerond zijn, gekopieerd naar de backlog of naar de komende iteratie.",
                                Description = "",
                                Order = 15,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft bij iedere feature die gepland is voor de komende iteratie aangegeven hoeveel punten er voor de feature gepland zijn.",
                                Description = "",
                                Order = 16,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft bij (bijna) iedere features op de backlog aangegeven hoeveel punten er voor de feature gepland zijn.",
                                Description = "",
                                Order = 17,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft de features voor de komende iteratie en op de backlog dusdanig omschreven dat alle betrokkenen nu en in de toekomst begrijpen wat de feature inhoudt.",
                                Description = "",
                                Order = 18,
                                Weight = "excellent"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft features die tijdens de iteratievergadering besproken zijn niet op het iteratielog gezet.",
                                Description = "",
                                Order = 19,
                                Weight = "fail"

                            },
                        }
                    },

                    new Exam_Category
                    {
                        Order = 3,
                        Name = "Iteratieplanning",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat vermeldt de correcte start- en einddata van de iteratie op de iteratieplanning.",
                                Description = "",
                                Order = 20,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat vermeldt de datum en tijd waarop de klant de software opgeleverd krijgt.",
                                Description = "",
                                Order = 21,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat vermeldt eventuele kosten die aan het uitvoeren van de iteratie verbonden zijn of de kandidaat vermeldt terecht dat er geen kosten zijn.",
                                Description = "",
                                Order = 22,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat vermeldt eventuele bijzonderheden (feestdagen, vakanties, e.d.), inclusief passende tijdsaanduiding of de kandidaat vermeldt terecht dat er de komende iteratie geen bijzonderheden zijn.",
                                Description = "",
                                Order = 23,
                                Weight = "excellent"

                            },
                        }
                    },
                    new Exam_Category
                    {
                        Order = 4,
                        Name = "Technisch ontwerp",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat geeft aan welke hard- en software nodig is voor het ontwikkelen van de applicatie.",
                                Description = "",
                                Order = 24,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat geeft aan welke hard- en software nodig is voor het gebruiken van de applicatie.",
                                Description = "",
                                Order = 25,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat schets in een ER-diagram of een vergelijkbaar diagram de structuur van de te ontwikkelen database.",
                                Description = "",
                                Order = 26,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat schets in een diagram de structuur van de te ontwikkelen code.",
                                Description = "",
                                Order = 27,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat geeft in tekst een zinvolle toelichting op het codediagram.",
                                Description = "",
                                Order = 28,
                                Weight = "excellent"

                            },
                        }
                    },
                    new Exam_Category
                    {
                        Order = 5,
                        Name = "Werkplek",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat kan vertellen hoe de ontwikkelomgeving in elkaar zit.",
                                Description = "",
                                Order = 29,
                                Weight = "pass"

                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan de inrichting van de ontwikkelomgeving verantwoorden.",
                                Description = "",
                                Order = 30,
                                Weight = "pass"

                            },
                        }
                    }
                }
            });

            examList.Add(new Exam
            {
                Name = "Realiseren van een applicatie",
                NameId = "realiserenvaneenapplicatie",
                Cohort = "2011",
                Crebo = "95311",
                Subject = "Applicatieontwikkelaar",
                SubjectId = "applicatieontwikkelaar",
                Categories = new List<Exam_Category>()
                {
                    new Exam_Category
                    {
                        Order = 1,
                        Name = "Broncode",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat slaat zijn/haar code op in een version control systeem.",
                                Description = "",
                                Order = 1,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat checkt minstens één keer per dag code in.",
                                Description = "",
                                Order = 2,
                                Weight = "excellent"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft significant minder code geschreven dan zijn/haar groepsgenoten.",
                                Description = "",
                                Order = 3,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan zelf geschreven code in detail toelichten.",
                                Description = "",
                                Order = 4,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan ter plaatse wijzigingen aanbrengen in zelf geschreven code.",
                                Description = "",
                                Order = 5,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De layout van de code is overzichtelijk en consequent.",
                                Description = "",
                                Order = 6,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "Niet-triviale code is voorzien van zinvol commentaar.",
                                Description = "",
                                Order = 7,
                                Weight = "excellent"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan in de code laten zien hoe de presentatielaag en de applicatielaag van elkaar gescheiden zijn.",
                                Description = "",
                                Order = 8,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan in de code laten zien hoe de applicatielaag en de gegevenslaag van elkaar gescheiden zijn.",
                                Description = "",
                                Order = 9,
                                Weight = "excellent"
                            },
                            new Criterion
                            {
                                Title = "Namen in de code (van variabelen, functies, klassen, enz.) zijn niet duidelijk en omschrijvend.",
                                Description = "",
                                Order = 10,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De structuur van de code komt in grote lijnen overeen met wat er in het technisch ontwerp staat.",
                                Description = "",
                                Order = 11,
                                Weight = "pass"
                            },
                        }
                    },
                    new Exam_Category
                    {
                        Order = 2,
                        Name = "Database",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De applicatie is beveiligd tegen injection acttacks.",
                                Description = "",
                                Order = 12,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De structuur van de database komt overeen met wat er in het technisch ontwerp staat.",
                                Description = "",
                                Order = 13,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan de structuur van de database toelichten en verantwoorden (voldoende)",
                                Description = "",
                                Order = 14,
                                Weight = "pass"
                            },
                        }
                    },

                    new Exam_Category
                    {
                        Order = 3,
                        Name = "Release build",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De release build is voor de klant direct toegankelijk, bijvoorbeeld via een browser, of makkelijk te installeren.",
                                Description = "",
                                Order = 15,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De release build is beschikbaar op een ander systeem dan waar de kandidaat op ontwikkelt.",
                                Description = "",
                                Order = 16,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De release build bevat alle features van de laatst opgeleverde iteratie die op het iteratielog als voltooid vermeld staan.",
                                Description = "",
                                Order = 17,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "Op het iteratielog staat voor de afgelopen iteratie geen enkele feature als voltooid vermeld.",
                                Description = "",
                                Order = 18,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De release build bevat bugs waardoor de gebruiker niet redelijkerwijs met de applicatie kan werken.",
                                Description = "",
                                Order = 19,
                                Weight = "fail"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat zorgt voor een interface die aansluit bij de behoeften van de doelgroep.",
                                Description = "",
                                Order = 20,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat heeft een aparte tag gemaakt in het version control systeem voor de code van de release build.",
                                Description = "",
                                Order = 21,
                                Weight = "pass"
                            },
                        }
                    },
                    new Exam_Category
                    {
                        Order = 3,
                        Name = "Testen en onderhouden",
                        Criteria = new List<Criterion>()
                        {
                            new Criterion
                            {
                                Title = "De kandidaat zorgt ervoor dat gevonden bugs gemeld worden in het bugtrackingsysteem.",
                                Description = "",
                                Order = 22,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan een voorbeeld geven van een bug die hij/zij heeft opgelost en dit toelichten vanuit de code.",
                                Description = "",
                                Order = 23,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat kan in het bugtrackingsysteem laten zien dat hij/zij heeft geregistreerd dat hij/zij een bug heeft opgelost.",
                                Description = "",
                                Order = 24,
                                Weight = "pass"
                            },
                            new Criterion
                            {
                                Title = "De kandidaat geeft bij het oplossen van een bug in het bugtrackingsysteem aan in welke versie van de applicatie de bug is opgelost.",
                                Description = "",
                                Order = 25,
                                Weight = "excellent"
                            }
                        }
                    }
                }
            });

            _db.SaveExams(examList);
        }

        private static readonly Database _db = new Database();
    }
}

