# HepsiBurada-Api
Ürünleri listeleme ve güncelleştirme

Merhabalar, bu ilk yazımızda özetle Hepsiburada Test Ortamında API üzerinden ürünlerin çekilmesi, ayrıca ürünlerin fiyat ve adet gibi kısımlarında değişiklik yapılması işlemlerine değineceğiz.

Öncelikle Hepsiburada kanalında yapılması gerekenleri yine Hepsiburada'dan alıntılayarak listeleyelim.

Hepsiburada'da entegrasyon süreci nasıl işler?
Öncelikle mağazanıza ait tüm sözleşme ve diğer evrakların Hepsiburada.com'a iletilmiş, carinizin açılmış ve satıcı portal bilgilerinizin size iletilmiş olması gerekmektedir.
Mağazanıza ait ürünlerin Hepsiburada.com kataloğuna eklenmiş ve satıcı portalınızda listelenmiş olması gerekmektedir.
Daha sonra entegrasyon yapmak istediğiniz aracı firma bilgileri ve diğer bilgileri paylaşmanızı istiyoruz. Eğer entegrasyonu kendi teknik ekibinizle gerçekleştirecekseniz bize bildirmenizi rica ediyoruz.
Gerekli teknik tanımlamalar IT departmanımız tarafından yapıldıktan sonra test ortamında entegrasyon işlemleriniz kontrol edilir.
Entegrasyon testlerini bitirdikten sonra sistem canlıya alınır.
Artık stok ve fiyat takibini daha kolay yapabilir ve operasyonel anlamda işlemlerinizi daha rahat takip edebilirsiniz.

Hepsiburada'da entegrasyon test sürecinde yapılması beklenen işlemler nelerdir?
Öncelikle test ortamı için Hepsiburada tarafından oluşturulan 5 adet test ürününün listesini çekmeniz,
Çektiğiniz bu ürünlerin adet, fiyat gibi bilgilerini değiştirerek Hepsiburada test ortamına yüklemeniz,
Yine Hepsiburada tarafından test ortamınıza yüklenecek test siparişlerinin çekilmesi tarafınızca yapılması gereken işlemlerdir.

Öncelikle Hepsiburada'ya başvurup tarafınıza API Test Ortamınının açılmasını istediğinizi ve gerekli kullanıcı adı ve parolalarını temin ettiğinizi varsayıyoruz.

Gerekli tüm bilgilere buradan erişebilirsiniz
HepsiBurada Developer Adresi: https://developers.hepsiburada.com/?docs=dokuman/baslangic

Gelelim kod tarafına...

Öncelikle Projemize RestSharp dll'yi dahil ediyoruz. RestSharp dll dosyasını ekleyebilmek için Projeden Nuget paket yöneticisine tıklayarak Gözat sekmesinden RestShap kütüphanesini yüklüyoruz. 

![2022-07-14 19_12_36-Window](https://user-images.githubusercontent.com/105115254/179028480-4f45fc8e-34e5-4c0d-8de3-1c103b4faabf.jpg)

Burada dikkat edilmesi gereken yüklenecek olan paketin sürümü. Her sürüm sağlıklı çalışmadığı için bu proje için 106.10.0 sürümünü kurmanız gerekmektedir.
![2022-07-14 18_43_17-Window](https://user-images.githubusercontent.com/105115254/179028158-5f4521bb-8a8c-4b94-9d7b-cddb05143c7b.jpg)
Sonrasında usinglerimizi ekliyoruz.
using RestSharp;
using System;
using System.Net;
using System.Text;
using System.Windows;
gibi
