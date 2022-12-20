# Apartment Management System Introduction

## Tablo Tasarımı
users : Bu tablo site sakinlerini ve site çalışanlarını tutan tablodur. Bu ayrımı "user_types" tablosuna göre yaparız. Basit olarak kullanıcı bilgilerini tutar.

users_type: user tablosuna hizmet eder.

messages: Apartmanlar arası mesajlaşma sistemidir. Mesaj bilgileri "From" ve "To" apartman biçiminde yer almaktadır.

apartments : Apartman bilgileri dışında "apartment_type" bilgisi yer almaktadır. Apartman type içerisinde "site yönetim ofisi", "ticari amaçlı dükkan" ve "apartman" tipleri yer alır. 
Bu tip içerisinde m2 ve ödemesi gereken aidat bilgileri gibi detay bilgiler de yer almaktadır.

Örnek olarak;


<table border="2">
    <body>
    <tr>
            <td>Daire Tipi</td>
            <td>Fiyatı</td>
            <td>m2 Ölçümü</td>
            <td>Kullanım Amacı</td>  
        </tr>
        <tr>
            <td>1+0</td>
            <td>0 TL</td>
            <td>200 m2</td>
            <td>ofis</td>
        </tr>
        <tr>
            <td>1+1</td>
            <td>1,500 TL</td>
            <td>100 m2</td>
            <td>commerce<br />
            </td>
        </tr>
        <tr>
            <td>2+1</td>
            <td>800 TL</td>
            <td>120 m2</td>
            <td>apart<br />
            </td>
        </tr>
        <tr>
            <td>2+1</td>
            <td>1200 TL</td>
            <td>140m2</td>
            <td>apart</td>
        </tr>
        <tr>
            <td>3+1</td>
            <td>1600 TL</td>
            <td>150m2</td>
            <td>apart</td>
        </tr>
    </body>
</table>



Apartman içerisinde owner_user_id bilgisi yer almaktadır. Bu user içerisinde, Çalışan,site sakini olarak farklı tiplerde ayrıştırmalar vardır.

apartments_type: Apartman tablosuna hizmet eder.

payments: Bu tabloda ödenen veya ödenmesi gereken tutarlar yer alır. Ödeme durumu "state"(success,error,waiting) olarak belirtilir. payment_type_id değeri ile ödemenin hangi tipte olduğu spesifik olarak belirtilir. Örneğin "Aidat","genel giderler","asansör yenileme" vs. gibi sabitlenmiş isimlendirmelerin olduğu referans bilgisi yer alır. Ödenecek tutar "amount" değerinde yer alır. Eğer ödenecek tutar aidat bilgisi ise otomatik olarak bulunan apartmanın tipi üzerinden çekilir.

payments_type : payment tablosuna hizmet eder.

Not : Veriler tablolardan silinmez, "deleted" olarak kaydı tutulur.


## Projede Kullanılan Paketler

Mssql Express Edition
Sql.Data
Dapper,
AutoMapper

## Proje İlerleme Bilgileri

Uygulama içerisinde veritabanı ile iletişimi dapper ile sağladım. Katmanlar arasında (Repository, Service ve Controller) verileri map ettim.
Yalnızca veritabanı işlemlerini gerçekleştiren süreçleri "Repository" katmanında en sade biçimiyle konumlandırdım.
İş akışı validasyonlarını gerçekleştirmek ve operasyonel olarak farklı repolara ihtiyac duyduğum yerleri birleştirmek için "Service" katmanını kullandım. 
Bunun örneği "UserService" içerisinde "PayMineDue" methodunda görülebilir. 
"Controller" katmanı ise gelen istekleri karşılamak ve ilgili servise aktarmak için kullandım.



## Teknik curl Dökümantasyonları


# Get Apartments Types 

curl -X 'GET' \
  'https://localhost:7200/apartments/types' \
  -H 'accept: */*'


# Get Apartments 

curl -X 'GET' \
  'https://localhost:7200/apartments' \
  -H 'accept: */*'


# Create Apartment

curl -X 'POST' \
  'https://localhost:7200/apartments' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "empty": true,
  "floor": 5,
  "doorNumber": 4,
  "ownerUserId": 1,
  "apartmentTypeId": 2
}'



# Update Apartment

curl -X 'PUT' \
  'https://localhost:7200/apartments' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id":33
  "floor": 5,
  "doorNumber": 4,
  "ownerUserId": 1,
}'


# Delete Apartment
curl -X 'DELETE' \
  'https://localhost:7200/apartments/1' \
  -H 'accept: */*'


# Get Messages

curl -X 'GET' \
  'https://localhost:7200/messages/1?isRead=true' \
  -H 'accept: */*'   


# Send Message to Site Manager

curl -X 'POST' \
  'https://localhost:7200/messages/to-manager' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "fromId": 1,
  "message": "hello i have a question"
}'



# Create User
curl -X 'POST' \
  'https://localhost:7200/users' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "fullName": "fatma",
  "identityNumber": "3434343",
  "email": "fatma@papara.com",
  "plate": "34 ftm 4567",
  "phone": "47389647343",
  "userTypeId": 1
}'


# Update User
curl -X 'PUST' \
  'https://localhost:7200/users' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "fullName": "fatma",
  "identityNumber": "3434343",
  "email": "fatma@papara.com",
  "plate": "34 ftm 4567",
  "phone": "47389647343",
  "userTypeId": 1
}'


# Delete User

curl -X 'DELETE' \
  'https://localhost:7200/users/1' \
  -H 'accept: */*'

