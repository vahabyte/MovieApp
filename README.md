
### Film Ekleme
![Film Ekleme](./Screenshots/filmekleme.png)

### Film Listesi
![Film Listesi](./Screenshots/filmlistesi.png)

# MovieApp

ASP.NET Core MVC ile geliştirilmiş, Entity Framework Core kullanılarak tasarlanmış, **çoka çok ve teke çok** ilişkilerle zenginleştirilmiş bir film yönetim uygulamasıdır. Projede **Scaffold-DbContext**, migrationlar, kapsamlı validation, Bootstrap tabanlı responsive tasarım ve dinamik JSON ile anlık doğrulama gibi ileri seviye özellikler entegre edilmiştir.

---

## İçindekiler

- [Proje Hakkında](#proje-hakkında)
- [Özellikler](#özellikler)
- [Veri Modeli ve İlişkiler](#veri-modeli-ve-iliskiler)
- [Kurulum ve Çalıştırma](#kurulum-ve-calistirma)
- [Kullanım Örnekleri](#kullanım-örnekleri)
- [Proje Dizini Örnekleri](#proje-dizini-ornekleri)
- [Önemli Notlar](#onemli-notlar)
- [Ekran Görüntüleri](#ekran-goruntuleri)
- [Kaynaklar](#kaynaklar)

---

## Proje Hakkında

MovieApp, yönetim (admin) ve kullanıcı (user) rollerinin aynı navbar üzerinden erişebildiği, modern, mobil uyumlu ve kullanışlı bir film yönetim platformudur.  
Projede:

- Scaffold-DbContext ile mevcut veritabanı şeması baz alınmıştır.
- Migrationlar ile versiyon kontrolü sağlanmıştır.
- Çoklu ilişkiler (**çoka çok**, **teke çok**) efektif şekilde tanımlanmıştır.
- Çoklu veri ekleme ve silme işlemleri (AddRange, DeleteRange) kullanılmıştır.
- Custom validation attribute’ları ve JSON tabanlı anlık doğrulamalar entegre edilmiştir.
- Bootstrap ile responsive ve erişilebilir UI tasarlanmıştır.

---

## Özellikler

- Film, Tür (Genre) ve ilişkili verilerin CRUD işlemleri  
- Çoklu tür seçimi ve ilişkilendirme  
- Çoklu silme işlemleri (DeleteRange)  
- Detaylı ve dinamik validasyonlar  
- Admin ve User için ortak navbar  
- Mobil uyumlu Bootstrap tasarım  
- JSON ile anlık kullanıcı adı veya veri doğrulama  
- Entity Framework Core migration yönetimi  
- Scaffold-DbContext ile var olan veritabanından model oluşturma  

---

## Veri Modeli ve İlişkiler

- Film ve Genre arasında **çoktan çoğa (many-to-many)** ilişki  
- Film ve diğer ilişkili tablolar ile **teke çok (one-to-many)** bağlantılar  
- Veri tutarlılığı için detaylı validasyonlar (benzersiz alanlar, format kontrolleri)  
- Çoklu kayıt ekleme ve silme için `AddRange`, `DeleteRange` yöntemleri kullanımı  

---

## Kurulum ve Çalıştırma

1. Depoyu klonlayın:

bash
git clone https://github.com/vahabyte/MovieApp.git
cd MovieApp

## Kullanım Örnekleri
Film Ekleme: Admin panelinden yeni film ekleyebilir, çoklu tür seçimi yapabilirsiniz.

Film Silme: Birden fazla filmi aynı anda seçip topluca silebilirsiniz (DeleteRange kullanımı).

Tür (Genre) Yönetimi: Tür ekleme, silme ve düzenleme işlemlerini yapabilirsiniz.

Anlık Validasyon: Kullanıcı adı veya diğer alanlar için JSON tabanlı anlık doğrulama sistemi entegre edilmiştir; formda veri girerken gerçek zamanlı geri bildirim alırsınız.

Mobil Duyarlılık: Tüm sayfalar Bootstrap 5 ile responsive tasarlanmıştır; mobilde, tablet ve desktop’ta rahat kullanılabilir.

## Ekran Görüntüleri

### Anasayfa
![Anasayfa](./Screenshots/anasayfa.png)

### Film Ekleme
![Film Ekleme](./Screenshots/filmekleme.png)

### Film Listesi
![Film Listesi](./Screenshots/filmlistesi.png)

### Kullanıcı Oluşturma
![Kullanıcı Oluşturma](./Screenshots/kullaniciolusturma.png)

### Tür Düzenleme
![Tür Düzenleme](./Screenshots/turduzenleme.png)

### Tür Listesi
![Tür Listesi](./Screenshots/turlistesi.png)