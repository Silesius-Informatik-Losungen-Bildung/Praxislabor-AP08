# StempelApp

## CyberGuardians

### Aufgaben

Konzept & programmiertechnische Umsetzung von allen Authentifizierung- und Autorisierung -Cases

- Registrierung
- Login
- Rollen

### Views

- Registrierung

- Login

- SystemAdmin-Dashboard

- ReinigungsAdmin-Dashboard

- ReinigungsKunden-Dashboard

- ReinigungsMitarbeiter-Dashboard

### Tabellen

- Personen
- Rollen

#### Personen

- E-Mail (unique)
- Passwort (hash)
- Rolle
- FirmenId

#### Rollen

- appAdmin
  - verwaltet ReinigungsAdmins
  - Zugriff auf alle Daten
- cleaningAdmin/ReinigungsAdmin
  - verwaltet ReinigungsMitarbeiter
  - verwaltet ReinigungsKunden
- claeaningStaff/Reinigungskraft
  - varwalten? von seinen Aufträgen
- buildingOwner/ImmobilienBesitzer
  - Nur Ansicht 

#### Namensvorschläge Rollen de/en

- appAdmin            AppAdmin
- cleaningAdmin    ReinigungsAdmin
- claeaningStaff    Reinigungskraft
- buildingOwner    ImmobilienBesitzer 

### Sonstiges

was wenn Internet nicht funktioniert?

# 