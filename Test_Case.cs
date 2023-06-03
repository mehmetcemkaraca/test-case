using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace TC_numarasi
{

    /*03.06.2023
     hastane ootomosyonu test case
    MEHMET CEM KARACA   

    başlıca testler:

    tc numarası kontrolu
    kullanıcı girişi testi
    personel girişi testi
    kayıt olma testi.

    4/4 başarılı.
     */
    internal class test_case
    {
        [Test] /*TC kimlik numarası kontrolü*/
        public void dogru_kontrolu()
        {
            int expected = 1; /*beklenen sonuç*/

            /*veriler*/
            int[] kimlik = { 7, 2, 4, 6, 7, 4, 4, 9, 1, 0, 4 }; /*örnek tc kimlik numarası. kaynak: https://tcnobul.com/ */
            TC check = new TC();
            int i = check.kontrol(kimlik);
            Assert.AreEqual(expected, i); /*sonuç doğru mu?*/
        }

        [Test]
        public void kullanici_giris_testi()
        {
            
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select tc,Şifre from kullanicigiris where tc=@tc and Şifre=@Şifre", baglanti);
            sorgu.Parameters.AddWithValue("@tc", "11111111111");
            sorgu.Parameters.AddWithValue("@Şifre", "1234");
            OleDbDataReader hs;
            hs = sorgu.ExecuteReader();
            Assert.AreEqual(hs.Read(),true);
        }


        [Test]
        public void personel_girisi()
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand sorgu = new OleDbCommand("select kad,sifre from personelgiris where kad=@kad and sifre=@sifre", baglanti);
            sorgu.Parameters.AddWithValue("@kad", "kaan");
            sorgu.Parameters.AddWithValue("@sifre", "1234");
            OleDbDataReader dr;
            dr = sorgu.ExecuteReader();
            Assert.AreEqual(dr.Read(), true); /*true mu?*/
        }

        [Test]
        public void kayit_ol()
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=database.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into kullanicigiris(tc,Şifre,ad,soyad,cinsiyet,Doğum_Yeri,Doğum_Tarihi,tel,eposta) values(@tc,@Şifre,@ad,@soyad,@cinsiyet,@Doğum_Yeri,@Doğum_Tarihi,@tel,@eposta)", baglanti);
            komut.Parameters.AddWithValue("@tc", "");
            komut.Parameters.AddWithValue("@Şifre", "");
            komut.Parameters.AddWithValue("@ad", "");
            komut.Parameters.AddWithValue("@soyad", "");
            komut.Parameters.AddWithValue("@cinsiyet", "");
            komut.Parameters.AddWithValue("@Doğum_Yeri", "");
            komut.Parameters.AddWithValue("@Doğum_Tarihi", "");
            komut.Parameters.AddWithValue("@tel", "");
            komut.Parameters.AddWithValue("@eposta", "");

            Assert.AreEqual(komut.ExecuteNonQuery(), 1);
            baglanti.Close();
        }
    }
}
