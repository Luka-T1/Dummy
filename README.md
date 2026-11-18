# Predmetni projekat iz predmeta OISISI 2026/2027 - Sajam knjiga

Članovi tima:

* Luka Tomašević RA44/2024
* Aleksandar Djurić RA49/2024

## Podela posla

**Aleksandar Djurić** - model podataka (`SajamKnjiga.Core/Models`), serijalizacija (`Serializer`, `Storage`, `ToCSV`/`FromCSV`), DAO klase, povezivanje entiteta posle ucitavanja, glavni meni (`Program.cs`)

**Luka Tomašević** - solution i projekti (`.sln`, `.csproj`), konzolni unos i ispis (`SajamKnjiga.CLI/Views`), dodavanje, izmena i brisanje svih entiteta u konzoli, README

## Pokretanje

Potreban je .NET 8 SDK.

```
dotnet build SajamKnjiga.sln
dotnet run --project SajamKnjiga.CLI
```

Podaci se cuvaju u folderu `Data` u korenu repozitorijuma, jedan `.txt` fajl po entitetu (vrednosti su odvojene sa `|`). Ako fajl ne postoji, napravi se prazan pri prvom pokretanju.
