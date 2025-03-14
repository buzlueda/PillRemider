# 🩺 **PillReminder** 💊

**PillReminder**, .NET kullanılarak geliştirilmiş basit ama güçlü bir ilaç hatırlatıcı uygulamasıdır. Kullanıcılar, ilaçlarını takip edebilir, dozajları, hatırlatma zamanlarını ekleyebilir ve zamanında bildirimler alarak hiçbir dozu kaçırmazlar. Uygulama, en yeni teknolojilerle geliştirilmiş olup **Clean Architecture** ve **SOLID prensipleri** takip edilerek güçlü, sürdürülebilir ve ölçeklenebilir bir çözüm sunar. 🌟

## 🚀 Özellikler

- **🔒 Kullanıcı Kimlik Doğrulaması**: Güvenli giriş ve kullanıcı yönetimi sistemi.
- **💊 İlaç Takibi**: İlaçlarınızı kolayca ekleyebilir, güncelleyebilir ve yönetebilirsiniz. Dozaj, sıklık ve zamanı belirleyebilirsiniz.
- **⏰ Hatırlatıcılar**: Planlanan her doz için zamanında bildirimler alarak sağlığınızı takip edin.
- **🧑‍💻 Clean Architecture**: Ölçeklenebilir, sürdürülebilir ve test edilebilir bir uygulama yapısı.
- **⚡ SOLID Prensipleri**: Güçlü ve sürdürülebilir yazılım tasarımı için SOLID prensiplerine uyum.

## 🛠 Kullanılan Teknolojiler

- **.NET Core**: Yüksek performans ve güvenilirlik için .NET Core kullanılarak geliştirilmiştir.
- **Entity Framework Core**: ORM ve veritabanı yönetimi.
- **SQLite / SQL Server**: Kullanıcı ve ilaç verilerini saklamak için kullanılır.
- **SignalR**: Gerçek zamanlı bildirimler için kullanılır.
- **JWT Kimlik Doğrulaması**: JSON Web Tokens ile güvenli kullanıcı kimlik doğrulama.
- **Swagger**: API dökümantasyonu ile uç noktaları kolayca keşfetmek ve kullanmak.

# 📂 PillReminder API Dökümantasyonu

PillReminder, kullanıcılar ve ilaçlarını yönetmek için RESTful API sunmaktadır. API uç noktalarını keşfetmek ve test etmek için Swagger UI'yı kullanabilirsiniz. 

## 🔑 Kimlik Doğrulama

### `POST /api/auth/login`

Kullanıcıyı doğrulayıp bir JWT token alın.

**Parametreler:**
| Parametre | Tür     | Açıklama     |
|-----------|---------|--------------|
| username  | string  | Kullanıcı adı|
| password  | string  | Şifre        |

**Yanıt:**
- `200 OK`: Başarılı giriş ve JWT token.
- `401 Unauthorized`: Hatalı kullanıcı adı veya şifre.

---

## 💊 İlaç Yönetimi

### `GET /api/medications`

Giriş yapmış kullanıcının tüm ilaçlarını alın.

**Yanıt:**
| Alan      | Tür     | Açıklama                          |
|-----------|---------|-----------------------------------|
| id        | int     | İlaç ID'si                       |
| name      | string  | İlaç adı                          |
| dosage    | string  | Dozaj bilgisi                    |
| frequency | string  | İlaç kullanım sıklığı            |
| time      | string  | İlaç alma zamanı (HH:mm)          |

---

### `POST /api/medications`

Yeni bir ilaç ekleyin.

**Parametreler:**
| Parametre | Tür     | Açıklama                          |
|-----------|---------|-----------------------------------|
| name      | string  | İlaç adı                          |
| dosage    | string  | Dozaj bilgisi                    |
| frequency | string  | İlaç kullanım sıklığı            |
| time      | string  | İlaç alma zamanı (HH:mm)          |

**Yanıt:**
- `201 Created`: İlaç başarıyla eklendi.
- `400 Bad Request`: Geçersiz parametreler.

---

### `PUT /api/medications/{id}`

Var olan bir ilacı güncelleyin.

**Parametreler:**
| Parametre | Tür     | Açıklama                          |
|-----------|---------|-----------------------------------|
| id        | int     | Güncellenecek ilaç ID'si         |
| name      | string  | İlaç adı                          |
| dosage    | string  | Dozaj bilgisi                    |
| frequency | string  | İlaç kullanım sıklığı            |
| time      | string  | İlaç alma zamanı (HH:mm)          |

