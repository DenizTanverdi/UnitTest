#Unit Test 

Basic Unit Test project . I used ASP.NET Core Web,XUnit Test,.Net Project.App, Entity Framework Core.

## Getting Started

```
git clone https://github.com/DenizTanverdi/UnitTest.git
cd UnitTest
```
## Unit Test Nedir ?

- Bir uygulamanın en küçük parçalarının birbirinden bağımsız nasıl davrandıklarını test edebilen süreçtir.

- Mvc projesinde en küçük bileşen methodlarımız oluyor.Methodlarımızın nasıl bir davranış sağladığını 
unit test sayesinde öğrenmiş oluyoruz

## Avantajları Nedir ?

- Bir uygulama için erken uyarı sistemi olmasıdır.Bir uygulamamızı yazdığımız zaman  
 daha production ortamına çıkmadan o uygulamamızın o uygulamamızın methodlarının 
 nasıl bir davranış sergilediğini öğrenmiş oluruz
- Bize zaman kazandırır.Unit test yazdığımız zaman vakit harcamış oluruz hatta daha fazla kod'da 
 yazmış olabiliriz ama ilerleyen zamanlar da ortaya çıkıcak olan hataları ilk başta görüceğimiz için 
 ciddi bir zaman kazanmış olucağız.

## Unit Test Framework'leri ? 

- MsTest "Microsoft tarafından geliştiren bir Test Framework'tur"
- NUnit	 "OpenSource olan bir framework'tur."
- XUnit  "OpenSource olan bir framework'tur." (En çok kullanılan framework)

## 3 Aşamadan Oluşmaktadır.
- Arrange ``` Hazırlık evresi ```
- Act ``` Test ettiğimiz methodun çalıştığı evre```
- Assert ``` Test ettiğimiz yer ```

## Test Method İsimlendirme.
```
[MethodName_StateUndeerTest_ExpectedBehavior]

Örnek : add_simpleValues_returnTotalValue
```
## Mock Nedir ?

- Mock kavramı istediğimiz bir objenin yerine geçebilen fake objelerdir. Bu objelerin istediğimiz gibi davranmalarını sağlayabiliriz.

## Mock/Mocklamak Bize Ne Sağlar?
- Unit test bir birimi test ettiği için, oradaki akışı test ederken bu akışa bağlı olan dependency‘lerin test akışını bozmamasını sağlar.
- Unit test işlemini yaparken, test’i istediğimiz senaryoda yönlendirebilmemizi sağlar.
- Complex objelerin yavaşlıklarından kurtulabilmemizi sağlar.

## Mock Metodları
 ``` mymock = new Mock<ICalculatorService>(); // Taklit eder. 
     mymock.Verify(x => x.Add(a, b), Times.Once); // Bu method 1 kere çalışırsa başarılı 1 den fazla çalışırsa hata döner
     mymock.Verify(x => x.Add(a, b), Times.Never); //Hiç çalışmazsa
     mymock.Verify(x => x.Add(a, b), Times.AtLeast(2)); // En az 2 kere çalışırsa True Döner
      
 ```
## Unit Test Attribute 
 ```
        [Fact]   //Hem parametre almaması hemde test methodu olduğunu belirtiyoruz
        public  async void Index_ActionExecute_ReturnView()
 ```
 ```
        [Theory] //Parametre aldığını belirtiyoruz
        [InlineData(2,5,7)]
        [InlineData(10, 5, 15)]
        public void Add_simpleValues_ReturnTotalValue(int a ,int b,int sum)
 ```
