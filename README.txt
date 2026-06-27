BEAUTYBOOKING – SYSTEM ZARZĄDZANIA REZERWACJAMI USŁUG KOSMETYCZNYCH

Autor: Albina Nechyporenko

OPIS PROJEKTU

BeautyBooking jest systemem służącym do zarządzania usługami kosmetycznymi, klientami, pracownikami, rezerwacjami oraz płatnościami.

Technologie wykorzystane w projekcie:

* .NET 8
* ASP.NET Core WebAPI
* Blazor Server
* Blazor WebAssembly
* Entity Framework Core
* SQLite
* AutoMapper
* FluentValidation
* NLog

ARCHITEKTURA PROJEKTU

Projekt został wykonany zgodnie z zasadami czystej architektury i składa się z następujących warstw:

* BeautyBooking.Domain
* BeautyBooking.Application
* BeautyBooking.Infrastructure
* BeautyBooking.WebAPI
* BeautyBooking.BlazorServer
* BeautyBooking.BlazorWasm
* BeautyBooking.SharedKernel

BAZA DANYCH

System wykorzystuje bazę danych SQLite.

Tabele:

* Services
* Clients
* Employees
* Reservations
* Payments

FUNKCJONALNOŚCI

* Zarządzanie usługami
* Zarządzanie klientami
* Zarządzanie pracownikami
* Zarządzanie rezerwacjami
* Zarządzanie płatnościami
* Operacje CRUD dla wszystkich encji
* Walidacja formularzy
* Dashboard prezentujący podstawowe statystyki systemu

URUCHOMIENIE

1. Otworzyć rozwiązanie BeautyBooking.sln.
2. Ustawić projekty startowe:

   * BeautyBooking.WebAPI
   * BeautyBooking.BlazorWasm
3. Uruchomić rozwiązanie.
4. WebAPI zostanie uruchomione wraz z bazą SQLite.
5. Interfejs użytkownika będzie dostępny w przeglądarce.

