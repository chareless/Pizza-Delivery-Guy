# Pizza-Delivery-Guy
 
-2 level ayrı olarak tasarlandı, eklendi.
-Yeni level tasarlandığında GameManager üzerinden "levels" kısmına da eklenmeli.
-Level sayısını geçtiğnide eski leveller rastgele eklenerek oyun devam ediyor.
-Levels->Level[i] üzerindeki "LevelManager" componenti üzerinden ilgili levelde kaç adet kamyon ve müşteri olacağı belirtilmeli ve eklenmelidir.
-Yoldan çıktığında, müşteriye çarptığında, kamyona çarptığında ve level için gerekli minimum müşteri sayısına ulaşılmadığında oyun kaybedilir.
-Pizzaların sallanması Quaternion.Euler ile yapıldı.
-Player script üzerindeki "RotateAngle" değiştirilerek döndürme açısı ayarlanabilir. Mouse ve touch kontrolleri için ayrı açı değerleri kullanılmalıdır.

EKLENEBİLECEK ÖZELLİKLER

-Level arttıkça oyuncunun hareket hızı arttırılabilir
-Zorluk olarak yola araç veya çeşitli başka engeller eklenebilir. 
-Market sistemi eklenebilir, kazanılan paralarla yeni araçlar alınabilir.
-Pizza aldıkça süre kazandığımız zamana karşı oyun modu eklenebilir.
-Müşteri ve pizza kamyonlarına çeşitlilik getirilebilir.

KARŞILAŞTIĞIM ZORLUKLAR

-Pizzaların bir arada durup araca bağlanması konusunda zorluk yaşamıştım. Sonrasında  "transform.parent = GameObject.FindGameObjectWithTag("Tabak").transform " kullanarak tüm pizzaları tabak objesine child olarak ekledim. 
-Hareket halindeyken pizza alındığında sallanma yüzünden pizzaların şekli bozuk ekleniyordu. Bu sebeple pizzaları aldıktan veya verdikten sonra tekrar sallanabilmesi için ekrana dokunmayı bırakmak gerekmektedir.
-Pizza alma ve müşteri noktalarında kaçıncı noktalara uğradığımı bulmak için " pizzaPoints = GameObject.FindGameObjectsWithTag("PizzaPoint")" kullandım. Bunu kullanmak geç aklıma geldiği için ilk başlarda zorladı.
-Müşterilere pizza verirken tüm pizzaları silip kalan pizza sayısı kadar tekrar üretiyordum. Sonradan liste şeklinde yapmayı öğrendim ve düzelttim.
