# 🍽️ MyAngularRestaurantServer

MyAngularRestaurant projesinin ASP.NET Core Web API backend uygulamasıdır. Restoran içerikleri, ürünler, kategoriler, rezervasyonlar, iletişim bilgileri ve kullanıcı işlemleri için RESTful API endpoint'leri sağlar.

## ✨ Özellikler

- RESTful ASP.NET Core Web API
- Entity Framework Core ile veritabanı işlemleri
- Kategori CRUD işlemleri
- Ürün / menü CRUD işlemleri
- Feature yönetimi
- Service yönetimi
- About yönetimi
- Reservation yönetimi
- Contact Info yönetimi
- Kullanıcı kayıt işlemi
- Kullanıcı giriş doğrulaması
- Şifrelerin hash'lenerek saklanması
- DTO kullanımı
- FluentValidation ile veri doğrulama
- Swagger üzerinden API testi
- Angular frontend ile HTTP tabanlı entegrasyon

## 🛠️ Kullanılan Teknolojiler

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- FluentValidation
- DTO Pattern
- Dependency Injection
- PasswordHasher
- Swagger / OpenAPI
- LINQ
- Async / Await

## 🧩 Temel Modüller

API aşağıdaki temel alanların yönetimini sağlar:

- Categories
- Products
- Features
- Services
- Abouts
- Reservations
- Contact Infos
- Users

Bu alanlar Angular yönetim paneli ve restoran kullanıcı arayüzü tarafından HTTP istekleriyle kullanılmaktadır.

## 🔐 Authentication

Case kapsamına uygun sade bir kullanıcı sistemi geliştirilmiştir.

### Register

Yeni kullanıcı oluşturulduğunda şifre doğrudan veritabanına kaydedilmez. `PasswordHasher<User>` kullanılarak hash oluşturulur ve `PasswordHash` alanında saklanır.

### Login

Login isteğinde kullanıcı e-posta adresi ile bulunur ve gönderilen şifre kayıtlı hash ile doğrulanır. Başarılı işlem sonucunda frontend'in kullanacağı kullanıcı bilgileri döndürülür.

> Not: Proje JWT veya ASP.NET Core Identity tabanlı production authentication sistemi kullanmamaktadır. Authentication yapısı demo/case projesinin ihtiyaçlarına göre sade tutulmuştur.

## 📦 Kullanıcı Modeli

```text
User
├── UserId
├── NameSurname
├── Email
└── PasswordHash
```

API response'larında `PasswordHash` istemciye gönderilmez.

## 🔗 Frontend

Bu API'nin Angular frontend repository'si:

https://github.com/ismailbarankarasu/MyAngularRestaurant

## 🚀 Kurulum

Repository'yi klonlayın:

```bash
git clone https://github.com/ismailbarankarasu/MyAngularRestaurantServer.git
cd MyAngularRestaurantServer
```

NuGet paketlerini yükleyin:

```bash
dotnet restore
```

Veritabanı connection string'ini kendi SQL Server ortamınıza göre yapılandırın.

Migration'ları uygulayın:

```bash
dotnet ef database update
```

Projeyi çalıştırın:

```bash
dotnet run
```

Development ortamında Swagger arayüzü üzerinden endpoint'leri inceleyebilir ve test edebilirsiniz.

## 🗄️ Veritabanı

Entity Framework Core Code First yaklaşımı kullanılmıştır. Entity değişiklikleri migration'lar aracılığıyla SQL Server veritabanına aktarılır.

Örnek migration komutları:

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
```

## 🏗️ Genel Akış

```text
Angular Client
      │
      │ HTTP / JSON
      ▼
ASP.NET Core Web API
      │
      ├── Controllers
      ├── DTOs
      ├── Validators
      ├── Services
      │
      ▼
Entity Framework Core
      │
      ▼
SQL Server
```

## 🔒 Güvenlik Notları

- Kullanıcı şifreleri plain-text olarak saklanmaz.
- Login sırasında genel hata mesajı kullanılarak e-posta/şifre doğrulaması yapılır.
- Kullanıcı response modellerinde şifre hash'i bulunmaz.
- Frontend admin erişimi Angular AuthGuard ile kontrol edilir.

## 👨‍💻 Geliştirici

**İsmail Baran Karasu**

- GitHub: https://github.com/ismailbarankarasu
- LinkedIn: https://www.linkedin.com/in/ismail-baran-karasu/

## 📄 Proje Hakkında

Bu proje Angular ve ASP.NET Core Web API teknolojilerinin birlikte kullanıldığı bir restoran yönetim uygulamasının backend katmanıdır. CRUD operasyonları, doğrulama, Entity Framework Core, SQL Server, REST API tasarımı ve temel kullanıcı doğrulama akışını uygulamalı olarak bir araya getirir.
