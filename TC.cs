using System;

namespace TC_numarasi
{
    internal class TC
    {
        public int kontrol(int[] tc)
        {
            try
            {
                if (tc.Length == 11 && tc[0] != 0)
                {


                    int toplam1 = 0;
                    for (int i = 0; i <= 8; i += 2)
                    {
                        toplam1 += tc[i];
                    }
                    toplam1 *= 7;

                    int toplam2 = 0;
                    for (int i = 1; i <= 8; i += 2)
                    {
                        toplam2 += tc[i];
                    }

                    int sonuc1 = (toplam1 - toplam2) % 10;
                    int sonuc2 = (tc[0] + tc[1] + tc[2] + tc[3] + tc[4] + tc[5] + tc[6] + tc[7] + tc[8] + tc[9]) % 10;

                    if (tc[9] == sonuc1 && tc[10] == sonuc2)
                    {
                        Console.WriteLine("Doğru TC numarası");
                        return 1; /*yani doğru*/
                    }
                    else
                    {
                        Console.WriteLine("Yanlış TC numarası");
                        return 0;
                        
                    }
                }
                else
                {
                    Console.WriteLine("Hata! TC 11 haneli değil veya ilk rakamı 0.");
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0; /**/
        }
    }
}
