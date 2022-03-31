# KatmanliMimari
Bu projede Ado.Net ile Katmanlı Mimari esas alınarak Generic Mimari ve Reflection yapıları ile veritabanındaki her tablo için tek bir Select , Insert , Update , Delete sorguları uygulanmıştır.Solution da yer alan 'KatmanliMimariEntity' projesindeki class'lar veritabanımızdaki tablolara karşılık gelmektedir.(Tablo isimleri ile class isimlerinin ve class'ların property'lerinin de kolon isimleri ile aynı olmasına dikkat edilmiştir.) Veri tabanımızdaki Store Procedure 'lerin isimleri de belli bir standarda uygun olarak verilmiştir.(prc_(tabloAdi)_(SorguAdi))


# Singleton Pattern
Burada Baglanti nesnesinin her kullanılacağı anda yeniden new'lenmesini önlemek amaçlı kullanılan bir yapı kullandım.Eğer Baglanti nesnesi daha önce new'lenmişse ve bu hala Ram'den silinmemişse o nesne kullanılsın , hiç new'lenilmemişse veya daha önce new'lenip Ram'dan silinmişse yeniden new'lensin. 

![2](https://user-images.githubusercontent.com/94843366/158041212-04f9c263-a133-4b5d-ba18-68c0f1e2eaea.png)


# Generic Interface
Dışarıdan tip alan bu interface bir sonraki adımda eklenecek olan ORMBase class'ına iplement edilerek içerisindeki tüm metotların ORMBase class'ından kalıtılacak olan diğer class'lar için kullanımı amaçlanmıştır.

![1](https://user-images.githubusercontent.com/94843366/158040632-9ca1a634-de7b-44d0-af7b-d0c5413e3327.png)

# Generic Class
ORMBase class'ındaki Select , Insert , Update , Delete Methodları

![4](https://user-images.githubusercontent.com/94843366/158041034-2f3f71c9-c4ca-4d01-9a8a-b48840f46b60.png)


Dışarıdan tip alan ProcedureType() metodu ile Insert ve Update metodlarında aynı kodların tekrar tekar yazılmaması amaçlanmıştır.

![3](https://user-images.githubusercontent.com/94843366/158041105-9861d1b3-caa4-403a-bf87-092b17b74aab.png)
 
![5](https://user-images.githubusercontent.com/94843366/158041038-61ef2004-a7ef-4662-99f2-b2eb505a012a.png)
  

# Arayüz
Ürünler Tablosu 

![6](https://user-images.githubusercontent.com/94843366/158041173-20e3ed65-cb0b-4a4a-b878-d6d7b584c1a9.png)

  