**Yanıt:**
- `200 OK`: İlaç başarıyla güncellendi.
- `404 Not Found`: İlaç bulunamadı.

---

### `DELETE /api/medications/{id}`

Bir ilacı listenizden kaldırın.

**Parametreler:**
| Parametre | Tür     | Açıklama                          |
|-----------|---------|-----------------------------------|
| id        | int     | Silinecek ilaç ID'si             |

**Yanıt:**
- `200 OK`: İlaç başarıyla silindi.
- `404 Not Found`: İlaç bulunamadı.

---

## ⏰ Hatırlatıcılar

### `POST /api/reminders`

Bir ilaç için hatırlatıcı ayarlayın.

**Parametreler:**
| Parametre    | Tür     | Açıklama                            |
|--------------|---------|-------------------------------------|
| medicationId | int     | İlaç ID'si                          |
| reminderTime | string  | Hatırlatıcı zamanı (HH:mm)          |

**Yanıt:**
- `201 Created`: Hatırlatıcı başarıyla oluşturuldu.

---

### `GET /api/reminders`

Giriş yapmış kullanıcının tüm hatırlatıcılarını alın.

**Yanıt:**
| Alan         | Tür     | Açıklama                            |
|--------------|---------|-------------------------------------|
| id           | int     | Hatırlatıcı ID'si                   |
| medicationId | int     | İlaç ID'si                          |
| reminderTime | string  | Hatırlatıcı zamanı (HH:mm)          |

---

## 🏗️ Clean Architecture & SOLID Prensipleri

PillReminder, Clean Architecture'ı takip ederek ölçeklenebilirlik ve sürdürülebilirlik sağlar. Uygulama yapısı şu katmanlara ayrılmıştır:

- **Core**: İş mantığı, varlıklar ve arayüzler bulunur.
- **Application**: Uygulama akışına özgü kullanım senaryoları ve servisler bulunur.
- **Infrastructure**: Veritabanı erişimi, dış API'ler ve altyapı ile ilgili diğer konular.
- **Web API**: Kullanıcı taleplerine cevap veren ve diğer katmanlarla iletişim kuran giriş noktası.

Uygulama, SOLID prensiplerine uyarak yüksek kaliteli, anlaşılır ve sürdürülebilir bir yazılım tasarımı sağlar:

- 📌 **Single Responsibility Principle** (Tek Sorumluluk Prensibi): Her sınıfın yalnızca bir sorumluluğu vardır, bu da sistemi daha anlaşılır ve hataya daha az yatkın hale getirir.
- 📍 **Open/Closed Principle** (Açık/Kapalı Prensibi): Sistem genişletilmeye açık ancak değiştirilmeye kapalıdır, bu da gelecekteki geliştirmeleri kolaylaştırır.
- 🔄 **Liskov Substitution Principle** (Liskov Yerine Geçme Prensibi): Türetilmiş sınıflar, ana sınıflarla değiştirilebilir olmalı, sistemin doğruluğunu etkilemeden.
- ✂️ **Interface Segregation Principle** (Arayüz Ayrımı Prensibi): Kullanıcılar, kullanmadıkları arayüzlere bağımlı olmamalıdır, bu da daha modüler bir tasarım sağlar.
- 🔌 **Dependency Inversion Principle** (Bağımlılık Tersine Çevirme Prensibi): Yüksek seviyeli modüller düşük seviyeli modüllere bağımlı olmamalıdır. Her ikisi de soyutlamalar üzerine bağımlı olmalıdır.

---

## 🌱 Gelecekteki Geliştirmeler

- 📱 **Mobil Uygulama**: Hem Android hem de iOS için mobil uygulama desteği.
- 🔔 **Akıllı Bildirimler**: Makine öğrenimi tabanlı akıllı hatırlatıcılar.

---

## 💬 İletişim

Bu projeyle ilgili iletişime geçmek isterseniz, [email@example.com](mailto:edabuzlu@gmail.com) adresinden ulaşabilirsiniz.

---

**PillReminder**'ı kullanarak sağlığınıza dikkat edin, ilaçlarınızı unutmayın! 💊✨
