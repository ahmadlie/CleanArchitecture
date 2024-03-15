# Clean Architecture

Clean Architecture, yazılım sistemlerini tasarlarken kullanılan, bağımsızlık, esneklik ve sürdürülebilirlik prensiplerine odaklanan bir mimari yaklaşımdır. Robert C. Martin (Uncle Bob) tarafından popüler hale getirilmiş olup, yazılımın iş kurallarını teknoloji ve altyapı detaylarından soyutlayarak daha temiz, daha anlaşılır ve daha kolay yönetilebilir sistemler oluşturmayı amaçlar. C# dili ile uygulandığında, .NET ekosisteminin sağladığı araçlar ve kütüphanelerle birlikte, bu prensipleri takip eden uygulamalar geliştirmek mümkündür.

**Clean Architecture, genellikle aşağıdaki katmanlardan oluşur**:

- **Entities (Varlıklar)**: İş kurallarını temsil eden ve uygulamanın temelini oluşturan nesnelerdir. Bu katman, en içte yer alır ve diğer katmanlar tarafından kullanılır.
- **Use Cases (Kullanım Durumları)**: Uygulamanın yapabileceği işlemleri temsil eder. İş kurallarını içerir ve sistemle etkileşimde bulunan dış katmanlardan gelen istekleri işler.
- **Interface Adapters (Arayüz Adaptörleri)**: Veri dönüşümlerini gerçekleştirir ve uygulamanın dış dünya ile etkileşimini sağlar. Bu katman, kullanıcı arayüzü (UI), web API'leri, veritabanı erişimi gibi dış sistemlerle iletişimi içerir.
Frameworks and Drivers (Çerçeveler ve Sürücüler): Uygulamanın dış dünyaya bağlandığı en dış katmandır. Bu katman, web sunucuları, veritabanı motorları gibi teknolojik detayları içerir.

Clean Architecture'ın temel avantajlarından biri, uygulamanın iş kurallarının teknolojik altyapıdan bağımsız olarak geliştirilebilmesidir. Bu sayede, teknoloji değişikliklerine veya farklı kullanım senaryolarına kolayca uyum sağlayabilir. C# ve .NET ile Clean Architecture uygulamak, kodun test edilebilirliğini ve yeniden kullanılabilirliğini artırırken, bağımlılıkları azaltır ve sistem karmaşıklığını yönetilebilir kılar.





```bash
   dotnet ef migrations add "InitialProject" --project src\Infrastructure --startup-project src\WebApi --output-dir Data\Migrations 
   dotnet ef database update   --project src\Infrastructure --startup-project src\WebApi  


```