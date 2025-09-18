# App-Name: StempelApp

## Team: CyberGuardians

### Team-Aufgaben
Konzept und programmiertechnische Umsetzung aller Authentifizierung- und Autorisierung-Cases
- Rollen
- Registrierung
- Login

### Rollen
|Name EN|Name DE|Berechtigungen|
|---|---|---|
|appAdmin|AppAdmin|- verwaltet ReinigungsAdmins<br>- Zugriff auf alle Daten|
|cleaningAdmin|ReinigungsAdmin|- verwaltet ReinigungsMitarbeiter<br>- verwaltet ReinigungsKunden|
|claeaningStaff|Reinigungskraft|varwalten von seinen Aufträgen|
|buildingOwner|ImmobilienBesitzer|Nur Ansicht|

### Views
- Registrierung
- Login
- appAdmin-Dashboard
- reinigungsAdmin-Dashboard
- reinigungskraft-Dashboard
- buildingOwner-Dashboard


### Benötigte Tabellen/Spalten
- Personen
    - email (unique)
    - passwort (hash)
    - salt?
    - roleId
    - companyId
- Rollen
    - roleId
    - roleName

---

### Sonstiges